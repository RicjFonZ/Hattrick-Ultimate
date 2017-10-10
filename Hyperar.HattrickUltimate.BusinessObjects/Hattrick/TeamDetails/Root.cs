// -----------------------------------------------------------------------
// <copyright file="Root.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
// -----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessObjects.Hattrick.TeamDetails
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
            this.User = new User();
            this.Teams = new List<Team>();
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>
        /// Gets or sets the Team list.
        /// </summary>
        public List<Team> Teams { get; set; }

        /// <summary>
        /// Gets or sets the User.
        /// </summary>
        public User User { get; set; }

        #endregion Public Properties
    }
}