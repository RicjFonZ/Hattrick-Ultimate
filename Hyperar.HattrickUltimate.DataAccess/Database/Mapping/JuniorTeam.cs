//-----------------------------------------------------------------------
// <copyright file="JuniorTeam.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.DataAccess.Database.Mapping
{
    using Constants;
    using Interface;

    /// <summary>
    /// JuniorTeam entity mapping implementation.
    /// </summary>
    internal class JuniorTeam : HattrickEntity<BusinessObjects.App.JuniorTeam>, IMapping
    {
        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="JuniorTeam" /> class.
        /// </summary>
        internal JuniorTeam()
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
                .HasMaxLength(ColumnLength.ShortText)
                .IsRequired();

            this.Property(p => p.ShortName)
                .HasColumnName(ColumnName.ShortName)
                .HasColumnOrder(3)
                .HasColumnType(ColumnType.UnicodeChar)
                .HasMaxLength(ColumnLength.ShortText)
                .IsOptional();
        }

        /// <summary>
        /// Register entity relationships.
        /// </summary>
        public void RegisterRelationships()
        {
            this.HasRequired(r => r.SeniorTeam)
                .WithOptional(r => r.JuniorTeam)
                .Map(m =>
                {
                    m.ToTable(TableName.JuniorTeam);
                    m.MapKey(ColumnName.SeniorTeamId);
                });

            this.HasOptional(r => r.JuniorSeries)
                .WithMany(r => r.JuniorTeams)
                .HasForeignKey(r => r.JuniorSeriesId);
        }

        /// <summary>
        /// Register entity table mapping.
        /// </summary>
        public void RegisterTable()
        {
            this.ToTable(TableName.JuniorTeam);
        }

        #endregion Public Methods
    }
}