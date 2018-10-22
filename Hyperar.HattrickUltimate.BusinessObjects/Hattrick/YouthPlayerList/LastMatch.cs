// -----------------------------------------------------------------------
// <copyright file="LastMatch.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
// -----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessObjects.Hattrick.YouthPlayerList
{
    using System;

    /// <summary>
    /// LastMatch node within Youth Player List XML file.
    /// </summary>
    public class LastMatch
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the date and time when the match took place.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets the minutes played on the last match.
        /// </summary>
        public byte PlayedMinutes { get; set; }

        /// <summary>
        /// Gets or sets the Position Code.
        /// </summary>
        public ushort PositionCode { get; set; }

        /// <summary>
        /// Gets or sets the player's average rating.
        /// </summary>
        public decimal Rating { get; set; }

        /// <summary>
        /// Gets or sets the Youth Match Id.
        /// </summary>
        public long YouthMatchId { get; set; }

        #endregion Public Properties
    }
}