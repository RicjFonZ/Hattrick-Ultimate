// -----------------------------------------------------------------------
// <copyright file="ModifiedEntryRollbackStrategy.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
// -----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.DataAccess.Database.Strategy.Rollback
{
    using System.Data.Entity;
    using System.Data.Entity.Core.Objects;
    using Interface;

    /// <summary>
    /// Modified Entity rollback strategy implementation.
    /// </summary>
    public class ModifiedEntryRollbackStrategy : IRollbackStrategy
    {
        #region Public Methods

        /// <summary>
        /// Revert changes for the specified entry on the specified context.
        /// </summary>
        /// <param name="entry">Entry to revert.</param>
        /// <param name="context">Object context that contains the changes.</param>
        public void Undo(ObjectStateEntry entry, ObjectContext context)
        {
            entry.ChangeState(EntityState.Unchanged);
        }

        #endregion Public Methods
    }
}