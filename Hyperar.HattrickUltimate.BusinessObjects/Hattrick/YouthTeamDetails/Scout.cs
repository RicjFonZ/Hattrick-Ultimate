//-----------------------------------------------------------------------
// <copyright file="Scout.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessObjects.Hattrick.YouthTeamDetails
{
    using System;

    /// <summary>
    /// Scout node within YouthTeamDetails XML file.
    /// </summary>
    public class Scout
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the Age.
        /// </summary>
        public byte Age { get; set; }

        /// <summary>
        /// Gets or sets the Country.
        /// </summary>
        public Country Country { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the Scout was hired.
        /// </summary>
        public DateTime HiredDate { get; set; }

        /// <summary>
        /// Gets or sets the ID of the associated Hall Of Fame Player.
        /// </summary>
        /// <remarks>
        /// 0 if None.
        /// </remarks>
        public long HofPlayerId { get; set; }

        /// <summary>
        /// Gets or sets the Country the Scout is in.
        /// </summary>
        public Country InCountry { get; set; }

        /// <summary>
        /// Gets or sets the Region the Scout is in.
        /// </summary>
        public Region InRegion { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the Scout was last called.
        /// </summary>
        public DateTime LastCalled { get; set; }

        /// <summary>
        /// Gets or sets the type of Player the Scout is searching for.
        /// </summary>
        /// <remarks>
        /// Any = 0.
        /// Keeper = 1.
        /// Defender = 2.
        /// Wingback = 3.
        /// Midfielder = 4.
        /// Winger = 5.
        /// Forward = 6.
        /// </remarks>
        public byte PlayerSearchType { get; set; }

        /// <summary>
        /// Gets or sets the Region.
        /// </summary>
        public Region Region { get; set; }

        /// <summary>
        /// Gets or sets the Scout Name.
        /// </summary>
        public string ScoutName { get; set; }

        /// <summary>
        /// Gets or sets the Scout's Travel details.
        /// </summary>
        public Travel Travel { get; set; }

        /// <summary>
        /// Gets or sets the Youth Scout ID.
        /// </summary>
        public long YouthScoutId { get; set; }

        #endregion Public Properties
    }
}