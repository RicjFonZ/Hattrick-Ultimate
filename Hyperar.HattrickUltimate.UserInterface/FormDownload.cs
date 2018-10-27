//-----------------------------------------------------------------------
// <copyright file="FormDownload.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.UserInterface
{
    using System;
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
        /// File Download Asynchronous Task ID.
        /// </summary>
        private Guid chppFilesTasksAsyncTaskId;

        /// <summary>
        /// Download manager.
        /// </summary>
        private BusinessLogic.ChppFileTaskManager chppFileTaskManager;

        /// <summary>
        /// Download settings.
        /// </summary>
        private BusinessObjects.OAuth.DownloadSettings downloadSettings;

        /// <summary>
        /// User manager.
        /// </summary>
        private BusinessLogic.UserManager userManager;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="FormDownload"/> class.
        /// </summary>
        /// <param name="chppFileManager">Chpp File manager.</param>
        /// <param name="userManager">User manager.</param>
        public FormDownload(
                   BusinessLogic.ChppFileTaskManager chppFileManager,
                   BusinessLogic.UserManager userManager)
        {
            this.InitializeComponent();

            this.chppFileTaskManager = chppFileManager;
            this.userManager = userManager;

            this.chppFileTaskManager.ChppFileTaskProgressChanged += new BusinessLogic.ChppFileTaskProgressChangedEventHandler(this.ChppFileTaskProgressChanged_EventHandler);
            this.chppFileTaskManager.ChppFilesTasksCompleted += new BusinessLogic.ChppFilesTasksCompletedEventHandler(this.ChppFilesTasksCompleted_EventHandler);

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
            this.Text = Localization.Controls.FormDownload_Text;
            this.BtnCancel.Text = Localization.Controls.FormGeneral_BtnCancel_Text;
            this.BtnDownload.Text = Localization.Controls.FormDownload_BtnDownload_Text;
            this.BtnClose.Text = Localization.Controls.FormGeneral_BtnClose_Text;
            this.ChkBoxCloseOnSuccessfulDownload.Text = Localization.Controls.FormDownload_ChkBoxCloseOnSuccessfulDownload_Text;
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        /// Gets a value indicating whether there are async tasks running or not.
        /// </summary>
        /// <returns>A value indicating whether there are async tasks running or not.</returns>
        private bool AreAsyncTasksRunning()
        {
            return this.chppFilesTasksAsyncTaskId != Guid.Empty;
        }

        /// <summary>
        /// BtnCancel Click Event Handler.
        /// </summary>
        /// <param name="sender">Object that raised the event.</param>
        /// <param name="e">Event arguments.</param>
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.BtnCancel.Enabled = false;

            if (this.chppFilesTasksAsyncTaskId != Guid.Empty)
            {
                this.chppFileTaskManager.CancelAsync(this.chppFilesTasksAsyncTaskId);

                this.PgrBarProcess.Style =
                this.PgrBarCurrentTask.Style = ProgressBarStyle.Marquee;
            }
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
                var downloadFileList = this.chppFileTaskManager.BuildDownloadFileList(this.downloadSettings);

                this.chppFilesTasksAsyncTaskId = Guid.NewGuid();

                this.SetControlState();

                this.chppFileTaskManager.ProcessChppFilesTasksAsync(user.Token, downloadFileList, this.chppFilesTasksAsyncTaskId);
            }
            else
            {
                MessageBox.Show(
                               this,
                               Localization.Messages.Unauthorized,
                               Localization.Messages.Error,
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Download Completed event handler.
        /// </summary>
        /// <param name="sender">Object that raised the event.</param>
        /// <param name="e">Event args.</param>
        private void ChppFilesTasksCompleted_EventHandler(object sender, AsyncCompletedEventArgs e)
        {
            this.chppFilesTasksAsyncTaskId = Guid.Empty;

            string title = null,
                   message = null;

            var icon = MessageBoxIcon.Information;

            if (e.Cancelled)
            {
                message = Localization.Messages.TaskCancelled;
                title = Localization.Messages.Information;
            }

            if (e.Error != null)
            {
                message = string.Format(Localization.Messages.AnErrorHasOccurred, e.Error.Message);
                title = Localization.Messages.Error;
            }

            this.SetControlState();

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
        /// Download ProgressChanged event handler.
        /// </summary>
        /// <param name="sender">Object that raised the event.</param>
        /// <param name="e">Event args.</param>
        private void ChppFileTaskProgressChanged_EventHandler(object sender, BusinessLogic.ChppFileTaskProgressChangedEventArgs e)
        {
            this.LblFile.Text = e.FileName;
            this.LblTask.Text = e.State.ToString();
            this.PgrBarProcess.Value = e.ProgressPercentage;
            this.PgrBarCurrentTask.Value = ((int)e.State + 1) * 20;
        }

        /// <summary>
        /// Sets the forms buttons to the corresponding state.
        /// </summary>
        private void SetControlState()
        {
            this.PgrBarCurrentTask.Value =
            this.PgrBarProcess.Value = 0;

            this.PgrBarCurrentTask.Style =
            this.PgrBarProcess.Style = ProgressBarStyle.Continuous;

            this.BtnDownload.Enabled =
            this.BtnDownload.Visible =
            this.BtnClose.Enabled =
            this.PropGridDownloadSettings.Enabled = !this.AreAsyncTasksRunning();

            this.BtnCancel.Enabled =
            this.BtnCancel.Visible = this.AreAsyncTasksRunning();
        }

        #endregion Private Methods
    }
}