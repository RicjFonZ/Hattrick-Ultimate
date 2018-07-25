//-----------------------------------------------------------------------
// <copyright file="Repository.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.DataAccess.Database
{
    using System;
    using System.Data.Entity;
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

        /// <summary>
        /// Query strategy.
        /// </summary>
        private IQueryStrategy<TEntity> queryStrategy;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository{TEntity}"/> class.
        /// </summary>
        /// <param name="context">App Database Context.</param>
        /// <param name="queryStrategy">Query strategy.</param>
        public Repository(IDatabaseContext context, IQueryStrategy<TEntity> queryStrategy)
        {
            this.context = context;
            this.EntityCollection = this.context.CreateSet<TEntity>();
            this.queryStrategy = queryStrategy;
        }

        #endregion Public Constructors

        #region Protected Properties

        /// <summary>
        /// Gets the entity collection.
        /// </summary>
        protected IDbSet<TEntity> EntityCollection { get; private set; }

        #endregion Protected Properties

        #region Public Methods

        /// <summary>
        /// Deletes the object with the specified ID.
        /// </summary>
        /// <param name="id">ID of the object to delete.</param>
        public void Delete(int id)
        {
            TEntity entity = this.GetById(id);

            if (entity == null)
            {
                var type = typeof(TEntity);

                throw new Exception(
                          string.Format(
                                     Localization.Messages.EntityIdNotFound,
                                     type.ToString(),
                                     id));
            }

            this.context.CreateSet<TEntity>().Remove(entity);
        }

        /// <summary>
        /// Gets the object with the specified ID, if any.
        /// </summary>
        /// <param name="id">ID of the desired object.</param>
        /// <returns>Entity with the specified ID, if any.</returns>
        public TEntity GetById(int id)
        {
            return this.EntityCollection
                       .Where(e => e.Id == id)
                       .SingleOrDefault();
        }

        /// <summary>
        /// Inserts the specified entity on the database.
        /// </summary>
        /// <param name="entity">Entity to insert.</param>
        public void Insert(TEntity entity)
        {
            this.EntityCollection.Add(entity);
        }

        /// <summary>
        /// Gets an IQueryable object with the entities that satisfy the specified predicate.
        /// </summary>
        /// <param name="predicate">Query filters.</param>
        /// <returns>IQueryable object with the entities that satisfy the specified predicate.</returns>
        public IQueryable<TEntity> Query(Func<TEntity, bool> predicate = null)
        {
            IQueryable<TEntity> query = this.queryStrategy.ApplyIncludes(
                                                               this.EntityCollection.AsQueryable());

            if (predicate != null)
            {
                query = query.Where(predicate)
                             .AsQueryable();
            }

            return query;
        }

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">Entity to update.</param>
        public void Update(TEntity entity)
        {
            this.EntityCollection.AddOrUpdate(entity);
        }

        #endregion Public Methods
    }
}