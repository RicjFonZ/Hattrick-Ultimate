// -----------------------------------------------------------------------
// <copyright file="Region.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
// -----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessObjects.App
{
    using System.Collections.Generic;
    using Interface;

    /// <summary>
    /// Represents a Region.
    /// </summary>
    public class Region : HattrickEntityBase, IEntity, IHattrickEntity
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the Country.
        /// </summary>
        public virtual Country Country { get; set; }

        /// <summary>
        /// Gets or sets the Country ID.
        /// </summary>
        public int CountryId { get; set; }

        /// <summary>
        /// Gets or sets the name.
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