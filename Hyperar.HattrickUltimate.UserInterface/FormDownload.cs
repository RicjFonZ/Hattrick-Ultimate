//-----------------------------------------------------------------------
// <copyright file="FormDownload.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.UserInterface
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Windows.Forms;
    using Interface;

    /// <summary>
    /// Download window.
    /// </summary>
    public partial class FormDownload : LocalizableFormBase, ILocalizableForm
    {
        #region Private Fields

        /// <summary>
        /// Download manager.
        /// </summary>
        private BusinessLogic.DownloadManager downloadManager;

        /// <summary>
        /// Download settings.
        /// </summary>
        private BusinessObjects.OAuth.DownloadSettings downloadSettings;

        /// <summary>
        /// File Download Asynchronous Task ID.
        /// </summary>
        private Guid fileDownloadAsyncTaskId;

        /// <summary>
        /// File Process Asynchronous Task ID.
        /// </summary>
        private Guid fileProcessAsyncTaskId;

        /// <summary>
        /// File Process manager.
        /// </summary>
        private BusinessLogic.FileProcessManager fileProcessManager;

        /// <summary>
        /// Generic task progress window.
        /// </summary>
        private FormGenericProgress formGenericProgress;

        /// <summary>
        /// User manager.
        /// </summary>
        private BusinessLogic.UserManager userManager;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="FormDownload" /> class.
        /// </summary>
        /// <param name="downloadManager">Download manager.</param>
        /// <param name="fileProcessManager">File Process manager.</param>
        /// <param name="userManager">User manager.</param>
        public FormDownload(
                   BusinessLogic.DownloadManager downloadManager,
                   BusinessLogic.FileProcessManager fileProcessManager,
                   BusinessLogic.UserManager userManager)
        {
            this.InitializeComponent();

            this.downloadManager = downloadManager;
            this.fileProcessManager = fileProcessManager;
            this.userManager = userManager;

            this.downloadManager.DownloadProgressChanged += new BusinessLogic.DownloadProgressChangedEventHandler(this.DownloadProgressChanged_EventHandler);
            this.downloadManager.DownloadCompleted += new BusinessLogic.DownloadCompletedEventHandler(this.DownloadCompleted_EventHandler);
            this.fileProcessManager.FileProcessProgressChanged += new BusinessLogic.FileProcessProgressChangedEventHandler(this.FileProcessProgressChanged_EventHandler);
            this.fileProcessManager.FileProcessCompleted += new BusinessLogic.FileProcessCompletedEventHandler(this.FileProcessCompleted_EventHandler);

            this.downloadSettings = new BusinessObjects.OAuth.DownloadSettings();

            this.PropGridDownloadSettings.SelectedObject = this.downloadSettings;
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// Populates controls' properties with the corresponding localized string.
        /// </summary>
        public override void PopulateLanguage()
        {
            this.Text = Localization.Strings.FormDownload_Text;
            this.BtnCancel.Text = Localization.Strings.FormGeneral_BtnCancel_Text;
            this.BtnDownload.Text = Localization.Strings.FormDownload_BtnDownload_Text;
            this.BtnClose.Text = Localization.Strings.FormGeneral_BtnClose_Text;
            this.ChkBoxCloseOnSuccessfulDownload.Text = Localization.Strings.FormDownload_ChkBoxCloseOnSuccessfulDownload_Text;
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        /// Gets a value indicating whether there are async tasks running or not.
        /// </summary>
        /// <returns>A value indicating whether there are async tasks running or not.</returns>
        private bool AreAsyncTasksRunning()
        {
            return this.fileDownloadAsyncTaskId != Guid.Empty ||
                   this.fileProcessAsyncTaskId != Guid.Empty;
        }

        /// <summary>
        /// BtnCancel Click Event Handler.
        /// </summary>
        /// <param name="sender">Object that raised the event.</param>
        /// <param name="e">Event arguments.</param>
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.BtnCancel.Enabled = false;

            if (this.fileDownloadAsyncTaskId != Guid.Empty)
            {
                this.downloadManager.CancelAsync(this.fileDownloadAsyncTaskId);
            }

            if (this.fileProcessAsyncTaskId != Guid.Empty)
            {
                this.fileProcessManager.CancelAsync(this.fileProcessAsyncTaskId);
            }

            this.formGenericProgress.SetCancelledState();
        }

        /// <summary>
        /// BtnClose Click Event Handler.
        /// </summary>
        /// <param name="sender">Object that raised the event.</param>
        /// <param name="e">Event arguments.</param>
        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// BtnDownload Click Event Handler.
        /// </summary>
        /// <param name="sender">Object that raised the event.</param>
        /// <param name="e">Event arguments.</param>
        private void BtnDownload_Click(object sender, EventArgs e)
        {
            var user = this.userManager.GetUser();

            if (user != null && user.Token != null)
            {
                List<BusinessLogic.DownloadFile> downloadFileList = this.downloadManager.BuildDownloadFileList(this.downloadSettings);

                this.formGenericProgress = BusinessLogic.ApplicationObjects.Container.GetInstance<FormGenericProgress>();

                this.formGenericProgress.Show(this);

                this.fileDownloadAsyncTaskId = Guid.NewGuid();

                this.SetButtonState();

                this.downloadManager.DownloadFileAsync(user.Token, downloadFileList, this.fileDownloadAsyncTaskId);
            }
            else
            {
                MessageBox.Show(
                               this,
                               Localization.Strings.Message_Unauthorized,
                               Localization.Strings.Message_Error,
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Download Completed event handler.
        /// </summary>
        /// <param name="sender">Object that raised the event.</param>
        /// <param name="e">Event args.</param>
        private void DownloadCompleted_EventHandler(object sender, BusinessLogic.DownloadFileCompletedEventArgs e)
        {
            this.fileDownloadAsyncTaskId = Guid.Empty;

            if (!e.Cancelled && e.Error == null)
            {
                this.fileProcessAsyncTaskId = Guid.NewGuid();
                this.fileProcessManager.ProcessFilesAsync(e.DownloadedFiles, this.fileProcessAsyncTaskId);
            }
            else
            {
                string title = null,
                       message = null;

                MessageBoxIcon icon = MessageBoxIcon.Information;

                if (e.Cancelled)
                {
                    title = Localization.Strings.Message_Information;
                    message = Localization.Strings.Message_TaskCancelled;
                }

                if (e.Error != null)
                {
                    title = Localization.Strings.Message_Error;
                    message = string.Format(Localization.Strings.Message_AnErrorHasOccurred, e.Error.Message);
                    icon = MessageBoxIcon.Error;
                }

                this.SetButtonState();

                this.formGenericProgress.Close();

                MessageBox.Show(this, message, title, MessageBoxButtons.OK, icon);
            }
        }

        /// <summary>
        /// Download ProgressChanged event handler.
        /// </summary>
        /// <param name="sender">Object that raised the event.</param>
        /// <param name="e">Event args.</param>
        private void DownloadProgressChanged_EventHandler(object sender, BusinessLogic.FileTaskProgressChangedEventArgs e)
        {
            this.formGenericProgress.SetProgress(
                                         e.FileTask,
                                         e.ProgressPercentage);
        }

        /// <summary>
        /// File Process Completed Event Handler.
        /// </summary>
        /// <param name="sender">Object that raised the event.</param>
        /// <param name="e">Event arguments.</param>
        private void FileProcessCompleted_EventHandler(object sender, AsyncCompletedEventArgs e)
        {
            this.fileProcessAsyncTaskId = Guid.Empty;

            string title = null,
                   message = null;

            MessageBoxIcon icon = MessageBoxIcon.Information;

            if (e.Cancelled)
            {
                message = Localization.Strings.Message_TaskCancelled;
                title = Localization.Strings.Message_Information;
            }

            if (e.Error != null)
            {
                message = string.Format(Localization.Strings.Message_AnErrorHasOccurred, e.Error.Message);
                title = Localization.Strings.Message_Error;
            }

            this.SetButtonState();

            this.formGenericProgress.Close();

            if (e.Cancelled || e.Error != null)
            {
                MessageBox.Show(this, message, title, MessageBoxButtons.OK, icon);
            }
            else if (this.ChkBoxCloseOnSuccessfulDownload.Checked)
            {
                this.Close();
            }
        }

        /// <summary>
        /// File Process Progress Changed Event Handler.
        /// </summary>
        /// <param name="sender">Object that raised the event.</param>
        /// <param name="e">Event arguments.</param>
        private void FileProcessProgressChanged_EventHandler(object sender, BusinessLogic.FileTaskProgressChangedEventArgs e)
        {
            this.formGenericProgress.SetProgress(e.FileTask, e.ProgressPercentage);
        }

        /// <summary>
        /// Sets the forms buttons to the corresponding state.
        /// </summary>
        private void SetButtonState()
        {
            this.BtnDownload.Enabled =
            this.BtnDownload.Visible =
            this.BtnClose.Enabled = !this.AreAsyncTasksRunning();

            this.BtnCancel.Enabled =
            this.BtnCancel.Visible = this.AreAsyncTasksRunning();
        }

        #endregion Private Methods
    }
}