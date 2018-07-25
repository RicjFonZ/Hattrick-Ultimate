//-----------------------------------------------------------------------
// <copyright file="LeagueNationalTeam.cs" company="Hyperar">
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
    /// LeagueNationalTeam Query Strategy.
    /// </summary>
    public class LeagueNationalTeam : IQueryStrategy<BusinessObjects.App.LeagueNationalTeam>
    {
        #region Public Methods

        /// <summary>
        /// Applies the corresponding Includes depending on the class.
        /// </summary>
        /// <param name="query">Query to apply includes to.</param>
        /// <returns>Query with included child entities.</returns>
        public IQueryable<BusinessObjects.App.LeagueNationalTeam> ApplyIncludes(IQueryable<BusinessObjects.App.LeagueNationalTeam> query)
        {
            return query.Include(p => p.League);
        }

        #endregion Public Methods
    }
}