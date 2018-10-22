//-----------------------------------------------------------------------
// <copyright file="Root.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessObjects.Hattrick.YouthPlayerList
{
    using System.Collections.Generic;

    /// <summary>
    /// Youth Player List XML file root.
    /// </summary>
    public class Root : XmlEntityBase
    {
        /// <summary>
        /// Gets or sets the Player List.
        /// </summary>
        public List<YouthPlayer> PlayerList { get; set; }
    }
}