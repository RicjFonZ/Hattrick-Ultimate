// -----------------------------------------------------------------------
// <copyright file="DataGridViewDenominatedValueCell.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
// -----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.UserInterface.Strategy.DataGridViewCellFormatterStrategy
{
    using System.Collections.Generic;
    using System.Windows.Forms;
    using Controls;
    using Interface;

    /// <summary>
    /// DataGridViewDenominatedValueCell Formatter Strategy implementation.
    /// </summary>
    public class DataGridViewDenominatedValueCell : IDataGridViewCellFormatterStrategy
    {
        #region Public Methods

        /// <summary>
        /// Applies the corresponding format to the specified cell.
        /// </summary>
        /// <param name="cellFormattingEventArgs">Cell Formatting event arguments.</param>
        /// <param name="cell">DataGridViewCell object.</param>
        public void ApplyFormat(DataGridViewCellFormattingEventArgs cellFormattingEventArgs, DataGridViewCell cell)
        {
            ValueDisplayMode displayMode = ValueDisplayMode.ValueOnly;
            Dictionary<object, string> valueDenominationDictionary;

            if (cell.OwningColumn is DataGridViewDenominatedValueColumn)
            {
                var parsedColumn = cell.OwningColumn as DataGridViewDenominatedValueColumn;

                displayMode = parsedColumn.DisplayMode;
                valueDenominationDictionary = parsedColumn.ValueDenominationDictionary;
            }
            else
            {
                var parsedColumn = cell.OwningColumn as DataGridViewDenominatedValueWithChangeTrackingColumn;

                displayMode = parsedColumn.DisplayMode;
                valueDenominationDictionary = parsedColumn.ValueDenominationDictionary;
            }

            // If can and should format the value.
            if (valueDenominationDictionary != null &&
                valueDenominationDictionary.ContainsKey(cellFormattingEventArgs.Value) &&
                displayMode != ValueDisplayMode.ValueOnly)
            {
                switch (displayMode)
                {
                    case ValueDisplayMode.DenominationOnly:
                        cellFormattingEventArgs.Value = valueDenominationDictionary[cellFormattingEventArgs.Value];
                        break;

                    case ValueDisplayMode.DenominationAndValue:
                        cellFormattingEventArgs.Value = $"{valueDenominationDictionary[cellFormattingEventArgs.Value]} ({cellFormattingEventArgs.Value})";
                        break;
                }

                // Format has been applied.
                cellFormattingEventArgs.FormattingApplied = true;
            }
        }

        #endregion Public Methods
    }
}