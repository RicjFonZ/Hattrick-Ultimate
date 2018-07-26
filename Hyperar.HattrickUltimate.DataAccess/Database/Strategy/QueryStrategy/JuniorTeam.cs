//-----------------------------------------------------------------------
// <copyright file="JuniorTeam.cs" company="Hyperar">
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
    /// JuniorTeam Query Strategy.
    /// </summary>
    public class JuniorTeam : IQueryStrategy<BusinessObjects.App.JuniorTeam>
    {
        #region Public Methods

        /// <summary>
        /// Applies the corresponding Includes depending on the class.
        /// </summary>
        /// <param name="query">Query to apply includes to.</param>
        /// <returns>Query with included child entities.</returns>
        public IQueryable<BusinessObjects.App.JuniorTeam> ApplyIncludes(IQueryable<BusinessObjects.App.JuniorTeam> query)
        {
            return query.Include(p => p.JuniorSeries)
                        .Include(p => p.SeniorTeam);
        }

        #endregion Public Methods
    }
}