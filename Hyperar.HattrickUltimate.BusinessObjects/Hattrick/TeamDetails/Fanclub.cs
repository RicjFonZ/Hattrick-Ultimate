// -----------------------------------------------------------------------
// <copyright file="Fanclub.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
// -----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessObjects.Hattrick.TeamDetails
{
    /// <summary>
    /// Fanclub node within TeamDetails XML file.
    /// </summary>
    public class Fanclub
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the Fan club Id.
        /// </summary>
        public long FanclubId { get; set; }

        /// <summary>
        /// Gets or sets the Fan club name.
        /// </summary>
        public string FanclubName { get; set; }

        /// <summary>
        /// Gets or sets the Fan club size.
        /// </summary>
        public long FanclubSize { get; set; }

        #endregion Public Properties
    }
}