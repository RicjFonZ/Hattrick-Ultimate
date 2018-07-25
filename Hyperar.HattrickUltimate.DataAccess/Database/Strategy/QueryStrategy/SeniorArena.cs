//-----------------------------------------------------------------------
// <copyright file="SeniorArena.cs" company="Hyperar">
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
    /// SeniorArena Query Strategy.
    /// </summary>
    public class SeniorArena : IQueryStrategy<BusinessObjects.App.SeniorArena>
    {
        #region Public Methods

        /// <summary>
        /// Applies the corresponding Includes depending on the class.
        /// </summary>
        /// <param name="query">Query to apply includes to.</param>
        /// <returns>Query with included child entities.</returns>
        public IQueryable<BusinessObjects.App.SeniorArena> ApplyIncludes(IQueryable<BusinessObjects.App.SeniorArena> query)
        {
            return query.Include(p => p.SeniorTeam);
        }

        #endregion Public Methods
    }
}