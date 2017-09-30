//-----------------------------------------------------------------------
// <copyright file="Manager.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.DataAccess.Database.Mapping
{
    using Constants;

    /// <summary>
    /// Manager entity mapping definition.
    /// </summary>
    internal class Manager : HattrickEntity<BusinessObjects.App.Manager>
    {
        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Manager" /> class.
        /// </summary>
        internal Manager()
        {
            this.RegisterTable();
            this.RegisterProperties();
        }

        #endregion Internal Constructors

        #region Public Methods

        /// <summary>
        /// Registers the Entity relationships.
        /// </summary>
        public void RegisterRelationships()
        {
            this.HasRequired(r => r.Country)
                .WithMany(r => r.Managers)
                .HasForeignKey(r => r.CountryId);
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        /// Registers entity properties.
        /// </summary>
        private void RegisterProperties()
        {
            this.Property(e => e.UserName)
                .HasColumnName(ColumnName.UserName)
                .HasColumnOrder(2)
                .HasColumnType(ColumnType.UnicodeVarChar)
                .HasMaxLength(ColumnLength.MediumText)
                .IsRequired();
        }

        /// <summary>
        /// Register entity table.
        /// </summary>
        private void RegisterTable()
        {
            this.ToTable(TableName.Manager);
        }

        #endregion Private Methods
    }
}