//-----------------------------------------------------------------------
// <copyright file="FormToken.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.UserInterface
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Windows.Forms;
    using Interface;

    /// <summary>
    /// Manage token window.
    /// </summary>
    public partial class FormToken : Form, ILocalizedForm
    {
        #region Private Fields

        /// <summary>
        /// Access token.
        /// </summary>
        private BusinessObjects.App.Token token;

        /// <summary>
        /// User manager.
        /// </summary>
        private BusinessLogic.UserManager userManager;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="FormToken" /> class.
        /// </summary>
        /// <param name="userManager">User Manager.</param>
        public FormToken(BusinessLogic.UserManager userManager)
        {
            this.InitializeComponent();
            this.PopulateLanguage();

            this.userManager = userManager;

            this.token = this.userManager.GetUser().Token;

            if (this.token == null)
            {
                this.token = new BusinessObjects.App.Token();
            }
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// Populates controls' properties with the corresponding localized string.
        /// </summary>
        public void PopulateLanguage()
        {
            this.Text = Localization.Strings.FormToken_Text;
            this.AdvTxtBoxVerificationCode.Placeholder = Localization.Strings.FormToken_AdvTxtBoxVerificationCode_Placeholder;
            this.BtnAllowToken.Text = Localization.Strings.FormToken_BtnAllowToken_Text;
            this.BtnCheckToken.Text = Localization.Strings.FormToken_BtnCheckToken_Text;
            this.BtnClose.Text = Localization.Strings.FormGeneral_BtnClose_Text;
            this.BtnOpenVerificationWebSite.Text = Localization.Strings.FormToken_BtnOpenVerificationWebSite_Text;
            this.BtnRevokeToken.Text = Localization.Strings.FormToken_BtnRevokeToken_Text;
            this.GrpBoxToken.Text = Localization.Strings.FormToken_GrpBoxToken_Text;
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        /// AdvTxtBoxVerificationCode Validated event handler.
        /// </summary>
        /// <param name="sender">Control that raised the event.</param>
        /// <param name="e">Event arguments.</param>
        private void AdvTxtBoxVerificationCode_Validated(object sender, EventArgs e)
        {
            this.ErrProvToken.SetError((Control)sender, null);
        }

        /// <summary>
        /// AdvTxtBoxVerificationCode Validating event handler.
        /// </summary>
        /// <param name="sender">Control that raised the event.</param>
        /// <param name="e">Event arguments.</param>
        private void AdvTxtBoxVerificationCode_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.AdvTxtBoxVerificationCode.Text))
            {
                this.ErrProvToken.SetError((Control)sender, Localization.Strings.FormToken_AdvTxtBoxVerificationCode_EmptyMessage);
                e.Cancel = true;
            }
        }

        /// <summary>
        /// BtnAllowToken Click event handler.
        /// </summary>
        /// <param name="sender">Control that raised the event.</param>
        /// <param name="e">Event arguments.</param>
        private void BtnAllowToken_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                this.userManager.GetAccessToken(this.AdvTxtBoxVerificationCode.Text, ref this.token);

                this.userManager.SetUserToken(this.token);

                this.Close();
            }
        }

        /// <summary>
        /// BtnCheckToken Click event handler.
        /// </summary>
        /// <param name="sender">Control that raised the event.</param>
        /// <param name="e">Event arguments.</param>
        private void BtnCheckToken_Click(object sender, EventArgs e)
        {
            this.userManager.CheckToken();
        }

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
        /// BtnOpenVerificationWebSite Click event handler.
        /// </summary>
        /// <param name="sender">Control that raised the event.</param>
        /// <param name="e">Event arguments.</param>
        private void BtnOpenVerificationWebSite_Click(object sender, EventArgs e)
        {
            string url = this.userManager.GetAuthorizationUrl(this.token.Scope);

            Process.Start(url);
        }

        /// <summary>
        /// BtnRevokeToken Click event handler.
        /// </summary>
        /// <param name="sender">Control that raised the event.</param>
        /// <param name="e">Event arguments.</param>
        private void BtnRevokeToken_Click(object sender, EventArgs e)
        {
            this.userManager.RevokeToken(this.token);
        }

        #endregion Private Methods
    }
}