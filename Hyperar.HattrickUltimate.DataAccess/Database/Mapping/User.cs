//-----------------------------------------------------------------------
// <copyright file="User.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.DataAccess.Database.Mapping
{
    using Constants;
    using Interface;

    /// <summary>
    /// User entity mapping implementation.
    /// </summary>
    internal class User : Entity<BusinessObjects.App.User>, IMapping
    {
        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="User" /> class.
        /// </summary>
        internal User()
        {
            this.RegisterTable();
            this.RegisterProperties();
            this.RegisterRelationships();
        }

        #endregion Internal Constructors

        #region Public Methods

        /// <summary>
        /// Registers property column mapping.
        /// </summary>
        public void RegisterProperties()
        {
        }

        /// <summary>
        /// Register entity relationships.
        /// </summary>
        public void RegisterRelationships()
        {
            this.HasOptional(r => r.Manager)
                .WithOptionalDependent(r => r.User)
                .Map(m =>
                {
                    m.ToTable(TableName.User);
                    m.MapKey(ColumnName.ManagerId);
                });
        }

        /// <summary>
        /// Register entity table mapping.
        /// </summary>
        public void RegisterTable()
        {
            this.ToTable(TableName.User);
        }

        #endregion Public Methods
    }
}