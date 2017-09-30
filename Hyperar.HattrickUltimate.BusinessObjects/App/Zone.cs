// -----------------------------------------------------------------------
// <copyright file="Zone.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
// -----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessObjects.App
{
    using System.Collections.Generic;
    using Interface;

    /// <summary>
    /// Represents a Geographical Zone.
    /// </summary>
    public class Zone : EntityBase, IEntity
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the Leagues.
        /// </summary>
        public virtual ICollection<League> Leagues { get; set; } = new HashSet<League>();

        /// <summary>
        /// Gets or sets the name.
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
            return $"{this.Name} ({this.Id})";
        }

        #endregion Public Methods
    }
}