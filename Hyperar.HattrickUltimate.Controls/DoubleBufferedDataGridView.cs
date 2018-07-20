//-----------------------------------------------------------------------
// <copyright file="DoubleBufferedDataGridView.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.Controls
{
    using System.Collections.Generic;
    using System.Windows.Forms;

    /// <summary>
    /// Extends <see cref="DataGridView" /> control to include Double Buffering and not auto generate columns.
    /// </summary>
    public class DoubleBufferedDataGridView : DataGridView
    {
        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DoubleBufferedDataGridView" /> class.
        /// </summary>
        public DoubleBufferedDataGridView()
        {
            this.AutoGenerateColumns = false;
            this.DoubleBuffered = true;
            this.SortColumns = new Dictionary<string, SortOrder>();
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>
        /// Gets or sets the Sort Columns Dictionary.
        /// </summary>
        public Dictionary<string, SortOrder> SortColumns { get; set; }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// Applies the specified sort criteria.
        /// </summary>
        /// <param name="columnName">Sort column.</param>
        /// <param name="order">Sort direction.</param>
        public void ApplySortCriteria(string columnName, SortOrder order)
        {
            if (this.SortColumns.ContainsKey(columnName))
            {
                // If None.
                if (order == SortOrder.None)
                {
                    // Remove sort key.
                    this.SortColumns.Remove(columnName);
                }
                else
                {
                    // Update sort key.
                    this.SortColumns[columnName] = order;
                }
            }
            else
            {
                // Add sort key.
                this.SortColumns.Add(columnName, order);
            }

            // Apply sort order icon.s
            this.Columns[columnName].HeaderCell.SortGlyphDirection = order;
        }

        #endregion Public Methods
    }
}