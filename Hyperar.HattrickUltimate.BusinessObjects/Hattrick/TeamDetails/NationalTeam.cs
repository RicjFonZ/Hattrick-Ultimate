// -----------------------------------------------------------------------
// <copyright file="NationalTeam.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
// -----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessObjects.Hattrick.TeamDetails
{
    /// <summary>
    /// NationalTeam node within TeamDetails XML file.
    /// </summary>
    public class NationalTeam
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the Index.
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// Gets or sets the NationalTeam ID.
        /// </summary>
        public long NationalTeamId { get; set; }

        /// <summary>
        /// Gets or sets the name of the NationalTeam.
        /// </summary>
        public string NationalTeamName { get; set; }

        #endregion Public Properties
    }
}