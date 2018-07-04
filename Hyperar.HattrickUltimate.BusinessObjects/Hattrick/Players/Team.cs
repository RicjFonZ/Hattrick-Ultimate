// -----------------------------------------------------------------------
// <copyright file="Team.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
// -----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessObjects.Hattrick.Players
{
    using System.Collections.Generic;

    /// <summary>
    /// Team node within WorldDetails XML file.
    /// </summary>
    public class Team
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the Player list.
        /// </summary>
        public List<Player> PlayerList { get; set; }

        /// <summary>
        /// Gets or sets the Team Id.
        /// </summary>
        public long TeamId { get; set; }

        /// <summary>
        /// Gets or sets the Team name.
        /// </summary>
        public string TeamName { get; set; }

        #endregion Public Properties
    }
}