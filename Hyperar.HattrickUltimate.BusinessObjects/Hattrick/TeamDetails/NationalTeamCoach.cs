// -----------------------------------------------------------------------
// <copyright file="NationalTeamCoach.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
// -----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessObjects.Hattrick.TeamDetails
{
    using System.Collections.Generic;

    /// <summary>
    /// NationalTeamCoach node within TeamDetails XML file.
    /// </summary>
    public class NationalTeamCoach
    {
        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="NationalTeamCoach"/> class.
        /// </summary>
        public NationalTeamCoach()
        {
            this.NationalTeam = new List<TeamDetails.NationalTeam>();
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>
        /// Gets or sets the number of National Teams.
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Gets or sets the National Teams.
        /// </summary>
        public List<NationalTeam> NationalTeam { get; set; }

        #endregion Public Properties
    }
}