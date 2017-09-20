// -----------------------------------------------------------------------
// <copyright file="Root.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
// -----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessObjects.Hattrick.CheckToken
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// CheckToken XML file root.
    /// </summary>
    public class Root : XmlEntityBase
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the date and time when the Token was created.
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the Token expires.
        /// </summary>
        public DateTime Expires { get; set; }

        /// <summary>
        /// Gets or sets the list of OAuth Scopes associated to the Token.
        /// </summary>
        public List<string> ExtendedPermissions { get; set; }

        /// <summary>
        /// Gets or sets the Token.
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Gets or sets the User ID.
        /// </summary>
        public uint User { get; set; }

        #endregion Public Properties
    }
}