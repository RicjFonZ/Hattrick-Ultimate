//-----------------------------------------------------------------------
// <copyright file="TimeFormat.cs" company="Hyperar">
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
    /// TimeFormat Query Strategy.
    /// </summary>
    public class TimeFormat : IQueryStrategy<BusinessObjects.App.TimeFormat>
    {
        #region Public Methods

        /// <summary>
        /// Applies the corresponding Includes depending on the class.
        /// </summary>
        /// <param name="query">Query to apply includes to.</param>
        /// <returns>Query with included child entities.</returns>
        public IQueryable<BusinessObjects.App.TimeFormat> ApplyIncludes(IQueryable<BusinessObjects.App.TimeFormat> query)
        {
            return query.Include(p => p.Countries);
        }

        #endregion Public Methods
    }
}