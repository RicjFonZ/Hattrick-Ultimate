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
    public partial class FormMain : Form, ILocalizedForm
    {
        #region Private Fields

        /// <summary>
        /// User manager.
        /// </summary>
        private BusinessLogic.UserManager userManager;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="FormMain" /> class.
        /// </summary>
        /// <param name="userManager">User Manager.</param>
        public FormMain(BusinessLogic.UserManager userManager)
        {
            this.InitializeComponent();

            this.Text = AppDomain.CurrentDomain.GetData("AppName").ToString();

            this.userManager = userManager;
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// Populates controls' properties with the corresponding localized string.
        /// </summary>
        public void PopulateLanguage()
        {
            throw new NotImplementedException();
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

            if (user == null || user.Manager == null)
            {
                using (var form = ApplicationObjects.Container.GetInstance<FormUser>())
                {
                    form.ShowDialog(this);
                }
            }
        }

        #endregion Private Methods
    }
}