//-----------------------------------------------------------------------
// <copyright file="YouthPlayer.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessObjects.Hattrick.YouthPlayerList
{
    using System;

    /// <summary>
    /// Youth Player node within the Youth Player List XML file.
    /// </summary>
    public class YouthPlayer
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the Age.
        /// </summary>
        public byte Age { get; set; }

        /// <summary>
        /// Gets or sets the Age Days.
        /// </summary>
        public byte AgeDays { get; set; }

        /// <summary>
        /// Gets or sets the Arrival Date.
        /// </summary>
        public DateTime ArrivalDate { get; set; }

        /// <summary>
        /// Gets or sets the number of days in which the Player Can Be Promoted In.
        /// </summary>
        public short CanBePromotedIn { get; set; }

        /// <summary>
        /// Gets or sets the Cards.
        /// </summary>
        public byte Cards { get; set; }

        /// <summary>
        /// Gets or sets the Career Goals.
        /// </summary>
        public short CareerGoals { get; set; }

        /// <summary>
        /// Gets or sets the Career Hattricks.
        /// </summary>
        public short CareerHattricks { get; set; }

        /// <summary>
        /// Gets or sets the First Name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the Friendly Goals.
        /// </summary>
        public byte FriendlyGoals { get; set; }

        /// <summary>
        /// Gets or sets the Injury Level.
        /// </summary>
        public int InjuryLevel { get; set; }

        /// <summary>
        /// Gets or sets the Last Match.
        /// </summary>
        public LastMatch LastMatch { get; set; }

        /// <summary>
        /// Gets or sets the Last Name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the League Goals.
        /// </summary>
        public byte LeagueGoals { get; set; }

        /// <summary>
        /// Gets or sets the Nick Name.
        /// </summary>
        public string NickName { get; set; }

        /// <summary>
        /// Gets or sets the Owner Notes.
        /// </summary>
        public string OwnerNotes { get; set; }

        /// <summary>
        /// Gets or sets the Owning Youth Team.
        /// </summary>
        public OwningYouthTeam OwningYouthTeam { get; set; }

        /// <summary>
        /// Gets or sets the Player Category ID.
        /// </summary>
        public byte? PlayerCategoryId { get; set; }

        /// <summary>
        /// Gets or sets the Player Number.
        /// </summary>
        public byte PlayerNumber { get; set; }

        /// <summary>
        /// Gets or sets the Player Skills.
        /// </summary>
        public PlayerSkills PlayerSkills { get; set; }

        /// <summary>
        /// Gets or sets the Scout Call.
        /// </summary>
        public ScoutCall ScoutCall { get; set; }

        /// <summary>
        /// Gets or sets the Specialty.
        /// </summary>
        public byte Specialty { get; set; }

        /// <summary>
        /// Gets or sets the Statement.
        /// </summary>
        public string Statement { get; set; }

        /// <summary>
        /// Gets or sets the Youth Player ID.
        /// </summary>
        public long YouthPlayerId { get; set; }

        #endregion Public Properties
    }
}