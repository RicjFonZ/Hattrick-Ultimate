// -----------------------------------------------------------------------
// <copyright file="SeniorPlayerSkills.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
// -----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessObjects.App
{
    using System;
    using Interface;

    /// <summary>
    /// Represents the Skills of a Senior Player at a given time.
    /// </summary>
    public class SeniorPlayerSkills : EntityBase, IEntity
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the Defending level.
        /// </summary>
        public byte Defending { get; set; }

        /// <summary>
        /// Gets or sets the Experience level.
        /// </summary>
        public byte Experience { get; set; }

        /// <summary>
        /// Gets or sets the Form level.
        /// </summary>
        public byte Form { get; set; }

        /// <summary>
        /// Gets or sets the Keeper level.
        /// </summary>
        public byte Keeper { get; set; }

        /// <summary>
        /// Gets or sets the Loyalty level.
        /// </summary>
        public byte Loyalty { get; set; }

        /// <summary>
        /// Gets or sets the Passing level.
        /// </summary>
        public byte Passing { get; set; }

        /// <summary>
        /// Gets or sets the Playmaking level.
        /// </summary>
        public byte Playmaking { get; set; }

        /// <summary>
        /// Gets or sets the Scoring level.
        /// </summary>
        public byte Scoring { get; set; }

        /// <summary>
        /// Gets or sets the Senior Player.
        /// </summary>
        public virtual SeniorPlayer SeniorPlayer { get; set; }

        /// <summary>
        /// Gets or sets the Senior Player Id.
        /// </summary>
        public int SeniorPlayerId { get; set; }

        /// <summary>
        /// Gets or sets the SetPieces level.
        /// </summary>
        public byte SetPieces { get; set; }

        /// <summary>
        /// Gets or sets the Stamina level.
        /// </summary>
        public byte Stamina { get; set; }

        /// <summary>
        /// Gets or sets the Total Skill Index.
        /// </summary>
        public int TotalSkillIndex { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the data was stored.
        /// </summary>
        public DateTime UpdatedOn { get; set; }

        /// <summary>
        /// Gets or sets the Winger level.
        /// </summary>
        public byte Winger { get; set; }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// Returns a System.String that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return this.GetType().FullName;
        }

        #endregion Public Methods
    }
}