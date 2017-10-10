//-----------------------------------------------------------------------
// <copyright file="Currency.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.DataAccess.Database.Mapping
{
    using Constants;
    using Interface;

    /// <summary>
    /// Currency entity mapping implementation.
    /// </summary>
    internal class Currency : Entity<BusinessObjects.App.Currency>, IMapping
    {
        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Currency" /> class.
        /// </summary>
        internal Currency()
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

            this.Property(p => p.Rate)
                .HasColumnName(ColumnName.Rate)
                .HasColumnOrder(2)
                .HasColumnType(ColumnType.Numeric)
                .HasPrecision(Precision.Currency, Scale.Currency)
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
            this.ToTable(TableName.Currency);
        }

        #endregion Public Methods
    }
}