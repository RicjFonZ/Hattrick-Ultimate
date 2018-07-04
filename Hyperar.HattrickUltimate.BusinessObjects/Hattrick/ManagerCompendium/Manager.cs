// -----------------------------------------------------------------------
// <copyright file="Manager.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
// -----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessObjects.Hattrick.ManagerCompendium
{
    using System.Collections.Generic;

    /// <summary>
    /// Manager node within ManagerCompendium XML file.
    /// </summary>
    public class Manager
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the avatar.
        /// </summary>
        public Avatar Avatar { get; set; }

        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        public Country Country { get; set; }

        /// <summary>
        /// Gets or sets the language.
        /// </summary>
        public Language Language { get; set; }

        /// <summary>
        /// Gets or sets the last logins date and time and part of the IP addresses.
        /// </summary>
        public List<string> LastLogins { get; set; }

        /// <summary>
        /// Gets or sets the login name.
        /// </summary>
        public string LoginName { get; set; }

        /// <summary>
        /// Gets or sets the national teams.
        /// </summary>
        public List<NationalTeam> NationalTeamCoach { get; set; }

        /// <summary>
        /// Gets or sets the Supporter Tier.
        /// </summary>
        public string SupporterTier { get; set; }

        /// <summary>
        /// Gets or sets the teams.
        /// </summary>
        public List<Team> Teams { get; set; }

        /// <summary>
        /// Gets or sets the ID.
        /// </summary>
        public long UserId { get; set; }

        #endregion Public Properties
    }
}