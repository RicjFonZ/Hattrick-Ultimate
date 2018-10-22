// -----------------------------------------------------------------------
// <copyright file="OAuthScopeExtensionMethods.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
// -----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessLogic.ExtensionMethods
{
    using System;
    using System.Collections.Generic;
    using BusinessObjects.App.Enums;

    /// <summary>
    /// OAuth Scope extension methods.
    /// </summary>
    public static class OAuthScopeExtensionMethods
    {
        #region Public Methods

        /// <summary>
        /// Gets an OAuthScope object from a string array.
        /// </summary>
        /// <param name="values">OAuth scopes tags.</param>
        /// <returns>OAuthScope object.</returns>
        public static OAuthScope GetEnum(this List<string> values)
        {
            if (values == null)
            {
                throw new ArgumentNullException(nameof(values));
            }

            // Having a valid token means at least having Read access, thus it's always ON.
            var result = OAuthScope.Read;

            foreach (string value in values)
            {
                switch (value)
                {
                    case Constants.OAuthScope.ManagerChallenges:
                        result |= OAuthScope.ManageChallenges;
                        break;

                    case Constants.OAuthScope.ManageYouthPlayers:
                        result |= OAuthScope.ManageChallenges;
                        break;

                    case Constants.OAuthScope.PlaceBid:
                        result |= OAuthScope.PlaceBid;
                        break;

                    case Constants.OAuthScope.SetMatchOrders:
                        result |= OAuthScope.SetMatchOrders;
                        break;

                    case Constants.OAuthScope.SetTraining:
                        result |= OAuthScope.SetTraining;
                        break;

                    default:
                        throw new NotImplementedException(
                                  string.Format(
                                             Localization.Messages.UnknownOAuthScope,
                                             value));
                }
            }

            return result;
        }

        /// <summary>
        /// Gets the Query String value of the current OAuthScope state.
        /// </summary>
        /// <param name="value">OAuthScope state to convert.</param>
        /// <returns>Query String value of the current OAuthScope state.</returns>
        public static string GetString(this OAuthScope value)
        {
            var result = new List<string>();

            if (value.HasFlag(OAuthScope.ManageChallenges))
            {
                result.Add(Constants.OAuthScope.ManagerChallenges);
            }

            if (value.HasFlag(OAuthScope.ManageYouthPlayers))
            {
                result.Add(Constants.OAuthScope.ManageYouthPlayers);
            }

            if (value.HasFlag(OAuthScope.PlaceBid))
            {
                result.Add(Constants.OAuthScope.PlaceBid);
            }

            if (value.HasFlag(OAuthScope.SetMatchOrders))
            {
                result.Add(Constants.OAuthScope.SetMatchOrders);
            }

            if (value.HasFlag(OAuthScope.SetTraining))
            {
                result.Add(Constants.OAuthScope.SetTraining);
            }

            return string.Join(
                              Constants.OAuthScope.Separator,
                              result.ToArray());
        }

        #endregion Public Methods
    }
}