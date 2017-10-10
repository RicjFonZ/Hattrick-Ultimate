// -----------------------------------------------------------------------
// <copyright file="SeniorTeam.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
// -----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessObjects.App
{
    using System;
    using Interface;

    /// <summary>
    /// Represents a Senior Team.
    /// </summary>
    public class SeniorTeam : HattrickEntityBase, IEntity, IHattrickEntity
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the date and time when the team was established.
        /// </summary>
        public DateTime EstablishedOn { get; set; }

        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the Team is the manager's primary team or not.
        /// </summary>
        public bool IsPrimary { get; set; }

        /// <summary>
        /// Gets or sets the Junior Team.
        /// </summary>
        public virtual JuniorTeam JuniorTeam { get; set; }

        /// <summary>
        /// Gets or sets the rank of the team within the league.
        /// </summary>
        public int LeagueRank { get; set; }

        /// <summary>
        /// Gets or sets the Manager.
        /// </summary>
        public virtual Manager Manager { get; set; }

        /// <summary>
        /// Gets or sets the Manager Id.
        /// </summary>
        public int ManagerId { get; set; }

        /// <summary>
        /// Gets or sets the Region.
        /// </summary>
        public virtual Region Region { get; set; }

        /// <summary>
        /// Gets or sets the Region Id.
        /// </summary>
        public int RegionId { get; set; }

        /// <summary>
        /// Gets or sets the Arena.
        /// </summary>
        public virtual SeniorArena SeniorArena { get; set; }

        /// <summary>
        /// Gets or sets the Series.
        /// </summary>
        public virtual SeniorSeries SeniorSeries { get; set; }

        /// <summary>
        /// Gets or sets the Series Id.
        /// </summary>
        public int SeniorSeriesId { get; set; }

        /// <summary>
        /// Gets or sets the Short Name.
        /// </summary>
        public string ShortName { get; set; }

        /// <summary>
        /// Gets or sets the number of official undefeated matches in a row.
        /// </summary>
        public int UndefeatedInRow { get; set; }

        /// <summary>
        /// Gets or sets the number of official won matches in a row.
        /// </summary>
        public int WinsInRow { get; set; }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// Returns a System.String that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return $"{this.FullName} ({this.HattrickId})";
        }

        #endregion Public Methods
    }
}