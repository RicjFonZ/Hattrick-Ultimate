﻿//-----------------------------------------------------------------------
// <copyright file="IRepository.cs" company="Hyperar">
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
    /// Generic entity repository definition.
    /// </summary>
    /// <typeparam name="TEntity">IEntity class.</typeparam>
    public interface IRepository<TEntity> where TEntity : class, IEntity
    {
        #region Methods

        /// <summary>
        /// Deletes the object with the specified ID.
        /// </summary>
        /// <param name="id">ID of the object to delete.</param>
        void Delete(int id);

        /// <summary>
        /// Gets an IQueryable object with the entities that satisfy the specified predicate.
        /// </summary>
        /// <param name="predicate">Query filters.</param>
        /// <returns>IQueryable object with the entities that satisfy the specified predicate.</returns>
        IQueryable<TEntity> Get(Func<TEntity, bool> predicate = null);

        /// <summary>
        /// Gets the object with the specified ID, if any.
        /// </summary>
        /// <param name="id">ID of the desired object.</param>
        /// <returns>Entity with the specified ID, if any.</returns>
        TEntity Get(int id);

        /// <summary>
        /// Inserts the specified entity on the database.
        /// </summary>
        /// <param name="entity">Entity to insert.</param>
        void Insert(TEntity entity);

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">Entity to update.</param>
        void Update(TEntity entity);

        #endregion Methods
    }
}