//-----------------------------------------------------------------------
// <copyright file="DataGridViewDenominatedValueWithChangeTrackingColumn.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.Controls
{
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;
    using Interface;

    /// <summary>
    /// Extends <see cref="DataGridViewTextBoxColumn"/> to reflect value changes and denominated values.
    /// </summary>
    public class DataGridViewDenominatedValueWithChangeTrackingColumn : DataGridViewTextBoxColumn, IDenominatedValueColumn, IValueWithChangeTrackingColumn
    {
        /// <summary>
        /// Gets or sets the template used to model cell appearance.
        /// </summary>
        public override DataGridViewCell CellTemplate { get; set; } = new DataGridViewDenominatedValueWithChangeTrackingCell();

        #region Public Properties

        /// <summary>
        /// Gets or sets the Value Display Mode.
        /// </summary>
        public ValueDisplayMode DisplayMode { get; set; }

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

        /// <summary>
        /// Gets or sets the Value Denomination Dictionary.
        /// </summary>
        public Dictionary<object, string> ValueDenominationDictionary { get; set; }
    }

    #endregion Public Properties
}