//-----------------------------------------------------------------------
// <copyright file="SeniorSeries.cs" company="Hyperar">
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
    /// SeniorSeries Query Strategy.
    /// </summary>
    public class SeniorSeries : IQueryStrategy<BusinessObjects.App.SeniorSeries>
    {
        #region Public Methods

        /// <summary>
        /// Applies the corresponding Includes depending on the class.
        /// </summary>
        /// <param name="query">Query to apply includes to.</param>
        /// <returns>Query with included child entities.</returns>
        public IQueryable<BusinessObjects.App.SeniorSeries> ApplyIncludes(IQueryable<BusinessObjects.App.SeniorSeries> query)
        {
            return query.Include(p => p.League)
                        .Include(p => p.SeniorTeams);
        }

        #endregion Public Methods
    }
}