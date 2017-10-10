// -----------------------------------------------------------------------
// <copyright file="League.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
// -----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessObjects.Hattrick.TeamDetails
{
    /// <summary>
    /// League node within TeamDetails XML file.
    /// </summary>
    public class League
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the League ID.
        /// </summary>
        public uint LeagueId { get; set; }

        /// <summary>
        /// Gets or sets the name of the League.
        /// </summary>
        public string LeagueName { get; set; }

        #endregion Public Properties
    }
}