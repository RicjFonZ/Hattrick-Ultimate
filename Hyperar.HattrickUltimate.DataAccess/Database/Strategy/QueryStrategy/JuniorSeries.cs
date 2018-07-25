//-----------------------------------------------------------------------
// <copyright file="JuniorSeries.cs" company="Hyperar">
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
    /// JuniorSeries Query Strategy.
    /// </summary>
    public class JuniorSeries : IQueryStrategy<BusinessObjects.App.JuniorSeries>
    {
        #region Public Methods

        /// <summary>
        /// Applies the corresponding Includes depending on the class.
        /// </summary>
        /// <param name="query">Query to apply includes to.</param>
        /// <returns>Query with included child entities.</returns>
        public IQueryable<BusinessObjects.App.JuniorSeries> ApplyIncludes(IQueryable<BusinessObjects.App.JuniorSeries> query)
        {
            return query.Include(p => p.JuniorTeams);
        }

        #endregion Public Methods
    }
}