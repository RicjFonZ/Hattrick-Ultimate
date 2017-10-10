//-----------------------------------------------------------------------
// <copyright file="LeagueSchedule.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.DataAccess.Database.Mapping
{
    using Constants;
    using Interface;

    /// <summary>
    /// LeagueSchedule entity mapping implementation.
    /// </summary>
    internal class LeagueSchedule : Entity<BusinessObjects.App.LeagueSchedule>, IMapping
    {
        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="LeagueSchedule" /> class.
        /// </summary>
        internal LeagueSchedule()
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
            this.Property(p => p.TrainingUpdateDayOfWeek)
                .HasColumnName(ColumnName.TrainingUpdateDayOfWeek)
                .HasColumnOrder(1)
                .HasColumnType(ColumnType.TinyInt)
                .IsRequired();

            this.Property(p => p.TrainingUpdateTimeOfDay)
                .HasColumnName(ColumnName.TrainingUpdateTimeOfDay)
                .HasColumnOrder(2)
                .HasColumnType(ColumnType.Time)
                .IsRequired();

            this.Property(p => p.EconomyUpdateDayOfWeek)
                .HasColumnName(ColumnName.EconomyUpdateDayOfWeek)
                .HasColumnOrder(3)
                .HasColumnType(ColumnType.TinyInt)
                .IsRequired();

            this.Property(p => p.EconomyUpdateTimeOfDay)
                .HasColumnName(ColumnName.EconomyUpdateTimeOfDay)
                .HasColumnOrder(4)
                .HasColumnType(ColumnType.Time)
                .IsRequired();

            this.Property(p => p.SeriesMatchDayOfWeek)
                .HasColumnName(ColumnName.SeriesMatchDayOfWeek)
                .HasColumnOrder(5)
                .HasColumnType(ColumnType.TinyInt)
                .IsRequired();

            this.Property(p => p.SeriesMatchTimeOfDay)
                .HasColumnName(ColumnName.SeriesMatchTimeOfDay)
                .HasColumnOrder(6)
                .HasColumnType(ColumnType.Time)
                .IsRequired();

            this.Property(p => p.CupMatchDayOfWeek)
                .HasColumnName(ColumnName.CupMatchDayOfWeek)
                .HasColumnOrder(7)
                .HasColumnType(ColumnType.TinyInt)
                .IsRequired();

            this.Property(p => p.CupMatchTimeOfDay)
                .HasColumnName(ColumnName.CupMatchTimeOfDay)
                .HasColumnOrder(8)
                .HasColumnType(ColumnType.Time)
                .IsRequired();
        }

        /// <summary>
        /// Register entity relationships.
        /// </summary>
        public void RegisterRelationships()
        {
            this.HasRequired(r => r.League)
                .WithOptional(r => r.Schedule)
                .Map(m =>
                {
                    m.ToTable(TableName.LeagueSchedule);
                    m.MapKey(ColumnName.LeagueId);
                });
        }

        /// <summary>
        /// Register entity table mapping.
        /// </summary>
        public void RegisterTable()
        {
            this.ToTable(TableName.LeagueSchedule);
        }

        #endregion Public Methods
    }
}