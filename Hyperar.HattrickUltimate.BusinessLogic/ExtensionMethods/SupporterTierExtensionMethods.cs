// -----------------------------------------------------------------------
// <copyright file="SupporterTierExtensionMethods.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
// -----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessLogic.ExtensionMethods
{
    using System;
    using BusinessObjects.App.Enums;

    /// <summary>
    /// Supporter Tier extension methods.
    /// </summary>
    public static class SupporterTierExtensionMethods
    {
        #region Public Methods

        /// <summary>
        /// Gets the string representation of the current Supporter Tier value.
        /// </summary>
        /// <param name="value">Value to convert to string.</param>
        /// <returns>String representation of the current value.</returns>
        public static string GetStringValue(this SupporterTier value)
        {
            switch (value)
            {
                case SupporterTier.None:
                    return Constants.SupporterTier.None;

                case SupporterTier.Silver:
                    return Constants.SupporterTier.Silver;

                case SupporterTier.Gold:
                    return Constants.SupporterTier.Gold;

                case SupporterTier.Platinum:
                    return Constants.SupporterTier.Platinum;

                case SupporterTier.Diamond:
                    return Constants.SupporterTier.Diamond;

                default:
                    throw new NotImplementedException($"No string value convertion found for: {value.ToString()}.");
            }
        }

        #endregion Public Methods
    }
}