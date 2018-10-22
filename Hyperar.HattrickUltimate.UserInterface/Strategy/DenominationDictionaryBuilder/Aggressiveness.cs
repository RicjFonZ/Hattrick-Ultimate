//-----------------------------------------------------------------------
// <copyright file="Aggressiveness.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.UserInterface.Strategy.DenominationDictionaryBuilder
{
    using System.Collections.Generic;
    using Interface;

    /// <summary>
    /// Aggressiveness Denomination Dictionary Builder Strategy contract.
    /// </summary>
    public class Aggressiveness : IDenominationDictionaryBuilderStrategy
    {
        #region Public Methods

        /// <summary>
        /// Builds the denomination values dictionary.
        /// </summary>
        /// <returns>Dictionary with the denomination values.</returns>
        public Dictionary<object, string> BuildDictionary()
        {
            string[] values = Localization.Denominations.AggressivenessLevel.Split(',');

            var denominations = new Dictionary<object, string>();

            for (int i = 0; i < values.Length; i++)
            {
                denominations.Add((byte)i, values[i]);
            }

            return denominations;
        }

        #endregion Public Methods
    }
}