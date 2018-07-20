//-----------------------------------------------------------------------
// <copyright file="IDenominationDictionaryBuilderFactory.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.UserInterface.Interface
{
    using BusinessObjects.App.Enums;

    /// <summary>
    /// Denominated Value Dictionary Builder Factory contract.
    /// </summary>
    public interface IDenominationDictionaryBuilderFactory
    {
        #region Public Methods

        /// <summary>
        /// Gets the corresponding Denominated Value Dictionary Builder Strategy for the specified parameter.
        /// </summary>
        /// <param name="denominationType">Denomination type to build value dictionary.</param>
        /// <returns>IDenominationDictionaryBuilderStrategy for the specified parameter.</returns>
        IDenominationDictionaryBuilderStrategy GetFor(ValueDenominationType denominationType);

        #endregion Public Methods
    }
}