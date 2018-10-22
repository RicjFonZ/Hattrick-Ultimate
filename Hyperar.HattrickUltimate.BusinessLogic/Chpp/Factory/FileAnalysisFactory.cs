//-----------------------------------------------------------------------
// <copyright file="FileAnalysisFactory.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessLogic.Chpp.Factory
{
    using System.Collections.Generic;
    using BusinessLogic.Chpp.Interface;
    using BusinessLogic.Chpp.Strategy.FileAnalysis;
    using BusinessObjects.Hattrick.Interface;
    using DataAccess.Chpp.Constants;

    /// <summary>
    /// File Analysis Strategy Factory.
    /// </summary>
    public class FileAnalysisFactory : IFileAnalysisFactory
    {
        /// <summary>
        /// Strategy Dictionary.
        /// </summary>
        private readonly Dictionary<string, IFileAnalysisStrategy> strategies;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileAnalysisFactory"/> class.
        /// </summary>
        public FileAnalysisFactory()
        {
            this.strategies = new Dictionary<string, IFileAnalysisStrategy>();
        }

        /// <summary>
        /// Gets the corresponding Strategy to Analyze the specified file.
        /// </summary>
        /// <param name="entity">Entity to analyze.</param>
        /// <returns>The corresponding IFileAnalysis strategy.</returns>
        public IFileAnalysisStrategy GetFor(IXmlEntity entity)
        {
            IFileAnalysisStrategy result = null;

            if (!this.strategies.ContainsKey(entity.FileName.ToLower()))
            {
                switch (entity.FileName.ToLower())
                {
                    case XmlFileName.Avatars:
                    case XmlFileName.WorldDetails:
                    case XmlFileName.CheckToken:
                    case XmlFileName.Players:
                    case XmlFileName.YouthTeamDetails:
                        this.strategies.Add(entity.FileName, new Default());
                        break;

                    case XmlFileName.ManagerCompendium:
                        this.strategies.Add(entity.FileName, new ManagerCompendium());
                        break;

                    case XmlFileName.TeamDetails:
                        this.strategies.Add(entity.FileName, new TeamDetails());
                        break;
                }
            }

            result = this.strategies[entity.FileName];

            return result;
        }
    }
}