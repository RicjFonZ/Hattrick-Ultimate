//-----------------------------------------------------------------------
// <copyright file="Agreeability.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.UserInterface.Strategy.DenominationDictionaryBuilder
{
    using System.Collections.Generic;
    using Interface;

    /// <summary>
    /// Agreeability Denomination Dictionary Builder Strategy contract.
    /// </summary>
    public class Agreeability : IDenominationDictionaryBuilderStrategy
    {
        #region Public Methods

        /// <summary>
        /// Builds the denomination values dictionary.
        /// </summary>
        /// <returns>Dictionary with the denomination values.</returns>
        public Dictionary<object, string> BuildDictionary()
        {
            var values = Localization.Denominations.AgreeabilityLevel.Split(',');

            Dictionary<object, string> denominations = new Dictionary<object, string>();

            for (int i = 0; i < values.Length; i++)
            {
                denominations.Add((byte)i, values[i]);
            }

            return denominations;
        }

        #endregion Public Methods
    }
}