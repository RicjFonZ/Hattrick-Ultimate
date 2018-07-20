//-----------------------------------------------------------------------
// <copyright file="DownloadSettings.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessObjects.OAuth
{
    using Localization;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class DownloadSettings : LocalizableObject
    {
        #region Public Properties

        [LocalizableProperty("DownloadItemCategory_World", "DownloadItemDisplayName_DownloadAllRegions", "DownloadItemDescription_DownloadAllRegions", typeof(Controls))]
        public bool DownloadAllRegions { get; set; }

        [LocalizableProperty("DownloadItemCategory_SeniorTeam", "DownloadItemDisplayName_SeniorTeamIncludeAwayFlags", "DownloadItemDescription_SeniorTeamIncludeAwayFlags", typeof(Controls))]
        public bool SeniorTeamIncludeAwayFlags { get; set; }

        [LocalizableProperty("DownloadItemCategory_SeniorTeam", "DownloadItemDisplayName_SeniorTeamIncludeHomeFlags", "DownloadItemDescription_SeniorTeamIncludeHomeFlags", typeof(Controls))]
        public bool SeniorTeamIncludeHomeFlags { get; set; }

        #endregion Public Properties
    }
}