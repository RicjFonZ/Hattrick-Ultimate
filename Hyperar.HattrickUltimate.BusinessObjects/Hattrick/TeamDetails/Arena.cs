// -----------------------------------------------------------------------
// <copyright file="Arena.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
// -----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessObjects.Hattrick.TeamDetails
{
    /// <summary>
    /// Arena node within TeamDetails XML file.
    /// </summary>
    public class Arena
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the Arena ID.
        /// </summary>
        public uint ArenaId { get; set; }

        /// <summary>
        /// Gets or sets the name of the Arena.
        /// </summary>
        public string ArenaName { get; set; }

        #endregion Public Properties
    }
}