// -----------------------------------------------------------------------
// <copyright file="XmlParserBase.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
// -----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.DataAccess.Chpp
{
    using System;
    using System.IO;
    using System.Xml;
    using BusinessObjects.Hattrick.Interface;
    using Factory;
    using Interface;

    /// <summary>
    /// Hattrick XML file base parser.
    /// </summary>
    internal class XmlParserBase
    {
        #region Private Fields

        /// <summary>
        /// Hattrick Entity factory.
        /// </summary>
        private EntityFactory entityFactory;

        /// <summary>
        /// Hattrick XML Parser factory.
        /// </summary>
        private XmlParserFactory parserFactory;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="XmlParserBase"/> class.
        /// </summary>
        internal XmlParserBase()
        {
            this.entityFactory = new EntityFactory();
            this.parserFactory = new XmlParserFactory();
        }

        #endregion Internal Constructors

        #region Internal Methods

        /// <summary>
        /// Parse the given file.
        /// </summary>
        /// <param name="file">File stream.</param>
        /// <returns>Corresponding IHattrickEntity object.</returns>
        internal IXmlEntity Parse(Stream file)
        {
            IXmlEntity result = null;

            using (XmlReader reader = XmlReader.Create(file, new XmlReaderSettings { CloseInput = true, IgnoreComments = true, IgnoreProcessingInstructions = true, IgnoreWhitespace = true }))
            {
                reader.ReadToFollowing(Constants.XmlTag.FileName);

                result = this.entityFactory.GetEntity(reader.ReadElementContentAsString());
                result.Version = reader.ReadElementContentAsDecimal();
                result.UserID = uint.Parse(reader.ReadElementContentAsString());
                result.FetchedDate = DateTime.Parse(reader.ReadElementContentAsString());

                IXmlParserStrategy parsingStrategy = this.parserFactory.GetParser(result.FileName);

                parsingStrategy.Parse(reader, ref result);
            }

            return result;
        }

        /// <summary>
        /// Parse the given file name.
        /// </summary>
        /// <param name="fileName">File name and path to parse.</param>
        /// <returns>Corresponding IHattrickEntity object.</returns>
        internal IXmlEntity Parse(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                throw new ArgumentNullException(nameof(fileName));
            }

            IXmlEntity result = null;

            Stream file = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);

            using (XmlReader reader = XmlReader.Create(file, new XmlReaderSettings { CloseInput = true, IgnoreComments = true, IgnoreProcessingInstructions = true, IgnoreWhitespace = true }))
            {
                reader.ReadToFollowing(Constants.XmlTag.FileName);

                result = this.entityFactory.GetEntity(reader.ReadElementContentAsString());
                result.Version = reader.ReadElementContentAsDecimal();
                result.UserID = uint.Parse(reader.ReadElementContentAsString());
                result.FetchedDate = DateTime.Parse(reader.ReadElementContentAsString());

                IXmlParserStrategy parsingStrategy = this.parserFactory.GetParser(result.FileName);

                parsingStrategy.Parse(reader, ref result);
            }

            return result;
        }

        #endregion Internal Methods
    }
}