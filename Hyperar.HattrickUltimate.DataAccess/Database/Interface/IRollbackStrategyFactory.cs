// -----------------------------------------------------------------------
// <copyright file="IRollbackStrategyFactory.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
// -----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.DataAccess.Database.Interface
{
    using System.Data.Entity;

    /// <summary>
    /// IRollbackStrategy object factory definition.
    /// </summary>
    internal interface IRollbackStrategyFactory
    {
        #region Public Methods

        /// <summary>
        /// Gets the corresponding Strategy for the given EntityState.
        /// </summary>
        /// <param name="state">Entity state.</param>
        /// <returns>Corresponding IRollbackStrategy object.</returns>
        IRollbackStrategy GetFor(EntityState state);

        #endregion Public Methods
    }
}