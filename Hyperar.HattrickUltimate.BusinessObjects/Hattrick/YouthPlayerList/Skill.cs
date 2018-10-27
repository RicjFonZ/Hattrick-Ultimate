//-----------------------------------------------------------------------
// <copyright file="Skill.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessObjects.Hattrick.YouthPlayerList
{
    /// <summary>
    /// Skill Max node within Youth Player List XML file.
    /// </summary>
    public class Skill : SkillBase
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets a value indicating whether Max Is Reached or not.
        /// </summary>
        public bool IsMaxReached { get; set; }

        #endregion Public Properties
    }
}