//-----------------------------------------------------------------------
// <copyright file="SkillBase.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessObjects.Hattrick.YouthPlayerList
{
    /// <summary>
    /// Youth Player List Skill base class.
    /// </summary>
    public abstract class SkillBase
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets a value indicating whether skill Is Available.
        /// </summary>
        public bool IsAvailable { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether May Unlock skill or not.
        /// </summary>
        public bool MayUnlock { get; set; }

        /// <summary>
        /// Gets or sets a the Value.
        /// </summary>
        public byte? Value { get; set; }

        #endregion Public Properties
    }
}