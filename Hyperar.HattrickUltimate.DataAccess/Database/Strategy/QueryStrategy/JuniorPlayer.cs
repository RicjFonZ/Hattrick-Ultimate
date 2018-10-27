//-----------------------------------------------------------------------
// <copyright file="JuniorPlayer.cs" company="Hyperar">
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
    /// JuniorPlayer Query Strategy.
    /// </summary>
    public class JuniorPlayer : IQueryStrategy<BusinessObjects.App.JuniorPlayer>
    {
        #region Public Methods

        /// <summary>
        /// Applies the corresponding Includes depending on the class.
        /// </summary>
        /// <param name="query">Query to apply includes to.</param>
        /// <returns>Query with included child entities.</returns>
        public IQueryable<BusinessObjects.App.JuniorPlayer> ApplyIncludes(IQueryable<BusinessObjects.App.JuniorPlayer> query)
        {
            return query.Include(p => p.Avatar)
                        .Include(p => p.JuniorTeam)
                        .Include(p => p.WeekLogs);
        }

        #endregion Public Methods
    }
}