// -----------------------------------------------------------------------
// <copyright file="Root.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
// -----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessObjects.Hattrick.ManagerCompendium
{
    /// <summary>
    /// ManagerCompendium XML file root.
    /// </summary>
    public class Root : XmlEntityBase
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the manager.
        /// </summary>
        public Manager Manager { get; set; }

        #endregion Public Properties
    }
}