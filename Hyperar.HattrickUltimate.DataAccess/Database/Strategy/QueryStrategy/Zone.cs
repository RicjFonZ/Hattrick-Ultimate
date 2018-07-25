//-----------------------------------------------------------------------
// <copyright file="Zone.cs" company="Hyperar">
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
    /// Zone Query Strategy.
    /// </summary>
    public class Zone : IQueryStrategy<BusinessObjects.App.Zone>
    {
        #region Public Methods

        /// <summary>
        /// Applies the corresponding Includes depending on the class.
        /// </summary>
        /// <param name="query">Query to apply includes to.</param>
        /// <returns>Query with included child entities.</returns>
        public IQueryable<BusinessObjects.App.Zone> ApplyIncludes(IQueryable<BusinessObjects.App.Zone> query)
        {
            return query.Include(p => p.Leagues);
        }

        #endregion Public Methods
    }
}