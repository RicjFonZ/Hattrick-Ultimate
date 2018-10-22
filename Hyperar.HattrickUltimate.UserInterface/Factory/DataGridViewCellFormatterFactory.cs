// -----------------------------------------------------------------------
// <copyright file="DataGridViewCellFormatterFactory.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
// -----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.UserInterface.Factory
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using Controls;
    using Interface;

    /// <summary>
    /// DataGridViewCellFormatter Factory implementation.
    /// </summary>
    public class DataGridViewCellFormatterFactory : IDataGridViewCellFormatterFactory
    {
        #region Private Fields

        /// <summary>
        /// DataGridViewCellFormatterStrategy dictionary.
        /// </summary>
        private readonly Dictionary<Type, IDataGridViewCellFormatterStrategy> strategyDictionary;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DataGridViewCellFormatterFactory"/> class.
        /// </summary>
        public DataGridViewCellFormatterFactory()
        {
            this.strategyDictionary = new Dictionary<Type, IDataGridViewCellFormatterStrategy>();
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// Gets the corresponding IDataGridViewCellFormatterStrategy for the specified cell.
        /// </summary>
        /// <param name="cell">Cell to format.</param>
        /// <returns>Cell formatter strategy.</returns>
        public IDataGridViewCellFormatterStrategy GetFor(DataGridViewCell cell)
        {
            if (!this.strategyDictionary.ContainsKey(cell.GetType()))
            {
                if (cell is DataGridViewImageCell)
                {
                    this.strategyDictionary.Add(cell.GetType(), new Strategy.DataGridViewCellFormatterStrategy.DataGridViewImageCell());
                }
                else if (cell is DataGridViewDenominatedValueCell || cell is DataGridViewDenominatedValueWithChangeTrackingCell)
                {
                    this.strategyDictionary.Add(cell.GetType(), new Strategy.DataGridViewCellFormatterStrategy.DataGridViewDenominatedValueCell());
                }
                else if (cell is DataGridViewTextBoxCell)
                {
                    this.strategyDictionary.Add(cell.GetType(), new Strategy.DataGridViewCellFormatterStrategy.DataGridViewTextBoxCell());
                }
            }

            return this.strategyDictionary[cell.GetType()];
        }

        #endregion Public Methods
    }
}