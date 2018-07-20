//-----------------------------------------------------------------------
// <copyright file="ValueDisplayMode.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.Controls
{
    /// <summary>
    /// DataGridViewCell Value Display Mode.
    /// </summary>
    public enum ValueDisplayMode : byte
    {
        /// <summary>
        /// Shows value only.
        /// </summary>
        ValueOnly = 0,

        /// <summary>
        /// Shows denomination only.
        /// </summary>
        DenominationOnly = 1,

        /// <summary>
        /// Shows value and denomination .
        /// </summary>
        DenominationAndValue = 2
    }
}