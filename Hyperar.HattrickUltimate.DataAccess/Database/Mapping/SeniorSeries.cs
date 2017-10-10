//-----------------------------------------------------------------------
// <copyright file="SeniorSeries.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.DataAccess.Database.Mapping
{
    using Constants;
    using Interface;

    /// <summary>
    /// SeniorSeries entity mapping implementation.
    /// </summary>
    internal class SeniorSeries : HattrickEntity<BusinessObjects.App.SeniorSeries>, IMapping
    {
        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SeniorSeries" /> class.
        /// </summary>
        internal SeniorSeries()
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

            this.Property(p => p.Division)
                .HasColumnName(ColumnName.Division)
                .HasColumnOrder(3)
                .HasColumnType(ColumnType.TinyInt)
                .IsRequired();
        }

        /// <summary>
        /// Register entity relationships.
        /// </summary>
        public void RegisterRelationships()
        {
            this.HasRequired(r => r.League)
                .WithMany(r => r.SeniorSeries)
                .HasForeignKey(r => r.LeagueId);
        }

        /// <summary>
        /// Register entity table mapping.
        /// </summary>
        public void RegisterTable()
        {
            this.ToTable(TableName.SeniorSeries);
        }

        #endregion Public Methods
    }
}