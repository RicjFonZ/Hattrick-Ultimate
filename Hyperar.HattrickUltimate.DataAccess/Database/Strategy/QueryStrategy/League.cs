//-----------------------------------------------------------------------
// <copyright file="League.cs" company="Hyperar">
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
    /// League Query Strategy.
    /// </summary>
    public class League : IQueryStrategy<BusinessObjects.App.League>
    {
        #region Public Methods

        /// <summary>
        /// Applies the corresponding Includes depending on the class.
        /// </summary>
        /// <param name="query">Query to apply includes to.</param>
        /// <returns>Query with included child entities.</returns>
        public IQueryable<BusinessObjects.App.League> ApplyIncludes(IQueryable<BusinessObjects.App.League> query)
        {
            return query.Include(p => p.Continent)
                        .Include(p => p.Country)
                        .Include(p => p.Cups)
                        .Include(p => p.Schedule)
                        .Include(p => p.SeniorSeries)
                        .Include(p => p.Zone);
        }

        #endregion Public Methods
    }
}