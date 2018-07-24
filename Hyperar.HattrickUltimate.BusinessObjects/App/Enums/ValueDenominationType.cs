//-----------------------------------------------------------------------
// <copyright file="ValueDenominationType.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessObjects.App.Enums
{
    /// <summary>
    /// Value Denomination Types.
    /// </summary>
    public enum ValueDenominationType : byte
    {
        /// <summary>
        /// No value denomination.
        /// </summary>
        None = 0,

        /// <summary>
        /// Agreeability value denomination.
        /// </summary>
        Agreeability = 1,

        /// <summary>
        /// Aggressiveness value denomination.
        /// </summary>
        Aggressiveness = 2,

        /// <summary>
        /// Honesty value denomination.
        /// </summary>
        Honesty = 3,

        /// <summary>
        /// Player Skill value denomination.
        /// </summary>
        PlayerSkill = 4,

        /// <summary>
        /// Player Specialty value denomination.
        /// </summary>
        PlayerSpecialty = 5
    }
}