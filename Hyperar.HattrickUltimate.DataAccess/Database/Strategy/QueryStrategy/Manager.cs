//-----------------------------------------------------------------------
// <copyright file="Manager.cs" company="Hyperar">
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
    /// Manager Query Strategy.
    /// </summary>
    public class Manager : IQueryStrategy<BusinessObjects.App.Manager>
    {
        #region Public Methods

        /// <summary>
        /// Applies the corresponding Includes depending on the class.
        /// </summary>
        /// <param name="query">Query to apply includes to.</param>
        /// <returns>Query with included child entities.</returns>
        public IQueryable<BusinessObjects.App.Manager> ApplyIncludes(IQueryable<BusinessObjects.App.Manager> query)
        {
            return query.Include(p => p.Country)
                        .Include(p => p.SeniorTeams)
                        .Include(p => p.User);
        }

        #endregion Public Methods
    }
}