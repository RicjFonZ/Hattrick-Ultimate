// -----------------------------------------------------------------------
// <copyright file="DataGridViewImageCell.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
// -----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.UserInterface.Strategy.DataGridViewCellFormatterStrategy
{
    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Imaging;
    using System.Drawing.Text;
    using System.Windows.Forms;
    using Interface;

    /// <summary>
    /// DataGridViewImageCell Formatter Strategy implementation.
    /// </summary>
    public class DataGridViewImageCell : IDataGridViewCellFormatterStrategy
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
                case "HasHomegrownBonus":
                    this.ApplyHomegrownBonusFormat(cellFormattingEventArgs);
                    break;

                case "BookingStatus":
                    this.ApplyCardsFormat(cellFormattingEventArgs);
                    break;

                case "InjuryStatus":
                    this.ApplyHealthFormat(cellFormattingEventArgs, cell);
                    break;
            }
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        /// Applies the corresponding format for BookingStatus cell.
        /// </summary>
        /// <param name="cellFormattingEventArgs">Cell Formatting event arguments.</param>
        private void ApplyCardsFormat(DataGridViewCellFormattingEventArgs cellFormattingEventArgs)
        {
            switch ((byte)cellFormattingEventArgs.Value)
            {
                case 0:
                    cellFormattingEventArgs.Value = Properties.Resources.Transparent;
                    break;

                case 1:
                    cellFormattingEventArgs.Value = Properties.Resources.YellowCard;
                    break;

                case 2:
                    cellFormattingEventArgs.Value = Properties.Resources.DualYellowCards;
                    break;

                case 3:
                    cellFormattingEventArgs.Value = Properties.Resources.RedCard;
                    break;
            }

            cellFormattingEventArgs.FormattingApplied = true;
        }

        /// <summary>
        /// Applies the corresponding format for InjuryStatus cell.
        /// </summary>
        /// <param name="cellFormattingEventArgs">Cell Formatting event arguments.</param>
        /// <param name="cell">DataGridViewCell object.</param>
        private void ApplyHealthFormat(DataGridViewCellFormattingEventArgs cellFormattingEventArgs, DataGridViewCell cell)
        {
            if (cellFormattingEventArgs.Value == null)
            {
                cellFormattingEventArgs.Value = Properties.Resources.Transparent;
                return;
            }
            else if ((byte?)cellFormattingEventArgs.Value == 0)
            {
                cellFormattingEventArgs.Value = Properties.Resources.Bruised;
            }
            else
            {
                var image = new Bitmap(21, 11, PixelFormat.Format32bppArgb);

                var graphics = Graphics.FromImage(image);

                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.AntiAlias;
                graphics.TextRenderingHint = TextRenderingHint.AntiAlias;

                graphics.DrawImage(Properties.Resources.Injured, 0f, 0f);

                graphics.DrawString(
                             cellFormattingEventArgs.Value.ToString(),
                             cellFormattingEventArgs.CellStyle.Font,
                             new SolidBrush(cell.Selected ? cellFormattingEventArgs.CellStyle.SelectionForeColor : cellFormattingEventArgs.CellStyle.ForeColor),
                             new RectangleF(13f, 0f, 10f, 11f));

                cellFormattingEventArgs.Value = image;
            }

            cellFormattingEventArgs.FormattingApplied = true;
        }

        /// <summary>
        /// Applies the corresponding format for HasHomegrownBonus cell.
        /// </summary>
        /// <param name="cellFormattingEventArgs">Cell Formatting event arguments.</param>
        private void ApplyHomegrownBonusFormat(DataGridViewCellFormattingEventArgs cellFormattingEventArgs)
        {
            cellFormattingEventArgs.Value = Convert.ToBoolean(cellFormattingEventArgs.Value)
                       ? Properties.Resources.HomegrownBonus
                       : Properties.Resources.Transparent;

            cellFormattingEventArgs.FormattingApplied = true;
        }

        #endregion Private Methods
    }
}