//-----------------------------------------------------------------------
// <copyright file="OwningYouthTeam.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessObjects.Hattrick.YouthPlayerList
{
    /// <summary>
    /// Owning Youth Team node within Youth Player List XML file.
    /// </summary>
    public class OwningYouthTeam
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the Senior Team.
        /// </summary>
        public SeniorTeam SeniorTeam { get; set; }

        /// <summary>
        /// Gets or sets the Youth Team ID.
        /// </summary>
        public long YouthTeamId { get; set; }

        /// <summary>
        /// Gets or sets the Youth Team League ID.
        /// </summary>
        public long? YouthTeamLeagueId { get; set; }

        /// <summary>
        /// Gets or sets the Youth Team Name.
        /// </summary>
        public string YouthTeamName { get; set; }

        #endregion Public Properties
    }
}