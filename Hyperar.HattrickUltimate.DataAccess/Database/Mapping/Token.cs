//-----------------------------------------------------------------------
// <copyright file="Token.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.DataAccess.Database.Mapping
{
    using Constants;
    using Interface;

    /// <summary>
    /// Token entity mapping implementation.
    /// </summary>
    internal class Token : Entity<BusinessObjects.App.Token>, IMapping
    {
        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Token" /> class.
        /// </summary>
        internal Token()
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
            this.Property(p => p.Key)
                .HasColumnName(ColumnName.Key)
                .HasColumnOrder(1)
                .HasColumnType(ColumnType.UnicodeVarChar)
                .HasMaxLength(ColumnLength.Token)
                .IsRequired();

            this.Property(p => p.Secret)
                .HasColumnName(ColumnName.Secret)
                .HasColumnOrder(2)
                .HasColumnType(ColumnType.UnicodeVarChar)
                .HasMaxLength(ColumnLength.Token)
                .IsRequired();

            this.Property(p => p.Scope)
                .HasColumnName(ColumnName.Scope)
                .HasColumnOrder(3)
                .HasColumnType(ColumnType.TinyInt)
                .IsRequired();

            this.Property(p => p.CreatedOn)
                .HasColumnName(ColumnName.CreatedOn)
                .HasColumnOrder(4)
                .HasColumnType(ColumnType.DateTime)
                .IsOptional();

            this.Property(p => p.ExpiresOn)
                .HasColumnName(ColumnName.ExpiresOn)
                .HasColumnOrder(5)
                .HasColumnType(ColumnType.DateTime)
                .IsOptional();
        }

        /// <summary>
        /// Register entity relationships.
        /// </summary>
        public void RegisterRelationships()
        {
            this.HasRequired(r => r.User)
                .WithOptional(r => r.Token)
                .Map(m =>
                {
                    m.ToTable(TableName.Token, SchemaName.Default);
                    m.MapKey(ColumnName.UserId);
                });
        }

        /// <summary>
        /// Register entity table mapping.
        /// </summary>
        public void RegisterTable()
        {
            this.ToTable(TableName.Token, SchemaName.Default);
        }

        #endregion Public Methods
    }
}