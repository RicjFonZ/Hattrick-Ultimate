// -----------------------------------------------------------------------
// <copyright file="Currency.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
// -----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessObjects.App
{
    using System.Collections.Generic;
    using Interface;

    /// <summary>
    /// Represents a Currency.
    /// </summary>
    public class Currency : EntityBase, IEntity
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the Countries that use the Currency.
        /// </summary>
        public virtual ICollection<Country> Countries { get; set; } = new HashSet<Country>();

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the exchange rate relative to the Swedish Kroner.
        /// </summary>
        public decimal Rate { get; set; }

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