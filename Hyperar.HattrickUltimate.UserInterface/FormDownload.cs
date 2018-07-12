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

            this.formGenericProgress = BusinessLogic.ApplicationObjects.Container.GetInstance<FormGenericProgress>();

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
            this.BtnClose.Text = Localization.Strings.FormGeneral_BtnCancel_Text;
            this.BtnDownload.Text = Localization.Strings.FormDownload_BtnDownload_Text;
            this.BtnClose.Text = Localization.Strings.FormGeneral_BtnClose_Text;
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        /// BtnCancel Click Event Handler.
        /// </summary>
        /// <param name="sender">Object that raised the event.</param>
        /// <param name="e">Event arguments.</param>
        private void BtnCancel_Click(object sender, EventArgs e)
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

            if (user != null && user.Manager == null && user.Token != null)
            {
                List<BusinessLogic.DownloadFile> downloadFileList = new List<BusinessLogic.DownloadFile>();

                downloadFileList.Add(new BusinessLogic.DownloadFile(BusinessObjects.Hattrick.Enums.XmlFile.WorldDetails));
                downloadFileList.Add(new BusinessLogic.DownloadFile(BusinessObjects.Hattrick.Enums.XmlFile.ManagerCompendium));
                downloadFileList.Add(new BusinessLogic.DownloadFile(BusinessObjects.Hattrick.Enums.XmlFile.TeamDetails));
                downloadFileList.Add(new BusinessLogic.DownloadFile(BusinessObjects.Hattrick.Enums.XmlFile.YouthTeamDetails));

                this.formGenericProgress.Show(this);

                this.downloadManager.DownloadFileAsync(user.Token, downloadFileList, Guid.NewGuid());
            }
        }

        /// <summary>
        /// Download Completed event handler.
        /// </summary>
        /// <param name="sender">Object that raised the event.</param>
        /// <param name="e">Event args.</param>
        private void DownloadCompleted_EventHandler(object sender, BusinessLogic.DownloadFileCompletedEventArgs e)
        {
            if (!e.Cancelled && e.Error == null)
            {
                this.fileProcessManager.ProcessFilesAsync(e.DownloadedFiles, Guid.NewGuid());
            }
            else
            {
                if (e.Cancelled)
                {
                    MessageBox.Show(
                                   this,
                                   Localization.Strings.Message_TaskCancelled,
                                   Localization.Strings.Message_Information,
                                   MessageBoxButtons.OK,
                                   MessageBoxIcon.Information);
                }

                if (e.Error != null)
                {
                    MessageBox.Show(
                                   this,
                                   string.Format(Localization.Strings.Message_AnErrorHasOccurred, e.Error.Message),
                                   Localization.Strings.Message_Error,
                                   MessageBoxButtons.OK,
                                   MessageBoxIcon.Error);
                }
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
            if (e.Cancelled)
            {
                MessageBox.Show(
                               this,
                               Localization.Strings.Message_TaskCancelled,
                               Localization.Strings.Message_Information,
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Information);

                return;
            }

            if (e.Error != null)
            {
                MessageBox.Show(
                               this,
                               string.Format(Localization.Strings.Message_AnErrorHasOccurred, e.Error.Message),
                               Localization.Strings.Message_Error,
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error);

                return;
            }

            this.formGenericProgress.Close();
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

        #endregion Private Methods
    }
}