// -----------------------------------------------------------------------
// <copyright file="NationalTeam.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
// -----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessObjects.Hattrick.ManagerCompendium
{
    /// <summary>
    /// NationalTeam node within ManagerCompendium XML file.
    /// </summary>
    public class NationalTeam
    {
        #region Properties

        /// <summary>
        /// Gets or sets the ID.
        /// </summary>
        public uint NationalTeamId { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string NationalTeamName { get; set; }

        #endregion Properties
    }
}