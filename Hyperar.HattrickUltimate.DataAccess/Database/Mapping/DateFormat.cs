//-----------------------------------------------------------------------
// <copyright file="DateFormat.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.DataAccess.Database.Mapping
{
    using Constants;
    using Interface;

    /// <summary>
    /// DateFormat entity mapping implementation.
    /// </summary>
    internal class DateFormat : Entity<BusinessObjects.App.DateFormat>, IMapping
    {
        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DateFormat" /> class.
        /// </summary>
        internal DateFormat()
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
            this.Property(p => p.Mask)
                .HasColumnName(ColumnName.Mask)
                .HasColumnOrder(1)
                .HasColumnType(ColumnType.UnicodeVarChar)
                .HasMaxLength(ColumnLength.Mask)
                .IsRequired();
        }

        /// <summary>
        /// Register entity relationships.
        /// </summary>
        public void RegisterRelationships()
        {
        }

        /// <summary>
        /// Register entity table mapping.
        /// </summary>
        public void RegisterTable()
        {
            this.ToTable(TableName.DateFormat);
        }

        #endregion Public Methods
    }
}