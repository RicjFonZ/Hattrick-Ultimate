//-----------------------------------------------------------------------
// <copyright file="Currency.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.DataAccess.Database.Mapping
{
    using Constants;

    /// <summary>
    /// Currency entity mapping.
    /// </summary>
    public class Currency : Entity<BusinessObjects.App.Currency>
    {
        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Currency"/> class.
        /// </summary>
        public Currency()
        {
            this.RegisterTable();
            this.RegisterProperties();
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// Registers the Entity database table columns.
        /// </summary>
        public void RegisterProperties()
        {
            this.Property(p => p.Name)
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
        /// Registers the Entity to it's database table.
        /// </summary>
        public void RegisterTable()
        {
            this.ToTable(TableName.Currency);
        }

        #endregion Public Methods
    }
}