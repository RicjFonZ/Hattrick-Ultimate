//-----------------------------------------------------------------------
// <copyright file="Country.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.DataAccess.Database.Mapping
{
    using Constants;
    using Interface;

    /// <summary>
    /// Country entity mapping implementation.
    /// </summary>
    internal class Country : HattrickEntity<BusinessObjects.App.Country>, IMapping
    {
        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Country" /> class.
        /// </summary>
        internal Country()
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
                .HasColumnOrder(2)
                .HasColumnType(ColumnType.UnicodeVarChar)
                .HasMaxLength(ColumnLength.ShortText)
                .IsRequired();

            this.Property(p => p.Code)
                .HasColumnName(ColumnName.Code)
                .HasColumnOrder(3)
                .HasColumnType(ColumnType.UnicodeChar)
                .HasMaxLength(ColumnLength.TwoCharCode)
                .IsRequired();
        }

        /// <summary>
        /// Register entity relationships.
        /// </summary>
        public void RegisterRelationships()
        {
            this.HasRequired(r => r.Currency)
                .WithMany(r => r.Countries)
                .HasForeignKey(r => r.CurrencyId);

            this.HasRequired(r => r.DateFormat)
                .WithMany(r => r.Countries)
                .HasForeignKey(r => r.DateFormatId);

            this.HasRequired(r => r.League)
                .WithOptional(r => r.Country)
                .Map(m =>
                {
                    m.ToTable(TableName.Country, SchemaName.Default);
                    m.MapKey(ColumnName.LeagueId);
                });

            this.HasRequired(r => r.TimeFormat)
                .WithMany(r => r.Countries)
                .HasForeignKey(r => r.TimeFormatId);
        }

        /// <summary>
        /// Register entity table mapping.
        /// </summary>
        public void RegisterTable()
        {
            this.ToTable(TableName.Country, SchemaName.Default);
        }

        #endregion Public Methods
    }
}