//-----------------------------------------------------------------------
// <copyright file="IQueryStrategy.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.DataAccess.Database.Interface
{
    using System.Linq;
    using BusinessObjects.App.Interface;

    /// <summary>
    /// Query strategy contract.
    /// </summary>
    /// <typeparam name="T">IEntity object.</typeparam>
    public interface IQueryStrategy<T> where T : class, IEntity
    {
        #region Public Methods

        /// <summary>
        /// Applies the corresponding Includes depending on the class.
        /// </summary>
        /// <param name="query">Query to apply includes to.</param>
        /// <returns>Query with included child entities.</returns>
        IQueryable<T> ApplyIncludes(IQueryable<T> query);

        #endregion Public Methods
    }
}