//-----------------------------------------------------------------------
// <copyright file="JuniorPlayerAvatar.cs" company="Hyperar">
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
    /// JuniorPlayerAvatar Query Strategy.
    /// </summary>
    public class JuniorPlayerAvatar : IQueryStrategy<BusinessObjects.App.JuniorPlayerAvatar>
    {
        #region Public Methods

        /// <summary>
        /// Applies the corresponding Includes depending on the class.
        /// </summary>
        /// <param name="query">Query to apply includes to.</param>
        /// <returns>Query with included child entities.</returns>
        public IQueryable<BusinessObjects.App.JuniorPlayerAvatar> ApplyIncludes(IQueryable<BusinessObjects.App.JuniorPlayerAvatar> query)
        {
            return query.Include(p => p.JuniorPlayer);
        }

        #endregion Public Methods
    }
}