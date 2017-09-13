//-----------------------------------------------------------------------
// <copyright file="HattrickEntityBase.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessObjects.App
{
    using Interface;

    /// <summary>
    /// Hattrick entity base class.
    /// </summary>
    public abstract class HattrickEntityBase : EntityBase, IEntity, IHattrickEntity
    {
        /// <summary>
        /// Gets or sets the Hattrick Id.
        /// </summary>
        public long HattrickId { get; set; }
    }
}