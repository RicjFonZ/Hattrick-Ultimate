// -----------------------------------------------------------------------
// <copyright file="IXmlEntity.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
// -----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessObjects.Hattrick.Interface
{
    using System;

    /// <summary>
    /// Hattrick base entity.
    /// </summary>
    public interface IXmlEntity
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the date and time when the file was fetched.
        /// </summary>
        DateTime FetchedDate { get; set; }

        /// <summary>
        /// Gets or sets the file name.
        /// </summary>
        string FileName { get; set; }

        /// <summary>
        /// Gets or sets the ID of the User that fetched the file.
        /// </summary>
        long UserID { get; set; }

        /// <summary>
        /// Gets or sets the version number.
        /// </summary>
        decimal Version { get; set; }

        #endregion Public Properties
    }
}