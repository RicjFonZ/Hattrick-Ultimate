//-----------------------------------------------------------------------
// <copyright file="SeniorPlayerWeekLog.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessObjects.App
{
    using Interface;

    /// <summary>
    /// Represents a Senior Player Week Log.
    /// </summary>
    public class SeniorPlayerWeekLog : EntityBase, IEntity
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the Age.
        /// </summary>
        public byte Age { get; set; }

        /// <summary>
        /// Gets or sets the Career Goals.
        /// </summary>
        public short CareerGoals { get; set; }

        /// <summary>
        /// Gets or sets the Career Hattricks.
        /// </summary>
        public short CareerHattricks { get; set; }

        /// <summary>
        /// Gets or sets the Cup Goals.
        /// </summary>
        public byte CupGoals { get; set; }

        /// <summary>
        /// Gets or sets the Defending.
        /// </summary>
        public byte Defending { get; set; }

        /// <summary>
        /// Gets or sets the Experience.
        /// </summary>
        public byte Experience { get; set; }

        /// <summary>
        /// Gets or sets the Form.
        /// </summary>
        public byte Form { get; set; }

        /// <summary>
        /// Gets or sets the Friendly Goals.
        /// </summary>
        public byte FriendlyGoals { get; set; }

        /// <summary>
        /// Gets or sets the Health Status.
        /// </summary>
        public int HealthStatus { get; set; }

        /// <summary>
        /// Gets or sets the Keeper.
        /// </summary>
        public byte Keeper { get; set; }

        /// <summary>
        /// Gets or sets the Loyalty.
        /// </summary>
        public byte Loyalty { get; set; }

        /// <summary>
        /// Gets or sets the Passing.
        /// </summary>
        public byte Passing { get; set; }

        /// <summary>
        /// Gets or sets the Playmaking.
        /// </summary>
        public byte Playmaking { get; set; }

        /// <summary>
        /// Gets or sets the Scoring.
        /// </summary>
        public byte Scoring { get; set; }

        /// <summary>
        /// Gets or sets the Season.
        /// </summary>
        public short Season { get; set; }

        /// <summary>
        /// Gets or sets the Senior Player.
        /// </summary>
        public virtual SeniorPlayer SeniorPlayer { get; set; }

        /// <summary>
        /// Gets or sets the Senior Player ID.
        /// </summary>
        public int SeniorPlayerId { get; set; }

        /// <summary>
        /// Gets or sets the Series Goals.
        /// </summary>
        public byte SeriesGoals { get; set; }

        /// <summary>
        /// Gets or sets the Set Pieces.
        /// </summary>
        public byte SetPieces { get; set; }

        /// <summary>
        /// Gets or sets the Stamina.
        /// </summary>
        public byte Stamina { get; set; }

        /// <summary>
        /// Gets or sets the Total Skill Index.
        /// </summary>
        public int TotalSkillIndex { get; set; }

        /// <summary>
        /// Gets or sets the Wage.
        /// </summary>
        public int Wage { get; set; }

        /// <summary>
        /// Gets or sets the Week.
        /// </summary>
        public byte Week { get; set; }

        /// <summary>
        /// Gets or sets the Winger.
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