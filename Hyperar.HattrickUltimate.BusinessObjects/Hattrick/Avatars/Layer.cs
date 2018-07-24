//-----------------------------------------------------------------------
// <copyright file="Layer.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessObjects.Hattrick.Avatars
{
    /// <summary>
    /// Layer node within Avatars XML file.
    /// </summary>
    public class Layer
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the Image URL.
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// Gets or sets the X value.
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Gets or sets the Y value.
        /// </summary>
        public int Y { get; set; }

        #endregion Public Properties
    }
}