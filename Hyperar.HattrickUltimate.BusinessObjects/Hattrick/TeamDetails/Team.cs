// -----------------------------------------------------------------------
// <copyright file="Team.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
// -----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessObjects.Hattrick.TeamDetails
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Team node within TeamDetails XML file.
    /// </summary>
    public class Team
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the Arena.
        /// </summary>
        public Arena Arena { get; set; }

        /// <summary>
        /// Gets or sets the Bot Status.
        /// </summary>
        public BotStatus BotStatus { get; set; }

        /// <summary>
        /// Gets or sets the Country.
        /// </summary>
        public Country Country { get; set; }

        /// <summary>
        /// Gets or sets the Cup.
        /// </summary>
        public Cup Cup { get; set; }

        /// <summary>
        /// Gets or sets the Dress Alternate Uri.
        /// </summary>
        public string DressAlternateUri { get; set; }

        /// <summary>
        /// Gets or sets the Dress Uri.
        /// </summary>
        public string DressUri { get; set; }

        /// <summary>
        /// Gets or sets the Fanclub.
        /// </summary>
        public Fanclub Fanclub { get; set; }

        /// <summary>
        /// Gets or sets the Flags.
        /// </summary>
        public Flags Flags { get; set; }

        /// <summary>
        /// Gets or sets the Founded Date.
        /// </summary>
        public DateTime FoundedDate { get; set; }

        /// <summary>
        /// Gets or sets the Friendly Team Id.
        /// </summary>
        public long? FriendlyTeamId { get; set; }

        /// <summary>
        /// Gets or sets the Guestbook.
        /// </summary>
        public Guestbook Guestbook { get; set; }

        /// <summary>
        /// Gets or sets the Home Page.
        /// </summary>
        public string HomePage { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether if the team is a primary team or not.
        /// </summary>
        public bool IsPrimaryClub { get; set; }

        /// <summary>
        /// Gets or sets the League.
        /// </summary>
        public League League { get; set; }

        /// <summary>
        /// Gets or sets the League Level Unit.
        /// </summary>
        public LeagueLevelUnit LeagueLevelUnit { get; set; }

        /// <summary>
        /// Gets or sets the LogoUrl.
        /// </summary>
        public string LogoUrl { get; set; }

        /// <summary>
        /// Gets or sets My Supporters.
        /// </summary>
        public MySupporters MySupporters { get; set; }

        /// <summary>
        /// Gets or sets the Number Of Undefeated.
        /// </summary>
        public int NumberOfUndefeated { get; set; }

        /// <summary>
        /// Gets or sets the Number Of Victories.
        /// </summary>
        public int NumberOfVictories { get; set; }

        /// <summary>
        /// Gets or sets the number of visits.
        /// </summary>
        public int NumberOfVisits { get; set; }

        /// <summary>
        /// Gets or sets the Press Announcement.
        /// </summary>
        public PressAnnouncement PressAnnouncement { get; set; }

        /// <summary>
        /// Gets or sets the Region.
        /// </summary>
        public Region Region { get; set; }

        /// <summary>
        /// Gets or sets the Short Team Name.
        /// </summary>
        public string ShortTeamName { get; set; }

        /// <summary>
        /// Gets or sets the Supported Teams.
        /// </summary>
        public SupportedTeams SupportedTeams { get; set; }

        /// <summary>
        /// Gets or sets the Team Colors.
        /// </summary>
        public TeamColors TeamColors { get; set; }

        /// <summary>
        /// Gets or sets the Team Id.
        /// </summary>
        public long TeamId { get; set; }

        /// <summary>
        /// Gets or sets the Team Name.
        /// </summary>
        public string TeamName { get; set; }

        /// <summary>
        /// Gets or sets the Team Rank.
        /// </summary>
        public int TeamRank { get; set; }

        /// <summary>
        /// Gets or sets the Trainer.
        /// </summary>
        public Trainer Trainer { get; set; }

        /// <summary>
        /// Gets or sets the Trophy List.
        /// </summary>
        public List<Trophy> TrophyList { get; set; }

        /// <summary>
        /// Gets or sets the Youth Team Id.
        /// </summary>
        public long? YouthTeamId { get; set; }

        /// <summary>
        /// Gets or sets the Youth Team Name.
        /// </summary>
        public string YouthTeamName { get; set; }

        #endregion Public Properties
    }
}