//-----------------------------------------------------------------------
// <copyright file="Country.cs" company="Hyperar">
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
    /// Country Query Strategy.
    /// </summary>
    public class Country : IQueryStrategy<BusinessObjects.App.Country>
    {
        #region Public Methods

        /// <summary>
        /// Applies the corresponding Includes depending on the class.
        /// </summary>
        /// <param name="query">Query to apply includes to.</param>
        /// <returns>Query with included child entities.</returns>
        public IQueryable<BusinessObjects.App.Country> ApplyIncludes(IQueryable<BusinessObjects.App.Country> query)
        {
            return query.Include(p => p.Currency)
                        .Include(p => p.DateFormat)
                        .Include(p => p.League)
                        .Include(p => p.Managers)
                        .Include(p => p.Regions)
                        .Include(p => p.SeniorPlayers)
                        .Include(p => p.TimeFormat);
        }

        #endregion Public Methods
    }
}