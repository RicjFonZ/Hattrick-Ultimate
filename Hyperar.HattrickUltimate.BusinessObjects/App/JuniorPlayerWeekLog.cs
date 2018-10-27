//-----------------------------------------------------------------------
// <copyright file="JuniorPlayerWeekLog.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessObjects.App
{
    using Interface;

    /// <summary>
    /// Represents a Junior Player Week Log.
    /// </summary>
    public class JuniorPlayerWeekLog : EntityBase, IEntity
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
        /// Gets or sets the Defending.
        /// </summary>
        public byte? Defending { get; set; }

        /// <summary>
        /// Gets or sets the Defending Max.
        /// </summary>
        public byte? DefendingMax { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the Defending skill Max Is Reached or not.
        /// </summary>
        public bool DefendingMaxReached { get; set; }

        /// <summary>
        /// Gets or sets the Friendly Goals.
        /// </summary>
        public byte FriendlyGoals { get; set; }

        /// <summary>
        /// Gets or sets the Health Status.
        /// </summary>
        public int HealthStatus { get; set; }

        /// <summary>
        /// Gets or sets the Junior Player.
        /// </summary>
        public virtual JuniorPlayer JuniorPlayer { get; set; }

        /// <summary>
        /// Gets or sets the Junior Player ID.
        /// </summary>
        public int JuniorPlayerId { get; set; }

        /// <summary>
        /// Gets or sets the Keeper.
        /// </summary>
        public byte? Keeper { get; set; }

        /// <summary>
        /// Gets or sets the Keeper Max.
        /// </summary>
        public byte? KeeperMax { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the Keeper skill Max Is Reached or not.
        /// </summary>
        public bool KeeperMaxReached { get; set; }

        /// <summary>
        /// Gets or sets the Passing.
        /// </summary>
        public byte? Passing { get; set; }

        /// <summary>
        /// Gets or sets the Passing Max.
        /// </summary>
        public byte? PassingMax { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the Passing skill Max Is Reached or not.
        /// </summary>
        public bool PassingMaxReached { get; set; }

        /// <summary>
        /// Gets or sets the Playmaking.
        /// </summary>
        public byte? Playmaking { get; set; }

        /// <summary>
        /// Gets or sets the Playmaking Max.
        /// </summary>
        public byte? PlaymakingMax { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the Playmaking skill Max Is Reached or not.
        /// </summary>
        public bool PlaymakingMaxReached { get; set; }

        /// <summary>
        /// Gets or sets the Scoring.
        /// </summary>
        public byte? Scoring { get; set; }

        /// <summary>
        /// Gets or sets the Scoring Max.
        /// </summary>
        public byte? ScoringMax { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the Scoring skill Max Is Reached or not.
        /// </summary>
        public bool ScoringMaxReached { get; set; }

        /// <summary>
        /// Gets or sets the Season.
        /// </summary>
        public short Season { get; set; }

        /// <summary>
        /// Gets or sets the Series Goals.
        /// </summary>
        public byte SeriesGoals { get; set; }

        /// <summary>
        /// Gets or sets the Set Pieces.
        /// </summary>
        public byte? SetPieces { get; set; }

        /// <summary>
        /// Gets or sets the Set Pieces Max.
        /// </summary>
        public byte? SetPiecesMax { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the Set Pieces skill Max Is Reached or not.
        /// </summary>
        public bool SetPiecesMaxReached { get; set; }

        /// <summary>
        /// Gets or sets the Week.
        /// </summary>
        public byte Week { get; set; }

        /// <summary>
        /// Gets or sets the Winger.
        /// </summary>
        public byte? Winger { get; set; }

        /// <summary>
        /// Gets or sets the Winger Max.
        /// </summary>
        public byte? WingerMax { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the Winger skill Max Is Reached or not.
        /// </summary>
        public bool WingerMaxReached { get; set; }

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