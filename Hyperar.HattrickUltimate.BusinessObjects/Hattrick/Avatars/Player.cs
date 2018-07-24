//-----------------------------------------------------------------------
// <copyright file="Player.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessObjects.Hattrick.Avatars
{
    /// <summary>
    /// Player node within Avatars XML file.
    /// </summary>
    public class Player
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the Avatar.
        /// </summary>
        public Avatar Avatar { get; set; }

        /// <summary>
        /// Gets or sets the Player ID.
        /// </summary>
        public long PlayerId { get; set; }

        #endregion Public Properties
    }
}