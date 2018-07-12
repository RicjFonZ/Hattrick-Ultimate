//-----------------------------------------------------------------------
// <copyright file="FormUser.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.UserInterface
{
    using System;
    using System.Linq;
    using Interface;

    /// <summary>
    /// User management window.
    /// </summary>
    public partial class FormUser : LocalizableFormBase, ILocalizableForm
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
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// Populates controls' properties with the corresponding localized string.
        /// </summary>
        public override void PopulateLanguage()
        {
            this.Text = Localization.Strings.FormUser_Text;
            this.GrpBoxManager.Text = Localization.Strings.FormUser_GrpBoxManager_Text;
            this.GrpBoxTeams.Text = Localization.Strings.FormUser_GrpBoxTeams_Text;
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

            this.LblJuniorTeamSeriesValue.Text =
            this.LblJuniorTeamValue.Text =
            this.LblManagerCountryValue.Text =
            this.LblManagerValue.Text =
            this.LblSeniorTeamArenaValue.Text =
            this.LblSeniorTeamCountryValue.Text =
            this.LblSeniorTeamLeagueValue.Text =
            this.LblSeniorTeamRegionValue.Text =
            this.LblSeniorTeamSeriesValue.Text =
            this.LblSupporterTierValue.Text = Localization.Strings.Message_UnavailableValue;
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
            using (var form = BusinessLogic.ApplicationObjects.Container.GetInstance<FormToken>())
            {
                form.ShowDialog(this);
            }
        }

        /// <summary>
        /// CmbBoxTeam SelectedIndexChanged event handler.
        /// </summary>
        /// <param name="sender">Control that raised the event.</param>
        /// <param name="e">Event arguments.</param>
        private void CmbBoxTeam_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.CmbBoxTeam.SelectedValue != null)
            {
                var selectedTeam = (BusinessObjects.App.SeniorTeam)this.CmbBoxTeam.SelectedValue;

                if (selectedTeam.JuniorTeam != null)
                {
                    this.LblJuniorTeamValue.Text = selectedTeam.JuniorTeam.ToString();

                    if (selectedTeam.JuniorTeam.JuniorSeries != null)
                    {
                        this.LblJuniorTeamSeriesValue.Text = selectedTeam.JuniorTeam.JuniorSeries.ToString();
                    }
                }

                this.LblSeniorTeamArenaValue.Text = selectedTeam.SeniorArena.ToString();
                this.LblSeniorTeamCountryValue.Text = selectedTeam.Region.Country.ToString();
                this.LblSeniorTeamLeagueValue.Text = selectedTeam.SeniorSeries.League.ToString();
                this.LblSeniorTeamRegionValue.Text = selectedTeam.Region.ToString();
                this.LblSeniorTeamSeriesValue.Text = selectedTeam.SeniorSeries.ToString();
            }
        }

        /// <summary>
        /// FormUser Shown event handler.
        /// </summary>
        /// <param name="sender">Object that raised the event.</param>
        /// <param name="e">Event arguments.</param>
        private void FormUser_Shown(object sender, EventArgs e)
        {
            var user = this.userManager.GetUser();

            if (user == null || user.Token == null)
            {
                using (var form = BusinessLogic.ApplicationObjects.Container.GetInstance<FormToken>())
                {
                    form.ShowDialog(this);
                    user = this.userManager.GetUser();
                }
            }

            if (user.Token != null)
            {
                using (var form = BusinessLogic.ApplicationObjects.Container.GetInstance<FormDownload>())
                {
                    form.ShowDialog(this);
                }
            }

            if (user.Manager != null)
            {
                this.PopulateControls();
            }
        }

        /// <summary>
        /// Populates controls' values.
        /// </summary>
        private void PopulateControls()
        {
            var user = this.userManager.GetUser();

            if (user != null)
            {
                if (user.Manager != null)
                {
                    this.LblManagerCountryValue.Text = user.Manager.Country.ToString();
                    this.LblSupporterTierValue.Text = user.Manager.SupporterTier.ToString();
                    this.LblManagerValue.Text = user.Manager.ToString();

                    if (user.Manager.SeniorTeams != null && user.Manager.SeniorTeams.Count > 0)
                    {
                        this.CmbBoxTeam.DisplayMember = "Display";
                        this.CmbBoxTeam.ValueMember = "Value";
                        this.CmbBoxTeam.DataSource = user.Manager.SeniorTeams.Select(st => new
                        {
                            Display = st.ToString(),
                            Value = st
                        }).ToArray();
                    }
                }
            }
        }

        #endregion Private Methods
    }
}