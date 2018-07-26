//-----------------------------------------------------------------------
// <copyright file="GridLayoutColumn.cs" company="Hyperar">
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
    /// GridLayoutColumn Query Strategy.
    /// </summary>
    public class GridLayoutColumn : IQueryStrategy<BusinessObjects.App.GridLayoutColumn>
    {
        #region Public Methods

        /// <summary>
        /// Applies the corresponding Includes depending on the class.
        /// </summary>
        /// <param name="query">Query to apply includes to.</param>
        /// <returns>Query with included child entities.</returns>
        public IQueryable<BusinessObjects.App.GridLayoutColumn> ApplyIncludes(IQueryable<BusinessObjects.App.GridLayoutColumn> query)
        {
            return query.Include(p => p.GridColumn)
                        .Include(p => p.GridLayout);
        }

        #endregion Public Methods
    }
}