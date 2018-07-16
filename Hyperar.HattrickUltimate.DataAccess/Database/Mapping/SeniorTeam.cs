//-----------------------------------------------------------------------
// <copyright file="SeniorTeam.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.DataAccess.Database.Mapping
{
    using Constants;
    using Interface;

    /// <summary>
    /// SeniorTeam entity mapping implementation.
    /// </summary>
    internal class SeniorTeam : HattrickEntity<BusinessObjects.App.SeniorTeam>, IMapping
    {
        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SeniorTeam" /> class.
        /// </summary>
        internal SeniorTeam()
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
            this.Property(p => p.FullName)
                .HasColumnName(ColumnName.FullName)
                .HasColumnOrder(2)
                .HasColumnType(ColumnType.UnicodeVarChar)
                .HasMaxLength(ColumnLength.ShortText)
                .IsRequired();

            this.Property(p => p.ShortName)
                .HasColumnName(ColumnName.ShortName)
                .HasColumnOrder(3)
                .HasColumnType(ColumnType.UnicodeVarChar)
                .HasMaxLength(ColumnLength.ShortText)
                .IsRequired();

            this.Property(p => p.IsPrimary)
                .HasColumnName(ColumnName.IsPrimary)
                .HasColumnOrder(4)
                .HasColumnType(ColumnType.Boolean)
                .IsRequired();

            this.Property(p => p.EstablishedOn)
                .HasColumnName(ColumnName.EstablishedOn)
                .HasColumnOrder(5)
                .HasColumnType(ColumnType.DateTime)
                .IsRequired();

            this.Property(p => p.WinsInRow)
                .HasColumnName(ColumnName.WinsInRow)
                .HasColumnOrder(6)
                .HasColumnType(ColumnType.Integer)
                .IsRequired();

            this.Property(p => p.UndefeatedInRow)
                .HasColumnName(ColumnName.UndefeatedInRow)
                .HasColumnOrder(7)
                .HasColumnType(ColumnType.Integer)
                .IsRequired();

            this.Property(p => p.LeagueRank)
                .HasColumnName(ColumnName.LeagueRank)
                .HasColumnOrder(8)
                .HasColumnType(ColumnType.Integer)
                .IsRequired();
        }

        /// <summary>
        /// Register entity relationships.
        /// </summary>
        public void RegisterRelationships()
        {
            this.HasRequired(r => r.Manager)
                .WithMany(r => r.SeniorTeams)
                .HasForeignKey(r => r.ManagerId);

            this.HasRequired(r => r.Region)
                .WithMany(r => r.SeniorTeams)
                .HasForeignKey(r => r.RegionId);

            this.HasRequired(r => r.SeniorSeries)
                .WithMany(r => r.SeniorTeams)
                .HasForeignKey(r => r.SeniorSeriesId);
        }

        /// <summary>
        /// Register entity table mapping.
        /// </summary>
        public void RegisterTable()
        {
            this.ToTable(TableName.SeniorTeam, SchemaName.Default);
        }

        #endregion Public Methods
    }
}