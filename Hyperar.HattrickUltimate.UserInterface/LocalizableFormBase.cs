//-----------------------------------------------------------------------
// <copyright file="LocalizableFormBase.cs" company="Hyperar">
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
    /// ILocalizableForm base implementation.
    /// </summary>
    public partial class LocalizableFormBase : Form, ILocalizableForm
    {
        #region Public Methods

        /// <summary>
        /// Populates controls' properties with the corresponding localized string.
        /// </summary>
        public virtual void PopulateLanguage()
        {
        }

        #endregion Public Methods

        #region Protected Methods

        /// <summary>
        /// Raises the System.Windows.Forms.Form.Load event.
        /// </summary>
        /// <param name="e">An System.EventArgs that contains the event data.</param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.PopulateLanguage();
        }

        #endregion Protected Methods
    }
}