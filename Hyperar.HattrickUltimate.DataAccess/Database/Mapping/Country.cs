//-----------------------------------------------------------------------
// <copyright file="Country.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.DataAccess.Database.Mapping
{
    using Constants;

    /// <summary>
    /// Country entity mapping.
    /// </summary>
    internal class Country : HattrickEntity<BusinessObjects.App.Country>
    {
        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Country"/> class
        /// </summary>
        public Country()
        {
            this.RegisterTable();
            this.RegisterProperties();
            this.RegisterRelationships();
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// Registers the Entity database table columns.
        /// </summary>
        public void RegisterProperties()
        {
            this.Property(p => p.Name)
                .HasColumnName(ColumnName.Name)
                .HasColumnOrder(2)
                .HasColumnType(ColumnType.UnicodeVarChar)
                .HasMaxLength(ColumnLength.MediumText)
                .IsRequired();

            this.Property(p => p.Code)
                .HasColumnName(ColumnName.Code)
                .HasColumnOrder(3)
                .HasColumnType(ColumnType.UnicodeVarChar)
                .HasMaxLength(ColumnLength.MiniText)
                .IsRequired();
        }

        /// <summary>
        /// Registers the Entity relationships.
        /// </summary>
        public void RegisterRelationships()
        {
            this.HasRequired(r => r.League)
                .WithOptional(r => r.Country)
                .Map(r =>
                {
                    r.MapKey(ColumnName.LeagueId);
                    r.ToTable(TableName.Country);
                });

            this.HasRequired(r => r.Currency)
                .WithMany(r => r.Countries)
                .HasForeignKey(r => r.CurrencyId);

            this.HasRequired(r => r.DateFormat)
                .WithMany(r => r.Countries)
                .HasForeignKey(r => r.DateFormatId);

            this.HasRequired(r => r.TimeFormat)
                .WithMany(r => r.Countries)
                .HasForeignKey(r => r.TimeFormatId);
        }

        /// <summary>
        /// Registers the Entity to it's database table.
        /// </summary>
        public void RegisterTable()
        {
            this.ToTable(TableName.Country);
        }

        #endregion Public Methods
    }
}