//-----------------------------------------------------------------------
// <copyright file="DownloadSettings.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.DataAccess.Database.Mapping
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;
    using Constants;
    using Interface;

    /// <summary>
    /// DownloadSettings entity mapping implementation.
    /// </summary>
    internal class DownloadSettings : EntityTypeConfiguration<BusinessObjects.App.DownloadSettings>, IMapping
    {
        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DownloadSettings"/> class.
        /// </summary>
        internal DownloadSettings()
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
            this.Property(p => p.Id)
                .HasColumnName(ColumnName.Id)
                .HasColumnOrder(0)
                .HasColumnType(ColumnType.Integer)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            this.HasKey(p => p.Id);

            this.Property(p => p.IncludeJuniorPlayerMatchInfo)
                .HasColumnName(ColumnName.IncludeJuniorPlayerMatchInfo)
                .HasColumnOrder(1)
                .HasColumnType(ColumnType.Boolean)
                .IsRequired();

            this.Property(p => p.IncludeSeniorPlayerMatchInfo)
                .HasColumnName(ColumnName.IncludeSeniorPlayerMatchInfo)
                .HasColumnOrder(2)
                .HasColumnType(ColumnType.Boolean)
                .IsRequired();

            this.Property(p => p.IncludeSeniorTeamAwayFlags)
                .HasColumnName(ColumnName.IncludeSeniorTeamAwayFlags)
                .HasColumnOrder(3)
                .HasColumnType(ColumnType.Boolean)
                .IsRequired();

            this.Property(p => p.IncludeSeniorTeamHomeFlags)
                .HasColumnName(ColumnName.IncludeSeniorTeamHomeFlags)
                .HasColumnOrder(4)
                .HasColumnType(ColumnType.Boolean)
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
            this.ToTable(TableName.DownloadSettings, SchemaName.Application);
        }

        #endregion Public Methods
    }
}