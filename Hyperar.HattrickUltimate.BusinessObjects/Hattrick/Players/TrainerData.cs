// -----------------------------------------------------------------------
// <copyright file="TrainerData.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
// -----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessObjects.Hattrick.Players
{
    /// <summary>
    /// TrainerData node within WorldDetails XML file.
    /// </summary>
    public class TrainerData
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the Trainer skill.
        /// </summary>
        public byte TrainerSkill { get; set; }

        /// <summary>
        /// Gets or sets the Trainer type.
        /// </summary>
        /// <remarks>
        /// Defensive = 0.
        /// Offensive = 1.
        /// Balanced = 2.
        /// </remarks>
        public byte TrainerType { get; set; }

        #endregion Public Properties
    }
}