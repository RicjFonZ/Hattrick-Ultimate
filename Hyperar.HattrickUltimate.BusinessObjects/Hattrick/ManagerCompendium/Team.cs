// -----------------------------------------------------------------------
// <copyright file="Team.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
// -----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessObjects.Hattrick.ManagerCompendium
{
    /// <summary>
    /// Team node within ManagerCompendium XML file.
    /// </summary>
    public class Team
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the Arena.
        /// </summary>
        public Arena Arena { get; set; }

        /// <summary>
        /// Gets or sets the League.
        /// </summary>
        public League League { get; set; }

        /// <summary>
        /// Gets or sets the League Level Unit.
        /// </summary>
        public LeagueLevelUnit LeagueLevelUnit { get; set; }

        /// <summary>
        /// Gets or sets the Region.
        /// </summary>
        public Region Region { get; set; }

        /// <summary>
        /// Gets or sets the ID.
        /// </summary>
        public long TeamId { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string TeamName { get; set; }

        /// <summary>
        /// Gets or sets the Youth Team.
        /// </summary>
        public YouthTeam YouthTeam { get; set; }

        #endregion Public Properties
    }
}