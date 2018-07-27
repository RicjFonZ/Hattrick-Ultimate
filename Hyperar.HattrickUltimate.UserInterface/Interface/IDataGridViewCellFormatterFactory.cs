// -----------------------------------------------------------------------
// <copyright file="IDataGridViewCellFormatterFactory.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
// -----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.UserInterface.Interface
{
    using System.Windows.Forms;

    /// <summary>
    /// DataGridViewCellFormatter Factory contract.
    /// </summary>
    public interface IDataGridViewCellFormatterFactory
    {
        #region Public Methods

        /// <summary>
        /// Gets the corresponding IDataGridViewCellFormatterStrategy for the specified cell.
        /// </summary>
        /// <param name="cell">Cell to format.</param>
        /// <returns>Cell formatter strategy.</returns>
        IDataGridViewCellFormatterStrategy GetFor(DataGridViewCell cell);

        #endregion Public Methods
    }
}