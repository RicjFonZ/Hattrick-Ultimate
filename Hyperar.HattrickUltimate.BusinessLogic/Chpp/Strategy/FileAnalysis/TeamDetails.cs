//-----------------------------------------------------------------------
// <copyright file="TeamDetails.cs" company="Hyperar">
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
    /// TeamDetails File Analysis Strategy.
    /// </summary>
    public class TeamDetails : IFileAnalysisStrategy
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

            var teamDetails = entity as BusinessObjects.Hattrick.TeamDetails.Root;

            foreach (var team in teamDetails.Teams)
            {
                additionalTasks.Add(
                                    new ChppFile(
                                        XmlFile.Players,
                                        new Dictionary<string, string>
                                        {
                                            {
                                                QueryStringParameterName.TeamId,
                                                team.TeamId.ToString()
                                            }
                                        }));

                additionalTasks.Add(
                                    new ChppFile(
                                        XmlFile.Avatars,
                                        new Dictionary<string, string>
                                        {
                                            {
                                                QueryStringParameterName.TeamId,
                                                team.TeamId.ToString()
                                            }
                                        }));

                if (team.YouthTeamId.HasValue)
                {
                    additionalTasks.Add(
                                        new ChppFile(
                                            XmlFile.YouthTeamDetails,
                                            new Dictionary<string, string>
                                            {
                                                {
                                                    QueryStringParameterName.YouthTeamId,
                                                    team.YouthTeamId.Value.ToString()
                                                }
                                            }));

                    additionalTasks.Add(
                                        new ChppFile(
                                            XmlFile.YouthPlayerList,
                                            new Dictionary<string, string>
                                            {
                                                {
                                                    QueryStringParameterName.ActionType,
                                                    "details"
                                                },
                                                {
                                                    QueryStringParameterName.YouthTeamId,
                                                    team.YouthTeamId.Value.ToString()
                                                },
                                                {
                                                    QueryStringParameterName.ShowScoutCall,
                                                    bool.TrueString
                                                },
                                                {
                                                    QueryStringParameterName.ShowLastMatch,
                                                    bool.TrueString
                                                }
                                            }));

                    additionalTasks.Add(
                                        new ChppFile(
                                            XmlFile.YouthAvatars,
                                            new Dictionary<string, string>
                                            {
                                                {
                                                    QueryStringParameterName.YouthTeamId,
                                                    team.YouthTeamId.Value.ToString()
                                                }
                                            }));
                }
            }

            return additionalTasks;
        }

        #endregion Public Methods
    }
}