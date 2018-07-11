//-----------------------------------------------------------------------
// <copyright file="Travel.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessObjects.Hattrick.YouthTeamDetails
{
    using System;

    /// <summary>
    /// Travel node within YouthTeamDetails XML file.
    /// </summary>
    public class Travel
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the length of the travel in kilometers.
        /// </summary>
        public int TravelLength { get; set; }

        /// <summary>
        /// Gets or sets the date when the travel started.
        /// </summary>
        public DateTime TravelStartDate { get; set; }

        /// <summary>
        /// Gets or sets the type of the travel.
        /// </summary>
        /// <remarks>
        /// Plane = 1.
        /// Car = 2.
        /// </remarks>
        public byte TravelType { get; set; }

        #endregion Public Properties
    }
}