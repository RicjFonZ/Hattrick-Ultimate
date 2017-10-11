﻿//-----------------------------------------------------------------------
// <copyright file="SeniorPlayer.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.DataAccess.Database.Mapping
{
    using Constants;
    using Interface;

    /// <summary>
    /// SeniorPlayer entity mapping implementation.
    /// </summary>
    internal class SeniorPlayer : HattrickEntity<BusinessObjects.App.SeniorPlayer>, IMapping
    {
        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SeniorPlayer" /> class.
        /// </summary>
        internal SeniorPlayer()
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
            this.Property(p => p.FirstName)
                .HasColumnName(ColumnName.FirstName)
                .HasColumnOrder(2)
                .HasColumnType(ColumnType.UnicodeVarChar)
                .HasMaxLength(ColumnLength.ShortText)
                .IsRequired();

            this.Property(p => p.NickName)
                .HasColumnName(ColumnName.NickName)
                .HasColumnOrder(3)
                .HasColumnType(ColumnType.UnicodeVarChar)
                .HasMaxLength(ColumnLength.ShortText)
                .IsOptional();

            this.Property(p => p.LastName)
                .HasColumnName(ColumnName.LastName)
                .HasColumnOrder(4)
                .HasColumnType(ColumnType.UnicodeVarChar)
                .HasMaxLength(ColumnLength.ShortText)
                .IsRequired();

            this.Property(p => p.Age)
                .HasColumnName(ColumnName.Age)
                .HasColumnOrder(5)
                .HasColumnType(ColumnType.Numeric)
                .HasPrecision(Precision.Age, Scale.Age)
                .IsRequired();

            this.Property(p => p.Statement)
                .HasColumnName(ColumnName.Statement)
                .HasColumnOrder(6)
                .HasColumnType(ColumnType.UnicodeVarChar)
                .HasMaxLength(ColumnLength.ShortText)
                .IsOptional();

            this.Property(p => p.HasHomegrownBonus)
                .HasColumnName(ColumnName.HasHomegrownBonus)
                .HasColumnOrder(7)
                .HasColumnType(ColumnType.Boolean)
                .IsRequired();

            this.Property(p => p.Agreeability)
                .HasColumnName(ColumnName.Agreeability)
                .HasColumnOrder(8)
                .HasColumnType(ColumnType.TinyInt)
                .IsRequired();

            this.Property(p => p.Aggressiveness)
                .HasColumnName(ColumnName.Aggressiveness)
                .HasColumnOrder(9)
                .HasColumnType(ColumnType.TinyInt)
                .IsRequired();

            this.Property(p => p.Honesty)
                .HasColumnName(ColumnName.Honesty)
                .HasColumnOrder(10)
                .HasColumnType(ColumnType.TinyInt)
                .IsRequired();

            this.Property(p => p.Leadership)
                .HasColumnName(ColumnName.Leadership)
                .HasColumnOrder(11)
                .HasColumnType(ColumnType.TinyInt)
                .IsRequired();

            this.Property(p => p.Specialty)
                .HasColumnName(ColumnName.Specialty)
                .HasColumnOrder(12)
                .HasColumnType(ColumnType.TinyInt)
                .IsRequired();

            this.Property(p => p.Wage)
                .HasColumnName(ColumnName.Wage)
                .HasColumnOrder(13)
                .HasColumnType(ColumnType.Integer)
                .IsRequired();

            this.Property(p => p.CareerGoals)
                .HasColumnName(ColumnName.CareerGoals)
                .HasColumnOrder(14)
                .HasColumnType(ColumnType.SmallInt)
                .IsRequired();

            this.Property(p => p.CareerHattricks)
                .HasColumnName(ColumnName.CareerHattricks)
                .HasColumnOrder(15)
                .HasColumnType(ColumnType.SmallInt)
                .IsRequired();

            this.Property(p => p.BookingStatus)
                .HasColumnName(ColumnName.BookingStatus)
                .HasColumnOrder(16)
                .HasColumnType(ColumnType.TinyInt)
                .IsRequired();

            this.Property(p => p.InjuryStatus)
                .HasColumnName(ColumnName.InjuryStatus)
                .HasColumnOrder(17)
                .HasColumnType(ColumnType.TinyInt)
                .IsOptional();

            this.Property(p => p.PlaysOnNationalTeam)
                .HasColumnName(ColumnName.PlaysOnNationalTeam)
                .HasColumnOrder(18)
                .HasColumnType(ColumnType.Boolean)
                .IsRequired();

            this.Property(p => p.IsOnTransferMarket)
                .HasColumnName(ColumnName.IsOnTransferMarket)
                .HasColumnOrder(19)
                .HasColumnType(ColumnType.Boolean)
                .IsRequired();

            this.Property(p => p.MatchesOnSeniorNationalTeam)
                .HasColumnName(ColumnName.MatchesOnSeniorNationalTeam)
                .HasColumnOrder(20)
                .HasColumnType(ColumnType.BigInt)
                .IsRequired();

            this.Property(p => p.MatchesOnJuniorNationalTeam)
                .HasColumnName(ColumnName.MatchesOnJuniorNationalTeam)
                .HasColumnOrder(21)
                .HasColumnType(ColumnType.BigInt)
                .IsRequired();

            this.Property(p => p.Category)
                .HasColumnName(ColumnName.Category)
                .HasColumnOrder(22)
                .HasColumnType(ColumnType.TinyInt)
                .IsOptional();
        }

        /// <summary>
        /// Register entity relationships.
        /// </summary>
        public void RegisterRelationships()
        {
            this.HasRequired(r => r.SeniorTeam)
                .WithMany(r => r.SeniorPlayers)
                .HasForeignKey(r => r.SeniorTeamId)
                .WillCascadeOnDelete(false);

            this.HasRequired(r => r.Country)
                .WithMany(r => r.SeniorPlayers)
                .HasForeignKey(r => r.CountryId);
        }

        /// <summary>
        /// Register entity table mapping.
        /// </summary>
        public void RegisterTable()
        {
            this.ToTable(TableName.SeniorPlayer);
        }

        #endregion Public Methods
    }
}