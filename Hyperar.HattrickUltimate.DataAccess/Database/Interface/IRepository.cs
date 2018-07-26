//-----------------------------------------------------------------------
// <copyright file="IRepository.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.DataAccess.Database.Interface
{
    using BusinessObjects.App.Interface;

    /// <summary>
    /// Entity repository definition.
    /// </summary>
    /// <typeparam name="TEntity">IEntity class.</typeparam>
    public interface IRepository<TEntity> : IRepositoryBase<TEntity> where TEntity : class, IEntity
    {
        #region Public Methods

        /// <summary>
        /// Deletes the object with the specified ID.
        /// </summary>
        /// <param name="id">ID of the object to delete.</param>
        void Delete(int id);

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

        #endregion Public Methods
    }
}