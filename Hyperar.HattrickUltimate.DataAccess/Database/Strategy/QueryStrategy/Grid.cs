//-----------------------------------------------------------------------
// <copyright file="Grid.cs" company="Hyperar">
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
    /// Grid Query Strategy.
    /// </summary>
    public class Grid : IQueryStrategy<BusinessObjects.App.Grid>
    {
        #region Public Methods

        /// <summary>
        /// Applies the corresponding Includes depending on the class.
        /// </summary>
        /// <param name="query">Query to apply includes to.</param>
        /// <returns>Query with included child entities.</returns>
        public IQueryable<BusinessObjects.App.Grid> ApplyIncludes(IQueryable<BusinessObjects.App.Grid> query)
        {
            return query.Include(p => p.GridColumns)
                        .Include(p => p.GridLayouts);
        }

        #endregion Public Methods
    }
}