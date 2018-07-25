//-----------------------------------------------------------------------
// <copyright file="GridColumn.cs" company="Hyperar">
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
    /// GridColumn Query Strategy.
    /// </summary>
    public class GridColumn : IQueryStrategy<BusinessObjects.App.GridColumn>
    {
        #region Public Methods

        /// <summary>
        /// Applies the corresponding Includes depending on the class.
        /// </summary>
        /// <param name="query">Query to apply includes to.</param>
        /// <returns>Query with included child entities.</returns>
        public IQueryable<BusinessObjects.App.GridColumn> ApplyIncludes(IQueryable<BusinessObjects.App.GridColumn> query)
        {
            return query.Include(p => p.Grid)
                        .Include(p => p.GridLayoutColumns);
        }

        #endregion Public Methods
    }
}