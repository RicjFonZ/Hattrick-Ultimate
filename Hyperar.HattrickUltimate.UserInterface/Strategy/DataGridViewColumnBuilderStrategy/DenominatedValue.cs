//-----------------------------------------------------------------------
// <copyright file="DenominatedValue.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.UserInterface.Strategy.DataGridViewColumnBuilderStrategy
{
    using System.Windows.Forms;
    using BusinessObjects.App;
    using Controls;
    using Interface;

    /// <summary>
    /// DenominatedValue implementation.
    /// </summary>
    public class DenominatedValue : IDataGridViewColumnBuilderStrategy
    {
        #region Private Fields

        /// <summary>
        /// DenominationDictionaryBuilderFactory factory.
        /// </summary>
        private IDenominationDictionaryBuilderFactory denominationDictionaryBuilderFactory;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DenominatedValue" /> class.
        /// </summary>
        /// <param name="denominationDictionaryBuilderFactory">DenominationDictionaryBuilderFactory factory.</param>
        public DenominatedValue(IDenominationDictionaryBuilderFactory denominationDictionaryBuilderFactory)
        {
            this.denominationDictionaryBuilderFactory = denominationDictionaryBuilderFactory;
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// Builds a DataGridViewDenominatedValueColumn using the specified GridLayoutColumn as a templates.
        /// </summary>
        /// <param name="gridLayoutColumn">Grid Layout Column to use as a template.</param>
        /// <returns>DataGridViewColumn generated with the specified template.</returns>
        public DataGridViewColumn Build(GridLayoutColumn gridLayoutColumn)
        {
            var newColumn = new DataGridViewDenominatedValueColumn();

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
            newColumn.ValueDenominationDictionary = this.denominationDictionaryBuilderFactory.GetFor(gridLayoutColumn.GridColumn.ValueDenominationType)
                                                                                             .BuildDictionary();
            newColumn.DisplayMode = ValueDisplayMode.DenominationAndValue;

            return newColumn;
        }

        #endregion Public Methods
    }
}