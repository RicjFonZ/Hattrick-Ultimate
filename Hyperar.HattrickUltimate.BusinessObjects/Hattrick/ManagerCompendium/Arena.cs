// -----------------------------------------------------------------------
// <copyright file="Arena.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
// -----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessObjects.Hattrick.ManagerCompendium
{
    /// <summary>
    /// Arena node within ManagerCompendium XML file.
    /// </summary>
    public class Arena
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the ID.
        /// </summary>
        public long ArenaId { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string ArenaName { get; set; }

        #endregion Public Properties
    }
}