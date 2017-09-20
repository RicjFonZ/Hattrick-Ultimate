// -----------------------------------------------------------------------
// <copyright file="IXmlParserStrategy.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
// -----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.DataAccess.Chpp.Interface
{
    using System.Xml;
    using BusinessObjects.Hattrick.Interface;

    /// <summary>
    /// Hattrick XML file parser definition.
    /// </summary>
    internal interface IXmlParserStrategy
    {
        #region Public Methods

        /// <summary>
        /// Parse XML file specific nodes.
        /// </summary>
        /// <param name="reader">Reader initialized with XML file.</param>
        /// <param name="entity">IHattrickEntity object to store read data.</param>
        void Parse(XmlReader reader, ref IXmlEntity entity);

        #endregion Public Methods
    }
}