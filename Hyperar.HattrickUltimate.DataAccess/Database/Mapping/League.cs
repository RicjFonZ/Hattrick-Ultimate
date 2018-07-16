//-----------------------------------------------------------------------
// <copyright file="League.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.DataAccess.Database.Mapping
{
    using Constants;
    using Interface;

    /// <summary>
    /// League entity mapping implementation.
    /// </summary>
    internal class League : HattrickEntity<BusinessObjects.App.League>, IMapping
    {
        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="League" /> class.
        /// </summary>
        internal League()
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

            this.Property(p => p.CurrentSeason)
                .HasColumnName(ColumnName.CurrentSeason)
                .HasColumnOrder(5)
                .HasColumnType(ColumnType.SmallInt)
                .IsRequired();

            this.Property(p => p.SeasonOffset)
                .HasColumnName(ColumnName.SeasonOffset)
                .HasColumnOrder(6)
                .HasColumnType(ColumnType.SmallInt)
                .IsRequired();

            this.Property(p => p.CurrentRound)
                .HasColumnName(ColumnName.CurrentRound)
                .HasColumnOrder(7)
                .HasColumnType(ColumnType.TinyInt)
                .IsRequired();

            this.Property(p => p.Divisions)
                .HasColumnName(ColumnName.Divisions)
                .HasColumnOrder(8)
                .HasColumnType(ColumnType.TinyInt)
                .IsRequired();

            this.Property(p => p.ActiveTeams)
                .HasColumnName(ColumnName.ActiveTeams)
                .HasColumnOrder(9)
                .HasColumnType(ColumnType.Integer)
                .IsRequired();

            this.Property(p => p.ActiveUsers)
                .HasColumnName(ColumnName.ActiveUsers)
                .HasColumnOrder(10)
                .HasColumnType(ColumnType.Integer)
                .IsRequired();

            this.Property(p => p.WaitingUsers)
                .HasColumnName(ColumnName.WaitingUsers)
                .HasColumnOrder(11)
                .HasColumnType(ColumnType.Integer)
                .IsRequired();
        }

        /// <summary>
        /// Register entity relationships.
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
        /// Register entity table mapping.
        /// </summary>
        public void RegisterTable()
        {
            this.ToTable(TableName.League, SchemaName.Default);
        }

        #endregion Public Methods
    }
}