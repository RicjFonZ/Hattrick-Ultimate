// -----------------------------------------------------------------------
// <copyright file="RollbackStrategyFactory.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
// -----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.DataAccess.Database.Factory
{
    using System;
    using System.Data.Entity;
    using Interface;
    using Strategy.Rollback;

    /// <summary>
    /// IRollbackStrategy object factory implementation.
    /// </summary>
    public class RollbackStrategyFactory : IRollbackStrategyFactory
    {
        #region Methods

        /// <summary>
        /// Gets the corresponding Strategy for the given EntityState.
        /// </summary>
        /// <param name="state">Entity state.</param>
        /// <returns>Corresponding IRollbackStrategy object.</returns>
        public IRollbackStrategy GetFor(EntityState state)
        {
            switch (state)
            {
                case EntityState.Added:
                    return new AddedEntryRollbackStrategy();

                case EntityState.Deleted:
                case EntityState.Modified:
                    return new ModifiedEntryRollbackStrategy();

                default:
                    throw new NotSupportedException($"EntityState: {state} rollback not supported.");
            }
        }

        #endregion Methods
    }
}