// -----------------------------------------------------------------------
// <copyright file="Flags.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
// -----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessObjects.Hattrick.TeamDetails
{
    using System.Collections.Generic;

    /// <summary>
    /// Flags node within TeamDetails XML file.
    /// </summary>
    public class Flags
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the Away Flags.
        /// </summary>
        public List<Flag> AwayFlags { get; set; }

        /// <summary>
        /// Gets or sets the Home Flags.
        /// </summary>
        public List<Flag> HomeFlags { get; set; }

        #endregion Public Properties
    }
}