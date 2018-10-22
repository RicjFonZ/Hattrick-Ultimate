//-----------------------------------------------------------------------
// <copyright file="Root.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessObjects.Hattrick.YouthTeamDetails
{
    using BusinessObjects.Hattrick.Interface;

    /// <summary>
    /// YouthTeamDetails XML file root.
    /// </summary>
    public class Root : XmlEntityBase, IXmlEntity
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the Youth Team.
        /// </summary>
        public YouthTeam YouthTeam { get; set; }

        #endregion Public Properties
    }
}