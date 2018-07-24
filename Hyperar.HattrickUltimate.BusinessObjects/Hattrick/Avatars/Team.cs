//-----------------------------------------------------------------------
// <copyright file="Team.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessObjects.Hattrick.Avatars
{
    using System.Collections.Generic;

    /// <summary>
    /// Team node within Avatars XML file.
    /// </summary>
    public class Team
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the Players.
        /// </summary>
        public List<Player> Players { get; set; }

        /// <summary>
        /// Gets or sets the Team ID.
        /// </summary>
        public long TeamId { get; set; }

        #endregion Public Properties
    }
}