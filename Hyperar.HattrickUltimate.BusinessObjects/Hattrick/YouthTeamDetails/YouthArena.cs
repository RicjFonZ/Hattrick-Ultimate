//-----------------------------------------------------------------------
// <copyright file="YouthArena.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessObjects.Hattrick.YouthTeamDetails
{
    /// <summary>
    /// YouthArena node within YouthTeamDetails XML file.
    /// </summary>
    public class YouthArena
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the Youth Arena ID.
        /// </summary>
        public long YouthArenaId { get; set; }

        /// <summary>
        /// Gets or sets the Youth Arena Name.
        /// </summary>
        public string YouthArenaName { get; set; }

        #endregion Public Properties
    }
}