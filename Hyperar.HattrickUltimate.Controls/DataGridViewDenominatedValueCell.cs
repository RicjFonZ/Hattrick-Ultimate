//-----------------------------------------------------------------------
// <copyright file="DataGridViewDenominatedValueCell.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.Controls
{
    using System.Drawing;
    using System.Windows.Forms;

    /// <summary>
    /// Extends <see cref="DataGridViewTextBoxCell"/> to work with denominated values.
    /// </summary>
    public class DataGridViewDenominatedValueCell : DataGridViewTextBoxCell
    {
        #region Protected Methods

        /// <summary>
        /// Paints the cell.
        /// </summary>
        /// <param name="graphics">The System.Drawing.Graphics used to paint the System.Windows.Forms.DataGridViewCell.</param>
        /// <param name="clipBounds">
        /// A System.Drawing.Rectangle that represents the area of the
        /// System.Windows.Forms.DataGridView that needs to be repainted.
        /// </param>
        /// <param name="cellBounds">
        /// A System.Drawing.Rectangle that contains the bounds of the
        /// System.Windows.Forms.DataGridViewCell that is being painted.
        /// </param>
        /// <param name="rowIndex">The row index of the cell that is being painted.</param>
        /// <param name="cellState">
        /// A bitwise combination of System.Windows.Forms.DataGridViewElementStates values that
        /// specifies the state of the cell.
        /// </param>
        /// <param name="value">
        /// The data of the System.Windows.Forms.DataGridViewCell that is being painted.
        /// </param>
        /// <param name="formattedValue">
        /// The formatted data of the System.Windows.Forms.DataGridViewCell that is being painted.
        /// </param>
        /// <param name="errorText">An error message that is associated with the cell.</param>
        /// <param name="cellStyle">
        /// A System.Windows.Forms.DataGridViewCellStyle that contains formatting and style
        /// information about the cell.
        /// </param>
        /// <param name="advancedBorderStyle">
        /// A System.Windows.Forms.DataGridViewAdvancedBorderStyle that contains border styles for
        /// the cell that is being painted.
        /// </param>
        /// <param name="paintParts">
        /// A bitwise combination of the System.Windows.Forms.DataGridViewPaintParts values that
        /// specifies which parts of the cell need to be painted.
        /// </param>
        protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, DataGridViewElementStates cellState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
        {
            // If not displayed, do not paint.
            if (!cellState.HasFlag(DataGridViewElementStates.Displayed))
            {
                return;
            }

            base.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts);
        }

        #endregion Protected Methods
    }
}