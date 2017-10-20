// -----------------------------------------------------------------------
// <copyright file="IFileProcessStrategy.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
// -----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessLogic.Chpp.Interface
{
    using BusinessObjects.Hattrick.Interface;

    /// <summary>
    /// Provides functionality to process Hattrick Xml files.
    /// </summary>
    public interface IFileProcessStrategy
    {
        #region Public Methods

        /// <summary>
        /// Process the specified file.
        /// </summary>
        /// <param name="fileToProcess">File to process.</param>
        void ProcessFile(IXmlEntity fileToProcess);

        #endregion Public Methods
    }
}