//-----------------------------------------------------------------------
// <copyright file="FormMain.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.UserInterface
{
    using System;
    using System.Windows.Forms;
    using Interface;

    /// <summary>
    /// Main window.
    /// </summary>
    public partial class FormMain : LocalizableFormBase, ILocalizableForm
    {
        #region Private Fields

        /// <summary>
        /// Token manager.
        /// </summary>
        private BusinessLogic.TokenManager tokenManager;

        /// <summary>
        /// User manager.
        /// </summary>
        private BusinessLogic.UserManager userManager;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="FormMain" /> class.
        /// </summary>
        /// <param name="tokenManager">Token Manager.</param>
        /// <param name="userManager">User Manager.</param>
        public FormMain(
                   BusinessLogic.TokenManager tokenManager,
                   BusinessLogic.UserManager userManager)
        {
            this.InitializeComponent();

            this.tokenManager = tokenManager;
            this.userManager = userManager;
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// Populates controls' properties with the corresponding localized string.
        /// </summary>
        public override void PopulateLanguage()
        {
            this.Text = AppDomain.CurrentDomain.GetData(Constants.Settings.AppName).ToString();
            this.ToolStrpBtnDownload.Text = Localization.Strings.FormMain_ToolStrpBtnDownload_Text;
            this.ToolStrpBtnDownload.ToolTipText = Localization.Strings.FormMain_ToolStrpBtnDownload_ToolTipText;
            this.ToolStrpBtnUser.Text = Localization.Strings.FormMain_ToolStrpBtnUser_Text;
            this.ToolStrpBtnUser.ToolTipText = Localization.Strings.FormMain_ToolStrpBtnUser_ToolTipText;
            this.ToolStrpMenuItemFile.Text = Localization.Strings.FormMain_ToolStrpMenuItemFile_Text;
            this.ToolStrpMenuItemDownload.Text = Localization.Strings.FormMain_ToolStrpMenuItemDownload_Text;
            this.ToolStrpMenuItemUser.Text = Localization.Strings.FormMain_ToolStrpMenuItemUser_Text;
            this.ToolStrpMenuItemExit.Text = Localization.Strings.FormMain_ToolStrpMenuItemExit_Text;
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        /// FormMain Load event handler.
        /// </summary>
        /// <param name="sender">Control that raised the event.</param>
        /// <param name="e">Event arguments.</param>
        private void FormMain_Load(object sender, EventArgs e)
        {
            var user = this.userManager.GetUser();

            // If no user exists.
            if (user == null)
            {
                // Create user.
                user = this.userManager.CreateUser();
            }

            // If not authorized or no download has been made.
            if (user.Token == null || user.Manager == null)
            {
                // Show user window.
                using (var form = BusinessLogic.ApplicationObjects.Container.GetInstance<FormUser>())
                {
                    form.ShowDialog();

                    user.Token = this.tokenManager.GetToken();

                    // If still not authorized or no download has been made.
                    if (user.Token == null || user.Manager == null)
                    {
                        // Close application.
                        Application.Exit();

                        return;
                    }
                }
            }
        }

        /// <summary>
        /// Shows the Download window.
        /// </summary>
        private void ShowDownloadWindow()
        {
            using (var form = BusinessLogic.ApplicationObjects.Container.GetInstance<FormDownload>())
            {
                form.ShowDialog(this);
            }
        }

        /// <summary>
        /// Shows the User window.
        /// </summary>
        private void ShowUserWindow()
        {
            using (var form = BusinessLogic.ApplicationObjects.Container.GetInstance<FormUser>())
            {
                form.ShowDialog(this);
            }
        }

        /// <summary>
        /// ToolStrpBtnDownload Click event handler.
        /// </summary>
        /// <param name="sender">Control that raised the event.</param>
        /// <param name="e">Event arguments.</param>
        private void ToolStrpBtnDownload_Click(object sender, EventArgs e)
        {
            this.ShowDownloadWindow();
        }

        /// <summary>
        /// ToolStrpBtnUser Click event handler.
        /// </summary>
        /// <param name="sender">Control that raised the event.</param>
        /// <param name="e">Event arguments.</param>
        private void ToolStrpBtnUser_Click(object sender, EventArgs e)
        {
            this.ShowUserWindow();
        }

        /// <summary>
        /// ToolStrpMenuItemDownload Click event handler.
        /// </summary>
        /// <param name="sender">Control that raised the event.</param>
        /// <param name="e">Event arguments.</param>
        private void ToolStrpMenuItemDownload_Click(object sender, EventArgs e)
        {
            this.ShowDownloadWindow();
        }

        /// <summary>
        /// ToolStrpMenuItemExit Click event handler.
        /// </summary>
        /// <param name="sender">Control that raised the event.</param>
        /// <param name="e">Event arguments.</param>
        private void ToolStrpMenuItemExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// ToolStrpMenuItemUser Click event handler.
        /// </summary>
        /// <param name="sender">Control that raised the event.</param>
        /// <param name="e">Event arguments.</param>
        private void ToolStrpMenuItemUser_Click(object sender, EventArgs e)
        {
            this.ShowUserWindow();
        }

        #endregion Private Methods
    }
}