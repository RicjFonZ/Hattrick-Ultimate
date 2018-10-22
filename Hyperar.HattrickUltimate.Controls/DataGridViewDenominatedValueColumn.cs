//-----------------------------------------------------------------------
// <copyright file="DataGridViewDenominatedValueColumn.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.Controls
{
    using System.Collections.Generic;
    using System.Windows.Forms;
    using Interface;

    /// <summary>
    /// Extends <see cref="DataGridViewTextBoxColumn"/> to show denominated values.
    /// </summary>
    public class DataGridViewDenominatedValueColumn : DataGridViewTextBoxColumn, IDenominatedValueColumn
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the template used to model cell appearance.
        /// </summary>
        public override DataGridViewCell CellTemplate { get; set; } = new DataGridViewDenominatedValueCell();

        /// <summary>
        /// Gets or sets cell Display Mode.
        /// </summary>
        public ValueDisplayMode DisplayMode { get; set; }

        /// <summary>
        /// Gets or sets the Value Denomination Dictionary.
        /// </summary>
        public Dictionary<object, string> ValueDenominationDictionary { get; set; }

        #endregion Public Properties
    }
}