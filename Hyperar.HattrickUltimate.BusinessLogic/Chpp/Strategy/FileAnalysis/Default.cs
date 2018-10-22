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

    /// <summary>
    /// Default File Analysis Strategy.
    /// </summary>
    public class Default : IFileAnalysisStrategy
    {
        /// <summary>
        /// Analyses the specified entity.
        /// </summary>
        /// <param name="entity">Entity to analyze.</param>
        /// <returns>Additional Files Tasks list.</returns>
        public List<ChppFile> Analyze(IXmlEntity entity)
        {
            return null;
        }
    }
}