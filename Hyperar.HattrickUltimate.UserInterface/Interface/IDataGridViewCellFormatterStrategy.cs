// -----------------------------------------------------------------------
// <copyright file="IDataGridViewCellFormatterStrategy.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
// -----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.UserInterface.Interface
{
    using System.Windows.Forms;

    /// <summary>
    /// DataGridViewCellFormatter Strategy contract.
    /// </summary>
    public interface IDataGridViewCellFormatterStrategy
    {
        #region Public Methods

        /// <summary>
        /// Applies the corresponding format to the specified cell.
        /// </summary>
        /// <param name="cellFormattingEventArgs">Cell Formatting event arguments.</param>
        /// <param name="cell">DataGridViewCell object.</param>
        void ApplyFormat(DataGridViewCellFormattingEventArgs cellFormattingEventArgs, DataGridViewCell cell);

        #endregion Public Methods
    }
}