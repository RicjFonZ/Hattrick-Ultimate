//-----------------------------------------------------------------------
// <copyright file="YouthLeague.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessObjects.Hattrick.YouthTeamDetails
{
    /// <summary>
    /// YouthLeague node within YouthTeamDetails XML file.
    /// </summary>
    public class YouthLeague
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the Youth League ID.
        /// </summary>
        public long YouthLeagueId { get; set; }

        /// <summary>
        /// Gets or sets the Youth League Name.
        /// </summary>
        public string YouthLeagueName { get; set; }

        /// <summary>
        /// Gets or sets the Youth League Status.
        /// </summary>
        /// <remarks>
        /// Not full = 0. About to create matches = 1. Matches created, league is running = 3 League
        /// is finished = 10.
        /// </remarks>
        public byte YouthLeagueStatus { get; set; }

        #endregion Public Properties
    }
}