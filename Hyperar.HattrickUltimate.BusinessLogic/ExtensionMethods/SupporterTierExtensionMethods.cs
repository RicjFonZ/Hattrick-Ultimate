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
        /// Gets an SupporterTier value from the specified string.
        /// </summary>
        /// <param name="value">Supporter Tier value in a System.String object.</param>
        /// <returns>SupporterTier value.</returns>
        public static SupporterTier GetEnum(this string value)
        {
            switch (value)
            {
                case Constants.SupporterTier.None:
                    return SupporterTier.None;

                case Constants.SupporterTier.Silver:
                    return SupporterTier.Silver;

                case Constants.SupporterTier.Gold:
                    return SupporterTier.Gold;

                case Constants.SupporterTier.Platinum:
                    return SupporterTier.Platinum;

                case Constants.SupporterTier.Diamond:
                    return SupporterTier.Diamond;

                default:
                    throw new ArgumentException(
                                  string.Format(
                                             Localization.Messages.UnknownSupporterTier,
                                             value));
            }
        }

        /// <summary>
        /// Gets an string value from the specified SupporterTier.
        /// </summary>
        /// <param name="value">SupporterTier value.</param>
        /// <returns>System.String representation of the specified SupporterTier.</returns>
        public static string GetString(this SupporterTier value)
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
                    throw new ArgumentNullException(
                              string.Format(
                                         Localization.Messages.UnknownSupporterTier,
                                         value.ToString()));
            }
        }

        #endregion Public Methods
    }
}