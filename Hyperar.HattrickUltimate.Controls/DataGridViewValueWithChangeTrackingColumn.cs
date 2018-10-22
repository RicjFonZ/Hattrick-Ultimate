//-----------------------------------------------------------------------
// <copyright file="DataGridViewValueWithChangeTrackingColumn.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.Controls
{
    using System.Drawing;
    using System.Windows.Forms;
    using Interface;

    /// <summary>
    /// Extends <see cref="DataGridViewTextBoxColumn"/> to reflect value changes.
    /// </summary>
    public class DataGridViewValueWithChangeTrackingColumn : DataGridViewTextBoxColumn, IValueWithChangeTrackingColumn
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the template used to model cell appearance.
        /// </summary>
        public override DataGridViewCell CellTemplate { get; set; } = new DataGridViewValueWithChangeTrackingCell();

        /// <summary>
        /// Gets or sets the color to represent negative value changes.
        /// </summary>
        public Color NegativeChangeBackColor { get; set; }

        /// <summary>
        /// Gets or sets the color to represent positive value changes.
        /// </summary>
        public Color PositiveChangeBackColor { get; set; }

        /// <summary>
        /// Gets or sets the name of the value change bound property.
        /// </summary>
        public string ValueChangeTrackingPropertyName { get; set; }

        #endregion Public Properties
    }
}