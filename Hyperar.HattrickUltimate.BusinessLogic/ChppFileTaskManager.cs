//-----------------------------------------------------------------------
// <copyright file="ChppFileTaskManager.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessLogic
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.ComponentModel;
    using System.Linq;
    using System.Threading;
    using BusinessObjects.Hattrick.Enums;
    using BusinessObjects.Hattrick.Interface;
    using DataAccess.Database.Interface;
    using Hyperar.HattrickUltimate.BusinessLogic.Chpp.Enums;
    using Hyperar.HattrickUltimate.BusinessObjects.App;

    /// <summary>
    /// ChppFilesTasksCompletedEventHandler event handler delegate.
    /// </summary>
    /// <param name="sender">Object that raised the event.</param>
    /// <param name="e">Event arguments.</param>
    public delegate void ChppFilesTasksCompletedEventHandler(object sender, AsyncCompletedEventArgs e);

    /// <summary>
    /// ChppFileTaskProgressChangedEventHandler event handler delegate.
    /// </summary>
    /// <param name="sender">Object that raised the event.</param>
    /// <param name="e">Event arguments.</param>
    public delegate void ChppFileTaskProgressChangedEventHandler(object sender, ChppFileTaskProgressChangedEventArgs e);

    /// <summary>
    /// Provides functionality to download, analyze and process CHPP files from Hattrick.
    /// </summary>
    public partial class ChppFileTaskManager
    {
        #region Private Fields

        /// <summary>
        /// Chpp File Analyser.
        /// </summary>
        private readonly Chpp.FileAnalyser chppFileAnalyser;

        /// <summary>
        /// Chpp File Processer.
        /// </summary>
        private readonly Chpp.FileProcesser chppFileProcesser;

        /// <summary>
        /// Chpp File Validator.
        /// </summary>
        private readonly Chpp.FileValidator chppFileValidator;

        /// <summary>
        /// CHPP Manager.
        /// </summary>
        private readonly DataAccess.Chpp.ChppManager chppManager;

        /// <summary>
        /// Database context.
        /// </summary>
        private readonly IDatabaseContext context;

        /// <summary>
        /// Download Settings repository.
        /// </summary>
        private readonly IRepository<DownloadSettings> downloadSettingsRepository;

        /// <summary>
        /// Tasks dictionary.
        /// </summary>
        private readonly HybridDictionary userStateToLifetime;

        /// <summary>
        /// On Complete delegate.
        /// </summary>
        private SendOrPostCallback onCompletedDelegate;

        /// <summary>
        /// On Progress Report delegate.
        /// </summary>
        private SendOrPostCallback onProgressReportDelegate;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ChppFileTaskManager"/> class.
        /// </summary>
        /// <param name="context">Database context.</param>
        /// <param name="downloadSettingsRepository">Download Settings repository.</param>
        /// <param name="chppFileAnalyser">Chpp File Analyser.</param>
        /// <param name="chppFileProcesser">Chpp File Processer.</param>
        /// <param name="chppFileValidator">Chpp File Validator.</param>
        /// <param name="chppManager">CHPP manager.</param>
        public ChppFileTaskManager(
                   IDatabaseContext context,
                   IRepository<DownloadSettings> downloadSettingsRepository,
                   Chpp.FileAnalyser chppFileAnalyser,
                   Chpp.FileProcesser chppFileProcesser,
                   Chpp.FileValidator chppFileValidator,
                   DataAccess.Chpp.ChppManager chppManager)
        {
            this.onCompletedDelegate = new SendOrPostCallback(this.ChppFilesTasksProcessCompleted);
            this.onProgressReportDelegate = new SendOrPostCallback(this.ReportProcessProgress);
            this.userStateToLifetime = new HybridDictionary();
            this.context = context;
            this.downloadSettingsRepository = downloadSettingsRepository;
            this.chppFileAnalyser = chppFileAnalyser;
            this.chppFileProcesser = chppFileProcesser;
            this.chppFileValidator = chppFileValidator;
            this.chppManager = chppManager;
        }

        #endregion Public Constructors

        #region Private Delegates

        /// <summary>
        /// Chpp file task worker handler.
        /// </summary>
        /// <param name="accessToken">Access token.</param>
        /// <param name="filesToDownload">List of files to download.</param>
        /// <param name="downloadSettings">Download Settings.</param>
        /// <param name="asyncOperation">Async operation.</param>
        private delegate void WorkerEventHandler(Token accessToken, List<ChppFile> filesToDownload, DownloadSettings downloadSettings, AsyncOperation asyncOperation);

        #endregion Private Delegates

        #region Public Events

        /// <summary>
        /// Chpp Files Tasks completed handler.
        /// </summary>
        public event ChppFilesTasksCompletedEventHandler ChppFilesTasksCompleted;

        /// <summary>
        /// Chpp File Task progress changed handler.
        /// </summary>
        public event ChppFileTaskProgressChangedEventHandler ChppFileTaskProgressChanged;

        #endregion Public Events

        #region Public Methods

        /// <summary>
        /// Builds the list of files to download customized with the user settings.
        /// </summary>
        /// <param name="downloadSettings">User settings.</param>
        /// <returns>List of files to download.</returns>
        public List<ChppFile> BuildDownloadFileList(DownloadSettings downloadSettings)
        {
            return new List<ChppFile>
            {
                new ChppFile(XmlFile.WorldDetails),
                new ChppFile(XmlFile.ManagerCompendium)
            };
        }

        /// <summary>
        /// Cancels the specified task.
        /// </summary>
        /// <param name="taskId">ID of the task to cancel.</param>
        public void CancelAsync(object taskId)
        {
            if (this.userStateToLifetime[taskId] is AsyncOperation asyncOperation)
            {
                lock (this.userStateToLifetime.SyncRoot)
                {
                    this.userStateToLifetime.Remove(taskId);
                }
            }
        }

        /// <summary>
        /// Gets the Download Settings.
        /// </summary>
        /// <returns>Stored Download Settings.</returns>
        public DownloadSettings GetDownloadSettings()
        {
            var downloadSettings = this.downloadSettingsRepository.Query()
                                                                  .SingleOrDefault();

            if (downloadSettings == null)
            {
                downloadSettings = new DownloadSettings
                {
                    IncludeJuniorPlayerMatchInfo = true,
                    IncludeSeniorPlayerMatchInfo = true,
                    IncludeSeniorTeamAwayFlags = false,
                    IncludeSeniorTeamHomeFlags = false
                };

                this.downloadSettingsRepository.Insert(downloadSettings);

                this.context.Save();
            }

            return downloadSettings;
        }

        /// <summary>
        /// Downloads the specified list of files.
        /// </summary>
        /// <param name="accessToken">Access token.</param>
        /// <param name="filesToDownload">List of files to download.</param>
        /// <param name="downloadSettings">Download Settings.</param>
        /// <param name="taskId">ID of the task.</param>
        public virtual void ProcessChppFilesTasksAsync(Token accessToken, List<ChppFile> filesToDownload, DownloadSettings downloadSettings, object taskId)
        {
            // Create an AsyncOperation for taskId.
            var asyncOperation = AsyncOperationManager.CreateOperation(taskId);

            // Multiple threads will access the task dictionary, so it must be locked to serialize access.
            lock (this.userStateToLifetime.SyncRoot)
            {
                if (this.userStateToLifetime.Contains(taskId))
                {
                    throw new ArgumentException(Localization.Messages.TaskIdMustBeUnique, nameof(taskId));
                }

                this.userStateToLifetime[taskId] = asyncOperation;
            }

            // Start the asynchronous operation.
            var workerDelegate = new WorkerEventHandler(this.ChppFilesTasksWorker);

            this.downloadSettingsRepository.Update(downloadSettings);

            this.context.Save();

            workerDelegate.BeginInvoke(accessToken, filesToDownload, downloadSettings, asyncOperation, null, null);
        }

        #endregion Public Methods

        #region Protected Methods

        /// <summary>
        /// Reports that the download completed.
        /// </summary>
        /// <param name="e">Event arguments.</param>
        protected void OnChppFilesTasksCompleted(AsyncCompletedEventArgs e)
        {
            this.ChppFilesTasksCompleted?.Invoke(this, e);
        }

        /// <summary>
        /// Reports that the files tasks progress changed.
        /// </summary>
        /// <param name="e">Event args.</param>
        protected void OnChppFileTaskProgressChanged(ChppFileTaskProgressChangedEventArgs e)
        {
            this.ChppFileTaskProgressChanged?.Invoke(this, e);
        }

        #endregion Protected Methods

        #region Private Methods

        /// <summary>
        /// Raises the OnChppFilesTasksCompleted event.
        /// </summary>
        /// <param name="operationState">Operation state.</param>
        private void ChppFilesTasksProcessCompleted(object operationState)
        {
            var e = operationState as AsyncCompletedEventArgs;

            this.OnChppFilesTasksCompleted(e);
        }

        /// <summary>
        /// Executes the files tasks.
        /// </summary>
        /// <param name="accessToken">Access token.</param>
        /// <param name="filesTasks">List of files tasks to execute.</param>
        /// <param name="downloadSettings">Download Settings.</param>
        /// <param name="asyncOperation">Async operation.</param>
        private void ChppFilesTasksWorker(Token accessToken, List<ChppFile> filesTasks, DownloadSettings downloadSettings, AsyncOperation asyncOperation)
        {
            var result = new List<IXmlEntity>();
            Exception exception = null;
            int i = 0;

            try
            {
                this.context.BeginTransaction();

                this.chppManager.CheckToken(accessToken);

                while (!this.IsCanceled(asyncOperation.UserSuppliedState) && i < filesTasks.Count)
                {
                    var currentFile = filesTasks[i];

                    this.PostProgress(
                             asyncOperation,
                             currentFile.File.ToString(),
                             FileTaskState.Downloading,
                             i,
                             filesTasks.Count,
                             asyncOperation.UserSuppliedState);

                    if (this.IsCanceled(asyncOperation.UserSuppliedState))
                    {
                        break;
                    }

                    var downloadResult = this.chppManager.GetProtectedResource(
                                                              accessToken,
                                                              currentFile.File,
                                                              currentFile.Parameters?.ToArray());

                    this.PostProgress(
                             asyncOperation,
                             currentFile.File.ToString(),
                             FileTaskState.Validating,
                             i,
                             filesTasks.Count,
                             asyncOperation.UserSuppliedState);

                    this.chppFileValidator.Validate(downloadResult);

                    this.PostProgress(
                             asyncOperation,
                             currentFile.File.ToString(),
                             FileTaskState.Analyzing,
                             i,
                             filesTasks.Count,
                             asyncOperation.UserSuppliedState);

                    var additionalTasks = this.chppFileAnalyser.Analyze(downloadResult, downloadSettings);

                    if (additionalTasks != null && additionalTasks.Any())
                    {
                        filesTasks.AddRange(additionalTasks);
                    }

                    this.PostProgress(
                             asyncOperation,
                             currentFile.File.ToString(),
                             FileTaskState.Processing,
                             i,
                             filesTasks.Count,
                             asyncOperation.UserSuppliedState);

                    if (this.IsCanceled(asyncOperation.UserSuppliedState))
                    {
                        break;
                    }

                    this.chppFileProcesser.ProcessFile(downloadResult);

                    i++;

                    this.PostProgress(
                             asyncOperation,
                             currentFile.File.ToString(),
                             FileTaskState.Finished,
                             i,
                             filesTasks.Count,
                             asyncOperation.UserSuppliedState);
                }
            }
            catch (Exception ex)
            {
                exception = ex;

                this.CancelAsync(asyncOperation.UserSuppliedState);
            }

            // If cancelled, perform rollback.
            if (this.IsCanceled(asyncOperation.UserSuppliedState) || exception != null)
            {
                this.context.Cancel();
            }

            this.context.EndTransaction();

            this.CompletionMethod(
                     exception,
                     this.IsCanceled(asyncOperation.UserSuppliedState),
                     asyncOperation);
        }

        /// <summary>
        /// Signals that the files tasks processing is complete.
        /// </summary>
        /// <param name="exception">The task exception, if any.</param>
        /// <param name="canceled">A value indicating whether the task was cancelled or not.</param>
        /// <param name="asyncOperation">Async operation.</param>
        private void CompletionMethod(Exception exception, bool canceled, AsyncOperation asyncOperation)
        {
            // If the task was not previously canceled, remove the task from the lifetime collection.
            if (!canceled)
            {
                lock (this.userStateToLifetime.SyncRoot)
                {
                    this.userStateToLifetime.Remove(asyncOperation.UserSuppliedState);
                }
            }

            // Package the results of the operation in a AsyncCompletedEventArgs.
            var e = new AsyncCompletedEventArgs(
                            exception,
                            canceled,
                            asyncOperation.UserSuppliedState);

            // End the task. The asyncOp object is responsible for marshaling the call.
            asyncOperation.PostOperationCompleted(this.onCompletedDelegate, e);
        }

        /// <summary>
        /// Gets a value indicating whether the specified task is cancelled or not.
        /// </summary>
        /// <param name="taskId">ID of the task.</param>
        /// <returns>A value indicating whether the task is cancelled or not.</returns>
        private bool IsCanceled(object taskId)
        {
            return this.userStateToLifetime[taskId] == null;
        }

        /// <summary>
        /// Raises AsyncOperation progress.
        /// </summary>
        /// <param name="asyncOperation">Asynchronous Operation.</param>
        /// <param name="fileName">File Name.</param>
        /// <param name="taskState">Task State.</param>
        /// <param name="currentTaskNumber">Current Task Number.</param>
        /// <param name="totalTasksNumber">Total Tasks Number.</param>
        /// <param name="additionalData">Additional data.</param>
        private void PostProgress(
                         AsyncOperation asyncOperation,
                         string fileName,
                         FileTaskState taskState,
                         int currentTaskNumber,
                         int totalTasksNumber,
                         object additionalData)
        {
            asyncOperation.Post(
                               this.onProgressReportDelegate,
                               new ChppFileTaskProgressChangedEventArgs(
                                   fileName,
                                   taskState,
                                   Convert.ToInt32(((float)currentTaskNumber / (float)totalTasksNumber) * 100f),
                                   additionalData));
        }

        /// <summary>
        /// Raises the OnChppFileTaskProgressChanged event.
        /// </summary>
        /// <param name="operationState">Operation state.</param>
        private void ReportProcessProgress(object operationState)
        {
            var e = operationState as ChppFileTaskProgressChangedEventArgs;

            this.OnChppFileTaskProgressChanged(e);
        }

        #endregion Private Methods
    }
}