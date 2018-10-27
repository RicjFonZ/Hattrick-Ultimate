//-----------------------------------------------------------------------
// <copyright file="FileAnalyser.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessLogic.Chpp
{
    using System.Collections.Generic;
    using BusinessLogic.Chpp.Interface;
    using BusinessObjects.Hattrick.Interface;

    /// <summary>
    /// Provides functionality to analyse CHPP files.
    /// </summary>
    public class FileAnalyser : IFileAnalysisStrategy
    {
        #region Private Fields

        /// <summary>
        /// File Analysis Strategy Factory.
        /// </summary>
        private readonly IFileAnalysisFactory factory;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="FileAnalyser"/> class.
        /// </summary>
        /// <param name="factory">File Analysis Strategy Factory.</param>
        public FileAnalyser(IFileAnalysisFactory factory)
        {
            this.factory = factory;
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// Analyse the specified file and adds additional Files Tasks.
        /// </summary>
        /// <param name="entity">Entity to analyze.</param>
        /// <returns>Additional Files Tasks.</returns>
        public List<ChppFile> Analyze(IXmlEntity entity)
        {
            return this.factory.GetFor(entity)
                               .Analyze(entity);
        }

        #endregion Public Methods
    }
}