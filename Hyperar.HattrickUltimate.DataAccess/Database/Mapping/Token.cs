//-----------------------------------------------------------------------
// <copyright file="Token.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.DataAccess.Database.Mapping
{
    using Constants;

    /// <summary>
    /// Token entity mapping definition.
    /// </summary>
    internal class Token : Entity<BusinessObjects.App.Token>
    {
        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Token" /> class.
        /// </summary>
        internal Token()
        {
            this.RegisterTable();
            this.RegisterProperties();
        }

        #endregion Internal Constructors

        #region Private Methods

        /// <summary>
        /// Registers entity properties.
        /// </summary>
        private void RegisterProperties()
        {
            this.Property(e => e.Key)
                .HasColumnName(ColumnName.Token)
                .HasColumnOrder(2)
                .HasColumnType(ColumnType.UnicodeChar)
                .HasMaxLength(ColumnLength.Token)
                .IsRequired();

            this.Property(e => e.Secret)
                .HasColumnName(ColumnName.TokenSecret)
                .HasColumnOrder(3)
                .HasColumnType(ColumnType.UnicodeChar)
                .HasMaxLength(ColumnLength.Token)
                .IsRequired();

            this.Property(e => e.Scope)
                .HasColumnName(ColumnName.AccessScope)
                .HasColumnOrder(4)
                .HasColumnType(ColumnType.TinyInteger)
                .IsRequired();

            this.Property(e => e.CreatedOn)
                .HasColumnName(ColumnName.CreatedOn)
                .HasColumnOrder(5)
                .HasColumnType(ColumnType.DateTime)
                .IsRequired();

            this.Property(e => e.ExpiresOn)
                .HasColumnName(ColumnName.ExpiresOn)
                .HasColumnOrder(6)
                .HasColumnType(ColumnType.DateTime)
                .IsRequired();
        }

        /// <summary>
        /// Register entity table.
        /// </summary>
        private void RegisterTable()
        {
            this.ToTable(TableName.Token);
        }

        #endregion Private Methods
    }
}