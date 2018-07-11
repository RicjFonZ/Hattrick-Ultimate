//-----------------------------------------------------------------------
// <copyright file="DownloadSettings.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessObjects.OAuth
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Localization;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class DownloadSettings : LocalizableObject
    {
        [LocalizableProperty("DownloadItemCategory_HattrickWorld", "DownloadItemDisplayName_DownloadAllRegions", "DownloadItemDescription_DescriptionDownloadAllRegions", typeof(Strings))]
        public bool DownloadAllRegions { get; set; }
    }
}