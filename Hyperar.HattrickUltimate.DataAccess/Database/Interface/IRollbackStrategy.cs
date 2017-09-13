// -----------------------------------------------------------------------
// <copyright file="IRollbackStrategy.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
// -----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.DataAccess.Database.Interface
{
    using System.Data.Entity.Core.Objects;

    /// <summary>
    /// Entity rollback strategy definition.
    /// </summary>
    public interface IRollbackStrategy
    {
        #region Methods

        /// <summary>
        /// Revert changes for the specified entry on the specified context.
        /// </summary>
        /// <param name="entry">Entry to revert.</param>
        /// <param name="context">Object context that contains the changes.</param>
        void Undo(ObjectStateEntry entry, ObjectContext context);

        #endregion Methods
    }
}