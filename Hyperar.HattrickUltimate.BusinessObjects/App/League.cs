// -----------------------------------------------------------------------
// <copyright file="League.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
// -----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessObjects.App
{
    using System.Collections.Generic;
    using Interface;

    /// <summary>
    /// Represents a League.
    /// </summary>
    public class League : HattrickEntityBase, IEntity, IHattrickEntity
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the number of active teams.
        /// </summary>
        public int ActiveTeams { get; set; }

        /// <summary>
        /// Gets or sets the number of active users.
        /// </summary>
        public int ActiveUsers { get; set; }

        /// <summary>
        /// Gets or sets the Continent.
        /// </summary>
        public virtual Continent Continent { get; set; }

        /// <summary>
        /// Gets or sets the Continent ID.
        /// </summary>
        public int ContinentId { get; set; }

        /// <summary>
        /// Gets or sets the Country.
        /// </summary>
        public virtual Country Country { get; set; }

        /// <summary>
        /// Gets or sets the Cups.
        /// </summary>
        public virtual ICollection<LeagueCup> Cups { get; set; } = new HashSet<LeagueCup>();

        /// <summary>
        /// Gets or sets the current round.
        /// </summary>
        public byte CurrentRound { get; set; }

        /// <summary>
        /// Gets or sets the current Season.
        /// </summary>
        public short CurrentSeason { get; set; }

        /// <summary>
        /// Gets or sets the number of divisions.
        /// </summary>
        public byte Divisions { get; set; }

        /// <summary>
        /// Gets or sets the English Name.
        /// </summary>
        public string EnglishName { get; set; }

        /// <summary>
        /// Gets or sets the Full Nam.
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Gets or sets the National Team.
        /// </summary>
        public virtual LeagueNationalTeam NationalTeam { get; set; }

        /// <summary>
        /// Gets or sets the Schedule.
        /// </summary>
        public virtual LeagueSchedule Schedule { get; set; }

        /// <summary>
        /// Gets or sets the season offset.
        /// </summary>
        public short SeasonOffset { get; set; }

        /// <summary>
        /// Gets or sets the Senior Series.
        /// </summary>
        public virtual ICollection<SeniorSeries> SeniorSeries { get; set; } = new HashSet<SeniorSeries>();

        /// <summary>
        /// Gets or sets the Senior Teams.
        /// </summary>
        public virtual ICollection<SeniorTeam> SeniorTeams { get; set; } = new HashSet<SeniorTeam>();

        /// <summary>
        /// Gets or sets the Short Name.
        /// </summary>
        public string ShortName { get; set; }

        /// <summary>
        /// Gets or sets the number of waiting users.
        /// </summary>
        public int WaitingUsers { get; set; }

        /// <summary>
        /// Gets or sets the Zone.
        /// </summary>
        public virtual Zone Zone { get; set; }

        /// <summary>
        /// Gets or sets the Zone ID.
        /// </summary>
        public int ZoneId { get; set; }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// Returns a System.String that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return $"{this.FullName} ({this.HattrickId})";
        }

        #endregion Public Methods
    }
}