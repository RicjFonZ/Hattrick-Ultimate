//-----------------------------------------------------------------------
// <copyright file="FormDataFolder.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.UserInterface
{
    using System;
    using System.Windows.Forms;

    /// <summary>
    /// Data folder selection folder.
    /// </summary>
    public partial class FormDataFolder : Form
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="FormDataFolder" /> class.
        /// </summary>
        public FormDataFolder()
        {
            this.InitializeComponent();
            this.PopulateLanguage();
        }

        #endregion Constructor

        #region Properties

        /// <summary>
        /// Gets the data folder.
        /// </summary>
        public string DataFolder { get; private set; }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Fills controls texts with localized strings.
        /// </summary>
        protected void PopulateLanguage()
        {
            this.Text = Localization.Strings.FormDataFolder_Text;
            this.AdvTxtBoxDataFolder.Placeholder = Localization.Strings.AdvTxtBoxDataFolder_Placeholder;
            this.BtnBrowse.Text = Localization.Strings.BtnBrowse_Text;
            this.BtnCancel.Text = Localization.Strings.BtnCancel_Text;
            this.BtnOk.Text = Localization.Strings.BtnOk_Text;
        }

        #endregion Methods

        #region Events

        /// <summary>
        /// AdvTxtBoxDataFolder KeyPress event handler.
        /// </summary>
        /// <param name="sender">The control that raised the event.</param>
        /// <param name="e">Event arguments.</param>
        private void AdvTxtBoxDataFolder_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Makes the text box readonly without using the Readonly property, which disables the placeholder.
            e.Handled = true;
        }

        /// <summary>
        /// AdvTextBoxDataFolder Validated event handler.
        /// </summary>
        /// <param name="sender">The control that raised the event.</param>
        /// <param name="e">Event arguments.</param>
        private void AdvTxtBoxDataFolder_Validated(object sender, System.EventArgs e)
        {
            this.ErrPrvForm.SetError(this.AdvTxtBoxDataFolder, null);
        }

        /// <summary>
        /// AdvTextBoxDataFolder Validating event handler.
        /// </summary>
        /// <param name="sender">The control that raised the event.</param>
        /// <param name="e">Event arguments.</param>
        private void AdvTxtBoxDataFolder_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.AdvTxtBoxDataFolder.Text))
            {
                this.ErrPrvForm.SetError(this.AdvTxtBoxDataFolder, Localization.Strings.AdvTxtBoxDataFolder_EmptyMessage);
                e.Cancel = true;
            }
        }

        /// <summary>
        /// BtnBrowse Click event handler.
        /// </summary>
        /// <param name="sender">The control that raised the event.</param>
        /// <param name="e">Event arguments.</param>
        private void BtnBrowse_Click(object sender, System.EventArgs e)
        {
            using (var form = new FolderBrowserDialog())
            {
                form.Description = Localization.Strings.DataFolderBrowserDialog_Description;
                form.RootFolder = Environment.SpecialFolder.UserProfile;
                form.ShowNewFolderButton = true;

                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    this.AdvTxtBoxDataFolder.Text = form.SelectedPath;
                }
            }
        }

        /// <summary>
        /// BtnCancel Click event handler.
        /// </summary>
        /// <param name="sender">The control that raised the event.</param>
        /// <param name="e">Event arguments.</param>
        private void BtnCancel_Click(object sender, System.EventArgs e)
        {
        }

        /// <summary>
        /// BtnOk Click event handler.
        /// </summary>
        /// <param name="sender">The control that raised the event.</param>
        /// <param name="e">Event arguments.</param>
        private void BtnOk_Click(object sender, System.EventArgs e)
        {
            if (this.Validate() && this.ValidateChildren())
            {
                this.DataFolder = this.AdvTxtBoxDataFolder.Text;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        #endregion Events
    }
}