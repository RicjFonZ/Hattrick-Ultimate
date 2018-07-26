//-----------------------------------------------------------------------
// <copyright file="GridLayout.cs" company="Hyperar">
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
    /// GridLayout Query Strategy.
    /// </summary>
    public class GridLayout : IQueryStrategy<BusinessObjects.App.GridLayout>
    {
        #region Public Methods

        /// <summary>
        /// Applies the corresponding Includes depending on the class.
        /// </summary>
        /// <param name="query">Query to apply includes to.</param>
        /// <returns>Query with included child entities.</returns>
        public IQueryable<BusinessObjects.App.GridLayout> ApplyIncludes(IQueryable<BusinessObjects.App.GridLayout> query)
        {
            return query.Include(p => p.Grid)
                        .Include(p => p.GridLayoutColumns);
        }

        #endregion Public Methods
    }
}