//-----------------------------------------------------------------------
// <copyright file="IReadOnlyRepository.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.DataAccess.Database.Interface
{
    using BusinessObjects.App.Interface;

    /// <summary>
    /// Generic entity read-only repository definition.
    /// </summary>
    /// <typeparam name="TEntity">IEntity class.</typeparam>
    public interface IReadOnlyRepository<TEntity> : IRepositoryBase<TEntity> where TEntity : class, IEntity
    {
    }
}