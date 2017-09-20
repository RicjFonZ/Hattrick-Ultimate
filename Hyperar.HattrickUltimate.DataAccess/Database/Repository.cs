//-----------------------------------------------------------------------
// <copyright file="Repository.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.DataAccess.Database
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using BusinessObjects.App.Interface;
    using Interface;

    /// <summary>
    /// IEntity class Repository implementation.
    /// </summary>
    /// <typeparam name="TEntity">IEntity class.</typeparam>
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        #region Private Fields

        /// <summary>
        /// Database context.
        /// </summary>
        private IDatabaseContext context;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository{TEntity}"/> class.
        /// </summary>
        /// <param name="context">App Database Context.</param>
        public Repository(IDatabaseContext context)
        {
            this.context = context;
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// Deletes the object with the specified ID.
        /// </summary>
        /// <param name="id">ID of the object to delete.</param>
        public void Delete(int id)
        {
            TEntity entity = this.Get(id);

            if (entity == null)
            {
                var type = typeof(TEntity);

                throw new Exception($"No entity of type: '{type}' with ID: '{id}' found.");
            }

            this.context.CreateSet<TEntity>().Remove(entity);
        }

        /// <summary>
        /// Gets the object with the specified ID, if any.
        /// </summary>
        /// <param name="id">ID of the desired object.</param>
        /// <returns>Entity with the specified ID, if any.</returns>
        public TEntity Get(int id)
        {
            return this.context.CreateSet<TEntity>()
                       .Where(e => e.Id == id)
                       .SingleOrDefault();
        }

        /// <summary>
        /// Gets an IQueryable object with the entities that satisfy the specified predicate.
        /// </summary>
        /// <param name="predicate">Query filters.</param>
        /// <returns>IQueryable object with the entities that satisfy the specified predicate.</returns>
        public IQueryable<TEntity> Get(Func<TEntity, bool> predicate = null)
        {
            IQueryable<TEntity> query = this.context.CreateSet<TEntity>();

            if (predicate != null)
            {
                query = query.Where(predicate).AsQueryable();
            }

            return query;
        }

        /// <summary>
        /// Inserts the specified entity on the database.
        /// </summary>
        /// <param name="entity">Entity to insert.</param>
        public void Insert(TEntity entity)
        {
            this.context.CreateSet<TEntity>().Add(entity);
        }

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">Entity to update.</param>
        public void Update(TEntity entity)
        {
            this.context.CreateSet<TEntity>().AddOrUpdate(entity);
        }

        #endregion Public Methods
    }
}