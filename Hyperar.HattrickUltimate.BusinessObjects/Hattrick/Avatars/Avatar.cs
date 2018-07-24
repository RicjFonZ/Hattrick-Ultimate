//-----------------------------------------------------------------------
// <copyright file="Avatar.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessObjects.Hattrick.Avatars
{
    using System.Collections.Generic;

    /// <summary>
    /// Avatar node within Avatars XML file.
    /// </summary>
    public class Avatar
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the Background Image URL.
        /// </summary>
        public string BackgroundImage { get; set; }

        /// <summary>
        /// Gets or sets the Layers.
        /// </summary>
        public List<Layer> Layers { get; set; }

        #endregion Public Properties
    }
}