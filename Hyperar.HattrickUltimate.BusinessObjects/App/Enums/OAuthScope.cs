// -----------------------------------------------------------------------
// <copyright file="OAuthScope.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
// -----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessObjects.App.Enums
{
    using System;

    /// <summary>
    /// Represents OAuth access permissions.
    /// </summary>
    [Flags]
    public enum OAuthScope : byte
    {
        /// <summary>
        /// Initial state.
        /// </summary>
        None = 0,

        /// <summary>
        /// Allows to accept, reject and send friendly match invitations.
        /// </summary>
        ManageChallenges = 1,

        /// <summary>
        /// Allows to set matches lineup and formation.
        /// </summary>
        SetMatchOrders = 2,

        /// <summary>
        /// Allows revealing youth players' hidden skills.
        /// </summary>
        ManageYouthPlayers = 4,

        /// <summary>
        /// Allows to set the training's type, intensity and stamina share
        /// </summary>
        SetTraining = 8,

        /// <summary>
        /// Allows to place a bid on a transfer listed player.
        /// </summary>
        PlaceBid = 16
    }
}