//-----------------------------------------------------------------------
// <copyright file="IDenominationDictionaryBuilderStrategy.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.UserInterface.Interface
{
    using System.Collections.Generic;

    /// <summary>
    /// Denomination Dictionary Builder Strategy contract.
    /// </summary>
    public interface IDenominationDictionaryBuilderStrategy
    {
        #region Public Methods

        /// <summary>
        /// Builds the denomination values dictionary.
        /// </summary>
        /// <returns>Dictionary with the denomination values.</returns>
        Dictionary<object, string> BuildDictionary();

        #endregion Public Methods
    }
}