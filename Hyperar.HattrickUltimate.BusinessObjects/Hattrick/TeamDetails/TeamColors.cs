// -----------------------------------------------------------------------
// <copyright file="TeamColors.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
// -----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessObjects.Hattrick.TeamDetails
{
    /// <summary>
    /// TeamColors node within TeamDetails XML file.
    /// </summary>
    public class TeamColors
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the background color.
        /// </summary>
        public string BacgroundColor { get; set; }

        /// <summary>
        /// Gets or sets the color.
        /// </summary>
        public string Color { get; set; }

        #endregion Public Properties
    }
}