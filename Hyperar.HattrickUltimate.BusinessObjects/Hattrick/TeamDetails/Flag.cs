// -----------------------------------------------------------------------
// <copyright file="Flag.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
// -----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessObjects.Hattrick.TeamDetails
{
    /// <summary>
    /// Flag node within TeamDetails XML file.
    /// </summary>
    public class Flag
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the Country Code.
        /// </summary>
        public string CountryCode { get; set; }

        /// <summary>
        /// Gets or sets the League Id.
        /// </summary>
        public uint LeagueId { get; set; }

        /// <summary>
        /// Gets or sets the League Name.
        /// </summary>
        public string LeagueName { get; set; }

        #endregion Public Properties
    }
}