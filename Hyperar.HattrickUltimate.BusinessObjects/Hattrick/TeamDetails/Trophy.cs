// -----------------------------------------------------------------------
// <copyright file="Trophy.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
// -----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessObjects.Hattrick.TeamDetails
{
    using System;

    /// <summary>
    /// Trophy node within TeamDetails XML file.
    /// </summary>
    public class Trophy
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the Gained Date.
        /// </summary>
        public DateTime GainedDate { get; set; }

        /// <summary>
        /// Gets or sets the Image Url.
        /// </summary>
        public string ImageUrl { get; set; }

        /// <summary>
        /// Gets or sets the League Level.
        /// </summary>
        public byte LeagueLevel { get; set; }

        /// <summary>
        /// Gets or sets League Level Unit Name.
        /// </summary>
        public string LeagueLevelUnitName { get; set; }

        /// <summary>
        /// Gets or sets the Season.
        /// </summary>
        public int Season { get; set; }

        /// <summary>
        /// Gets or sets the Trophy Type Id.
        /// </summary>
        public int TrophyTypeId { get; set; }

        #endregion Public Properties
    }
}