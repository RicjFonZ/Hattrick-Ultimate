// -----------------------------------------------------------------------
// <copyright file="SupportedTeams.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
// -----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessObjects.Hattrick.TeamDetails
{
    using System.Collections.Generic;

    /// <summary>
    /// SupportedTeams node within TeamDetails XML file.
    /// </summary>
    public class SupportedTeams
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the maximum number of teams that will be in the output.
        /// </summary>
        public int MaxItems { get; set; }

        /// <summary>
        /// Gets or sets the Supported Teams.
        /// </summary>
        public List<SupportedTeam> SupportedTeamList { get; set; }

        /// <summary>
        /// Gets or sets the total number of supporter teams.
        /// </summary>
        public int TotalItems { get; set; }

        #endregion Public Properties
    }
}