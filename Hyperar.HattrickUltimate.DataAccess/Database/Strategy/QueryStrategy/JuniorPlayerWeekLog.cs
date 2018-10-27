//-----------------------------------------------------------------------
// <copyright file="JuniorPlayerWeekLog.cs" company="Hyperar">
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
    /// JuniorPlayerWeekLog Query Strategy.
    /// </summary>
    public class JuniorPlayerWeekLog : IQueryStrategy<BusinessObjects.App.JuniorPlayerWeekLog>
    {
        #region Public Methods

        /// <summary>
        /// Applies the corresponding Includes depending on the class.
        /// </summary>
        /// <param name="query">Query to apply includes to.</param>
        /// <returns>Query with included child entities.</returns>
        public IQueryable<BusinessObjects.App.JuniorPlayerWeekLog> ApplyIncludes(IQueryable<BusinessObjects.App.JuniorPlayerWeekLog> query)
        {
            return query.Include(p => p.JuniorPlayer);
        }

        #endregion Public Methods
    }
}