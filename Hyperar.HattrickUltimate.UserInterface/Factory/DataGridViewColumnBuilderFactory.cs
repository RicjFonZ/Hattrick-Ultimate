//-----------------------------------------------------------------------
// <copyright file="DataGridViewColumnBuilderFactory.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.UserInterface.Factory
{
    using System;
    using System.Collections.Generic;
    using BusinessObjects.App.Enums;
    using Interface;
    using Strategy.DataGridViewColumnBuilder;

    /// <summary>
    /// Data Grid Column Builder Factory implementation.
    /// </summary>
    public class DataGridViewColumnBuilderFactory : IDataGridViewColumnBuilderFactory
    {
        #region Private Fields

        /// <summary>
        /// Column Builder Strategies Dictionary.
        /// </summary>
        private Dictionary<GridColumnType, IDataGridViewColumnBuilderStrategy> strategyDictionary;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DataGridViewColumnBuilderFactory" /> class.
        /// </summary>
        public DataGridViewColumnBuilderFactory()
        {
            this.strategyDictionary = new Dictionary<GridColumnType, IDataGridViewColumnBuilderStrategy>();
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// Gets the correct strategy for the specified column type.
        /// </summary>
        /// <param name="columnType">Column type to build.</param>
        /// <returns>The corresponding IDataGridViewColumnBuilderStrategy object.</returns>
        public IDataGridViewColumnBuilderStrategy GetFor(GridColumnType columnType)
        {
            if (!this.strategyDictionary.ContainsKey(columnType))
            {
                switch (columnType)
                {
                    case GridColumnType.Text:
                        this.strategyDictionary.Add(GridColumnType.Text, new Text());
                        break;

                    case GridColumnType.Image:
                        this.strategyDictionary.Add(GridColumnType.Image, new Image());
                        break;

                    case GridColumnType.DenominatedValue:
                        this.strategyDictionary.Add(GridColumnType.DenominatedValue, BusinessLogic.ApplicationObjects.Container.GetInstance<DenominatedValue>());
                        break;

                    case GridColumnType.DenominatedValueWithChangeTracking:
                        this.strategyDictionary.Add(GridColumnType.DenominatedValueWithChangeTracking, BusinessLogic.ApplicationObjects.Container.GetInstance<DenominatedValueWithChangeTracking>());
                        break;

                    case GridColumnType.ValueWithChangeTracking:
                        this.strategyDictionary.Add(GridColumnType.ValueWithChangeTracking, BusinessLogic.ApplicationObjects.Container.GetInstance<ValueWithChangeTracking>());
                        break;

                    default:
                        throw new NotImplementedException(
                                  string.Format(
                                            Localization.Messages.NotImplemented,
                                            typeof(IDataGridViewColumnBuilderStrategy).Name,
                                            columnType.ToString()));
                }
            }

            return this.strategyDictionary[columnType];
        }

        #endregion Public Methods
    }
}