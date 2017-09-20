//-----------------------------------------------------------------------
// <copyright file="IEntity.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessObjects.App.Interface
{
    /// <summary>
    /// Entity base definition.
    /// </summary>
    public interface IEntity
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the ID.
        /// </summary>
        int Id { get; set; }

        #endregion Public Properties
    }
}