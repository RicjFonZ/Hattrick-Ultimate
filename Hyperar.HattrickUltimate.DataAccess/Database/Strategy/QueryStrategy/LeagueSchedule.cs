//-----------------------------------------------------------------------
// <copyright file="LeagueSchedule.cs" company="Hyperar">
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
    /// LeagueSchedule Query Strategy.
    /// </summary>
    public class LeagueSchedule : IQueryStrategy<BusinessObjects.App.LeagueSchedule>
    {
        #region Public Methods

        /// <summary>
        /// Applies the corresponding Includes depending on the class.
        /// </summary>
        /// <param name="query">Query to apply includes to.</param>
        /// <returns>Query with included child entities.</returns>
        public IQueryable<BusinessObjects.App.LeagueSchedule> ApplyIncludes(IQueryable<BusinessObjects.App.LeagueSchedule> query)
        {
            return query.Include(p => p.League);
        }

        #endregion Public Methods
    }
}