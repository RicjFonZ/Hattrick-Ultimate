// -----------------------------------------------------------------------
// <copyright file="WizardTabControl.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
// -----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.Controls
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Windows.Forms;

    /// <summary>
    /// Wizard style tab control.
    /// </summary>
    public class WizardTabControl : TabControl
    {
        #region Protected Methods

        /// <summary>
        /// This member overrides System.Windows.Forms.Control.WndProc(System.Windows.Forms.Message@).
        /// </summary>
        /// <param name="m">A Windows Message Object</param>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Overriden method can't be renamed.")]
        protected override void WndProc(ref Message m)
        {
            // Hide tabs by trapping the TCM_ADJUSTRECT message.
            if (m.Msg == 0x1328)
            {
                m.Result = (IntPtr)1;
            }
            else
            {
                base.WndProc(ref m);
            }
        }

        #endregion Protected Methods
    }
}