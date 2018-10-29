//-----------------------------------------------------------------------
// <copyright file="DownloadSettings.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessObjects.App
{
    using System.ComponentModel;
    using Hyperar.HattrickUltimate.BusinessObjects.App.Interface;
    using Localization;

    /// <summary>
    /// Represents the Download Settings.
    /// </summary>
    public class DownloadSettings : LocalizableObject, IEntity
    {
        #region Private Fields

        /// <summary>
        /// Junior Player Include Match Info Description resource name.
        /// </summary>
        private const string JuniorPlayerIncludeMatchInfoDescription = "DownloadItemDescription_IncludeJuniorPlayerMatchInfo";

        /// <summary>
        /// Junior Player Include Match Info Name resource name.
        /// </summary>
        private const string JuniorPlayerIncludeMatchInfoName = "DownloadItemDisplayName_IncludeJuniorPlayerMatchInfo";

        /// <summary>
        /// Junior Players Category resource name.
        /// </summary>
        private const string JuniorPlayersCategory = "DownloadItemCategory_JuniorPlayers";

        /// <summary>
        /// Senior Player Include Match Info Description resource name.
        /// </summary>
        private const string SeniorPlayerIncludeMatchInfoDescription = "DownloadItemDescription_IncludeSeniorPlayerMatchInfo";

        /// <summary>
        /// Senior Player Include Match Info Name resource name.
        /// </summary>
        private const string SeniorPlayerIncludeMatchInfoName = "DownloadItemDisplayName_IncludeSeniorPlayerMatchInfo";

        /// <summary>
        /// Senior Players Category resource name.
        /// </summary>
        private const string SeniorPlayersCategory = "DownloadItemCategory_SeniorPlayers";

        /// <summary>
        /// Senior Team Category resource name.
        /// </summary>
        private const string SeniorTeamCategory = "DownloadItemCategory_SeniorTeam";

        /// <summary>
        /// Senior Team Include Away Flags Description resource name.
        /// </summary>
        private const string SeniorTeamIncludeAwayFlagsDescription = "DownloadItemDescription_IncludeSeniorTeamAwayFlags";

        /// <summary>
        /// Senior Team Include Away Flags Name resource name.
        /// </summary>
        private const string SeniorTeamIncludeAwayFlagsName = "DownloadItemDisplayName_IncludeSeniorTeamAwayFlags";

        /// <summary>
        /// Senior Team Include Home Flags Description resource name.
        /// </summary>
        private const string SeniorTeamIncludeHomeFlagsDescription = "DownloadItemDescription_IncludeSeniorTeamHomeFlags";

        /// <summary>
        /// Senior Team Include Home Flag Name resource name.
        /// </summary>
        private const string SeniorTeamIncludeHomeFlagsName = "DownloadItemDisplayName_IncludeSeniorTeamHomeFlags";

        #endregion Private Fields

        #region Public Properties

        /// <summary>
        /// Gets or sets the ID.
        /// </summary>
        [Browsable(false)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to Include Junior Player Match Info or not.
        /// </summary>
        [LocalizableProperty(JuniorPlayersCategory, JuniorPlayerIncludeMatchInfoName, JuniorPlayerIncludeMatchInfoDescription, typeof(Controls))]
        public bool IncludeJuniorPlayerMatchInfo { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to Include Senior Player Match Info or not.
        /// </summary>
        [LocalizableProperty(SeniorPlayersCategory, SeniorPlayerIncludeMatchInfoName, SeniorPlayerIncludeMatchInfoDescription, typeof(Controls))]
        public bool IncludeSeniorPlayerMatchInfo { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to Include Senior Team Away Flags or not.
        /// </summary>
        [LocalizableProperty(SeniorTeamCategory, SeniorTeamIncludeAwayFlagsName, SeniorTeamIncludeAwayFlagsDescription, typeof(Controls))]
        public bool IncludeSeniorTeamAwayFlags { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to Include Senior Team Home Flags or not.
        /// </summary>
        [LocalizableProperty(SeniorTeamCategory, SeniorTeamIncludeHomeFlagsName, SeniorTeamIncludeHomeFlagsDescription, typeof(Controls))]
        public bool IncludeSeniorTeamHomeFlags { get; set; }

        #endregion Public Properties
    }
}