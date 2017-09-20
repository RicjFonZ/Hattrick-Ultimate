// -----------------------------------------------------------------------
// <copyright file="LeagueLevelUnit.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
// -----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessObjects.Hattrick.ManagerCompendium
{
    /// <summary>
    /// LeagueLevelUnit node within ManagerCompendium XML file.
    /// </summary>
    public class LeagueLevelUnit
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the ID.
        /// </summary>
        public uint LeagueLevelUnitId { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string LeagueLevelUnitName { get; set; }

        #endregion Public Properties
    }
}