//-----------------------------------------------------------------------
// <copyright file="ScoutCall.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessObjects.Hattrick.YouthPlayerList
{
    using System.Collections.Generic;

    /// <summary>
    /// LastMatch node within Youth Player List XML file.
    /// </summary>
    public class ScoutCall
    {
        /// <summary>
        /// Gets or sets the Scout.
        /// </summary>
        public Scout Scout { get; set; }

        /// <summary>
        /// Gets or sets the Scout Comments.
        /// </summary>
        public List<ScoutComment> ScoutComments { get; set; }

        /// <summary>
        /// Gets or sets the Region ID where the Scout is looking for Players.
        /// </summary>
        public long ScoutRegionId { get; set; }
    }
}