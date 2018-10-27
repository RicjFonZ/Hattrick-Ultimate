//-----------------------------------------------------------------------
// <copyright file="SeniorPlayerWeekLog.cs" company="Hyperar">
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
    /// SeniorPlayerWeekLog Query Strategy.
    /// </summary>
    public class SeniorPlayerWeekLog : IQueryStrategy<BusinessObjects.App.SeniorPlayerWeekLog>
    {
        #region Public Methods

        /// <summary>
        /// Applies the corresponding Includes depending on the class.
        /// </summary>
        /// <param name="query">Query to apply includes to.</param>
        /// <returns>Query with included child entities.</returns>
        public IQueryable<BusinessObjects.App.SeniorPlayerWeekLog> ApplyIncludes(IQueryable<BusinessObjects.App.SeniorPlayerWeekLog> query)
        {
            return query.Include(p => p.SeniorPlayer);
        }

        #endregion Public Methods
    }
}