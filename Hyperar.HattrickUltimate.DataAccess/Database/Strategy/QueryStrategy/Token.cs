//-----------------------------------------------------------------------
// <copyright file="Token.cs" company="Hyperar">
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
    /// Token Query Strategy.
    /// </summary>
    public class Token : IQueryStrategy<BusinessObjects.App.Token>
    {
        #region Public Methods

        /// <summary>
        /// Applies the corresponding Includes depending on the class.
        /// </summary>
        /// <param name="query">Query to apply includes to.</param>
        /// <returns>Query with included child entities.</returns>
        public IQueryable<BusinessObjects.App.Token> ApplyIncludes(IQueryable<BusinessObjects.App.Token> query)
        {
            return query.Include(p => p.User);
        }

        #endregion Public Methods
    }
}