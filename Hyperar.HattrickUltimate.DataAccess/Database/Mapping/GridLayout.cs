//-----------------------------------------------------------------------
// <copyright file="GridLayout.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.DataAccess.Database.Mapping
{
    using Constants;
    using Interface;

    /// <summary>
    /// GridLayout entity mapping implementation.
    /// </summary>
    internal class GridLayout : Entity<BusinessObjects.App.GridLayout>, IMapping
    {
        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="GridLayout" /> class.
        /// </summary>
        internal GridLayout()
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
                .HasColumnType(ColumnType.UnicodeChar)
                .HasMaxLength(ColumnLength.ShortText)
                .IsRequired();

            this.Property(p => p.IsDefault)
                .HasColumnName(ColumnName.IsDefault)
                .HasColumnOrder(2)
                .HasColumnType(ColumnType.Boolean)
                .IsRequired();
        }

        /// <summary>
        /// Register entity relationships.
        /// </summary>
        public void RegisterRelationships()
        {
            this.HasMany(r => r.GridLayoutColumns)
                .WithRequired(r => r.GridLayout)
                .HasForeignKey(r => r.GridLayoutId)
                .WillCascadeOnDelete(false);
        }

        /// <summary>
        /// Register entity table mapping.
        /// </summary>
        public void RegisterTable()
        {
            this.ToTable(TableName.GridLayout, SchemaName.Application);
        }

        #endregion Public Methods
    }
}