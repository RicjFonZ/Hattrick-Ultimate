// -----------------------------------------------------------------------
// <copyright file="SupporterTeam.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
// -----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessObjects.Hattrick.TeamDetails
{
    /// <summary>
    /// Cup node within TeamDetails XML file.
    /// </summary>
    public class SupporterTeam
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the League Id.
        /// </summary>
        public long LeagueId { get; set; }

        /// <summary>
        /// Gets or sets the LeagueLevelUnit Id.
        /// </summary>
        public long LeagueLevelUnitId { get; set; }

        /// <summary>
        /// Gets or sets the LeagueLevelUnit Name.
        /// </summary>
        public string LeagueLevelUnitName { get; set; }

        /// <summary>
        /// Gets or sets the League Name.
        /// </summary>
        public string LeagueName { get; set; }

        /// <summary>
        /// Gets or sets the login name.
        /// </summary>
        public string LoginName { get; set; }

        /// <summary>
        /// Gets or sets the Team Id.
        /// </summary>
        public long TeamId { get; set; }

        /// <summary>
        /// Gets or sets the Team Name.
        /// </summary>
        public string TeamName { get; set; }

        /// <summary>
        /// Gets or sets the User Id.
        /// </summary>
        public long UserId { get; set; }

        #endregion Public Properties
    }
}