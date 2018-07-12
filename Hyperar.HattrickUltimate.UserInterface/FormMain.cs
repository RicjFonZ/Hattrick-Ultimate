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
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        /// Form Load event handler.
        /// </summary>
        /// <param name="sender">Control that raised the event.</param>
        /// <param name="e">Event arguments.</param>
        private void FormMain_Load(object sender, EventArgs e)
        {
            var user = this.userManager.GetUser();

            if (user == null)
            {
                user = this.userManager.CreateUser();
            }

            if (user.Token == null)
            {
                using (var formToken = BusinessLogic.ApplicationObjects.Container.GetInstance<FormToken>())
                {
                    formToken.ShowDialog();

                    user.Token = this.tokenManager.GetToken();

                    if (user.Token == null)
                    {
                        Application.Exit();

                        return;
                    }
                }
            }

            if (user.Manager == null)
            {
                using (var formUser = BusinessLogic.ApplicationObjects.Container.GetInstance<FormUser>())
                {
                    formUser.ShowDialog();
                }
            }

            using (var formDownload = BusinessLogic.ApplicationObjects.Container.GetInstance<FormDownload>())
            {
                formDownload.ShowDialog(this);
            }
        }

        #endregion Private Methods
    }
}