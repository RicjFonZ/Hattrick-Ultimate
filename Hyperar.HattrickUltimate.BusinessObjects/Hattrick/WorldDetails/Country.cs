// -----------------------------------------------------------------------
// <copyright file="Country.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
// -----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessObjects.Hattrick.WorldDetails
{
    using System.Collections.Generic;

    /// <summary>
    /// Country node within WorldDetails XML file.
    /// </summary>
    public class Country
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the country code.
        /// </summary>
        public string CountryCode { get; set; }

        /// <summary>
        /// Gets or sets the Country ID.
        /// </summary>
        public uint CountryId { get; set; }

        /// <summary>
        /// Gets or sets the name of the Country.
        /// </summary>
        public string CountryName { get; set; }

        /// <summary>
        /// Gets or sets the currency of the country.
        /// </summary>
        public string CurrencyName { get; set; }

        /// <summary>
        /// Gets or sets the currency rate.
        /// </summary>
        public decimal CurrencyRate { get; set; }

        /// <summary>
        /// Gets or sets the country's date format.
        /// </summary>
        public string DateFormat { get; set; }

        /// <summary>
        /// Gets or sets the Regions of the Country.
        /// </summary>
        public List<Region> RegionList { get; set; }

        /// <summary>
        /// Gets or sets the country's time format.
        /// </summary>
        public string TimeFormat { get; set; }

        #endregion Public Properties
    }
}