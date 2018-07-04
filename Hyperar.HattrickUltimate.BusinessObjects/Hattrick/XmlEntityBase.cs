// -----------------------------------------------------------------------
// <copyright file="XmlEntityBase.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
// -----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessObjects.Hattrick
{
    using System;
    using Interface;

    /// <summary>
    /// Hattrick XML files' header.
    /// </summary>
    public abstract class XmlEntityBase : IXmlEntity
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the date and time when the file was fetched.
        /// </summary>
        public DateTime FetchedDate { get; set; }

        /// <summary>
        /// Gets or sets the file name.
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// Gets or sets the ID of the User that fetched the file.
        /// </summary>
        public long UserID { get; set; }

        /// <summary>
        /// Gets or sets the version number.
        /// </summary>
        public decimal Version { get; set; }

        #endregion Public Properties
    }
}