// -----------------------------------------------------------------------
// <copyright file="SupporterTier.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
// -----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessObjects.App.Enums
{
    /// <summary>
    /// Represents the different Supporter Tiers.
    /// </summary>
    public enum SupporterTier : byte
    {
        /// <summary>
        /// No supporter.
        /// </summary>
        None = 0,

        /// <summary>
        /// Silver supporter.
        /// </summary>
        Silver = 1,

        /// <summary>
        /// Gold supporter.
        /// </summary>
        Gold = 2,

        /// <summary>
        /// Platinum supporter.
        /// </summary>
        Platinum = 3,

        /// <summary>
        /// Diamond supporter.
        /// </summary>
        Diamond = 4
    }
}