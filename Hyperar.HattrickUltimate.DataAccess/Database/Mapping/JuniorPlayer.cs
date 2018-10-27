//-----------------------------------------------------------------------
// <copyright file="JuniorPlayer.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.DataAccess.Database.Mapping
{
    using Constants;
    using Interface;

    /// <summary>
    /// JuniorPlayer entity mapping implementation.
    /// </summary>
    internal class JuniorPlayer : HattrickEntity<BusinessObjects.App.JuniorPlayer>, IMapping
    {
        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="JuniorPlayer"/> class.
        /// </summary>
        internal JuniorPlayer()
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

            this.Property(p => p.AgeDays)
                .HasColumnName(ColumnName.AgeDays)
                .HasColumnOrder(5)
                .HasColumnType(ColumnType.TinyInt)
                .IsRequired();

            this.Property(p => p.ShirtNumber)
                .HasColumnName(ColumnName.ShirtNumber)
                .HasColumnOrder(6)
                .HasColumnType(ColumnType.TinyInt)
                .IsOptional();

            this.Property(p => p.Statement)
                .HasColumnName(ColumnName.Statement)
                .HasColumnOrder(7)
                .HasColumnType(ColumnType.UnicodeVarChar)
                .HasMaxLength(ColumnLength.ShortText)
                .IsOptional();

            this.Property(p => p.OwnerNotes)
                .HasColumnName(ColumnName.OwnerNotes)
                .HasColumnOrder(8)
                .HasColumnType(ColumnType.UnicodeVarChar)
                .HasMaxLength(ColumnLength.ShortText)
                .IsOptional();

            this.Property(p => p.ArrivedOn)
                .HasColumnName(ColumnName.ArrivedOn)
                .HasColumnOrder(9)
                .HasColumnType(ColumnType.DateTime)
                .IsRequired();

            this.Property(p => p.DaysToPromote)
                .HasColumnName(ColumnName.DaysToPromote)
                .HasColumnOrder(10)
                .HasColumnType(ColumnType.Integer)
                .IsRequired();

            this.Property(p => p.Specialty)
                .HasColumnName(ColumnName.Specialty)
                .HasColumnOrder(11)
                .HasColumnType(ColumnType.TinyInt)
                .IsOptional();

            this.Property(p => p.BookingStatus)
                .HasColumnName(ColumnName.BookingStatus)
                .HasColumnOrder(12)
                .HasColumnType(ColumnType.TinyInt)
                .IsRequired();

            this.Property(p => p.Category)
                .HasColumnName(ColumnName.Category)
                .HasColumnOrder(13)
                .HasColumnType(ColumnType.TinyInt)
                .IsOptional();
        }

        /// <summary>
        /// Register entity relationships.
        /// </summary>
        public void RegisterRelationships()
        {
            this.HasRequired(r => r.JuniorTeam)
                .WithMany(r => r.JuniorPlayers)
                .HasForeignKey(r => r.JuniorTeamId)
                .WillCascadeOnDelete(false);
        }

        /// <summary>
        /// Register entity table mapping.
        /// </summary>
        public void RegisterTable()
        {
            this.ToTable(TableName.JuniorPlayer, SchemaName.Default);
        }

        #endregion Public Methods
    }
}