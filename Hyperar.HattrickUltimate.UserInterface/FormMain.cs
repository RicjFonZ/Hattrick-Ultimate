//-----------------------------------------------------------------------
// <copyright file="FormMain.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.UserInterface
{
    using System.Windows.Forms;

    /// <summary>
    /// Main window.
    /// </summary>
    public partial class FormMain : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FormMain" /> class.
        /// </summary>
        public FormMain()
        {
            this.InitializeComponent();

            this.Text = $"{Application.ProductName} v{Application.ProductVersion}";

#if DEBUG
            this.Text += " [DEBUG]";
#endif
        }
    }
}