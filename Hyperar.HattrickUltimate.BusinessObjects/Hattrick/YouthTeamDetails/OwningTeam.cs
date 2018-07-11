//-----------------------------------------------------------------------
// <copyright file="OwningTeam.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessObjects.Hattrick.YouthTeamDetails
{
    /// <summary>
    /// OwningTeam node within YouthTeamDetails XML file.
    /// </summary>
    public class OwningTeam
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the Mother Team ID.
        /// </summary>
        public long MotherTeamId { get; set; }

        /// <summary>
        /// Gets or sets the Mother Team Name.
        /// </summary>
        public string MotherTeamName { get; set; }

        #endregion Public Properties
    }
}