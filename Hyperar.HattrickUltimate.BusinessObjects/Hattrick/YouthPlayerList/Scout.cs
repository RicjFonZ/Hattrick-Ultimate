//-----------------------------------------------------------------------
// <copyright file="Scout.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessObjects.Hattrick.YouthPlayerList
{
    /// <summary>
    /// Scout node within Youth Player List XML file.
    /// </summary>
    public class Scout
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the Scout ID.
        /// </summary>
        public long ScoutId { get; set; }

        /// <summary>
        /// Gets or sets the Scout Name.
        /// </summary>
        public string ScoutName { get; set; }

        #endregion Public Properties
    }
}