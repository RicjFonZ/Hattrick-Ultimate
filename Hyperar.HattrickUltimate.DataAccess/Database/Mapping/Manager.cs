//-----------------------------------------------------------------------
// <copyright file="Manager.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.DataAccess.Database.Mapping
{
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

        #region Private Methods

        /// <summary>
        /// Registers entity properties.
        /// </summary>
        private void RegisterProperties()
        {
            this.Property(e => e.UserName)
                .HasColumnName(Constants.ColumnName.UserName)
                .HasColumnOrder(3)
                .HasColumnType(Constants.ColumnType.UnicodeVarChar)
                .HasMaxLength(Constants.ColumnLength.MediumText)
                .IsRequired();
        }

        /// <summary>
        /// Register entity table.
        /// </summary>
        private void RegisterTable()
        {
            this.ToTable(Constants.TableName.Manager);
        }

        #endregion Private Methods
    }
}