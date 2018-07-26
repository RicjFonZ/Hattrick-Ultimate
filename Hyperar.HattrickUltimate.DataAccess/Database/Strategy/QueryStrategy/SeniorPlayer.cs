//-----------------------------------------------------------------------
// <copyright file="SeniorPlayer.cs" company="Hyperar">
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
    /// SeniorPlayer Query Strategy.
    /// </summary>
    public class SeniorPlayer : IQueryStrategy<BusinessObjects.App.SeniorPlayer>
    {
        #region Public Methods

        /// <summary>
        /// Applies the corresponding Includes depending on the class.
        /// </summary>
        /// <param name="query">Query to apply includes to.</param>
        /// <returns>Query with included child entities.</returns>
        public IQueryable<BusinessObjects.App.SeniorPlayer> ApplyIncludes(IQueryable<BusinessObjects.App.SeniorPlayer> query)
        {
            return query.Include(p => p.Country)
                        .Include(p => p.SeniorTeam)
                        .Include(p => p.Skills);
        }

        #endregion Public Methods
    }
}