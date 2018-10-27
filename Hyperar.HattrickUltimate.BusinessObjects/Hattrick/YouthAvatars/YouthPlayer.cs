//-----------------------------------------------------------------------
// <copyright file="YouthPlayer.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessObjects.Hattrick.YouthAvatars
{
    /// <summary>
    /// Youth Player node within Avatars XML file.
    /// </summary>
    public class YouthPlayer
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the Avatar.
        /// </summary>
        public Avatar Avatar { get; set; }

        /// <summary>
        /// Gets or sets the Youth Player ID.
        /// </summary>
        public long YouthPlayerId { get; set; }

        #endregion Public Properties
    }
}