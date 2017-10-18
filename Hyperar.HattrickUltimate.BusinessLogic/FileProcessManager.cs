namespace Hyperar.HattrickUltimate.BusinessLogic
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.ComponentModel;
    using System.Threading;
    using BusinessObjects.Hattrick.Interface;

    public delegate void FileProcessCompletedEventHandler(object sender, EventArgs e);

    public delegate void FileProcessProgressChangedEventHandler(object sender, EventArgs e);

    public class FileProcessManager
    {
        #region Protected Fields

        protected SendOrPostCallback onCompletedDelegate;

        protected SendOrPostCallback onProgressChangedDelegate;

        #endregion Protected Fields

        #region Private Fields

        private HybridDictionary userStateToLifetime;

        #endregion Private Fields

        #region Public Constructors

        public FileProcessManager()
        {
            this.InitailizeDelegates();
        }

        #endregion Public Constructors

        #region Public Events

        public event FileProcessCompletedEventHandler FileProcessCompleted;

        public event FileProcessProgressChangedEventHandler FileProcessProgressChanged;

        #endregion Public Events

        #region Public Methods

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

        public virtual void ProcessFilesAsync(List<IXmlEntity> filesToProcess, object taskId)
        {
            var asyncOperation = AsyncOperationManager.CreateOperation(taskId);

            lock (this.userStateToLifetime.SyncRoot)
            {
                if (this.userStateToLifetime.Contains(taskId))
                {
                    throw new ArgumentException(Localization.Strings.Message_TaskIdMustBeUnique, nameof(taskId));
                }
            }
        }

        #endregion Public Methods

        #region Protected Methods

        protected void OnFileProcessCompleted(object sender, EventArgs e)
        {
            this.FileProcessCompleted?.Invoke(sender, e);
        }

        protected void OnFileProcessProgressChanged(object sender, EventArgs e)
        {
            this.FileProcessProgressChanged?.Invoke(sender, e);
        }

        #endregion Protected Methods

        #region Private Methods

        private void InitailizeDelegates()
        {
            this.onCompletedDelegate = new SendOrPostCallback(this.ProcessCompleted);
            this.onProgressChangedDelegate = new SendOrPostCallback(this.ProcessReportProgress);
        }

        private bool IsCanceled(object taskId)
        {
            return (this.userStateToLifetime[taskId] == null);
        }

        private void ProcessCompleted(object state)
        {
            this.OnFileProcessCompleted(this, state as EventArgs);
        }

        private void ProcessFilesWorker(List<IXmlEntity> filesToProcess, AsyncOperation asyncOperation)
        {
        }

        private void ProcessReportProgress(object state)
        {
            this.OnFileProcessProgressChanged(this, state as EventArgs);
        }

        #endregion Private Methods
    }
}