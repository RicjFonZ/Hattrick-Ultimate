// -----------------------------------------------------------------------
// <copyright file="Avatar.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
// -----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessObjects.Hattrick.ManagerCompendium
{
    using System.Collections.Generic;

    /// <summary>
    /// Avatar node within ManagerCompendium XML file.
    /// </summary>
    public class Avatar
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the background image URL.
        /// </summary>
        public string BackgroundImage { get; set; }

        /// <summary>
        /// Gets or sets the avatar layers.
        /// </summary>
        public List<Layer> Layers { get; set; }

        #endregion Public Properties
    }
}