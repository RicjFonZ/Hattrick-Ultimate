// -----------------------------------------------------------------------
// <copyright file="LeagueSchedule.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
// -----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessObjects.App
{
    using System;
    using Interface;

    /// <summary>
    /// Represents a League Schedule.
    /// </summary>
    public class LeagueSchedule : EntityBase, IEntity
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the Cup Match day of week.
        /// </summary>
        public byte CupMatchDayOfWeek { get; set; }

        /// <summary>
        /// Gets or sets the Cup Match time of day.
        /// </summary>
        public TimeSpan CupMatchTimeOfDay { get; set; }

        /// <summary>
        /// Gets or sets the Economy Update day of week.
        /// </summary>
        public byte EconomyUpdateDayOfWeek { get; set; }

        /// <summary>
        /// Gets or sets the Economy Update time of day.
        /// </summary>
        public TimeSpan EconomyUpdateTimeOfDay { get; set; }

        /// <summary>
        /// Gets or sets the League.
        /// </summary>
        public virtual League League { get; set; }

        /// <summary>
        /// Gets the League Id.
        /// </summary>
        public int? LeagueId
        {
            get
            {
                return this.League?.Id;
            }
        }

        /// <summary>
        /// Gets or sets the Series Match day of week.
        /// </summary>
        public byte SeriesMatchDayOfWeek { get; set; }

        /// <summary>
        /// Gets or sets the Series Match time of day.
        /// </summary>
        public TimeSpan SeriesMatchTimeOfDay { get; set; }

        /// <summary>
        /// Gets or sets the Training Update day of week.
        /// </summary>
        public byte TrainingUpdateDayOfWeek { get; set; }

        /// <summary>
        /// Gets or sets the Training Update time of day.
        /// </summary>
        public TimeSpan TrainingUpdateTimeOfDay { get; set; }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// Returns a System.String that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return this.GetType().FullName;
        }

        #endregion Public Methods
    }
}