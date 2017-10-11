//-----------------------------------------------------------------------
// <copyright file="SeniorPlayerSkills.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.DataAccess.Database.Mapping
{
    using Constants;
    using Interface;

    /// <summary>
    /// SeniorPlayerSkills entity mapping implementation.
    /// </summary>
    internal class SeniorPlayerSkills : Entity<BusinessObjects.App.SeniorPlayerSkills>, IMapping
    {
        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SeniorPlayerSkills" /> class.
        /// </summary>
        internal SeniorPlayerSkills()
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
            this.Property(p => p.Form)
                .HasColumnName(ColumnName.Form)
                .HasColumnOrder(2)
                .HasColumnType(ColumnType.TinyInt)
                .IsRequired();

            this.Property(p => p.Stamina)
                .HasColumnName(ColumnName.Stamina)
                .HasColumnOrder(3)
                .HasColumnType(ColumnType.TinyInt)
                .IsRequired();

            this.Property(p => p.Keeper)
                .HasColumnName(ColumnName.Keeper)
                .HasColumnOrder(4)
                .HasColumnType(ColumnType.TinyInt)
                .IsRequired();

            this.Property(p => p.Defending)
                .HasColumnName(ColumnName.Defending)
                .HasColumnOrder(5)
                .HasColumnType(ColumnType.TinyInt)
                .IsRequired();

            this.Property(p => p.Playmaking)
                .HasColumnName(ColumnName.Playmaking)
                .HasColumnOrder(6)
                .HasColumnType(ColumnType.TinyInt)
                .IsRequired();

            this.Property(p => p.Winger)
                .HasColumnName(ColumnName.Winger)
                .HasColumnOrder(7)
                .HasColumnType(ColumnType.TinyInt)
                .IsRequired();

            this.Property(p => p.Passing)
                .HasColumnName(ColumnName.Passing)
                .HasColumnOrder(8)
                .HasColumnType(ColumnType.TinyInt)
                .IsRequired();

            this.Property(p => p.Scoring)
                .HasColumnName(ColumnName.Scoring)
                .HasColumnOrder(9)
                .HasColumnType(ColumnType.TinyInt)
                .IsRequired();

            this.Property(p => p.SetPieces)
                .HasColumnName(ColumnName.SetPieces)
                .HasColumnOrder(10)
                .HasColumnType(ColumnType.TinyInt)
                .IsRequired();

            this.Property(p => p.Loyalty)
                .HasColumnName(ColumnName.Loyalty)
                .HasColumnOrder(11)
                .HasColumnType(ColumnType.TinyInt)
                .IsRequired();

            this.Property(p => p.Experience)
                .HasColumnName(ColumnName.Experience)
                .HasColumnOrder(12)
                .HasColumnType(ColumnType.TinyInt)
                .IsRequired();

            this.Property(p => p.TotalSkillIndex)
                .HasColumnName(ColumnName.TotalSkillIndex)
                .HasColumnOrder(13)
                .HasColumnType(ColumnType.Integer)
                .IsRequired();

            this.Property(p => p.UpdatedOn)
                .HasColumnName(ColumnName.UpdatedOn)
                .HasColumnOrder(14)
                .HasColumnType(ColumnType.DateTime)
                .IsRequired();
        }

        /// <summary>
        /// Register entity relationships.
        /// </summary>
        public void RegisterRelationships()
        {
            this.HasRequired(r => r.SeniorPlayer)
                .WithMany(r => r.Skills)
                .HasForeignKey(r => r.SeniorPlayerId);
        }

        /// <summary>
        /// Register entity table mapping.
        /// </summary>
        public void RegisterTable()
        {
            this.ToTable(TableName.SeniorPlayerSkills);
        }

        #endregion Public Methods
    }
}