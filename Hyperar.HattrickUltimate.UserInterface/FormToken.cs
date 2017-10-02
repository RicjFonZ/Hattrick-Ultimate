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
        /// GetAuthorizationUrl response.
        /// </summary>
        private BusinessObjects.OAuth.GetAuthorizationUrlResponse getAuthorizationUrlResponse;

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
        /// Initializes a new instance of the <see cref="FormToken" /> class.
        /// </summary>
        /// <param name="tokenManager">Token Manager.</param>
        /// <param name="userManager">User Manager.</param>
        public FormToken(
                   BusinessLogic.TokenManager tokenManager,
                   BusinessLogic.UserManager userManager)
        {
            this.InitializeComponent();
            this.PopulateLanguage();

            this.tokenManager = tokenManager;
            this.userManager = userManager;

            var token = this.tokenManager.GetToken();

            if (token == null)
            {
                this.BtnCheckToken.Enabled =
                this.BtnRevokeToken.Enabled = false;
            }

            this.AdvTxtBoxVerificationCode.Enabled =
            this.BtnAllowToken.Enabled =
            this.BtnCopyAuthorizationLink.Enabled = false;
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
            this.BtnGetAuthorizationLink.Text = Localization.Strings.FormToken_BtnGetAuthorizationLink_Text;
            this.BtnRevokeToken.Text = Localization.Strings.FormToken_BtnRevokeToken_Text;
            this.GrpBoxToken.Text = Localization.Strings.FormToken_GrpBoxToken_Text;
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        /// AdvTxtBoxVerificationCode TextChanged event handler.
        /// </summary>
        /// <param name="sender">Control that raised the event.</param>
        /// <param name="e">Event arguments.</param>
        private void AdvTxtBoxVerificationCode_TextChanged(object sender, EventArgs e)
        {
            this.BtnAllowToken.Enabled = !string.IsNullOrWhiteSpace(this.AdvTxtBoxVerificationCode.Text);
        }

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
            try
            {
                var accessToken = this.userManager.GetAccessToken(
                                                       new BusinessObjects.OAuth.GetAccessTokenRequest(
                                                           this.AdvTxtBoxVerificationCode.Text,
                                                           this.getAuthorizationUrlResponse.Token,
                                                           this.getAuthorizationUrlResponse.TokenSecret));

                var user = this.userManager.GetUser();

                this.tokenManager.SetUserToken(accessToken, user);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                               this,
                               string.Format(Localization.Strings.Message_AnErrorHasOccurred, ex.Message),
                               Localization.Strings.Message_Error,
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
            }
            finally
            {
                this.LnkLblAuthorizationLink.Text = null;
                this.LnkLblAuthorizationLink.Links.Clear();
                this.getAuthorizationUrlResponse = null;
                this.AdvTxtBoxVerificationCode.Text = null;
                this.AdvTxtBoxVerificationCode.Enabled =
                this.BtnAllowToken.Enabled =
                this.BtnCopyAuthorizationLink.Enabled = false;
                this.BtnCheckToken.Enabled =
                this.BtnRevokeToken.Enabled = true;
            }
        }

        /// <summary>
        /// BtnCheckToken Click event handler.
        /// </summary>
        /// <param name="sender">Control that raised the event.</param>
        /// <param name="e">Event arguments.</param>
        private void BtnCheckToken_Click(object sender, EventArgs e)
        {
            string text, title = null;
            MessageBoxIcon icon = MessageBoxIcon.Information;
            MessageBoxButtons buttons = MessageBoxButtons.OK;

            try
            {
                var user = this.userManager.GetUser();

                var token = this.tokenManager.CheckToken(user.Token);

                text = string.Format(
                                  Localization.Strings.Message_CheckToken,
                                  token.CreatedOn.ToString(),
                                  token.ExpiresOn.ToString());

                title = Localization.Strings.Message_Information;
            }
            catch (Exception ex)
            {
                text = string.Format(
                                  Localization.Strings.Message_AnErrorHasOccurred,
                                  ex.Message);

                title = Localization.Strings.Message_Error;

                icon = MessageBoxIcon.Error;
            }

            MessageBox.Show(this, text, title, buttons, icon);
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
        /// BtnCopyAuthorizationUrl Click event handler.
        /// </summary>
        /// <param name="sender">Control that raised the event.</param>
        /// <param name="e">Event arguments.</param>
        private void BtnCopyAuthorizationLink_Click(object sender, EventArgs e)
        {
            var link = this.LnkLblAuthorizationLink.Links.Count > 0
                     ? this.LnkLblAuthorizationLink.Links[0]
                     : null;

            if (link != null)
            {
                Clipboard.SetText(link.LinkData.ToString());
            }
        }

        /// <summary>
        /// BtnGetAuthorizationLink Click event handler.
        /// </summary>
        /// <param name="sender">Control that raised the event.</param>
        /// <param name="e">Event arguments.</param>
        private void BtnGetAuthorizationLink_Click(object sender, EventArgs e)
        {
            try
            {
                this.getAuthorizationUrlResponse = this.userManager.GetAuthorizationUrl();

                this.LnkLblAuthorizationLink.Text = Localization.Strings.FormToken_LnkLabelAuthorizationUrl_Text;

                this.LnkLblAuthorizationLink.Links.Add(
                                                       0,
                                                       this.LnkLblAuthorizationLink.Text.Length,
                                                       this.getAuthorizationUrlResponse.AuthorizationUrl);

                this.AdvTxtBoxVerificationCode.Enabled =
                this.BtnCopyAuthorizationLink.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                               this,
                               string.Format(Localization.Strings.Message_AnErrorHasOccurred, ex.Message),
                               Localization.Strings.Message_Error,
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// BtnRevokeToken Click event handler.
        /// </summary>
        /// <param name="sender">Control that raised the event.</param>
        /// <param name="e">Event arguments.</param>
        private void BtnRevokeToken_Click(object sender, EventArgs e)
        {
            string text, title = null;
            MessageBoxIcon icon = MessageBoxIcon.Information;
            MessageBoxButtons buttons = MessageBoxButtons.OK;

            try
            {
                var user = this.userManager.GetUser();

                this.tokenManager.RevokeToken(user.Token);

                this.BtnCheckToken.Enabled =
                this.BtnRevokeToken.Enabled = false;

                text = Localization.Strings.Message_TokenRevokedSuccessfully;
                title = Localization.Strings.Message_Information;
            }
            catch (Exception ex)
            {
                text = string.Format(
                                  Localization.Strings.Message_AnErrorHasOccurred,
                                  ex.Message);

                icon = MessageBoxIcon.Error;

                title = Localization.Strings.Message_Error;
            }

            MessageBox.Show(this, text, title, buttons, icon);
        }

        /// <summary>
        /// LnkLblAuthorizationLink LinkClicked event handler.
        /// </summary>
        /// <param name="sender">Control that raised the event.</param>
        /// <param name="e">Event arguments.</param>
        private void LnkLblAuthorizationLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var link = this.LnkLblAuthorizationLink.Links.Count > 0
                     ? this.LnkLblAuthorizationLink.Links[0]
                     : null;

            if (link != null)
            {
                Process.Start(link.LinkData.ToString());
            }
        }

        #endregion Private Methods
    }
}