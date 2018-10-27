//-----------------------------------------------------------------------
// <copyright file="YouthPlayerList.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.DataAccess.Chpp.Strategy.XmlParser
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml;
    using BusinessObjects.Hattrick.Interface;
    using Constants;
    using Interface;

    /// <summary>
    /// Youth Player List XML file parser strategy.
    /// </summary>
    internal class YouthPlayerList : IXmlParserStrategy
    {
        #region Public Methods

        /// <summary>
        /// Parse XML file specific nodes.
        /// </summary>
        /// <param name="reader">Reader initialized with XML file.</param>
        /// <param name="entity">IHattrickEntity object to store read data.</param>
        public void Parse(XmlReader reader, ref IXmlEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            var result = (BusinessObjects.Hattrick.YouthPlayerList.Root)entity;

            result.PlayerList = new List<BusinessObjects.Hattrick.YouthPlayerList.YouthPlayer>();

            // Skips PlayerList opening tag.
            reader.Read();

            while (reader.Name.Equals(XmlTag.YouthPlayer, StringComparison.OrdinalIgnoreCase))
            {
                result.PlayerList.Add(
                                      this.ParseYouthPlayerNode(reader));
            }

            // Skips PlayerList closing tag.
            reader.Read();
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        /// Parses LastMatch node.
        /// </summary>
        /// <param name="reader">XmlReader object loaded with the Xml file.</param>
        /// <returns>BusinessObjects.Hattrick.YouthPlayerList.LastMatch with the parsed data.</returns>
        private BusinessObjects.Hattrick.YouthPlayerList.LastMatch ParseLastMatchNode(XmlReader reader)
        {
            if (!reader.Name.Equals(XmlTag.LastMatch, StringComparison.OrdinalIgnoreCase))
            {
                throw new Exception(
                              string.Format(
                                         Localization.Messages.UnexpectedXmlElement,
                                         reader.Name));
            }

            BusinessObjects.Hattrick.YouthPlayerList.LastMatch lastMatch = null;

            if (!reader.IsEmptyElement)
            {
                // Skips LastMatch opening tag.
                reader.Read();

                lastMatch = new BusinessObjects.Hattrick.YouthPlayerList.LastMatch
                {
                    YouthMatchId = long.Parse(reader.ReadElementContentAsString()),
                    Date = DateTime.Parse(reader.ReadElementContentAsString()),
                    PositionCode = ushort.Parse(reader.ReadElementContentAsString()),
                    PlayedMinutes = byte.Parse(reader.ReadElementContentAsString()),
                    Rating = decimal.Parse(reader.ReadElementContentAsString())
                };
            }

            // Skips LastMatch closing tag.
            reader.Read();

            return lastMatch;
        }

        /// <summary>
        /// Parses OwningYouthTeam node.
        /// </summary>
        /// <param name="reader">XmlReader object loaded with the Xml file.</param>
        /// <returns>
        /// BusinessObjects.Hattrick.YouthPlayerList.OwningYouthTeam with the parsed data.
        /// </returns>
        private BusinessObjects.Hattrick.YouthPlayerList.OwningYouthTeam ParseOwningYouthTeamNode(XmlReader reader)
        {
            if (!reader.Name.Equals(XmlTag.OwningYouthTeam, StringComparison.OrdinalIgnoreCase))
            {
                throw new Exception(
                              string.Format(
                                         Localization.Messages.UnexpectedXmlElement,
                                         reader.Name));
            }

            // Skips OwningYouthTeam opening tag.
            reader.Read();

            var newYouthTeam = new BusinessObjects.Hattrick.YouthPlayerList.OwningYouthTeam
            {
                YouthTeamId = long.Parse(reader.ReadElementContentAsString()),
                YouthTeamName = reader.ReadElementContentAsString(),
                YouthTeamLeagueId = long.Parse(reader.ReadElementContentAsString()),
                SeniorTeam = this.ParseSeniorTeamNode(reader)
            };

            // Skips OwningYouthTeam closing tag.
            reader.Read();

            return newYouthTeam;
        }

        /// <summary>
        /// Parses PlayerSkills node.
        /// </summary>
        /// <param name="reader">XmlReader object loaded with the Xml file.</param>
        /// <returns>BusinessObjects.Hattrick.YouthPlayerList.PlayerSkills with the parsed data.</returns>
        private BusinessObjects.Hattrick.YouthPlayerList.PlayerSkills ParsePlayerSkillsNode(XmlReader reader)
        {
            if (!reader.Name.Equals(XmlTag.PlayerSkills, StringComparison.OrdinalIgnoreCase))
            {
                throw new Exception(
                              string.Format(
                                         Localization.Messages.UnexpectedXmlElement,
                                         reader.Name));
            }

            // Skips PlayerSkills opening tag.
            reader.Read();

            var playerSkills = new BusinessObjects.Hattrick.YouthPlayerList.PlayerSkills
            {
                KeeperSkill = this.ParseSkillNode(reader),
                KeeperSkillMax = this.ParseSkillMaxNode(reader),
                DefenderSkill = this.ParseSkillNode(reader),
                DefenderSkillMax = this.ParseSkillMaxNode(reader),
                PlaymakerSkill = this.ParseSkillNode(reader),
                PlaymakerSkillMax = this.ParseSkillMaxNode(reader),
                WingerSkill = this.ParseSkillNode(reader),
                WingerSkillMax = this.ParseSkillMaxNode(reader),
                PassingSkill = this.ParseSkillNode(reader),
                PassingSkillMax = this.ParseSkillMaxNode(reader),
                ScorerSkill = this.ParseSkillNode(reader),
                ScorerSkillMax = this.ParseSkillMaxNode(reader),
                SetPiecesSkill = this.ParseSkillNode(reader),
                SetPiecesSkillMax = this.ParseSkillMaxNode(reader),
            };

            // Skips PlayerSkills closing tag.
            reader.Read();

            return playerSkills;
        }

        /// <summary>
        /// Parses ScoutCall node.
        /// </summary>
        /// <param name="reader">XmlReader object loaded with the Xml file.</param>
        /// <returns>BusinessObjects.Hattrick.YouthPlayerList.ScoutCall with the parsed data.</returns>
        private BusinessObjects.Hattrick.YouthPlayerList.ScoutCall ParseScoutCallNode(XmlReader reader)
        {
            if (!reader.Name.Equals(XmlTag.ScoutCall, StringComparison.OrdinalIgnoreCase))
            {
                throw new Exception(
                              string.Format(
                                         Localization.Messages.UnexpectedXmlElement,
                                         reader.Name));
            }

            // Skips ScoutCall opening tag.
            reader.Read();

            var newScoutCall = new BusinessObjects.Hattrick.YouthPlayerList.ScoutCall
            {
                Scout = this.ParseScoutNode(reader),
                ScoutRegionId = long.Parse(reader.ReadElementContentAsString()),
                ScoutComments = this.ParseScoutCommentsNode(reader)
            };

            // Skips ScoutCall closing tag.
            reader.Read();

            return newScoutCall;
        }

        /// <summary>
        /// Parses ScoutComment node.
        /// </summary>
        /// <param name="reader">XmlReader object loaded with the Xml file.</param>
        /// <returns>BusinessObjects.Hattrick.YouthPlayerList.ScoutComment with the parsed data.</returns>
        private BusinessObjects.Hattrick.YouthPlayerList.ScoutComment ParseScoutCommentNode(XmlReader reader)
        {
            if (!reader.Name.Equals(XmlTag.ScoutComment, StringComparison.OrdinalIgnoreCase))
            {
                throw new Exception(
                              string.Format(
                                         Localization.Messages.UnexpectedXmlElement,
                                         reader.Name));
            }

            // Skips ScoutComment opening tag.
            reader.Read();

            var newScoutComment = new BusinessObjects.Hattrick.YouthPlayerList.ScoutComment
            {
                CommentText = reader.ReadElementContentAsString(),
                CommentType = byte.Parse(reader.ReadElementContentAsString()),
                CommentVariation = long.Parse(reader.ReadElementContentAsString()),
                CommentSkillType = long.Parse(reader.ReadElementContentAsString()),
                CommentSkillLevel = byte.Parse(reader.ReadElementContentAsString())
            };

            // Skips ScoutComment closing tag.
            reader.Read();

            return newScoutComment;
        }

        /// <summary>
        /// Parses ScoutComments node.
        /// </summary>
        /// <param name="reader">XmlReader object loaded with the Xml file.</param>
        /// <returns>BusinessObjects.Hattrick.YouthPlayerList.ScoutComments with the parsed data.</returns>
        private List<BusinessObjects.Hattrick.YouthPlayerList.ScoutComment> ParseScoutCommentsNode(XmlReader reader)
        {
            if (!reader.Name.Equals(XmlTag.ScoutComments, StringComparison.OrdinalIgnoreCase))
            {
                throw new Exception(
                              string.Format(
                                         Localization.Messages.UnexpectedXmlElement,
                                         reader.Name));
            }

            // Skips ScoutComments opening tag.
            reader.Read();

            var scoutComments = new List<BusinessObjects.Hattrick.YouthPlayerList.ScoutComment>();

            while (reader.Name.Equals(XmlTag.ScoutComment))
            {
                scoutComments.Add(
                                  this.ParseScoutCommentNode(reader));
            }

            // Skips ScoutComments closing tag.
            reader.Read();

            return scoutComments;
        }

        /// <summary>
        /// Parses Scout node.
        /// </summary>
        /// <param name="reader">XmlReader object loaded with the Xml file.</param>
        /// <returns>BusinessObjects.Hattrick.YouthPlayerList.Scout with the parsed data.</returns>
        private BusinessObjects.Hattrick.YouthPlayerList.Scout ParseScoutNode(XmlReader reader)
        {
            if (!reader.Name.Equals(XmlTag.Scout, StringComparison.OrdinalIgnoreCase))
            {
                throw new Exception(
                              string.Format(
                                         Localization.Messages.UnexpectedXmlElement,
                                         reader.Name));
            }

            // Skips Scout opening tag.
            reader.Read();

            var newScout = new BusinessObjects.Hattrick.YouthPlayerList.Scout
            {
                ScoutId = long.Parse(reader.ReadElementContentAsString()),
                ScoutName = reader.ReadElementContentAsString()
            };

            // Skips Scout closing tag.
            reader.Read();

            return newScout;
        }

        /// <summary>
        /// Parses SeniorTeam node.
        /// </summary>
        /// <param name="reader">XmlReader object loaded with the Xml file.</param>
        /// <returns>BusinessObjects.Hattrick.YouthPlayerList.SeniorTeam with the parsed data.</returns>
        private BusinessObjects.Hattrick.YouthPlayerList.SeniorTeam ParseSeniorTeamNode(XmlReader reader)
        {
            if (!reader.Name.Equals(XmlTag.SeniorTeam, StringComparison.OrdinalIgnoreCase))
            {
                throw new Exception(
                              string.Format(
                                         Localization.Messages.UnexpectedXmlElement,
                                         reader.Name));
            }

            // Skips SeniorTeam opening tag.
            reader.Read();

            var newSeniorTeam = new BusinessObjects.Hattrick.YouthPlayerList.SeniorTeam
            {
                SeniorTeamId = long.Parse(reader.ReadElementContentAsString()),
                SeniorTeamName = reader.ReadElementContentAsString()
            };

            // Skips SeniorTeam closing tag.
            reader.Read();

            return newSeniorTeam;
        }

        /// <summary>
        /// Parses SkillMax node.
        /// </summary>
        /// <param name="reader">XmlReader object loaded with the Xml file.</param>
        /// <returns>BusinessObjects.Hattrick.YouthPlayerList.SkillMax with the parsed data.</returns>
        private BusinessObjects.Hattrick.YouthPlayerList.SkillMax ParseSkillMaxNode(XmlReader reader)
        {
            string[] validTags = new string[]
            {
                XmlTag.KeeperSkillMax,
                XmlTag.DefenderSkillMax,
                XmlTag.PlaymakerSkillMax,
                XmlTag.WingerSkillMax,
                XmlTag.PassingSkillMax,
                XmlTag.ScorerSkillMax,
                XmlTag.SetPiecesSkillMax
            };

            if (!validTags.Contains(reader.Name))
            {
                throw new Exception(
                              string.Format(
                                         Localization.Messages.UnexpectedXmlElement,
                                         reader.Name));
            }

            // Attributes are on opening tag.
            var newSkill = new BusinessObjects.Hattrick.YouthPlayerList.SkillMax
            {
                IsAvailable = reader.MoveToAttribute(XmlTag.IsAvailable)
                            ? bool.Parse(reader.GetAttribute(XmlTag.IsAvailable))
                            : false,
                MayUnlock = reader.MoveToAttribute(XmlTag.MayUnlock)
                            ? bool.Parse(reader.GetAttribute(XmlTag.MayUnlock))
                            : false,
            };

            // Skips Skill opening tag.
            reader.Read();

            if (reader.HasValue)
            {
                newSkill.Value = byte.Parse(reader.ReadContentAsString());

                // Skips Skill closing tag.
                reader.Read();
            }

            return newSkill;
        }

        /// <summary>
        /// Parses Skill node.
        /// </summary>
        /// <param name="reader">XmlReader object loaded with the Xml file.</param>
        /// <returns>BusinessObjects.Hattrick.YouthPlayerList.Skill with the parsed data.</returns>
        private BusinessObjects.Hattrick.YouthPlayerList.Skill ParseSkillNode(XmlReader reader)
        {
            string[] validTags = new string[]
            {
                XmlTag.KeeperSkill,
                XmlTag.DefenderSkill,
                XmlTag.PlaymakerSkill,
                XmlTag.WingerSkill,
                XmlTag.PassingSkill,
                XmlTag.ScorerSkill,
                XmlTag.SetPiecesSkill
            };

            if (!validTags.Contains(reader.Name))
            {
                throw new Exception(
                              string.Format(
                                         Localization.Messages.UnexpectedXmlElement,
                                         reader.Name));
            }

            // Attributes are on opening tag.
            var newSkill = new BusinessObjects.Hattrick.YouthPlayerList.Skill
            {
                IsAvailable = reader.MoveToAttribute(XmlTag.IsAvailable)
                            ? bool.Parse(reader.GetAttribute(XmlTag.IsAvailable))
                            : false,
                IsMaxReached = reader.MoveToAttribute(XmlTag.IsMaxReached)
                            ? bool.Parse(reader.GetAttribute(XmlTag.IsMaxReached))
                            : false,
                MayUnlock = reader.MoveToAttribute(XmlTag.MayUnlock)
                            ? bool.Parse(reader.GetAttribute(XmlTag.MayUnlock))
                            : false,
            };

            // Skips Skill opening tag.
            reader.Read();

            if (reader.HasValue)
            {
                newSkill.Value = byte.Parse(reader.ReadContentAsString());

                // Skips Skill closing tag.
                reader.Read();
            }

            return newSkill;
        }

        /// <summary>
        /// Parses YouthPlayer node.
        /// </summary>
        /// <param name="reader">XmlReader object loaded with the Xml file.</param>
        /// <returns>BusinessObjects.Hattrick.YouthPlayerList.YouthPlayer with the parsed data.</returns>
        private BusinessObjects.Hattrick.YouthPlayerList.YouthPlayer ParseYouthPlayerNode(XmlReader reader)
        {
            if (!reader.Name.Equals(XmlTag.YouthPlayer, StringComparison.OrdinalIgnoreCase))
            {
                throw new Exception(
                              string.Format(
                                         Localization.Messages.UnexpectedXmlElement,
                                         reader.Name));
            }

            // Skips YouthPlayer opening node.
            reader.Read();

            var newYouthPlayer = new BusinessObjects.Hattrick.YouthPlayerList.YouthPlayer
            {
                YouthPlayerId = long.Parse(reader.ReadElementContentAsString()),
                FirstName = reader.ReadElementContentAsString(),
                NickName = reader.ReadElementContentAsString(),
                LastName = reader.ReadElementContentAsString()
            };

            if (reader.Name.Equals(XmlTag.Age, StringComparison.OrdinalIgnoreCase))
            {
                newYouthPlayer.Age = byte.Parse(reader.ReadElementContentAsString());

                // If age exists then Details ActionType was used, which means all the following tags
                // SHOULD exist.
                newYouthPlayer.AgeDays = byte.Parse(reader.ReadElementContentAsString());
                newYouthPlayer.ArrivalDate = DateTime.Parse(reader.ReadElementContentAsString());
                newYouthPlayer.CanBePromotedIn = short.Parse(reader.ReadElementContentAsString());
                newYouthPlayer.PlayerNumber = byte.Parse(reader.ReadElementContentAsString());
                newYouthPlayer.Statement = reader.ReadElementContentAsString();

                // OwnerNotes and PlayerCategoryId nodes are only present if the user is Supporter.
                if (reader.Name.Equals(XmlTag.OwnerNotes, StringComparison.OrdinalIgnoreCase))
                {
                    newYouthPlayer.OwnerNotes = reader.ReadElementContentAsString();
                }

                if (reader.Name.Equals(XmlTag.PlayerCategoryId, StringComparison.OrdinalIgnoreCase))
                {
                    newYouthPlayer.PlayerCategoryId = byte.Parse(reader.ReadElementContentAsString());
                }

                newYouthPlayer.Cards = byte.Parse(reader.ReadElementContentAsString());
                newYouthPlayer.InjuryLevel = int.Parse(reader.ReadElementContentAsString());
                newYouthPlayer.Specialty = byte.Parse(reader.ReadElementContentAsString());
                newYouthPlayer.CareerGoals = short.Parse(reader.ReadElementContentAsString());
                newYouthPlayer.CareerHattricks = short.Parse(reader.ReadElementContentAsString());
                newYouthPlayer.LeagueGoals = byte.Parse(reader.ReadElementContentAsString());
                newYouthPlayer.FriendlyGoals = byte.Parse(reader.ReadElementContentAsString());
                newYouthPlayer.OwningYouthTeam = this.ParseOwningYouthTeamNode(reader);
                newYouthPlayer.PlayerSkills = this.ParsePlayerSkillsNode(reader);
            }

            if (reader.Name.Equals(XmlTag.ScoutCall, StringComparison.OrdinalIgnoreCase))
            {
                newYouthPlayer.ScoutCall = this.ParseScoutCallNode(reader);
            }

            if (reader.Name.Equals(XmlTag.LastMatch, StringComparison.OrdinalIgnoreCase))
            {
                newYouthPlayer.LastMatch = this.ParseLastMatchNode(reader);
            }

            // Skips YouthPlayer closing node.
            reader.Read();

            return newYouthPlayer;
        }

        #endregion Private Methods
    }
}