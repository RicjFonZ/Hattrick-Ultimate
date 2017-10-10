// -----------------------------------------------------------------------
// <copyright file="BotStatus.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
// -----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessObjects.Hattrick.TeamDetails
{
    using System;

    /// <summary>
    /// BotStatus node within TeamDetails XML file.
    /// </summary>
    public class BotStatus
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the date and time when the team became bot.
        /// </summary>
        public DateTime BotSince { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the team is bot or not.
        /// </summary>
        public bool IsBot { get; set; }

        #endregion Public Properties
    }
}