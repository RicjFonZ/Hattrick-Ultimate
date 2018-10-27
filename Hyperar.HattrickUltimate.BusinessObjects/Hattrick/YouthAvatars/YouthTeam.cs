//-----------------------------------------------------------------------
// <copyright file="YouthTeam.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessObjects.Hattrick.YouthAvatars
{
    using System.Collections.Generic;

    /// <summary>
    /// Youth Team node within Avatars XML file.
    /// </summary>
    public class YouthTeam
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the Youth Players.
        /// </summary>
        public List<YouthPlayer> YouthPlayers { get; set; }

        /// <summary>
        /// Gets or sets the Youth Team ID.
        /// </summary>
        public long YouthTeamId { get; set; }

        #endregion Public Properties
    }
}