//-----------------------------------------------------------------------
// <copyright file="LeagueNationalTeam.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.DataAccess.Database.Mapping
{
    using Constants;
    using Interface;

    /// <summary>
    /// LeagueNationalTeam entity mapping implementation.
    /// </summary>
    internal class LeagueNationalTeam : Entity<BusinessObjects.App.LeagueNationalTeam>, IMapping
    {
        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="LeagueNationalTeam" /> class.
        /// </summary>
        internal LeagueNationalTeam()
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
            this.Property(p => p.SeniorNationalTeamId)
                .HasColumnName(ColumnName.SeniorNationalTeamId)
                .HasColumnOrder(1)
                .HasColumnType(ColumnType.BigInt)
                .IsRequired();

            this.Property(p => p.JuniorNationalTeamId)
                .HasColumnName(ColumnName.JuniorNationalTeamId)
                .HasColumnOrder(2)
                .HasColumnType(ColumnType.BigInt)
                .IsRequired();
        }

        /// <summary>
        /// Register entity relationships.
        /// </summary>
        public void RegisterRelationships()
        {
            this.HasRequired(r => r.League)
                .WithOptional(r => r.NationalTeam)
                .Map(m =>
                {
                    m.ToTable(TableName.LeagueNationalTeam);
                    m.MapKey(ColumnName.LeagueId);
                });
        }

        /// <summary>
        /// Register entity table mapping.
        /// </summary>
        public void RegisterTable()
        {
            this.ToTable(TableName.LeagueNationalTeam);
        }

        #endregion Public Methods
    }
}