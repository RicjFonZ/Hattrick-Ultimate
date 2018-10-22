//-----------------------------------------------------------------------
// <copyright file="Image.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.UserInterface.Strategy.DataGridViewColumnBuilder
{
    using System.Windows.Forms;
    using BusinessObjects.App;
    using Interface;

    /// <summary>
    /// DataGridViewImageColumn implementation.
    /// </summary>
    public class Image : IDataGridViewColumnBuilderStrategy
    {
        #region Public Methods

        /// <summary>
        /// Builds a DataGridViewImageColumn using the specified GridLayoutColumn as a templates.
        /// </summary>
        /// <param name="gridLayoutColumn">Grid Layout Column to use as a template.</param>
        /// <returns>DataGridViewColumn generated with the specified template.</returns>
        public DataGridViewColumn Build(GridLayoutColumn gridLayoutColumn)
        {
            var newColumn = new DataGridViewImageColumn();

            newColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            newColumn.DataPropertyName = gridLayoutColumn.GridColumn.ValuePropertyName;
            newColumn.DefaultCellStyle.Alignment = (DataGridViewContentAlignment)gridLayoutColumn.Alignment;
            newColumn.DisplayIndex = gridLayoutColumn.DisplayIndex;
            newColumn.HeaderCell.Style.Alignment = (DataGridViewContentAlignment)gridLayoutColumn.Alignment;
            newColumn.Frozen = gridLayoutColumn.IsFixed;
            newColumn.HeaderText = gridLayoutColumn.CustomHeaderText ??
                                  Localization.Controls.ResourceManager.GetString($"{gridLayoutColumn.GridColumn.Name}_HeaderText") ??
                                  gridLayoutColumn.GridColumn.Name;
            newColumn.Name = gridLayoutColumn.GridColumn.Name;
            newColumn.ReadOnly = true;
            newColumn.Resizable = DataGridViewTriState.True;
            newColumn.SortMode = DataGridViewColumnSortMode.Programmatic;
            newColumn.Width = gridLayoutColumn.Width;

            return newColumn;
        }

        #endregion Public Methods
    }
}