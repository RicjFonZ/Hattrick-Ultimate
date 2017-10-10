// -----------------------------------------------------------------------
// <copyright file="PressAnnouncement.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
// -----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessObjects.Hattrick.TeamDetails
{
    using System;

    /// <summary>
    /// PressAnnouncement node within TeamDetails XML file.
    /// </summary>
    public class PressAnnouncement
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the body of the press announcement.
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// Gets or sets the date of the press announcement.
        /// </summary>
        public DateTime SendDate { get; set; }

        /// <summary>
        /// Gets or sets the subject of the press announcement.
        /// </summary>
        public string Subject { get; set; }

        #endregion Public Properties
    }
}