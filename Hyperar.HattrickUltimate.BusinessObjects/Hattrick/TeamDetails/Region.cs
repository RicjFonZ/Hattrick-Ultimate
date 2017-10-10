// -----------------------------------------------------------------------
// <copyright file="Region.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
// -----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessObjects.Hattrick.TeamDetails
{
    /// <summary>
    /// Region node within TeamDetails XML file.
    /// </summary>
    public class Region
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the Region ID.
        /// </summary>
        public uint RegionId { get; set; }

        /// <summary>
        /// Gets or sets the name of the Region.
        /// </summary>
        public string RegionName { get; set; }

        #endregion Public Properties
    }
}