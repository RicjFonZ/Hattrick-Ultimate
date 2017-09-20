// -----------------------------------------------------------------------
// <copyright file="IXmlParserFactory.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
// -----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.DataAccess.Chpp.Interface
{
    /// <summary>
    /// Hattrick XML file parser factory definition.
    /// </summary>
    internal interface IXmlParserFactory
    {
        #region Public Methods

        /// <summary>
        /// Gets the corresponding IXmlParserStrategy for the specified file and version.
        /// </summary>
        /// <param name="fileName">Hattrick XML filename (from the FileName tag).</param>
        /// <returns>The corresponding IXmlParserStrategy object.</returns>
        IXmlParserStrategy GetParser(string fileName);

        #endregion Public Methods
    }
}