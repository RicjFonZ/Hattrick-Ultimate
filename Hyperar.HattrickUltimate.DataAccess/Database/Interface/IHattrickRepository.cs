//-----------------------------------------------------------------------
// <copyright file="IHattrickRepository.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.DataAccess.Database.Interface
{
    using BusinessObjects.App.Interface;

    /// <summary>
    /// Generic Hattrick entity repository definition.
    /// </summary>
    /// <typeparam name="TEntity">IHattrickEntity class.</typeparam>
    public interface IHattrickRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity, IHattrickEntity
    {
        #region Public Methods

        /// <summary>
        /// Gets the object with the specified Hattrick ID, if any.
        /// </summary>
        /// <param name="hattrickId">Hattrick ID of the desired object.</param>
        /// <returns>Entity with the specified Hattrick ID, if any.</returns>
        TEntity GetByHattrickId(long hattrickId);

        #endregion Public Methods
    }
}