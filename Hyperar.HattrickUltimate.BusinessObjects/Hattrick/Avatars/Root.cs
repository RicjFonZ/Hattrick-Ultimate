// -----------------------------------------------------------------------
// <copyright file="Root.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
// -----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessObjects.Hattrick.Avatars
{
    /// <summary>
    /// Avatars XML file root.
    /// </summary>
    public class Root : XmlEntityBase
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the Team.
        /// </summary>
        public Team Team { get; set; }

        #endregion Public Properties
    }
}