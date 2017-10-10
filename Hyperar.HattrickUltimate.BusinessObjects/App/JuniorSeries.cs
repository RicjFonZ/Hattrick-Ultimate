// -----------------------------------------------------------------------
// <copyright file="JuniorSeries.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
// -----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessObjects.App
{
    using System.Collections.Generic;
    using Interface;

    /// <summary>
    /// Represents a Junior Series.
    /// </summary>
    public class JuniorSeries : HattrickEntityBase, IEntity, IHattrickEntity
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the Junior Teams.
        /// </summary>
        public virtual ICollection<JuniorTeam> JuniorTeams { get; set; } = new HashSet<JuniorTeam>();

        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        public string Name { get; set; }

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