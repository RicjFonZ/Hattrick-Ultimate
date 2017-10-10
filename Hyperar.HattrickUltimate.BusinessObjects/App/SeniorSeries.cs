// -----------------------------------------------------------------------
// <copyright file="SeniorSeries.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
// -----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessObjects.App
{
    using System.Collections.Generic;
    using Interface;

    /// <summary>
    /// Represents a Senior Series.
    /// </summary>
    public class SeniorSeries : HattrickEntityBase, IEntity, IHattrickEntity
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the Division.
        /// </summary>
        public byte Division { get; set; }

        /// <summary>
        /// Gets or sets the League.
        /// </summary>
        public virtual League League { get; set; }

        /// <summary>
        /// Gets or sets the League Id.
        /// </summary>
        public int LeagueId { get; set; }

        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Senior Teams.
        /// </summary>
        public virtual ICollection<SeniorTeam> SeniorTeams { get; set; } = new HashSet<SeniorTeam>();

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// Returns a System.String that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return $"{this.Name} ({this.HattrickId})";
        }

        #endregion Public Methods
    }
}