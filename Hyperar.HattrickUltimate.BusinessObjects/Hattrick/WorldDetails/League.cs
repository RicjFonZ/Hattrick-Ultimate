// -----------------------------------------------------------------------
// <copyright file="League.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
// -----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessObjects.Hattrick.WorldDetails
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// League node within WorldDetails XML file.
    /// </summary>
    public class League
    {
        #region Properties

        /// <summary>
        /// Gets or sets the number of active teams within the League.
        /// </summary>
        public int ActiveTeams { get; set; }

        /// <summary>
        /// Gets or sets the number of active users within the League.
        /// </summary>
        public int ActiveUsers { get; set; }

        /// <summary>
        /// Gets or sets the continent of the League.
        /// </summary>
        public string Continent { get; set; }

        /// <summary>
        /// Gets or sets the Country of the League.
        /// </summary>
        public Country Country { get; set; }

        /// <summary>
        /// Gets or sets the date and time of the next cup match date of the League.
        /// </summary>
        public DateTime CupMatchDate { get; set; }

        /// <summary>
        /// Gets or sets the Cups of the League.
        /// </summary>
        public List<Cup> Cups { get; set; } = new List<Cup>();

        /// <summary>
        /// Gets or sets the date and time of the next economy update of the League.
        /// </summary>
        public DateTime EconomyDate { get; set; }

        /// <summary>
        /// Gets or sets the english name of the League.
        /// </summary>
        public string EnglishName { get; set; }

        /// <summary>
        /// Gets or sets the League ID.
        /// </summary>
        public uint LeagueId { get; set; }

        /// <summary>
        /// Gets or sets the name of the League.
        /// </summary>
        public string LeagueName { get; set; }

        /// <summary>
        /// Gets or sets the current match round.
        /// </summary>
        public int MatchRound { get; set; }

        /// <summary>
        /// Gets or sets the National Team ID.
        /// </summary>
        public uint NationalTeamId { get; set; }

        /// <summary>
        /// Gets or sets the number of divisions within the League.
        /// </summary>
        public int NumberOfLevels { get; set; }

        /// <summary>
        /// Gets or sets the current season of the League.
        /// </summary>
        public int Season { get; set; }

        /// <summary>
        /// Gets or sets the difference between the season of the League and the global season.
        /// </summary>
        public int SeasonOffset { get; set; }

        /// <summary>
        /// Gets or sets the date and time of the next series match date of the League.
        /// </summary>
        /// <remarks>
        /// A League can have several series match dates, this represents the first batch of the
        /// series matches of the League.
        /// </remarks>
        public DateTime SeriesMatchDate { get; set; }

        /// <summary>
        /// Gets or sets the short name of the League.
        /// </summary>
        public string ShortName { get; set; }

        /// <summary>
        /// Gets or sets the date and time of the next training update of the League.
        /// </summary>
        public DateTime TrainingDate { get; set; }

        /// <summary>
        /// Gets or sets the U20 National Team ID.
        /// </summary>
        public uint U20TeamId { get; set; }

        /// <summary>
        /// Gets or sets the number of users waiting to join the League.
        /// </summary>
        public int WaitingUsers { get; set; }

        /// <summary>
        /// Gets or sets the zone name.
        /// </summary>
        public string ZoneName { get; set; }

        #endregion Properties
    }
}