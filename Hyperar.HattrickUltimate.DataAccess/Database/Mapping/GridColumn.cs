//-----------------------------------------------------------------------
// <copyright file="GridColumn.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.DataAccess.Database.Mapping
{
    using Constants;
    using Interface;

    /// <summary>
    /// GridColumn entity mapping implementation.
    /// </summary>
    internal class GridColumn : Entity<BusinessObjects.App.GridColumn>, IMapping
    {
        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="GridColumn"/> class.
        /// </summary>
        internal GridColumn()
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
            this.Property(p => p.Name)
                .HasColumnName(ColumnName.Name)
                .HasColumnOrder(1)
                .HasColumnType(ColumnType.UnicodeVarChar)
                .HasMaxLength(ColumnLength.ShortText)
                .IsRequired();

            this.Property(p => p.GridColumnType)
                .HasColumnName(ColumnName.GridColumnType)
                .HasColumnOrder(2)
                .HasColumnType(ColumnType.TinyInt)
                .IsRequired();

            this.Property(p => p.ValueDenominationType)
                .HasColumnName(ColumnName.ValueDenominationType)
                .HasColumnOrder(3)
                .HasColumnType(ColumnType.TinyInt)
                .IsRequired();

            this.Property(p => p.ValuePropertyName)
                .HasColumnName(ColumnName.ValuePropertyName)
                .HasColumnOrder(4)
                .HasColumnType(ColumnType.UnicodeVarChar)
                .HasMaxLength(ColumnLength.ShortText)
                .IsRequired();

            this.Property(p => p.ValueChangeTrackingPropertyName)
                .HasColumnName(ColumnName.ValueChangeTrackingPropertyName)
                .HasColumnOrder(5)
                .HasColumnType(ColumnType.UnicodeVarChar)
                .HasMaxLength(ColumnLength.ShortText)
                .IsOptional();

            this.Property(p => p.IsVisible)
                .HasColumnName(ColumnName.IsVisible)
                .HasColumnOrder(6)
                .HasColumnType(ColumnType.Boolean)
                .IsRequired();
        }

        /// <summary>
        /// Register entity relationships.
        /// </summary>
        public void RegisterRelationships()
        {
            this.HasMany(r => r.GridLayoutColumns)
                .WithRequired(r => r.GridColumn)
                .HasForeignKey(r => r.GridColumnId)
                .WillCascadeOnDelete(false);
        }

        /// <summary>
        /// Register entity table mapping.
        /// </summary>
        public void RegisterTable()
        {
            this.ToTable(TableName.GridColumn, SchemaName.Application);
        }

        #endregion Public Methods
    }
}