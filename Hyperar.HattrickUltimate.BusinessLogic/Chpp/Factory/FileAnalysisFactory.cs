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
        #region Private Fields

        /// <summary>
        /// Strategy Dictionary.
        /// </summary>
        private readonly Dictionary<string, IFileAnalysisStrategy> strategies;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="FileAnalysisFactory"/> class.
        /// </summary>
        public FileAnalysisFactory()
        {
            this.strategies = new Dictionary<string, IFileAnalysisStrategy>();
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// Gets the corresponding Strategy to Analyze the specified file.
        /// </summary>
        /// <param name="entity">Entity to analyze.</param>
        /// <returns>The corresponding IFileAnalysis strategy.</returns>
        public IFileAnalysisStrategy GetFor(IXmlEntity entity)
        {
            IFileAnalysisStrategy result = null;

            string key = entity.FileName.ToLower();

            if (!this.strategies.ContainsKey(key))
            {
                switch (key)
                {
                    case XmlFileName.Avatars:
                    case XmlFileName.WorldDetails:
                    case XmlFileName.CheckToken:
                    case XmlFileName.Players:
                    case XmlFileName.YouthAvatars:
                    case XmlFileName.YouthPlayerList:
                    case XmlFileName.YouthTeamDetails:
                        this.strategies.Add(key, new Default());
                        break;

                    case XmlFileName.ManagerCompendium:
                        this.strategies.Add(key, new ManagerCompendium());
                        break;

                    case XmlFileName.TeamDetails:
                        this.strategies.Add(key, new TeamDetails());
                        break;
                }
            }

            result = this.strategies[key];

            return result;
        }

        #endregion Public Methods
    }
}