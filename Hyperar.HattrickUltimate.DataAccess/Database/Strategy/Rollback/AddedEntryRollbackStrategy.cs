// -----------------------------------------------------------------------
// <copyright file="AddedEntryRollbackStrategy.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
// -----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.DataAccess.Database.Strategy.Rollback
{
    using System.Data.Entity.Core.Objects;
    using Interface;

    /// <summary>
    /// Added Entity rollback strategy implementation.
    /// </summary>
    public class AddedEntryRollbackStrategy : IRollbackStrategy
    {
        #region Methods

        /// <summary>
        /// Revert changes for the specified entry on the specified context.
        /// </summary>
        /// <param name="entry">Entry to revert.</param>
        /// <param name="context">Object context that contains the changes.</param>
        public void Undo(ObjectStateEntry entry, ObjectContext context)
        {
            context.Detach(entry.Entity);
        }

        #endregion Methods
    }
}