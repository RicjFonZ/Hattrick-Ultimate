//-----------------------------------------------------------------------
// <copyright file="User.cs" company="Hyperar">
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
    /// User Query Strategy.
    /// </summary>
    public class User : IQueryStrategy<BusinessObjects.App.User>
    {
        #region Public Methods

        /// <summary>
        /// Applies the corresponding Includes depending on the class.
        /// </summary>
        /// <param name="query">Query to apply includes to.</param>
        /// <returns>Query with included child entities.</returns>
        public IQueryable<BusinessObjects.App.User> ApplyIncludes(IQueryable<BusinessObjects.App.User> query)
        {
            return query.Include(p => p.Manager)
                        .Include(p => p.Token);
        }

        #endregion Public Methods
    }
}