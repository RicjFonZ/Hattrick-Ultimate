//-----------------------------------------------------------------------
// <copyright file="IReadOnlyRepository.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.DataAccess.Database.Interface
{
    using System;
    using System.Linq;
    using BusinessObjects.App.Interface;

    /// <summary>
    /// Generic entity read-only repository definition.
    /// </summary>
    /// <typeparam name="TEntity">IEntity class.</typeparam>
    public interface IReadOnlyRepository<TEntity> where TEntity : class, IEntity
    {
        #region Public Methods

        /// <summary>
        /// Gets the object with the specified ID, if any.
        /// </summary>
        /// <param name="id">ID of the desired object.</param>
        /// <returns>Entity with the specified ID, if any.</returns>
        TEntity GetById(int id);

        /// <summary>
        /// Gets an IQueryable object with the entities that satisfy the specified predicate.
        /// </summary>
        /// <param name="predicate">Query filters.</param>
        /// <returns>IQueryable object with the entities that satisfy the specified predicate.</returns>
        IQueryable<TEntity> Query(Func<TEntity, bool> predicate = null);

        #endregion Public Methods
    }
}