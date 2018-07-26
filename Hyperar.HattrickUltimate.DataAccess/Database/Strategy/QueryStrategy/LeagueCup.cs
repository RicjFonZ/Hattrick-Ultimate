//-----------------------------------------------------------------------
// <copyright file="LeagueCup.cs" company="Hyperar">
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
    /// LeagueCup Query Strategy.
    /// </summary>
    public class LeagueCup : IQueryStrategy<BusinessObjects.App.LeagueCup>
    {
        #region Public Methods

        /// <summary>
        /// Applies the corresponding Includes depending on the class.
        /// </summary>
        /// <param name="query">Query to apply includes to.</param>
        /// <returns>Query with included child entities.</returns>
        public IQueryable<BusinessObjects.App.LeagueCup> ApplyIncludes(IQueryable<BusinessObjects.App.LeagueCup> query)
        {
            return query.Include(p => p.League);
        }

        #endregion Public Methods
    }
}