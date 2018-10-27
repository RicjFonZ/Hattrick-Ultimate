//-----------------------------------------------------------------------
// <copyright file="SeniorPlayerWeekLog.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.DataAccess.Database.Mapping
{
    using Hyperar.HattrickUltimate.DataAccess.Database.Constants;
    using Interface;

    /// <summary>
    /// SeniorPlayerWeekLog entity mapping implementation.
    /// </summary>
    internal class SeniorPlayerWeekLog : Entity<BusinessObjects.App.SeniorPlayerWeekLog>, IMapping
    {
        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SeniorPlayerWeekLog"/> class.
        /// </summary>
        internal SeniorPlayerWeekLog()
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
            this.Property(p => p.Season)
                .HasColumnName(ColumnName.Season)
                .HasColumnOrder(1)
                .HasColumnType(ColumnType.SmallInt)
                .IsRequired();

            this.Property(p => p.Week)
                .HasColumnName(ColumnName.Week)
                .HasColumnOrder(2)
                .HasColumnType(ColumnType.TinyInt)
                .IsRequired();

            this.Property(p => p.Age)
                .HasColumnName(ColumnName.Age)
                .HasColumnOrder(3)
                .HasColumnType(ColumnType.TinyInt)
                .IsRequired();

            this.Property(p => p.HealthStatus)
                .HasColumnName(ColumnName.HealthStatus)
                .HasColumnOrder(4)
                .HasColumnType(ColumnType.Integer)
                .IsRequired();

            this.Property(p => p.CareerGoals)
                .HasColumnName(ColumnName.CareerGoals)
                .HasColumnOrder(5)
                .HasColumnType(ColumnType.SmallInt)
                .IsRequired();

            this.Property(p => p.CareerHattricks)
                .HasColumnName(ColumnName.CareerHattricks)
                .HasColumnOrder(6)
                .HasColumnType(ColumnType.SmallInt)
                .IsRequired();

            this.Property(p => p.SeriesGoals)
                .HasColumnName(ColumnName.SeriesGoals)
                .HasColumnOrder(7)
                .HasColumnType(ColumnType.TinyInt)
                .IsRequired();

            this.Property(p => p.CupGoals)
                .HasColumnName(ColumnName.CupGoals)
                .HasColumnOrder(8)
                .HasColumnType(ColumnType.TinyInt)
                .IsRequired();

            this.Property(p => p.FriendlyGoals)
                .HasColumnName(ColumnName.FriendlyGoals)
                .HasColumnOrder(9)
                .HasColumnType(ColumnType.TinyInt)
                .IsRequired();

            this.Property(p => p.Form)
                .HasColumnName(ColumnName.Form)
                .HasColumnOrder(10)
                .HasColumnType(ColumnType.TinyInt)
                .IsOptional();

            this.Property(p => p.Stamina)
                .HasColumnName(ColumnName.Stamina)
                .HasColumnOrder(11)
                .HasColumnType(ColumnType.TinyInt)
                .IsOptional();

            this.Property(p => p.Keeper)
                .HasColumnName(ColumnName.Keeper)
                .HasColumnOrder(12)
                .HasColumnType(ColumnType.TinyInt)
                .IsOptional();

            this.Property(p => p.Defending)
                .HasColumnName(ColumnName.Defending)
                .HasColumnOrder(13)
                .HasColumnType(ColumnType.TinyInt)
                .IsOptional();

            this.Property(p => p.Playmaking)
                .HasColumnName(ColumnName.Playmaking)
                .HasColumnOrder(14)
                .HasColumnType(ColumnType.TinyInt)
                .IsOptional();

            this.Property(p => p.Passing)
                .HasColumnName(ColumnName.Passing)
                .HasColumnOrder(15)
                .HasColumnType(ColumnType.TinyInt)
                .IsOptional();

            this.Property(p => p.Winger)
                .HasColumnName(ColumnName.Winger)
                .HasColumnOrder(16)
                .HasColumnType(ColumnType.TinyInt)
                .IsOptional();

            this.Property(p => p.Scoring)
                .HasColumnName(ColumnName.Scoring)
                .HasColumnOrder(17)
                .HasColumnType(ColumnType.TinyInt)
                .IsOptional();

            this.Property(p => p.SetPieces)
                .HasColumnName(ColumnName.SetPieces)
                .HasColumnOrder(18)
                .HasColumnType(ColumnType.TinyInt)
                .IsOptional();

            this.Property(p => p.Loyalty)
                .HasColumnName(ColumnName.Loyalty)
                .HasColumnOrder(19)
                .HasColumnType(ColumnType.TinyInt)
                .IsOptional();

            this.Property(p => p.Experience)
                .HasColumnName(ColumnName.Experience)
                .HasColumnOrder(20)
                .HasColumnType(ColumnType.TinyInt)
                .IsOptional();

            this.Property(p => p.TotalSkillIndex)
                .HasColumnName(ColumnName.TotalSkillIndex)
                .HasColumnOrder(21)
                .HasColumnType(ColumnType.Integer)
                .IsOptional();

            this.Property(p => p.Wage)
                .HasColumnName(ColumnName.Wage)
                .HasColumnOrder(22)
                .HasColumnType(ColumnType.Integer)
                .IsOptional();
        }

        /// <summary>
        /// Register entity relationships.
        /// </summary>
        public void RegisterRelationships()
        {
            this.HasRequired(r => r.SeniorPlayer)
                .WithMany(r => r.WeekLogs)
                .HasForeignKey(r => r.SeniorPlayerId)
                .WillCascadeOnDelete(true);
        }

        /// <summary>
        /// Register entity table mapping.
        /// </summary>
        public void RegisterTable()
        {
            this.ToTable(TableName.SeniorPlayerWeekLog, SchemaName.Default);
        }

        #endregion Public Methods
    }
}