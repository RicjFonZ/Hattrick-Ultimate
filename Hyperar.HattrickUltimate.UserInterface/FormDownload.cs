//-----------------------------------------------------------------------
// <copyright file="FormDataFolder.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.UserInterface
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using Interface; 

    public partial class FormDownload : Form, ILocalizableForm
    {
        public BusinessObjects.OAuth.DownloadSettings DownloadSettings { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="FormDownload" /> class.
        /// </summary>
        public FormDownload()
        {
            this.InitializeComponent();
            this.DownloadSettings = new BusinessObjects.OAuth.DownloadSettings();

            this.propertyGrid1.SelectedObject = this.DownloadSettings;
        }

        /// <summary>
        /// Populates controls' properties with the corresponding localized string.
        /// </summary>
        public void PopulateLanguage()
        {
            throw new NotImplementedException();
        }
    }
}
