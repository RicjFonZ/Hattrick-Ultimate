// -----------------------------------------------------------------------
// <copyright file="Root.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
// -----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessObjects.Hattrick.Players
{
    /// <summary>
    /// Players XML file root.
    /// </summary>
    public class Root : XmlEntityBase
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the Action type.
        /// </summary>
        public string ActionType { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the team is playing a match or not.
        /// </summary>
        public bool IsPlayingMatch { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the info requested is for Youth players or not.
        /// </summary>
        /// <remarks>Deprecated, always false.</remarks>
        public bool IsYouth { get; set; }

        /// <summary>
        /// Gets or sets the Team.
        /// </summary>
        public Team Team { get; set; }

        /// <summary>
        /// Gets or sets the fetching user Supporter Tier.
        /// </summary>
        public string UserSupporterTier { get; set; }

        #endregion Public Properties
    }
}