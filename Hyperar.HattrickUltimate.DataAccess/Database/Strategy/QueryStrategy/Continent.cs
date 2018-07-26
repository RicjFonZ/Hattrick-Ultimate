//-----------------------------------------------------------------------
// <copyright file="Continent.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.DataAccess.Database.Strategy.QueryStrategy
{
    using System.Data.Entity;
    using System.Linq;
    using Interface;

    /// <summary>
    /// Continent Query Strategy.
    /// </summary>
    public class Continent : IQueryStrategy<BusinessObjects.App.Continent>
    {
        #region Public Methods

        /// <summary>
        /// Applies the corresponding Includes depending on the class.
        /// </summary>
        /// <param name="query">Query to apply includes to.</param>
        /// <returns>Query with included child entities.</returns>
        public IQueryable<BusinessObjects.App.Continent> ApplyIncludes(IQueryable<BusinessObjects.App.Continent> query)
        {
            return query.Include(p => p.Leagues);
        }

        #endregion Public Methods
    }
}