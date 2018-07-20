//-----------------------------------------------------------------------
// <copyright file="GridLayoutColumn.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.DataAccess.Database.Mapping
{
    using Constants;
    using Interface;

    /// <summary>
    /// GridLayoutColumn entity mapping implementation.
    /// </summary>
    internal class GridLayoutColumn : Entity<BusinessObjects.App.GridLayoutColumn>, IMapping
    {
        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="GridLayoutColumn" /> class.
        /// </summary>
        internal GridLayoutColumn()
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
            this.Property(p => p.CustomHeaderText)
                .HasColumnName(ColumnName.CustomHeaderText)
                .HasColumnOrder(1)
                .HasColumnType(ColumnType.UnicodeVarChar)
                .HasMaxLength(ColumnLength.ShortText)
                .IsOptional();

            this.Property(p => p.IsFixed)
                .HasColumnName(ColumnName.IsFixed)
                .HasColumnOrder(2)
                .HasColumnType(ColumnType.Boolean)
                .IsRequired();

            this.Property(p => p.Alignment)
                .HasColumnName(ColumnName.Alignment)
                .HasColumnOrder(3)
                .HasColumnType(ColumnType.Integer)
                .IsRequired();

            this.Property(p => p.DisplayIndex)
                .HasColumnName(ColumnName.DisplayIndex)
                .HasColumnOrder(4)
                .HasColumnType(ColumnType.Integer)
                .IsRequired();

            this.Property(p => p.DisplayMode)
                .HasColumnName(ColumnName.DisplayMode)
                .HasColumnOrder(5)
                .HasColumnType(ColumnType.TinyInt)
                .IsRequired();

            this.Property(p => p.Width)
                .HasColumnName(ColumnName.Width)
                .HasColumnOrder(6)
                .HasColumnType(ColumnType.Integer)
                .IsRequired();
        }

        /// <summary>
        /// Register entity relationships.
        /// </summary>
        public void RegisterRelationships()
        {
        }

        /// <summary>
        /// Register entity table mapping.
        /// </summary>
        public void RegisterTable()
        {
            this.ToTable(TableName.GridLayoutColumn, SchemaName.Application);
        }

        #endregion Public Methods
    }
}