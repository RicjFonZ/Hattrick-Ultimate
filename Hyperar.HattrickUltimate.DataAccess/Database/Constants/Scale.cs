//-----------------------------------------------------------------------
// <copyright file="Scale.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.DataAccess.Database.Constants
{
    /// <summary>
    /// Numeric column scale constants.
    /// </summary>
    internal class Scale
    {
        #region Internal Fields

        /// <summary>
        /// MatchRating numeric column precision.
        /// </summary>
        internal const byte MatchRating = 1;

        /// <summary>
        /// Currency numeric column scale.
        /// </summary>
        internal const byte Currency = 8;

        #endregion Internal Fields
    }
}