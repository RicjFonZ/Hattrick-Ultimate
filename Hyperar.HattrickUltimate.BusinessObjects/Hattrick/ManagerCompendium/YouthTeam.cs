// -----------------------------------------------------------------------
// <copyright file="YouthTeam.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
// -----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessObjects.Hattrick.ManagerCompendium
{
    /// <summary>
    /// YouthTeam node within ManagerCompendium XML file.
    /// </summary>
    public class YouthTeam
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the league.
        /// </summary>
        public YouthLeague YouthLeague { get; set; }

        /// <summary>
        /// Gets or sets the ID.
        /// </summary>
        public uint YouthTeamId { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string YouthTeamName { get; set; }

        #endregion Public Properties
    }
}