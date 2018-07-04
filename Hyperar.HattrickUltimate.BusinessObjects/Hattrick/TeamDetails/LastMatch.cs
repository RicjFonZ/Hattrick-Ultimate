// -----------------------------------------------------------------------
// <copyright file="LastMatch.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
// -----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessObjects.Hattrick.TeamDetails
{
    using System;

    /// <summary>
    /// LastMatch node within TeamDetails XML file.
    /// </summary>
    public class LastMatch
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the Last Match Away Team Goals.
        /// </summary>
        public byte LastMatchAwayTeamGoals { get; set; }

        /// <summary>
        /// Gets or sets the Away Team Id.
        /// </summary>
        public long LastMatchAwayTeamId { get; set; }

        /// <summary>
        /// Gets or sets the Away Team Name.
        /// </summary>
        public string LastMatchAwayTeamName { get; set; }

        /// <summary>
        /// Gets or sets the Last Match date.
        /// </summary>
        public DateTime LastMatchDate { get; set; }

        /// <summary>
        /// Gets or sets the Last Match Home Team Goals.
        /// </summary>
        public byte LastMatchHomeTeamGoals { get; set; }

        /// <summary>
        /// Gets or sets the Home Team Id.
        /// </summary>
        public long LastMatchHomeTeamId { get; set; }

        /// <summary>
        /// Gets or sets the Home Team Name.
        /// </summary>
        public string LastMatchHomeTeamName { get; set; }

        /// <summary>
        /// Gets or sets the Last Match Id.
        /// </summary>
        public long LastMatchId { get; set; }

        #endregion Public Properties
    }
}