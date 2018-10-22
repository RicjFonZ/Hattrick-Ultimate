//-----------------------------------------------------------------------
// <copyright file="LeagueCup.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.DataAccess.Database.Mapping
{
    using Constants;
    using Interface;

    /// <summary>
    /// LeagueCup entity mapping implementation.
    /// </summary>
    internal class LeagueCup : HattrickEntity<BusinessObjects.App.LeagueCup>, IMapping
    {
        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="LeagueCup"/> class.
        /// </summary>
        internal LeagueCup()
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
            this.Property(p => p.Name)
                .HasColumnName(ColumnName.Name)
                .HasColumnOrder(2)
                .HasColumnType(ColumnType.UnicodeVarChar)
                .HasMaxLength(ColumnLength.ShortText)
                .IsRequired();

            this.Property(p => p.Type)
                .HasColumnName(ColumnName.Type)
                .HasColumnOrder(3)
                .HasColumnType(ColumnType.TinyInt)
                .IsRequired();

            this.Property(p => p.Tier)
                .HasColumnName(ColumnName.Tier)
                .HasColumnOrder(4)
                .HasColumnType(ColumnType.TinyInt)
                .IsOptional();

            this.Property(p => p.Division)
                .HasColumnName(ColumnName.Division)
                .HasColumnOrder(5)
                .HasColumnType(ColumnType.TinyInt)
                .IsOptional();

            this.Property(p => p.CurrentRound)
                .HasColumnName(ColumnName.CurrentRound)
                .HasColumnOrder(6)
                .HasColumnType(ColumnType.TinyInt)
                .IsRequired();

            this.Property(p => p.RoundsLeft)
                .HasColumnName(ColumnName.RoundsLeft)
                .HasColumnOrder(7)
                .HasColumnType(ColumnType.TinyInt)
                .IsRequired();
        }

        /// <summary>
        /// Register entity relationships.
        /// </summary>
        public void RegisterRelationships()
        {
            this.HasRequired(r => r.League)
                .WithMany(r => r.Cups)
                .HasForeignKey(r => r.LeagueId);
        }

        /// <summary>
        /// Register entity table mapping.
        /// </summary>
        public void RegisterTable()
        {
            this.ToTable(TableName.LeagueCup, SchemaName.Default);
        }

        #endregion Public Methods
    }
}