// -----------------------------------------------------------------------
// <copyright file="NextMatch.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
// -----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessObjects.Hattrick.TeamDetails
{
    using System;

    /// <summary>
    /// NextMatch node within TeamDetails XML file.
    /// </summary>
    public class NextMatch
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the Away Team Id.
        /// </summary>
        public long NextMatchAwayTeamId { get; set; }

        /// <summary>
        /// Gets or sets the Away Team Name.
        /// </summary>
        public string NextMatchAwayTeamName { get; set; }

        /// <summary>
        /// Gets or sets the Next Match date.
        /// </summary>
        public DateTime NextMatchDate { get; set; }

        /// <summary>
        /// Gets or sets the Home Team Id.
        /// </summary>
        public long NextMatchHomeTeamId { get; set; }

        /// <summary>
        /// Gets or sets the Home Team Name.
        /// </summary>
        public string NextMatchHomeTeamName { get; set; }

        /// <summary>
        /// Gets or sets the Next Match Id.
        /// </summary>
        public long NextMatchId { get; set; }

        #endregion Public Properties
    }
}