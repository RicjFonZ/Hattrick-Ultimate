//-----------------------------------------------------------------------
// <copyright file="FormGenericProgress.cs" company="Hyperar">
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
    /// TODO: Update summary.
    /// </summary>
    public partial class FormGenericProgress : Form, ILocalizedForm
    {
        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="FormGenericProgress" /> class.
        /// </summary>
        public FormGenericProgress()
        {
            this.InitializeComponent();
            this.PopulateLanguage();
        }

        #endregion Public Constructors

        #region Public Methods

        public void PopulateLanguage()
        {
            this.Text = Localization.Strings.FormGenericProgress_Text;
            this.LblTask.Text = Localization.Strings.Message_TaskStarting;
        }

        public void SetProgress(string task, int completedPercentage)
        {
            if (string.IsNullOrWhiteSpace(task))
            {
                throw new ArgumentNullException(nameof(task));
            }

            if (completedPercentage > this.PrgBarPercentage.Maximum || completedPercentage < this.PrgBarPercentage.Minimum)
            {
                throw new ArgumentException(nameof(completedPercentage));
            }

            this.LblTask.Text = task;
            this.PrgBarPercentage.Value = completedPercentage;
        }

        #endregion Public Methods
    }
}