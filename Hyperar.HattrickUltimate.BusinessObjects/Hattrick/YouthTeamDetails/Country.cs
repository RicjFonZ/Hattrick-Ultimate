//-----------------------------------------------------------------------
// <copyright file="Country.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessObjects.Hattrick.YouthTeamDetails
{
    /// <summary>
    /// Country node within YouthTeamDetails XML file.
    /// </summary>
    public class Country
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the Country ID.
        /// </summary>
        public long CountryId { get; set; }

        /// <summary>
        /// Gets or sets the Country Name.
        /// </summary>
        public string CountryName { get; set; }

        #endregion Public Properties
    }
}