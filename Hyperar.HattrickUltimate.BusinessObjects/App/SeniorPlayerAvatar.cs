//-----------------------------------------------------------------------
// <copyright file="SeniorPlayerAvatar.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessObjects.App
{
    using Interface;

    /// <summary>
    /// Represents a Senior Player Avatar.
    /// </summary>
    public class SeniorPlayerAvatar : EntityBase, IEntity
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the Avatar Image Bytes.
        /// </summary>
        public byte[] AvatarBytes { get; set; }

        /// <summary>
        /// Gets or sets the Senior Player.
        /// </summary>
        public virtual SeniorPlayer SeniorPlayer { get; set; }

        /// <summary>
        /// Gets the Senior Player Id.
        /// </summary>
        public int SeniorPlayerId
        {
            get
            {
                return this.SeniorPlayer.Id;
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