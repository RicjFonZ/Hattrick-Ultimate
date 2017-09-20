// -----------------------------------------------------------------------
// <copyright file="OAuthScopeExtensionMethods.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
// -----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessLogic.ExtensionMethods
{
    using System.Collections.Generic;
    using BusinessObjects.App.Enums;

    /// <summary>
    /// OAuth Scope extension methods.
    /// </summary>
    public static class OAuthScopeExtensionMethods
    {
        #region Public Methods

        /// <summary>
        /// Gets the Query String value of the current OAuthScope state.
        /// </summary>
        /// <param name="value">OAuthScope state to convert.</param>
        /// <returns>Query String value of the current OAuthScope state.</returns>
        public static string GetQueryStringValue(this OAuthScope value)
        {
            List<string> result = new List<string>();

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