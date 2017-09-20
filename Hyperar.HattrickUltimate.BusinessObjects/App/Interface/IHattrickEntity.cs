//-----------------------------------------------------------------------
// <copyright file="IHattrickEntity.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessObjects.App.Interface
{
    /// <summary>
    /// Hattrick ID entity definition.
    /// </summary>
    public interface IHattrickEntity
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the Hattrick ID.
        /// </summary>
        long HattrickId { get; set; }

        #endregion Public Properties
    }
}