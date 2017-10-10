// -----------------------------------------------------------------------
// <copyright file="LeagueLevelUnit.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
// -----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessObjects.Hattrick.TeamDetails
{
    /// <summary>
    /// LeagueLevelUnit node within TeamDetails XML file.
    /// </summary>
    public class LeagueLevelUnit
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the League level unit Id.
        /// </summary>
        public long LeagueLevelUnitId { get; set; }

        /// <summary>
        /// Gets or sets the League level unit level.
        /// </summary>
        public byte LeagueLevelUnitLevel { get; set; }

        /// <summary>
        /// Gets or sets the League level unit name.
        /// </summary>
        public string LeagueLevelUnitName { get; set; }

        #endregion Public Properties
    }
}