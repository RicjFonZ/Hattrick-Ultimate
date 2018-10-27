//-----------------------------------------------------------------------
// <copyright file="JuniorPlayerWeekLog.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.DataAccess.Database.Mapping
{
    using Hyperar.HattrickUltimate.DataAccess.Database.Constants;
    using Interface;

    /// <summary>
    /// JuniorPlayerWeekLog entity mapping implementation.
    /// </summary>
    internal class JuniorPlayerWeekLog : Entity<BusinessObjects.App.JuniorPlayerWeekLog>, IMapping
    {
        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="JuniorPlayerWeekLog"/> class.
        /// </summary>
        internal JuniorPlayerWeekLog()
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

            this.Property(p => p.FriendlyGoals)
                .HasColumnName(ColumnName.FriendlyGoals)
                .HasColumnOrder(8)
                .HasColumnType(ColumnType.TinyInt)
                .IsRequired();

            this.Property(p => p.Keeper)
                .HasColumnName(ColumnName.Keeper)
                .HasColumnOrder(9)
                .HasColumnType(ColumnType.TinyInt)
                .IsOptional();

            this.Property(p => p.KeeperMax)
                .HasColumnName(ColumnName.KeeperMax)
                .HasColumnOrder(10)
                .HasColumnType(ColumnType.TinyInt)
                .IsOptional();

            this.Property(p => p.KeeperMaxReached)
                .HasColumnName(ColumnName.KeeperMaxReached)
                .HasColumnOrder(11)
                .HasColumnType(ColumnType.Boolean)
                .IsRequired();

            this.Property(p => p.Defending)
                .HasColumnName(ColumnName.Defending)
                .HasColumnOrder(12)
                .HasColumnType(ColumnType.TinyInt)
                .IsOptional();

            this.Property(p => p.DefendingMax)
                .HasColumnName(ColumnName.DefendingMax)
                .HasColumnOrder(13)
                .HasColumnType(ColumnType.TinyInt)
                .IsOptional();

            this.Property(p => p.DefendingMaxReached)
                .HasColumnName(ColumnName.DefendingMaxReached)
                .HasColumnOrder(14)
                .HasColumnType(ColumnType.Boolean)
                .IsRequired();

            this.Property(p => p.Playmaking)
                .HasColumnName(ColumnName.Playmaking)
                .HasColumnOrder(15)
                .HasColumnType(ColumnType.TinyInt)
                .IsOptional();

            this.Property(p => p.PlaymakingMax)
                .HasColumnName(ColumnName.PlaymakingMax)
                .HasColumnOrder(16)
                .HasColumnType(ColumnType.TinyInt)
                .IsOptional();

            this.Property(p => p.PlaymakingMaxReached)
                .HasColumnName(ColumnName.PlaymakingMaxReached)
                .HasColumnOrder(17)
                .HasColumnType(ColumnType.Boolean)
                .IsRequired();

            this.Property(p => p.Passing)
                .HasColumnName(ColumnName.Passing)
                .HasColumnOrder(18)
                .HasColumnType(ColumnType.TinyInt)
                .IsOptional();

            this.Property(p => p.PassingMax)
                .HasColumnName(ColumnName.PassingMax)
                .HasColumnOrder(19)
                .HasColumnType(ColumnType.TinyInt)
                .IsOptional();

            this.Property(p => p.PassingMaxReached)
                .HasColumnName(ColumnName.PassingMaxReached)
                .HasColumnOrder(20)
                .HasColumnType(ColumnType.Boolean)
                .IsRequired();

            this.Property(p => p.Winger)
                .HasColumnName(ColumnName.Winger)
                .HasColumnOrder(21)
                .HasColumnType(ColumnType.TinyInt)
                .IsOptional();

            this.Property(p => p.WingerMax)
                .HasColumnName(ColumnName.WingerMax)
                .HasColumnOrder(22)
                .HasColumnType(ColumnType.TinyInt)
                .IsOptional();

            this.Property(p => p.WingerMaxReached)
                .HasColumnName(ColumnName.WingerMaxReached)
                .HasColumnOrder(23)
                .HasColumnType(ColumnType.Boolean)
                .IsRequired();

            this.Property(p => p.Scoring)
                .HasColumnName(ColumnName.Scoring)
                .HasColumnOrder(24)
                .HasColumnType(ColumnType.TinyInt)
                .IsOptional();

            this.Property(p => p.ScoringMax)
                .HasColumnName(ColumnName.ScoringMax)
                .HasColumnOrder(25)
                .HasColumnType(ColumnType.TinyInt)
                .IsOptional();

            this.Property(p => p.ScoringMaxReached)
                .HasColumnName(ColumnName.ScoringMaxReached)
                .HasColumnOrder(26)
                .HasColumnType(ColumnType.Boolean)
                .IsRequired();

            this.Property(p => p.SetPieces)
                .HasColumnName(ColumnName.SetPieces)
                .HasColumnOrder(27)
                .HasColumnType(ColumnType.TinyInt)
                .IsOptional();

            this.Property(p => p.SetPiecesMax)
                .HasColumnName(ColumnName.SetPiecesMax)
                .HasColumnOrder(28)
                .HasColumnType(ColumnType.TinyInt)
                .IsOptional();

            this.Property(p => p.SetPiecesMaxReached)
                .HasColumnName(ColumnName.SetPiecesMaxReached)
                .HasColumnOrder(29)
                .HasColumnType(ColumnType.Boolean)
                .IsRequired();
        }

        /// <summary>
        /// Register entity relationships.
        /// </summary>
        public void RegisterRelationships()
        {
            this.HasRequired(r => r.JuniorPlayer)
                .WithMany(r => r.WeekLogs)
                .HasForeignKey(r => r.JuniorPlayerId)
                .WillCascadeOnDelete(true);
        }

        /// <summary>
        /// Register entity table mapping.
        /// </summary>
        public void RegisterTable()
        {
            this.ToTable(TableName.JuniorPlayerWeekLog, SchemaName.Default);
        }

        #endregion Public Methods
    }
}