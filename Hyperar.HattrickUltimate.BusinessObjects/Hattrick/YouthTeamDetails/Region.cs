//-----------------------------------------------------------------------
// <copyright file="Region.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessObjects.Hattrick.YouthTeamDetails
{
    /// <summary>
    /// Region node within YouthTeamDetails XML file.
    /// </summary>
    public class Region
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the Region ID.
        /// </summary>
        public long RegionId { get; set; }

        /// <summary>
        /// Gets or sets the Region Name.
        /// </summary>
        public string RegionName { get; set; }

        #endregion Public Properties
    }
}