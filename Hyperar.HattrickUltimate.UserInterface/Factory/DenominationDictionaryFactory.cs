//-----------------------------------------------------------------------
// <copyright file="DenominationDictionaryFactory.cs" company="Hyperar">
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
    using Strategy.DenominationDictionaryBuilderStrategy;

    /// <summary>
    /// Denominated Value Dictionary Builder Factory implementation.
    /// </summary>
    public class DenominationDictionaryFactory : IDenominationDictionaryBuilderFactory
    {
        #region Private Fields

        /// <summary>
        /// DenominationDictionaryBuilderStrategy dictionary.
        /// </summary>
        private Dictionary<ValueDenominationType, IDenominationDictionaryBuilderStrategy> strategyDictionary;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DenominationDictionaryFactory" /> class.
        /// </summary>
        public DenominationDictionaryFactory()
        {
            this.strategyDictionary = new Dictionary<ValueDenominationType, IDenominationDictionaryBuilderStrategy>();
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// Gets the corresponding Denominated Value Dictionary Builder Strategy for the specified parameter.
        /// </summary>
        /// <param name="denominationType">Denomination type to build value dictionary.</param>
        /// <returns>IDenominationDictionaryBuilderStrategy for the specified parameter.</returns>
        public IDenominationDictionaryBuilderStrategy GetFor(ValueDenominationType denominationType)
        {
            if (!this.strategyDictionary.ContainsKey(denominationType))
            {
                switch (denominationType)
                {
                    case ValueDenominationType.Aggressiveness:
                        this.strategyDictionary.Add(denominationType, new Aggressiveness());
                        break;

                    case ValueDenominationType.Agreeability:
                        this.strategyDictionary.Add(denominationType, new Agreeability());
                        break;

                    case ValueDenominationType.Honesty:
                        this.strategyDictionary.Add(denominationType, new Honesty());
                        break;

                    case ValueDenominationType.PlayerSkill:
                        this.strategyDictionary.Add(denominationType, new PlayerSkill());
                        break;

                    default:
                        throw new NotImplementedException(
                                  string.Format(
                                            Localization.Messages.NotImplemented,
                                            typeof(IDenominationDictionaryBuilderStrategy).Name,
                                            denominationType.ToString()));
                }
            }

            return this.strategyDictionary[denominationType];
        }

        #endregion Public Methods
    }
}