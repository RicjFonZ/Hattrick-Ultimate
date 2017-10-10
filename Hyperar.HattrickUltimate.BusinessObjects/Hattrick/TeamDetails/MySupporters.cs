// -----------------------------------------------------------------------
// <copyright file="MySupporters.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
// -----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessObjects.Hattrick.TeamDetails
{
    using System.Collections.Generic;

    /// <summary>
    /// MySupporters node within TeamDetails XML file.
    /// </summary>
    public class MySupporters
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the maximum number of teams that will be in the output.
        /// </summary>
        public int MaxItems { get; set; }

        /// <summary>
        /// Gets or sets the Supporter Teams.
        /// </summary>
        public List<SupporterTeam> SupporterTeamList { get; set; }

        /// <summary>
        /// Gets or sets the total number of supporter teams.
        /// </summary>
        public int TotalItems { get; set; }

        #endregion Public Properties
    }
}