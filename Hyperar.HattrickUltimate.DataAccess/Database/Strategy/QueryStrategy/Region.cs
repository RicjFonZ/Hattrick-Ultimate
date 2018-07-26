//-----------------------------------------------------------------------
// <copyright file="Region.cs" company="Hyperar">
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
    /// Region Query Strategy.
    /// </summary>
    public class Region : IQueryStrategy<BusinessObjects.App.Region>
    {
        #region Public Methods

        /// <summary>
        /// Applies the corresponding Includes depending on the class.
        /// </summary>
        /// <param name="query">Query to apply includes to.</param>
        /// <returns>Query with included child entities.</returns>
        public IQueryable<BusinessObjects.App.Region> ApplyIncludes(IQueryable<BusinessObjects.App.Region> query)
        {
            return query.Include(p => p.Country)
                        .Include(p => p.SeniorTeams);
        }

        #endregion Public Methods
    }
}