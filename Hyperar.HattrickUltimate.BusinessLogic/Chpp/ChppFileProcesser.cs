// -----------------------------------------------------------------------
// <copyright file="ChppFileProcesser.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
// -----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessLogic.Chpp
{
    using BusinessObjects.Hattrick.Interface;
    using Interface;

    /// <summary>
    /// Provides functionality to process CHPP files.
    /// </summary>
    public class ChppFileProcesser : IFileProcessStrategy
    {
        #region Private Fields

        /// <summary>
        /// File Process Factory.
        /// </summary>
        private IFileProcessFactory fileProcessFactory;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ChppFileProcesser" /> class.
        /// </summary>
        /// <param name="fileProcessFactory">File Process Factory.</param>
        public ChppFileProcesser(IFileProcessFactory fileProcessFactory)
        {
            this.fileProcessFactory = fileProcessFactory;
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// Processes the specified file.
        /// </summary>
        /// <param name="fileToProcess">File to process.</param>
        public void ProcessFile(IXmlEntity fileToProcess)
        {
            this.fileProcessFactory.GetFor(fileToProcess)
                                   .ProcessFile(fileToProcess);
        }

        #endregion Public Methods
    }
}