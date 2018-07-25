//-----------------------------------------------------------------------
// <copyright file="SeniorTeam.cs" company="Hyperar">
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
    /// SeniorTeam Query Strategy.
    /// </summary>
    public class SeniorTeam : IQueryStrategy<BusinessObjects.App.SeniorTeam>
    {
        #region Public Methods

        /// <summary>
        /// Applies the corresponding Includes depending on the class.
        /// </summary>
        /// <param name="query">Query to apply includes to.</param>
        /// <returns>Query with included child entities.</returns>
        public IQueryable<BusinessObjects.App.SeniorTeam> ApplyIncludes(IQueryable<BusinessObjects.App.SeniorTeam> query)
        {
            return query.Include(p => p.JuniorTeam)
                        .Include(p => p.Manager)
                        .Include(p => p.Region)
                        .Include(p => p.SeniorArena)
                        .Include(p => p.SeniorSeries);
        }

        #endregion Public Methods
    }
}