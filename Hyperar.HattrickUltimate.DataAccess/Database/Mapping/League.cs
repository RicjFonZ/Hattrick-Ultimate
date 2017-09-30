//-----------------------------------------------------------------------
// <copyright file="League.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.DataAccess.Database.Mapping
{
    using Constants;

    /// <summary>
    /// League entity mapping.
    /// </summary>
    internal class League : HattrickEntity<BusinessObjects.App.League>
    {
        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="League"/> class.
        /// </summary>
        public League()
        {
            this.RegisterTable();
            this.RegisterProperties();
            this.RegisterRelationships();
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// Registers the Entity database table columns.
        /// </summary>
        public void RegisterProperties()
        {
            this.Property(p => p.FullName)
                .HasColumnName(ColumnName.FullName)
                .HasColumnOrder(2)
                .HasColumnType(ColumnType.UnicodeVarChar)
                .HasMaxLength(ColumnLength.MediumText)
                .IsRequired();

            this.Property(p => p.ShortName)
                .HasColumnName(ColumnName.ShortName)
                .HasColumnOrder(3)
                .HasColumnType(ColumnType.UnicodeVarChar)
                .HasMaxLength(ColumnLength.ShortText)
                .IsRequired();

            this.Property(p => p.EnglishName)
                .HasColumnName(ColumnName.EnglishName)
                .HasColumnOrder(4)
                .HasColumnType(ColumnType.UnicodeVarChar)
                .HasMaxLength(ColumnLength.ShortText)
                .IsRequired();

            this.Property(p => p.SeasonOffset)
                .HasColumnName(ColumnName.SeasonOffset)
                .HasColumnOrder(5)
                .HasColumnType(ColumnType.Integer)
                .IsOptional();

            this.Property(p => p.SeniorNationalTeamId)
                .HasColumnName(ColumnName.SeniorNationalTeamId)
                .HasColumnOrder(6)
                .HasColumnType(ColumnType.BigInteger)
                .IsOptional();

            this.Property(p => p.JuniorNationalTeamId)
                .HasColumnName(ColumnName.JuniorNationalTeamId)
                .HasColumnOrder(7)
                .HasColumnType(ColumnType.BigInteger)
                .IsOptional();

            this.Property(p => p.ActiveTeams)
                .HasColumnName(ColumnName.ActiveTeams)
                .HasColumnOrder(8)
                .HasColumnType(ColumnType.Integer)
                .IsOptional();

            this.Property(p => p.ActiveUsers)
                .HasColumnName(ColumnName.ActiveUsers)
                .HasColumnOrder(9)
                .HasColumnType(ColumnType.Integer)
                .IsOptional();

            this.Property(p => p.WaitingUsers)
                .HasColumnName(ColumnName.WaitingUsers)
                .HasColumnOrder(10)
                .HasColumnType(ColumnType.Integer)
                .IsOptional();

            this.Property(p => p.Divisions)
                .HasColumnName(ColumnName.Divisions)
                .HasColumnOrder(11)
                .HasColumnType(ColumnType.Integer)
                .IsRequired();
        }

        /// <summary>
        /// Registers the Entity relationships.
        /// </summary>
        public void RegisterRelationships()
        {
            this.HasRequired(r => r.Continent)
                .WithMany(r => r.Leagues)
                .HasForeignKey(r => r.ContinentId);

            this.HasRequired(r => r.Zone)
                .WithMany(r => r.Leagues)
                .HasForeignKey(r => r.ZoneId);
        }

        /// <summary>
        /// Registers the Entity to it's database table.
        /// </summary>
        public void RegisterTable()
        {
            this.ToTable(TableName.League);
        }

        #endregion Public Methods
    }
}