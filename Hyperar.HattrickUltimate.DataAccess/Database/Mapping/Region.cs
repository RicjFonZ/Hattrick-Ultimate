//-----------------------------------------------------------------------
// <copyright file="Region.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.DataAccess.Database.Mapping
{
    using Constants;

    /// <summary>
    /// Region entity mapping.
    /// </summary>
    internal class Region : HattrickEntity<BusinessObjects.App.Region>
    {
        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Region"/> class.
        /// </summary>
        public Region()
        {
            this.RegisterTable();
            this.RegisterProperties();
            this.RegisterRelationships();
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// Registers the Entity Key.
        /// </summary>
        public void RegisterKey()
        {
            this.HasKey(p => p.Id);
        }

        /// <summary>
        /// Registers the Entity database table columns.
        /// </summary>
        public void RegisterProperties()
        {
            this.Property(p => p.Name)
                .HasColumnName(ColumnName.Name)
                .HasColumnOrder(2)
                .HasColumnType(ColumnType.UnicodeVarChar)
                .HasMaxLength(ColumnLength.MediumText)
                .IsRequired();
        }

        /// <summary>
        /// Registers the Entity relationships.
        /// </summary>
        public void RegisterRelationships()
        {
            this.HasRequired(r => r.Country)
                .WithMany(r => r.Regions)
                .HasForeignKey(r => r.CountryId);
        }

        /// <summary>
        /// Registers the Entity to it's database table.
        /// </summary>
        public void RegisterTable()
        {
            this.ToTable(TableName.Region);
        }

        #endregion Public Methods
    }
}