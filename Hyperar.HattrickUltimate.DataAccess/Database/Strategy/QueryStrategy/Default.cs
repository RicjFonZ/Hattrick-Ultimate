//-----------------------------------------------------------------------
// <copyright file="Default.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.DataAccess.Database.Strategy.QueryStrategy
{
    using System.Linq;
    using BusinessObjects.App.Interface;
    using Interface;

    /// <summary>
    /// Default Query Strategy.
    /// </summary>
    /// <typeparam name="T">IEntity object.</typeparam>
    public class Default<T> : IQueryStrategy<T> where T : class, IEntity
    {
        #region Public Methods

        /// <summary>
        /// Applies the corresponding Includes depending on the class.
        /// </summary>
        /// <param name="query">Query to apply includes to.</param>
        /// <returns>Query with included child entities.</returns>
        public IQueryable<T> ApplyIncludes(IQueryable<T> query)
        {
            return query;
        }

        #endregion Public Methods
    }
}