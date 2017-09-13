// -----------------------------------------------------------------------
// <copyright file="EntityBase.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
// -----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessObjects.App
{
    using Interface;

    /// <summary>
    /// Entity base class.
    /// </summary>
    public abstract class EntityBase : IEntity
    {
        #region Properties

        /// <summary>
        /// Gets or sets the ID.
        /// </summary>
        public int Id { get; set; }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Returns a System.String that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public abstract override string ToString();

        #endregion Methods
    }
}