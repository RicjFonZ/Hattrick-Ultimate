//-----------------------------------------------------------------------
// <copyright file="FormDataFolder.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.UserInterface
{
    using System;
    using System.IO;
    using System.Windows.Forms;
    using Interface;

    /// <summary>
    /// Data folder selection folder.
    /// </summary>
    public partial class FormDataFolder : Form, ILocalizedForm
    {
        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="FormDataFolder" /> class.
        /// </summary>
        public FormDataFolder()
        {
            this.InitializeComponent();
            this.PopulateLanguage();
            this.PopulateControls();
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>
        /// Gets the data folder.
        /// </summary>
        public string DataFolder { get; private set; }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// Populates controls' properties with the corresponding localized string.
        /// </summary>
        public void PopulateLanguage()
        {
            this.Text = Localization.Strings.FormDataFolder_Text;
            this.AdvTxtBoxDataFolder.Text = Localization.Strings.FormDataFolder_AdvTxtBoxDataFolder_Placeholder;
            this.BtnBrowse.Text = Localization.Strings.FormGeneral_BtnBrowse_Text;
            this.BtnCancel.Text = Localization.Strings.FormGeneral_BtnCancel_Text;
            this.BtnOk.Text = Localization.Strings.FormGeneral_BtnOk_Text;
            this.GrpBoxDatabaseFolder.Text = Localization.Strings.FormDataFolder_GrpBoxDatabaseFolder_Text;
        }

        #endregion Public Methods

        #region Private Methods

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
        /// BtnBrowse Click event handler.
        /// </summary>
        /// <param name="sender">The control that raised the event.</param>
        /// <param name="e">Event arguments.</param>
        private void BtnBrowse_Click(object sender, System.EventArgs e)
        {
            using (var form = new FolderBrowserDialog())
            {
                form.Description = Localization.Strings.FormDataFolder_DataFolderBrowserDialog_Description;
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

        /// <summary>
        /// Sets initial values to form controls.
        /// </summary>
        private void PopulateControls()
        {
            this.AdvTxtBoxDataFolder.Text = Path.Combine(
                                                     Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                                                     "Hattrick Ultimate");
        }

        #endregion Private Methods
    }
}