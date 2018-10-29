//-----------------------------------------------------------------------
// <copyright file="Default.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessLogic.Chpp.Strategy.FileAnalysis
{
    using System.Collections.Generic;
    using BusinessLogic.Chpp.Interface;
    using BusinessObjects.Hattrick.Interface;
    using Hyperar.HattrickUltimate.BusinessObjects.App;

    /// <summary>
    /// Default File Analysis Strategy.
    /// </summary>
    public class Default : IFileAnalysisStrategy
    {
        #region Public Methods

        /// <summary>
        /// Analyses the specified entity.
        /// </summary>
        /// <param name="entity">Entity to analyze.</param>
        /// <param name="downloadSettings">Download Settings.</param>
        /// <returns>Additional Files Tasks list.</returns>
        public List<ChppFile> Analyze(IXmlEntity entity, DownloadSettings downloadSettings)
        {
            return null;
        }

        #endregion Public Methods
    }
}