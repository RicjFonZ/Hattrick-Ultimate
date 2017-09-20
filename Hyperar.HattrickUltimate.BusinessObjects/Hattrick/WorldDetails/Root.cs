// -----------------------------------------------------------------------
// <copyright file="Root.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
// -----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessObjects.Hattrick.WorldDetails
{
    using System.Collections.Generic;

    /// <summary>
    /// WorldDetails XML file root.
    /// </summary>
    public class Root : XmlEntityBase
    {
        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Root"/> class.
        /// </summary>
        public Root()
        {
            this.LeagueList = new List<League>();
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>
        /// Gets or sets the League list.
        /// </summary>
        public List<League> LeagueList { get; set; }

        #endregion Public Properties
    }
}