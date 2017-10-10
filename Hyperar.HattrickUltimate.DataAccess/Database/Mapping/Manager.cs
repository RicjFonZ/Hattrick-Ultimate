//-----------------------------------------------------------------------
// <copyright file="Manager.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.DataAccess.Database.Mapping
{
    using Constants;
    using Interface;

    /// <summary>
    /// Manager entity mapping implementation.
    /// </summary>
    internal class Manager : HattrickEntity<BusinessObjects.App.Manager>, IMapping
    {
        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Manager" /> class.
        /// </summary>
        internal Manager()
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
            this.Property(p => p.UserName)
                .HasColumnName(ColumnName.UserName)
                .HasColumnOrder(2)
                .HasColumnType(ColumnType.UnicodeVarChar)
                .HasMaxLength(ColumnLength.ShortText)
                .IsRequired();

            this.Property(p => p.SupporterTier)
                .HasColumnName(ColumnName.SupporterTier)
                .HasColumnOrder(3)
                .HasColumnType(ColumnType.TinyInt)
                .IsRequired();
        }

        /// <summary>
        /// Register entity relationships.
        /// </summary>
        public void RegisterRelationships()
        {
            this.HasRequired(r => r.Country)
                .WithMany(r => r.Managers)
                .HasForeignKey(r => r.CountryId);
        }

        /// <summary>
        /// Register entity table mapping.
        /// </summary>
        public void RegisterTable()
        {
            this.ToTable(TableName.Manager);
        }

        #endregion Public Methods
    }
}