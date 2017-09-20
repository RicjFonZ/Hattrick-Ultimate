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

    /// <summary>
    /// Main window.
    /// </summary>
    public partial class FormMain : Form
    {
        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="FormMain" /> class.
        /// </summary>
        public FormMain()
        {
            this.InitializeComponent();

            this.Text = AppDomain.CurrentDomain.GetData("AppName").ToString();
        }

        #endregion Public Constructors
    }
}