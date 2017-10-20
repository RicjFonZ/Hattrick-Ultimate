// -----------------------------------------------------------------------
// <copyright file="FileProcessManager.cs" company="Hyperar">
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
    using System.Threading;
    using BusinessObjects.Hattrick.Interface;
    using DataAccess.Database.Interface;

    /// <summary>
    /// FileProcessCompleted event handler delegate.
    /// </summary>
    /// <param name="sender">Object that raised the event.</param>
    /// <param name="e">Event arguments</param>
    public delegate void FileProcessCompletedEventHandler(object sender, AsyncCompletedEventArgs e);

    /// <summary>
    /// FileProcessProgressChanged event handler delegate.
    /// </summary>
    /// <param name="sender">Object that raised the event.</param>
    /// <param name="e">Event arguments</param>
    public delegate void FileProcessProgressChangedEventHandler(object sender, FileTaskProgressChangedEventArgs e);

    /// <summary>
    /// Provides functionality to process CHPP files from Hattrick.
    /// </summary>
    public class FileProcessManager
    {
        #region Private Fields

        /// <summary>
        /// Chpp File Processer.
        /// </summary>
        private Chpp.ChppFileProcesser chppFileProcesser;

        /// <summary>
        /// Database context.
        /// </summary>
        private IDatabaseContext context;

        /// <summary>
        /// On Complete delegate.
        /// </summary>
        private SendOrPostCallback onCompletedDelegate;

        /// <summary>
        /// On Progress Report delegate.
        /// </summary>
        private SendOrPostCallback onProgressChangedDelegate;

        /// <summary>
        /// Tasks dictionary.
        /// </summary>
        private HybridDictionary userStateToLifetime;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="FileProcessManager" /> class.
        /// </summary>
        /// <param name="chppFileProcesser">Chpp File Processer.</param>
        /// <param name="context">Database context.</param>
        public FileProcessManager(
                   Chpp.ChppFileProcesser chppFileProcesser,
                   IDatabaseContext context)
        {
            this.onCompletedDelegate = new SendOrPostCallback(this.ProcessCompleted);
            this.onProgressChangedDelegate = new SendOrPostCallback(this.ReportProcessProgress);

            this.chppFileProcesser = chppFileProcesser;
            this.context = context;
            this.userStateToLifetime = new HybridDictionary();
        }

        #endregion Public Constructors

        #region Private Delegates

        /// <summary>
        /// Download worker handler.
        /// </summary>
        /// <param name="filesToProcess">List of files to process.</param>
        /// <param name="asyncOperation">Async operation.</param>
        private delegate void WorkerEventHandler(List<IXmlEntity> filesToProcess, AsyncOperation asyncOperation);

        #endregion Private Delegates

        #region Public Events

        /// <summary>
        /// File Process complete handler.
        /// </summary>
        public event FileProcessCompletedEventHandler FileProcessCompleted;

        /// <summary>
        /// File Process progress changed handler.
        /// </summary>
        public event FileProcessProgressChangedEventHandler FileProcessProgressChanged;

        #endregion Public Events

        #region Public Methods

        /// <summary>
        /// Cancels the specified task.
        /// </summary>
        /// <param name="taskId">ID of the task to cancel.</param>
        public void CancelAsync(object taskId)
        {
            if (this.userStateToLifetime[taskId] as AsyncOperation != null)
            {
                lock (this.userStateToLifetime.SyncRoot)
                {
                    this.userStateToLifetime.Remove(taskId);
                }
            }
        }

        /// <summary>
        /// Process the specified list of files.
        /// </summary>
        /// <param name="filesToProcess">List of files to process.</param>
        /// <param name="taskId">ID of the task.</param>
        public virtual void ProcessFilesAsync(List<IXmlEntity> filesToProcess, object taskId)
        {
            var asyncOperation = AsyncOperationManager.CreateOperation(taskId);

            // Multiple threads will access the task dictionary,
            // so it must be locked to serialize access.
            lock (this.userStateToLifetime.SyncRoot)
            {
                if (this.userStateToLifetime.Contains(taskId))
                {
                    throw new ArgumentException(Localization.Strings.Message_TaskIdMustBeUnique, nameof(taskId));
                }

                this.userStateToLifetime[taskId] = asyncOperation;
            }

            // Start the asynchronous operation.
            WorkerEventHandler workerDelegate = new WorkerEventHandler(this.ProcessFilesWorker);

            workerDelegate.BeginInvoke(
                               filesToProcess,
                               asyncOperation,
                               null,
                               null);
        }

        #endregion Public Methods

        #region Protected Methods

        /// <summary>
        /// Reports that the file process completed.
        /// </summary>
        /// <param name="e">Event arguments.</param>
        protected void OnFileProcessCompleted(AsyncCompletedEventArgs e)
        {
            this.FileProcessCompleted?.Invoke(this, e);
        }

        /// <summary>
        /// Reports that the file process progress changed.
        /// </summary>
        /// <param name="e">Event args.</param>
        protected void OnFileProcessProgressChanged(FileTaskProgressChangedEventArgs e)
        {
            this.FileProcessProgressChanged?.Invoke(this, e);
        }

        #endregion Protected Methods

        #region Private Methods

        /// <summary>
        /// Signals that the file process is complete.
        /// </summary>
        /// <param name="exception">The task exception, if any.</param>
        /// <param name="canceled">A value indicating whether the task was cancelled or not.</param>
        /// <param name="asyncOperation">Async operation.</param>
        private void CompletionMethod(Exception exception, bool canceled, AsyncOperation asyncOperation)
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
            AsyncCompletedEventArgs e = new AsyncCompletedEventArgs(
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
        /// Raises the OnFileProcessCompleted event.
        /// </summary>
        /// <param name="operationState">Operation state.</param>
        private void ProcessCompleted(object operationState)
        {
            this.OnFileProcessCompleted(operationState as AsyncCompletedEventArgs);
        }

        /// <summary>
        /// Executes the file process tasks.
        /// </summary>
        /// <param name="filesToProcess">List of files to download.</param>
        /// <param name="asyncOperation">Async operation.</param>
        private void ProcessFilesWorker(List<IXmlEntity> filesToProcess, AsyncOperation asyncOperation)
        {
            Exception exception = null;
            FileTaskProgressChangedEventArgs eventArgs = null;
            int i = 0;

            this.context.BeginTransaction();

            while (!this.IsCanceled(asyncOperation.UserSuppliedState) && i < filesToProcess.Count)
            {
                IXmlEntity currentFile = filesToProcess[i];

                try
                {
                    eventArgs = new FileTaskProgressChangedEventArgs(
                                        string.Format(
                                                   Localization.Strings.Message_Processing,
                                                   currentFile.FileName),
                                        (int)Math.Round(((float)i / (float)filesToProcess.Count) * (float)100),
                                        asyncOperation.UserSuppliedState);

                    asyncOperation.Post(this.onProgressChangedDelegate, eventArgs);

                    this.chppFileProcesser.ProcessFile(currentFile);

                    i++;

                    eventArgs = new FileTaskProgressChangedEventArgs(
                                        string.Format(
                                                   Localization.Strings.Message_Processing,
                                                   currentFile.FileName),
                                        (int)Math.Round(((float)i / (float)filesToProcess.Count) * (float)100),
                                        asyncOperation.UserSuppliedState);

                    asyncOperation.Post(this.onProgressChangedDelegate, eventArgs);
                }
                catch (Exception ex)
                {
                    exception = ex;

                    this.context.Cancel();

                    break;
                }
            }

            this.context.EndTransaction();

            this.CompletionMethod(
                     exception,
                     this.IsCanceled(asyncOperation.UserSuppliedState),
                     asyncOperation);
        }

        /// <summary>
        /// Raises the OnFileProcessProgressChanged event.
        /// </summary>
        /// <param name="operationState">Operation state.</param>
        private void ReportProcessProgress(object operationState)
        {
            this.OnFileProcessProgressChanged(operationState as FileTaskProgressChangedEventArgs);
        }

        #endregion Private Methods
    }
}