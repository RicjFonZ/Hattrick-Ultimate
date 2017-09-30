//-----------------------------------------------------------------------
// <copyright file="TimeFormat.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.DataAccess.Database.Mapping
{
    using Constants;

    /// <summary>
    /// TimeFormat entity mapping.
    /// </summary>
    public class TimeFormat : Entity<BusinessObjects.App.TimeFormat>
    {
        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TimeFormat"/> class.
        /// </summary>
        public TimeFormat()
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
            this.Property(p => p.Mask)
                .HasColumnOrder(1)
                .HasColumnType(ColumnType.UnicodeVarChar)
                .HasMaxLength(ColumnLength.ShortText)
                .IsRequired();
        }

        /// <summary>
        /// Registers the Entity to it's database table.
        /// </summary>
        public void RegisterTable()
        {
            this.ToTable(TableName.TimeFormat);
        }

        #endregion Public Methods
    }
}