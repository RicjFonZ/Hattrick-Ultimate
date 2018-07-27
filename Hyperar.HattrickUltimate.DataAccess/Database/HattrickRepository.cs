//-----------------------------------------------------------------------
// <copyright file="HattrickRepository.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.DataAccess.Database
{
    using System.Linq;
    using BusinessObjects.App.Interface;
    using Interface;

    /// <summary>
    /// IHattrickEntity class Repository implementation.
    /// </summary>
    /// <typeparam name="TEntity">IHattrickEntity class.</typeparam>
    public class HattrickRepository<TEntity> : Repository<TEntity>, IHattrickRepository<TEntity> where TEntity : class, IEntity, IHattrickEntity
    {
        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="HattrickRepository{TEntity}"/> class.
        /// </summary>
        /// <param name="context">App Database Context.</param>
        /// <param name="queryStrategy">Query Strategy.</param>
        public HattrickRepository(IDatabaseContext context, IQueryStrategy<TEntity> queryStrategy) : base(context, queryStrategy)
        {
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// Gets the object with the specified Hattrick ID, if any.
        /// </summary>
        /// <param name="hattrickId">Hattrick ID of the desired object.</param>
        /// <returns>Entity with the specified Hattrick ID, if any.</returns>
        public TEntity GetByHattrickId(long hattrickId)
        {
            return this.EntityCollection.SingleOrDefault(e => e.HattrickId == hattrickId);
        }

        #endregion Public Methods
    }
}