//-----------------------------------------------------------------------
// <copyright file="SeniorPlayerWithSkillDelta.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.DataAccess.Database.Mapping
{
    using Constants;
    using Interface;

    /// <summary>
    /// SeniorPlayerWithSkillDelta entity mapping implementation.
    /// </summary>
    internal class SeniorPlayerWithSkillDelta : Entity<BusinessObjects.App.SeniorPlayerWithSkillDelta>, IMapping
    {
        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SeniorPlayerWithSkillDelta" /> class.
        /// </summary>
        internal SeniorPlayerWithSkillDelta()
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
                .IsRequired();

            this.Property(p => p.NickName)
                .HasColumnName(ColumnName.NickName)
                .HasColumnOrder(3)
                .HasColumnType(ColumnType.UnicodeVarChar)
                .IsOptional();

            this.Property(p => p.LastName)
                .HasColumnName(ColumnName.LastName)
                .HasColumnOrder(4)
                .HasColumnType(ColumnType.UnicodeVarChar)
                .IsRequired();

            this.Property(p => p.Age)
                .HasColumnName(ColumnName.Age)
                .HasColumnOrder(5)
                .HasColumnType(ColumnType.Numeric)
                .HasPrecision(Precision.Age, Scale.Age)
                .IsRequired();

            this.Property(p => p.HasHomegrownBonus)
                .HasColumnName(ColumnName.HasHomegrownBonus)
                .HasColumnOrder(6)
                .HasColumnType(ColumnType.Boolean)
                .IsRequired();

            this.Property(p => p.ShirtNumber)
                .HasColumnName(ColumnName.ShirtNumber)
                .HasColumnOrder(7)
                .HasColumnType(ColumnType.TinyInt)
                .IsOptional();

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
                .HasColumnType(ColumnType.Integer)
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
                .HasColumnType(ColumnType.SmallInt)
                .IsRequired();

            this.Property(p => p.MatchesOnJuniorNationalTeam)
                .HasColumnName(ColumnName.MatchesOnJuniorNationalTeam)
                .HasColumnOrder(21)
                .HasColumnType(ColumnType.SmallInt)
                .IsRequired();

            this.Property(p => p.Category)
                .HasColumnName(ColumnName.Category)
                .HasColumnOrder(22)
                .HasColumnType(ColumnType.TinyInt)
                .IsOptional();

            this.Property(p => p.CountryId)
                .HasColumnName(ColumnName.CountryId)
                .HasColumnOrder(23)
                .HasColumnType(ColumnType.Integer)
                .IsRequired();

            this.Property(p => p.CountryHattrickId)
                .HasColumnName(ColumnName.CountryHattrickId)
                .HasColumnOrder(24)
                .HasColumnType(ColumnType.BigInt)
                .IsRequired();

            this.Property(p => p.CountryName)
                .HasColumnName(ColumnName.CountryName)
                .HasColumnOrder(25)
                .HasColumnType(ColumnType.UnicodeVarChar)
                .IsRequired();

            this.Property(p => p.CountryEnglishName)
                .HasColumnName(ColumnName.CountryEnglishName)
                .HasColumnOrder(26)
                .HasColumnType(ColumnType.UnicodeVarChar)
                .IsRequired();

            this.Property(p => p.Form)
                .HasColumnName(ColumnName.Form)
                .HasColumnOrder(27)
                .HasColumnType(ColumnType.Integer)
                .IsRequired();

            this.Property(p => p.Stamina)
                .HasColumnName(ColumnName.Stamina)
                .HasColumnOrder(28)
                .HasColumnType(ColumnType.Integer)
                .IsRequired();

            this.Property(p => p.Defending)
                .HasColumnName(ColumnName.Defending)
                .HasColumnOrder(29)
                .HasColumnType(ColumnType.Integer)
                .IsRequired();

            this.Property(p => p.Playmaking)
                .HasColumnName(ColumnName.Playmaking)
                .HasColumnOrder(30)
                .HasColumnType(ColumnType.Integer)
                .IsRequired();

            this.Property(p => p.Winger)
                .HasColumnName(ColumnName.Winger)
                .HasColumnOrder(31)
                .HasColumnType(ColumnType.Integer)
                .IsRequired();

            this.Property(p => p.Passing)
                .HasColumnName(ColumnName.Passing)
                .HasColumnOrder(32)
                .HasColumnType(ColumnType.Integer)
                .IsRequired();

            this.Property(p => p.Scoring)
                .HasColumnName(ColumnName.Scoring)
                .HasColumnOrder(33)
                .HasColumnType(ColumnType.Integer)
                .IsRequired();

            this.Property(p => p.SetPieces)
                .HasColumnName(ColumnName.SetPieces)
                .HasColumnOrder(34)
                .HasColumnType(ColumnType.Integer)
                .IsRequired();

            this.Property(p => p.Loyalty)
                .HasColumnName(ColumnName.Loyalty)
                .HasColumnOrder(35)
                .HasColumnType(ColumnType.Integer)
                .IsRequired();

            this.Property(p => p.Experience)
                .HasColumnName(ColumnName.Experience)
                .HasColumnOrder(36)
                .HasColumnType(ColumnType.Integer)
                .IsRequired();

            this.Property(p => p.TotalSkillIndex)
                .HasColumnName(ColumnName.TotalSkillIndex)
                .HasColumnOrder(37)
                .HasColumnType(ColumnType.Integer)
                .IsRequired();

            this.Property(p => p.FormDelta)
                .HasColumnName(ColumnName.FormDelta)
                .HasColumnOrder(38)
                .HasColumnType(ColumnType.Integer)
                .IsOptional();

            this.Property(p => p.StaminaDelta)
                .HasColumnName(ColumnName.StaminaDelta)
                .HasColumnOrder(39)
                .HasColumnType(ColumnType.Integer)
                .IsOptional();

            this.Property(p => p.DefendingDelta)
                .HasColumnName(ColumnName.DefendingDelta)
                .HasColumnOrder(40)
                .HasColumnType(ColumnType.Integer)
                .IsOptional();

            this.Property(p => p.PlaymakingDelta)
                .HasColumnName(ColumnName.PlaymakingDelta)
                .HasColumnOrder(41)
                .HasColumnType(ColumnType.Integer)
                .IsOptional();

            this.Property(p => p.WingerDelta)
                .HasColumnName(ColumnName.WingerDelta)
                .HasColumnOrder(42)
                .HasColumnType(ColumnType.Integer)
                .IsOptional();

            this.Property(p => p.PassingDelta)
                .HasColumnName(ColumnName.PassingDelta)
                .HasColumnOrder(43)
                .HasColumnType(ColumnType.Integer)
                .IsOptional();

            this.Property(p => p.ScoringDelta)
                .HasColumnName(ColumnName.ScoringDelta)
                .HasColumnOrder(44)
                .HasColumnType(ColumnType.Integer)
                .IsOptional();

            this.Property(p => p.SetPiecesDelta)
                .HasColumnName(ColumnName.SetPiecesDelta)
                .HasColumnOrder(45)
                .HasColumnType(ColumnType.Integer)
                .IsOptional();

            this.Property(p => p.LoyaltyDelta)
                .HasColumnName(ColumnName.LoyaltyDelta)
                .HasColumnOrder(46)
                .HasColumnType(ColumnType.Integer)
                .IsOptional();

            this.Property(p => p.ExperienceDelta)
                .HasColumnName(ColumnName.ExperienceDelta)
                .HasColumnOrder(47)
                .HasColumnType(ColumnType.Integer)
                .IsOptional();

            this.Property(p => p.TotalSkillIndexDelta)
                .HasColumnName(ColumnName.TotalSkillIndexDelta)
                .HasColumnOrder(48)
                .HasColumnType(ColumnType.Integer)
                .IsOptional();

            this.Property(p => p.SeniorTeamId)
                .HasColumnName(ColumnName.SeniorTeamId)
                .HasColumnOrder(49)
                .HasColumnType(ColumnType.Integer)
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
            this.ToTable(TableName.SeniorPlayerWithSkillDelta, SchemaName.Application);
        }

        #endregion Public Methods
    }
}