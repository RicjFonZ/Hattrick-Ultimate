//-----------------------------------------------------------------------
// <copyright file="Precision.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.DataAccess.Database.Constants
{
    /// <summary>
    /// Numeric column precision constants.
    /// </summary>
    internal class Precision
    {
        #region Internal Fields

        /// <summary>
        /// MatchRating numeric column precision.
        /// </summary>
        internal const byte MatchRating = 2;

        /// <summary>
        /// Currency numeric column precision.
        /// </summary>
        internal const byte Currency = 10;

        #endregion Internal Fields
    }
}