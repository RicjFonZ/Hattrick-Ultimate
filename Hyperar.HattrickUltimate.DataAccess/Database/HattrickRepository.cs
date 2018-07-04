//-----------------------------------------------------------------------
// <copyright file="HattrickRepository.cs" company="Accenture">
//     Copyright (c) Accenture. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.DataAccess.Database
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using BusinessObjects.App.Interface;
    using Interface;

    /// <summary>
    /// IHattrickEntity class Repository implementation.
    /// </summary>
    /// <typeparam name="TEntity">IHattrickEntity class.</typeparam>
    public class HattrickRepository<TEntity> : Repository<TEntity>, IHattrickRepository<TEntity> where TEntity : class, IEntity, IHattrickEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HattrickRepository{TEntity}"/> class.
        /// </summary>
        /// <param name="context">App Database Context.</param>
        public HattrickRepository(IDatabaseContext context) : base(context)
        {
        }

        /// <summary>
        /// Gets the object with the specified Hattrick ID, if any.
        /// </summary>
        /// <param name="hattrickId">Hattrick ID of the desired object.</param>
        /// <returns>Entity with the specified Hattrick ID, if any.</returns>
        public TEntity GetByHattrickId(long hattrickId)
        {
            return this.EntityCollection.SingleOrDefault(e => e.HattrickId == hattrickId);
        }
    }
}