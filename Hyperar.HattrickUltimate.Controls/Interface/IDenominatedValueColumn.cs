//-----------------------------------------------------------------------
// <copyright file="IDenominatedValueColumn.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.Controls.Interface
{
    using System.Collections.Generic;

    /// <summary>
    /// IDenominatedValueColumn contract.
    /// </summary>
    public interface IDenominatedValueColumn
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets cell Display Mode.
        /// </summary>
        ValueDisplayMode DisplayMode { get; set; }

        /// <summary>
        /// Gets or sets the Value Denomination Dictionary.
        /// </summary>
        Dictionary<object, string> ValueDenominationDictionary { get; set; }

        #endregion Public Properties
    }
}