//-----------------------------------------------------------------------
// <copyright file="Token.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessObjects.App
{
    using System;
    using Enums;
    using Interface;

    /// <summary>
    /// OAuth Token.
    /// </summary>
    public class Token : EntityBase, IEntity
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the date and time when the token was created.
        /// </summary>
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the token was expires.
        /// </summary>
        public DateTime ExpiresOn { get; set; }

        /// <summary>
        /// Gets or sets the key.
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Gets or sets the permissions associated with the token.
        /// </summary>
        public OAuthScope Scope { get; set; }

        /// <summary>
        /// Gets or sets the secret.
        /// </summary>
        public string Secret { get; set; }

        /// <summary>
        /// Gets or sets the User.
        /// </summary>
        public virtual User User { get; set; }

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