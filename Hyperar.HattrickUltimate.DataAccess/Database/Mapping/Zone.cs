//-----------------------------------------------------------------------
// <copyright file="Zone.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.DataAccess.Database.Mapping
{
    using Constants;

    /// <summary>
    /// Zone entity mapping.
    /// </summary>
    public class Zone : Entity<BusinessObjects.App.Zone>
    {
        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Zone"/> class.
        /// </summary>
        public Zone()
        {
            this.RegisterTable();
            this.RegisterProperties();
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// Registers the Entity database table columns.
        /// </summary>
        public void RegisterProperties()
        {
            this.Property(p => p.Name)
                .HasColumnOrder(2)
                .HasColumnType(ColumnType.UnicodeVarChar)
                .HasMaxLength(ColumnLength.ShortText)
                .IsRequired();
        }

        /// <summary>
        /// Registers the Entity to it's database table.
        /// </summary>
        public void RegisterTable()
        {
            this.ToTable(TableName.Zone);
        }

        #endregion Public Methods
    }
}