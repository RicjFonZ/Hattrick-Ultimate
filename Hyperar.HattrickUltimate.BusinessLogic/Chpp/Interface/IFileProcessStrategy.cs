// -----------------------------------------------------------------------
// <copyright file="IFileProcessStrategy.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
// -----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessLogic.Chpp.Interface
{
    using System.Collections.Generic;
    using BusinessObjects.Hattrick.Interface;

    /// <summary>
    /// Provides functionality to process Hattrick Xml files.
    /// </summary>
    internal interface IFileProcessStrategy
    {
        #region Public Methods

        /// <summary>
        /// Process the specified file.
        /// </summary>
        /// <param name="fileToProcess">File to process.</param>
        /// <param name="parameters">Process parameters.</param>
        void ProcessFile(IXmlEntity fileToProcess, Dictionary<string, object> parameters = null);

        #endregion Public Methods
    }
}