// -----------------------------------------------------------------------
// <copyright file="DateFormat.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
// -----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessObjects.App
{
    using System.Collections.Generic;
    using Interface;

    /// <summary>
    /// Represents a Date Format.
    /// </summary>
    public class DateFormat : EntityBase, IEntity
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the Countries that use the Date Format.
        /// </summary>
        public virtual ICollection<Country> Countries { get; set; } = new HashSet<Country>();

        /// <summary>
        /// Gets or sets the mask.
        /// </summary>
        public string Mask { get; set; }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// Returns a System.String that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return $"{this.Mask} ({this.Id})";
        }

        #endregion Public Methods
    }
}