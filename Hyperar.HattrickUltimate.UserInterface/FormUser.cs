//-----------------------------------------------------------------------
// <copyright file="FormUser.cs" company="Hyperar">
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
    /// User management window.
    /// </summary>
    public partial class FormUser : Form, ILocalizedForm
    {
        #region Private Fields

        /// <summary>
        /// User manager.
        /// </summary>
        private BusinessLogic.UserManager userManager;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="FormUser" /> class.
        /// </summary>
        /// <param name="userManager">User manager.</param>
        public FormUser(BusinessLogic.UserManager userManager)
        {
            this.InitializeComponent();
            this.userManager = userManager;

            this.PopulateLanguage();
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// Populates controls' properties with the corresponding localized string.
        /// </summary>
        public void PopulateLanguage()
        {
            this.Text = Localization.Strings.FormUser_Text;
            this.GrpBoxManager.Text = Localization.Strings.FormUser_GrpBoxManager_Text;
            this.LblManager.Text = Localization.Strings.FormUser_LblManager_Text;
            this.LblSupporterTier.Text = Localization.Strings.FormUser_LblSupporterTier_Text;
            this.LblManagerCountry.Text = Localization.Strings.FormUser_LblManagerCountry_Text;
            this.LblSeniorTeamArena.Text = Localization.Strings.FormUser_LblSeniorTeamArena_Text;
            this.LblSeniorTeamCountry.Text = Localization.Strings.FormUser_LblSeniorTeamCountry_Text;
            this.LblSeniorTeamRegion.Text = Localization.Strings.FormUser_LblSeniorTeamRegion_Text;
            this.LblSeniorTeamLeague.Text = Localization.Strings.FormUser_LblSeniorTeamLeague_Text;
            this.LblSeniorTeamSeries.Text = Localization.Strings.FormUser_LblSeniorTeamSeries_Text;
            this.LblJuniorTeam.Text = Localization.Strings.FormUser_LblJuniorTeam_Text;
            this.LblJuniorTeamSeries.Text = Localization.Strings.FormUser_LblJuniorTeamSeries_Text;
            this.BtnManageToken.Text = Localization.Strings.FormUser_BtnManageToken_Text;
            this.BtnClose.Text = Localization.Strings.FormGeneral_BtnClose_Text;
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        /// BtnClose Click event handler.
        /// </summary>
        /// <param name="sender">Control that raised the event.</param>
        /// <param name="e">Event arguments.</param>
        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// BtnManageToken Click event handler.
        /// </summary>
        /// <param name="sender">Control that raised the event.</param>
        /// <param name="e">Event arguments.</param>
        private void BtnManageToken_Click(object sender, EventArgs e)
        {
            using (var form = ApplicationObjects.Container.GetInstance<FormToken>())
            {
                form.ShowDialog(this);
            }
        }

        /// <summary>
        /// FormUser Load event handler.
        /// </summary>
        /// <param name="sender">Control that raised the event.</param>
        /// <param name="e">Event arguments.</param>
        private void FormUser_Load(object sender, EventArgs e)
        {
            var user = this.userManager.GetUser();

            if (user == null || user.Token == null)
            {
                using (var form = ApplicationObjects.Container.GetInstance<FormToken>())
                {
                    form.ShowDialog(this);
                }
            }
        }

        #endregion Private Methods
    }
}