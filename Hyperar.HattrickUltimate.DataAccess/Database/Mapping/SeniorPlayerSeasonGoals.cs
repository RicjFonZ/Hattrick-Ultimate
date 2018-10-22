//-----------------------------------------------------------------------
// <copyright file="SeniorPlayerSeasonGoals.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.DataAccess.Database.Mapping
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;
    using Constants;

    /// <summary>
    /// SeniorPlayerSeasonGoals entity mapping implementation.
    /// </summary>
    internal class SeniorPlayerSeasonGoals : EntityTypeConfiguration<BusinessObjects.App.SeniorPlayerSeasonGoals>
    {
        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SeniorPlayerSeasonGoals"/> class.
        /// </summary>
        internal SeniorPlayerSeasonGoals()
        {
            this.RegisterTable();
            this.RegisterPrimaryKey();
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
            this.Property(p => p.Id)
                .HasColumnName(ColumnName.Id)
                .HasColumnOrder(0)
                .HasColumnType(ColumnType.Integer)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            this.Property(p => p.Season)
                .HasColumnName(ColumnName.Season)
                .HasColumnOrder(1)
                .HasColumnType(ColumnType.SmallInt)
                .IsRequired();

            this.Property(p => p.SeriesGoals)
                .HasColumnName(ColumnName.SeriesGoals)
                .HasColumnOrder(2)
                .HasColumnType(ColumnType.SmallInt)
                .IsRequired();

            this.Property(p => p.CupGoals)
                .HasColumnName(ColumnName.CupGoals)
                .HasColumnOrder(3)
                .HasColumnType(ColumnType.SmallInt)
                .IsRequired();

            this.Property(p => p.FriendlyGoals)
                .HasColumnName(ColumnName.FriendlyGoals)
                .HasColumnOrder(4)
                .HasColumnType(ColumnType.SmallInt)
                .IsRequired();
        }

        /// <summary>
        /// Register entity relationships.
        /// </summary>
        public void RegisterRelationships()
        {
            this.HasRequired(r => r.SeniorPlayer)
                .WithMany(r => r.SeasonGoals)
                .HasForeignKey(r => r.SeniorPlayerId);
        }

        /// <summary>
        /// Register entity table mapping.
        /// </summary>
        public void RegisterTable()
        {
            this.ToTable(TableName.SeniorPlayerSeasonGoals, SchemaName.Default);
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        /// Registers table primary key.
        /// </summary>
        private void RegisterPrimaryKey()
        {
            this.HasKey(p => new { p.Id, p.Season });
        }

        #endregion Private Methods
    }
}