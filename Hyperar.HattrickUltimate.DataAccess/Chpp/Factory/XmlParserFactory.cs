//-----------------------------------------------------------------------
// <copyright file="XmlParserFactory.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.DataAccess.Chpp.Factory
{
    using System;
    using System.Collections.Generic;
    using Constants;
    using Interface;
    using Strategy.XmlParser;

    /// <summary>
    /// Hattrick XML file parser factory definition.
    /// </summary>
    internal class XmlParserFactory : IXmlParserFactory
    {
        #region Private Fields

        /// <summary>
        /// Parser dictionary.
        /// </summary>
        private readonly Dictionary<string, IXmlParserStrategy> parserDictionary;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="XmlParserFactory"/> class.
        /// </summary>
        internal XmlParserFactory()
        {
            this.parserDictionary = new Dictionary<string, IXmlParserStrategy>();
        }

        #endregion Internal Constructors

        #region Public Methods

        /// <summary>
        /// Gets the corresponding IXmlParserStrategy for the specified file and version.
        /// </summary>
        /// <param name="fileName">Hattrick XML filename (from the FileName tag).</param>
        /// <returns>The corresponding IXmlParserStrategy object.</returns>
        public IXmlParserStrategy GetParser(string fileName)
        {
            fileName = fileName.ToLower();

            if (string.IsNullOrWhiteSpace(fileName))
            {
                throw new ArgumentNullException(nameof(fileName));
            }

            if (!this.parserDictionary.ContainsKey(fileName))
            {
                switch (fileName)
                {
                    case XmlFileName.Avatars:
                        this.parserDictionary.Add(fileName, new Avatars());
                        break;

                    case XmlFileName.CheckToken:
                        this.parserDictionary.Add(fileName, new CheckToken());
                        break;

                    case XmlFileName.ManagerCompendium:
                        this.parserDictionary.Add(fileName, new ManagerCompendium());
                        break;

                    case XmlFileName.Players:
                        this.parserDictionary.Add(fileName, new Players());
                        break;

                    case XmlFileName.TeamDetails:
                        this.parserDictionary.Add(fileName, new TeamDetails());
                        break;

                    case XmlFileName.WorldDetails:
                        this.parserDictionary.Add(fileName, new WorldDetails());
                        break;

                    case XmlFileName.YouthAvatars:
                        this.parserDictionary.Add(fileName, new YouthAvatars());
                        break;

                    case XmlFileName.YouthPlayerList:
                        this.parserDictionary.Add(fileName, new YouthPlayerList());
                        break;

                    case XmlFileName.YouthTeamDetails:
                        this.parserDictionary.Add(fileName, new YouthTeamDetails());
                        break;

                    default:
                        throw new NotImplementedException(
                                      string.Format(
                                                 Localization.Messages.NotImplemented,
                                                 typeof(IXmlParserStrategy).Name,
                                                 fileName));
                }
            }

            return this.parserDictionary[fileName];
        }

        #endregion Public Methods
    }
}