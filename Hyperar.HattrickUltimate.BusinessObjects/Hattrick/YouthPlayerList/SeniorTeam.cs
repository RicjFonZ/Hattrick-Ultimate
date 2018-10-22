//-----------------------------------------------------------------------
// <copyright file="SeniorTeam.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessObjects.Hattrick.YouthPlayerList
{
    /// <summary>
    /// Senior Team node within Youth Player List XML file.
    /// </summary>
    public class SeniorTeam
    {
        /// <summary>
        /// Gets or sets the Senior Team ID.
        /// </summary>
        public long SeniorTeamId { get; set; }

        /// <summary>
        /// Gets or sets the Senior Team Name.
        /// </summary>
        public string SeniorTeamName { get; set; }
    }
}