//-----------------------------------------------------------------------
// <copyright file="DenominatedValueWithChangeTracking.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.UserInterface.Strategy.DataGridViewColumnBuilder
{
    using System.Drawing;
    using System.Windows.Forms;
    using BusinessObjects.App;
    using Controls;
    using Interface;

    /// <summary>
    /// DenominatedValueWithChangeTracking implementation.
    /// </summary>
    public class DenominatedValueWithChangeTracking : IDataGridViewColumnBuilderStrategy
    {
        #region Private Fields

        /// <summary>
        /// DenominationDictionaryBuilderFactory factory.
        /// </summary>
        private readonly IDenominationDictionaryBuilderFactory denominationDictionaryBuilderFactory;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DenominatedValueWithChangeTracking"/> class.
        /// </summary>
        /// <param name="denominationDictionaryBuilderFactory">
        /// DenominationDictionaryBuilderFactory factory.
        /// </param>
        public DenominatedValueWithChangeTracking(IDenominationDictionaryBuilderFactory denominationDictionaryBuilderFactory)
        {
            this.denominationDictionaryBuilderFactory = denominationDictionaryBuilderFactory;
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// Builds a DataGridViewDenominatedValueWithChangeTrackingColumn using the specified
        /// GridLayoutColumn as a templates.
        /// </summary>
        /// <param name="gridLayoutColumn">Grid Layout Column to use as a template.</param>
        /// <returns>DataGridViewColumn generated with the specified template.</returns>
        public DataGridViewColumn Build(GridLayoutColumn gridLayoutColumn)
        {
            var newColumn = new DataGridViewDenominatedValueWithChangeTrackingColumn();

            newColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            newColumn.DataPropertyName = gridLayoutColumn.GridColumn.ValuePropertyName;
            newColumn.DefaultCellStyle.Alignment = (DataGridViewContentAlignment)gridLayoutColumn.Alignment;
            newColumn.DisplayIndex = gridLayoutColumn.DisplayIndex;
            newColumn.DisplayMode = (ValueDisplayMode)gridLayoutColumn.DisplayMode;
            newColumn.HeaderCell.Style.Alignment = (DataGridViewContentAlignment)gridLayoutColumn.Alignment;
            newColumn.Frozen = gridLayoutColumn.IsFixed;
            newColumn.HeaderText = gridLayoutColumn.CustomHeaderText ??
                                  Localization.Controls.ResourceManager.GetString($"{gridLayoutColumn.GridColumn.Name}_HeaderText") ??
                                  gridLayoutColumn.GridColumn.Name;
            newColumn.Name = gridLayoutColumn.GridColumn.Name;
            newColumn.ReadOnly = true;
            newColumn.Resizable = DataGridViewTriState.True;
            newColumn.SortMode = DataGridViewColumnSortMode.Programmatic;
            newColumn.ValueDenominationDictionary = this.denominationDictionaryBuilderFactory.GetFor(gridLayoutColumn.GridColumn.ValueDenominationType)
                                                                                             .BuildDictionary();
            newColumn.NegativeChangeBackColor = Color.FromArgb(255, 80, 80);
            newColumn.PositiveChangeBackColor = Color.FromArgb(153, 204, 0);
            newColumn.ValueChangeTrackingPropertyName = gridLayoutColumn.GridColumn.ValueChangeTrackingPropertyName;

            return newColumn;
        }

        #endregion Public Methods
    }
}