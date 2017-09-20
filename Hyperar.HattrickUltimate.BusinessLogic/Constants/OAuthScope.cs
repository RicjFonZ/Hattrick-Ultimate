// -----------------------------------------------------------------------
// <copyright file="OAuthScope.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
// -----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessLogic.Constants
{
    /// <summary>
    /// OAuth Scope constants.
    /// </summary>
    internal class OAuthScope
    {
        #region Internal Fields

        /// <summary>
        /// Manage Challenges OAuth scope constant.
        /// </summary>
        internal const string ManagerChallenges = "manage_challenges";

        /// <summary>
        /// Manage Youth Players OAuth scope constant.
        /// </summary>
        internal const string ManageYouthPlayers = "manage_youthplayers";

        /// <summary>
        /// Place Bid OAuth scope constant.
        /// </summary>
        internal const string PlaceBid = "place_bid";

        /// <summary>
        /// OAuth scope query string parameter.
        /// </summary>
        internal const string QueryStringParameter = "scope";

        /// <summary>
        /// OAuth Scope query string separator.
        /// </summary>
        internal const string Separator = ",";

        /// <summary>
        /// Set Match Orders OAuth scope constant.
        /// </summary>
        internal const string SetMatchOrders = "set_matchorder";

        /// <summary>
        /// Set Training OAuth scope constant.
        /// </summary>
        internal const string SetTraining = "set_training";

        #endregion Internal Fields
    }
}