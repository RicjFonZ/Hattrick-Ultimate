//-----------------------------------------------------------------------
// <copyright file="ManagerCompendium.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessLogic.Chpp.Strategy.FileAnalysis
{
    using System.Collections.Generic;
    using BusinessLogic.Chpp.Interface;
    using BusinessObjects.Hattrick.Enums;
    using BusinessObjects.Hattrick.Interface;
    using DataAccess.Chpp.Constants;

    /// <summary>
    /// ManagerCompendium File Analysis Strategy.
    /// </summary>
    public class ManagerCompendium : IFileAnalysisStrategy
    {
        #region Public Methods

        /// <summary>
        /// Analyses the specified entity.
        /// </summary>
        /// <param name="entity">Entity to analyze.</param>
        /// <returns>Additional Files Tasks list.</returns>
        public List<ChppFile> Analyze(IXmlEntity entity)
        {
            var additionalTasks = new List<ChppFile>();

            var managerCompendium = entity as BusinessObjects.Hattrick.ManagerCompendium.Root;

            foreach (var team in managerCompendium.Manager.Teams)
            {
                additionalTasks.Add(
                        new ChppFile(
                            XmlFile.WorldDetails,
                            new Dictionary<string, string>
                            {
                                            {
                                                QueryStringParameterName.LeagueId,
                                                team.League.LeagueId.ToString()
                                            },
                                            {
                                                QueryStringParameterName.IncludeRegions,
                                                bool.TrueString
                                            }
                            }));

                additionalTasks.Add(
                                    new ChppFile(
                                        XmlFile.TeamDetails,
                                        new Dictionary<string, string>
                                        {
                                            {
                                                QueryStringParameterName.TeamId,
                                                team.TeamId.ToString()
                                            }
                                        }));
            }

            return additionalTasks;
        }

        #endregion Public Methods
    }
}