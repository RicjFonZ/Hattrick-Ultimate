// -----------------------------------------------------------------------
// <copyright file="ChppFile.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
// -----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessLogic
{
    using System.Collections.Generic;
    using BusinessObjects.Hattrick.Enums;

    /// <summary>
    /// Download file task definition.
    /// </summary>
    public class ChppFile
    {
        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ChppFile"/> class.
        /// </summary>
        /// <param name="file">Xml file to download.</param>
        /// <param name="parameters">Parameter list.</param>
        public ChppFile(XmlFile file, Dictionary<string, string> parameters = null)
        {
            this.File = file;
            this.Parameters = parameters;
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>
        /// Gets the Xml file to download.
        /// </summary>
        public XmlFile File { get; }

        /// <summary>
        /// Gets the parameter list.
        /// </summary>
        public Dictionary<string, string> Parameters { get; }

        #endregion Public Properties
    }
}