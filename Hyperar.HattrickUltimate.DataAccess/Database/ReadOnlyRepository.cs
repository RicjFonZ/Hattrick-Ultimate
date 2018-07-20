//-----------------------------------------------------------------------
// <copyright file="ReadOnlyRepository.cs" company="Hyperar">
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
    /// IEntity class ReadOnlyRepository implementation.
    /// </summary>
    /// <typeparam name="TEntity">IEntity class.</typeparam>
    public class ReadOnlyRepository<TEntity> : IReadOnlyRepository<TEntity> where TEntity : class, IEntity
    {
        #region Private Fields

        /// <summary>
        /// Database context.
        /// </summary>
        private IDatabaseContext context;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ReadOnlyRepository{TEntity}"/> class.
        /// </summary>
        /// <param name="context">App Database Context.</param>
        public ReadOnlyRepository(IDatabaseContext context)
        {
            this.context = context;
            this.EntityCollection = this.context.CreateSet<TEntity>();
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
            IQueryable<TEntity> query = this.EntityCollection.AsQueryable();

            if (predicate != null)
            {
                query = query.Where(predicate).AsQueryable();
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