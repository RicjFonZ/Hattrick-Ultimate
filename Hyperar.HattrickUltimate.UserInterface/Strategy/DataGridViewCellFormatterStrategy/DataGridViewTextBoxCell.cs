// -----------------------------------------------------------------------
// <copyright file="DataGridViewTextBoxCell.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
// -----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.UserInterface.Strategy.DataGridViewCellFormatterStrategy
{
    using System.Windows.Forms;
    using Interface;

    /// <summary>
    /// DataGridViewTextBoxCell Formatter Strategy implementation.
    /// </summary>
    public class DataGridViewTextBoxCell : IDataGridViewCellFormatterStrategy
    {
        #region Public Methods

        /// <summary>
        /// Applies the corresponding format to the specified cell.
        /// </summary>
        /// <param name="cellFormattingEventArgs">Cell Formatting event arguments.</param>
        /// <param name="cell">DataGridViewCell object.</param>
        public void ApplyFormat(DataGridViewCellFormattingEventArgs cellFormattingEventArgs, DataGridViewCell cell)
        {
            switch (cell.OwningColumn.DataPropertyName)
            {
                case "Age":
                    this.ApplyAgeFormat(cellFormattingEventArgs);
                    break;
            }
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        /// Applies the corresponding format for Age cell.
        /// </summary>
        /// <param name="cellFormattingEventArgs">Cell Formatting event arguments.</param>
        private void ApplyAgeFormat(DataGridViewCellFormattingEventArgs cellFormattingEventArgs)
        {
            var parsedValue = (decimal)cellFormattingEventArgs.Value;

            int integralValue = (int)decimal.Truncate(parsedValue);
            int decimalValue = (int)((parsedValue - integralValue) * 1000);

            cellFormattingEventArgs.Value = decimalValue == 1
                       ? string.Format(Localization.Controls.FormGeneral_AgeDay, integralValue, decimalValue)
                       : string.Format(Localization.Controls.FormGeneral_AgeDays, integralValue, decimalValue);

            cellFormattingEventArgs.FormattingApplied = true;
        }

        #endregion Private Methods
    }
}