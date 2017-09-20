// -----------------------------------------------------------------------
// <copyright file="Layer.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
// -----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessObjects.Hattrick.ManagerCompendium
{
    /// <summary>
    /// Layer node within ManagerCompendium XML file.
    /// </summary>
    public class Layer
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the image URL.
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// Gets or sets the X axis position.
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Gets or sets the Y axis position.
        /// </summary>
        public int Y { get; set; }

        #endregion Public Properties
    }
}