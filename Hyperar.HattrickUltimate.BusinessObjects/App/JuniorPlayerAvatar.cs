//-----------------------------------------------------------------------
// <copyright file="JuniorPlayerAvatar.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessObjects.App
{
    using Interface;

    /// <summary>
    /// Represents a Junior Player Avatar.
    /// </summary>
    public class JuniorPlayerAvatar : EntityBase, IEntity
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the Avatar Image Bytes.
        /// </summary>
        public byte[] AvatarBytes { get; set; }

        /// <summary>
        /// Gets or sets the Junior Player.
        /// </summary>
        public virtual JuniorPlayer JuniorPlayer { get; set; }

        /// <summary>
        /// Gets the Junior Player Id.
        /// </summary>
        public int JuniorPlayerId
        {
            get
            {
                return this.JuniorPlayer.Id;
            }
        }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// Returns a System.String that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return this.GetType().FullName;
        }

        #endregion Public Methods
    }
}