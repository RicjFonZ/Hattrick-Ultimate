// -----------------------------------------------------------------------
// <copyright file="DownloadFile.cs" company="Hyperar">
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
    public class DownloadFile
    {
        #region Private Fields

        /// <summary>
        /// Xml file to download.
        /// </summary>
        private readonly XmlFile file;

        /// <summary>
        /// Parameter list.
        /// </summary>
        private readonly List<KeyValuePair<string, string>> parameters;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DownloadFile" /> class.
        /// </summary>
        /// <param name="file">Xml file to download.</param>
        /// <param name="parameters">Parameter list.</param>
        public DownloadFile(XmlFile file, List<KeyValuePair<string, string>> parameters = null)
        {
            this.file = file;
            this.parameters = parameters;
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>
        /// Gets the Xml file to download.
        /// </summary>
        public XmlFile File
        {
            get
            {
                return this.file;
            }
        }

        /// <summary>
        /// Gets the parameter list.
        /// </summary>
        public List<KeyValuePair<string, string>> Parameters
        {
            get
            {
                return this.parameters;
            }
        }

        #endregion Public Properties
    }
}