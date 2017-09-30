//-----------------------------------------------------------------------
// <copyright file="User.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.DataAccess.Database.Mapping
{
    using Constants;

    /// <summary>
    /// User entity mapping definition.
    /// </summary>
    internal class User : Entity<BusinessObjects.App.User>
    {
        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="User" /> class.
        /// </summary>
        internal User()
        {
            this.RegisterTable();
            this.RegisterRelationships();
        }

        #endregion Internal Constructors

        #region Private Methods

        /// <summary>
        /// Register entity relationships.
        /// </summary>
        private void RegisterRelationships()
        {
            this.HasOptional(r => r.Manager)
                .WithOptionalDependent(r => r.User)
                .Map(r =>
                {
                    r.MapKey(ColumnName.ManagerId);
                    r.ToTable(TableName.User);
                });

            this.HasOptional(r => r.Token)
                .WithRequired(r => r.User)
                .Map(r =>
                {
                    r.MapKey(ColumnName.UserId);
                    r.ToTable(TableName.Token);
                });
        }

        /// <summary>
        /// Register entity table.
        /// </summary>
        private void RegisterTable()
        {
            this.ToTable(TableName.User);
        }

        #endregion Private Methods
    }
}