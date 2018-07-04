// -----------------------------------------------------------------------
// <copyright file="League.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
// -----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessObjects.Hattrick.ManagerCompendium
{
    /// <summary>
    /// League node within ManagerCompendium XML file.
    /// </summary>
    public class League
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the ID.
        /// </summary>
        public long LeagueId { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string LeagueName { get; set; }

        #endregion Public Properties
    }
}