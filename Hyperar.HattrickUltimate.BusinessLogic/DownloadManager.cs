// -----------------------------------------------------------------------
// <copyright file="DownloadManager.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
// -----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessLogic
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.ComponentModel;
    using System.Linq;
    using System.Threading;
    using BusinessObjects.Hattrick.Interface;

    /// <summary>
    /// DownloadCompleted event handler delegate.
    /// </summary>
    /// <param name="sender">Object that raised the event.</param>
    /// <param name="e">Event arguments.</param>
    public delegate void DownloadCompletedEventHandler(object sender, DownloadFileCompletedEventArgs e);

    /// <summary>
    /// DownloadProgressChanged event handler delegate.
    /// </summary>
    /// <param name="sender">Object that raised the event.</param>
    /// <param name="e">Event arguments.</param>
    public delegate void DownloadProgressChangedEventHandler(object sender, FileTaskProgressChangedEventArgs e);

    /// <summary>
    /// Provides functionality to download CHPP files from Hattrick.
    /// </summary>
    public partial class DownloadManager
    {
        #region Private Fields

        /// <summary>
        /// CHPP Manager.
        /// </summary>
        private DataAccess.Chpp.ChppManager chppManager;

        /// <summary>
        /// On Complete delegate.
        /// </summary>
        private SendOrPostCallback onCompletedDelegate;

        /// <summary>
        /// On Progress Report delegate.
        /// </summary>
        private SendOrPostCallback onProgressReportDelegate;

        /// <summary>
        /// Tasks dictionary.
        /// </summary>
        private HybridDictionary userStateToLifetime;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DownloadManager" /> class.
        /// </summary>
        /// <param name="chppManager">CHPP manager.</param>
        public DownloadManager(DataAccess.Chpp.ChppManager chppManager)
        {
            this.onCompletedDelegate = new SendOrPostCallback(this.DownloadProcessCompleted);
            this.onProgressReportDelegate = new SendOrPostCallback(this.ReportProcessProgress);

            this.userStateToLifetime = new HybridDictionary();
            this.chppManager = chppManager;
        }

        #endregion Public Constructors

        #region Private Delegates

        /// <summary>
        /// Download worker handler.
        /// </summary>
        /// <param name="accessToken">Access token.</param>
        /// <param name="filesToDownload">List of files to download.</param>
        /// <param name="asyncOperation">Async operation.</param>
        private delegate void WorkerEventHandler(BusinessObjects.App.Token accessToken, List<DownloadFile> filesToDownload, AsyncOperation asyncOperation);

        #endregion Private Delegates

        #region Public Events

        /// <summary>
        /// Download complete handler.
        /// </summary>
        public event DownloadCompletedEventHandler DownloadCompleted;

        /// <summary>
        /// Download progress changed handler.
        /// </summary>
        public event DownloadProgressChangedEventHandler DownloadProgressChanged;

        #endregion Public Events

        #region Public Methods

        /// <summary>
        /// Builds the list of files to download customized with the user settings.
        /// </summary>
        /// <param name="downloadSettings">User settings.</param>
        /// <returns>List of files to download.</returns>
        public List<DownloadFile> BuildDownloadFileList(BusinessObjects.OAuth.DownloadSettings downloadSettings)
        {
            var downloadFileList = new List<DownloadFile>();

            downloadFileList.Add(
                                 new DownloadFile(
                                     BusinessObjects.Hattrick.Enums.XmlFile.WorldDetails,
                                     new Dictionary<string, string>
                                     {
                                         {
                                             DataAccess.Chpp.Constants.QueryStringParameterName.IncludeRegions,
                                             downloadSettings.DownloadAllRegions.ToString()
                                         }
                                     }));

            downloadFileList.Add(new DownloadFile(BusinessObjects.Hattrick.Enums.XmlFile.ManagerCompendium));

            downloadFileList.Add(
                                 new DownloadFile(
                                     BusinessObjects.Hattrick.Enums.XmlFile.TeamDetails,
                                     new Dictionary<string, string>
                                     {
                                         {
                                             DataAccess.Chpp.Constants.QueryStringParameterName.IncludeDomesticFlags,
                                             downloadSettings.SeniorTeamIncludeHomeFlags.ToString()
                                         },
                                         {
                                             DataAccess.Chpp.Constants.QueryStringParameterName.IncludeFlags,
                                             downloadSettings.SeniorTeamIncludeAwayFlags.ToString()
                                         },
                                     }));

            downloadFileList.Add(new DownloadFile(BusinessObjects.Hattrick.Enums.XmlFile.Players));

            downloadFileList.Add(new DownloadFile(BusinessObjects.Hattrick.Enums.XmlFile.YouthTeamDetails));

            return downloadFileList;
        }

        /// <summary>
        /// Cancels the specified task.
        /// </summary>
        /// <param name="taskId">ID of the task to cancel.</param>
        public void CancelAsync(object taskId)
        {
            AsyncOperation asyncOperation = this.userStateToLifetime[taskId] as AsyncOperation;

            if (asyncOperation != null)
            {
                lock (this.userStateToLifetime.SyncRoot)
                {
                    this.userStateToLifetime.Remove(taskId);
                }
            }
        }

        /// <summary>
        /// Downloads the specified list of files.
        /// </summary>
        /// <param name="accessToken">Access token.</param>
        /// <param name="filesToDownload">List of files to download.</param>
        /// <param name="taskId">ID of the task.</param>
        public virtual void DownloadFileAsync(BusinessObjects.App.Token accessToken, List<DownloadFile> filesToDownload, object taskId)
        {
            // Create an AsyncOperation for taskId.
            AsyncOperation asyncOperation = AsyncOperationManager.CreateOperation(taskId);

            // Multiple threads will access the task dictionary,
            // so it must be locked to serialize access.
            lock (this.userStateToLifetime.SyncRoot)
            {
                if (this.userStateToLifetime.Contains(taskId))
                {
                    throw new ArgumentException(Localization.Messages.TaskIdMustBeUnique, nameof(taskId));
                }

                this.userStateToLifetime[taskId] = asyncOperation;
            }

            // Start the asynchronous operation.
            WorkerEventHandler workerDelegate = new WorkerEventHandler(this.DownloadWorker);

            workerDelegate.BeginInvoke(
                               accessToken,
                               filesToDownload,
                               asyncOperation,
                               null,
                               null);
        }

        #endregion Public Methods

        #region Protected Methods

        /// <summary>
        /// Reports that the download completed.
        /// </summary>
        /// <param name="e">Event arguments.</param>
        protected void OnDownloadCompleted(DownloadFileCompletedEventArgs e)
        {
            this.DownloadCompleted?.Invoke(this, e);
        }

        /// <summary>
        /// Reports that the download progress changed.
        /// </summary>
        /// <param name="e">Event args.</param>
        protected void OnDownloadProgressChanged(FileTaskProgressChangedEventArgs e)
        {
            this.DownloadProgressChanged?.Invoke(this, e);
        }

        #endregion Protected Methods

        #region Private Methods

        /// <summary>
        /// Signals that the download is complete.
        /// </summary>
        /// <param name="downloadedFiles">List of downloaded files.</param>
        /// <param name="exception">The task exception, if any.</param>
        /// <param name="canceled">A value indicating whether the task was cancelled or not.</param>
        /// <param name="asyncOperation">Async operation.</param>
        private void CompletionMethod(List<IXmlEntity> downloadedFiles, Exception exception, bool canceled, AsyncOperation asyncOperation)
        {
            // If the task was not previously canceled,
            // remove the task from the lifetime collection.
            if (!canceled)
            {
                lock (this.userStateToLifetime.SyncRoot)
                {
                    this.userStateToLifetime.Remove(asyncOperation.UserSuppliedState);
                }
            }

            // Package the results of the operation in a
            // CalculatePrimeCompletedEventArgs.
            DownloadFileCompletedEventArgs e = new DownloadFileCompletedEventArgs(
                                                       downloadedFiles,
                                                       exception,
                                                       canceled,
                                                       asyncOperation.UserSuppliedState);

            // End the task. The asyncOp object is responsible for marshaling the call.
            asyncOperation.PostOperationCompleted(this.onCompletedDelegate, e);
        }

        /// <summary>
        /// Raises the OnDownloadCompleted event.
        /// </summary>
        /// <param name="operationState">Operation state.</param>
        private void DownloadProcessCompleted(object operationState)
        {
            var e = operationState as DownloadFileCompletedEventArgs;

            this.OnDownloadCompleted(e);
        }

        /// <summary>
        /// Executes the download tasks.
        /// </summary>
        /// <param name="accessToken">Access token.</param>
        /// <param name="filesToDownload">List of files to download.</param>
        /// <param name="asyncOperation">Async operation.</param>
        private void DownloadWorker(BusinessObjects.App.Token accessToken, List<DownloadFile> filesToDownload, AsyncOperation asyncOperation)
        {
            List<IXmlEntity> result = new List<IXmlEntity>();
            Exception exception = null;
            FileTaskProgressChangedEventArgs eventArgs = null;
            int i = 0;

            while (!this.IsCanceled(asyncOperation.UserSuppliedState) && i < filesToDownload.Count)
            {
                DownloadFile currentFile = filesToDownload[i];

                try
                {
                    eventArgs = new FileTaskProgressChangedEventArgs(
                                        string.Format(
                                                   Localization.Messages.Downloading,
                                                   currentFile.File.ToString()),
                                        (int)Math.Round(((float)i / (float)filesToDownload.Count) * (float)100),
                                        asyncOperation.UserSuppliedState);

                    asyncOperation.Post(this.onProgressReportDelegate, eventArgs);

                    result.Add(
                               this.chppManager.GetProtectedResource(
                                                    accessToken,
                                                    currentFile.File,
                                                    currentFile.Parameters?.ToArray()));

                    i++;

                    eventArgs = new FileTaskProgressChangedEventArgs(
                                        string.Format(
                                                   Localization.Messages.Downloaded,
                                                   currentFile.File.ToString()),
                                        (int)Math.Round(((float)i / (float)filesToDownload.Count) * (float)100),
                                        asyncOperation.UserSuppliedState);

                    asyncOperation.Post(this.onProgressReportDelegate, eventArgs);
                }
                catch (Exception ex)
                {
                    exception = ex;
                    break;
                }
            }

            this.CompletionMethod(
                     result,
                     exception,
                     this.IsCanceled(asyncOperation.UserSuppliedState),
                     asyncOperation);
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
        /// Raises the OnDownloadProgressChanged event.
        /// </summary>
        /// <param name="operationState">Operation state.</param>
        private void ReportProcessProgress(object operationState)
        {
            var e = operationState as FileTaskProgressChangedEventArgs;

            this.OnDownloadProgressChanged(e);
        }

        #endregion Private Methods
    }
}