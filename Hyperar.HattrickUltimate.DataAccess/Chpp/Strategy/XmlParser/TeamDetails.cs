//-----------------------------------------------------------------------
// <copyright file="TeamDetails.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.DataAccess.Chpp.Strategy.XmlParser
{
    using System;
    using System.Collections.Generic;
    using System.Xml;
    using BusinessObjects.Hattrick.Interface;
    using Constants;
    using Interface;

    /// <summary>
    /// Hattrick TeamDetails XML file parser implementation.
    /// </summary>
    internal class TeamDetails : IXmlParserStrategy
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

            var result = (BusinessObjects.Hattrick.TeamDetails.Root)entity;

            if (reader.Name.Equals(XmlTag.User, StringComparison.OrdinalIgnoreCase))
            {
                result.User = this.ParseUserNode(reader);
            }

            if (reader.Name.Equals(XmlTag.Teams, StringComparison.OrdinalIgnoreCase))
            {
                // Skips Teams opening node.
                reader.Read();

                result.Teams = new List<BusinessObjects.Hattrick.TeamDetails.Team>();

                while (reader.Name.Equals(XmlTag.Team, StringComparison.OrdinalIgnoreCase))
                {
                    result.Teams.Add(
                                    this.ParseTeamNode(reader));
                }

                // Skips Teams opening node.
                reader.Read();
            }
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        /// Parses Arena node.
        /// </summary>
        /// <param name="reader">XmlReader object loaded with the Xml file.</param>
        /// <returns>BusinessObjects.Hattrick.TeamDetails.Arena with the parsed data.</returns>
        private BusinessObjects.Hattrick.TeamDetails.Arena ParseArenaNode(XmlReader reader)
        {
            if (!reader.Name.Equals(XmlTag.Arena, StringComparison.OrdinalIgnoreCase))
            {
                throw new Exception(
                              string.Format(
                                         Localization.Strings.Message_UnexpectedXmlElement,
                                         reader.Name));
            }

            // Skips Arena opening node.
            reader.Read();

            var newArena = new BusinessObjects.Hattrick.TeamDetails.Arena();

            newArena.ArenaId = long.Parse(reader.ReadElementContentAsString());
            newArena.ArenaName = reader.ReadElementContentAsString();

            // Skips Arena closing node.
            reader.Read();

            return newArena;
        }

        /// <summary>
        /// Parses BotStatus node.
        /// </summary>
        /// <param name="reader">XmlReader object loaded with the Xml file.</param>
        /// <returns>BusinessObjects.Hattrick.TeamDetails.BotStatus with the parsed data.</returns>
        private BusinessObjects.Hattrick.TeamDetails.BotStatus ParseBotStatusNode(XmlReader reader)
        {
            if (!reader.Name.Equals(XmlTag.BotStatus, StringComparison.OrdinalIgnoreCase))
            {
                throw new Exception(
                              string.Format(
                                         Localization.Strings.Message_UnexpectedXmlElement,
                                         reader.Name));
            }

            // Skips BotStatus opening node.
            reader.Read();

            var newBotStatus = new BusinessObjects.Hattrick.TeamDetails.BotStatus();

            newBotStatus.IsBot = bool.Parse(reader.ReadElementContentAsString());

            if (newBotStatus.IsBot)
            {
                newBotStatus.BotSince = DateTime.Parse(reader.ReadElementContentAsString());
            }

            // Skips BotStatus closing node.
            reader.Read();

            return newBotStatus;
        }

        /// <summary>
        /// Parses Country node.
        /// </summary>
        /// <param name="reader">XmlReader object loaded with the Xml file.</param>
        /// <returns>BusinessObjects.Hattrick.TeamDetails.Country with the parsed data.</returns>
        private BusinessObjects.Hattrick.TeamDetails.Country ParseCountryNode(XmlReader reader)
        {
            if (!reader.Name.Equals(XmlTag.Country, StringComparison.OrdinalIgnoreCase))
            {
                throw new Exception(
                              string.Format(
                                         Localization.Strings.Message_UnexpectedXmlElement,
                                         reader.Name));
            }

            // Skips Country opening node.
            reader.Read();

            var newCountry = new BusinessObjects.Hattrick.TeamDetails.Country();

            newCountry.CountryId = long.Parse(reader.ReadElementContentAsString());
            newCountry.CountryName = reader.ReadElementContentAsString();

            // Skips Country closing node.
            reader.Read();

            return newCountry;
        }

        /// <summary>
        /// Parses Cup node.
        /// </summary>
        /// <param name="reader">XmlReader object loaded with the Xml file.</param>
        /// <returns>BusinessObjects.Hattrick.TeamDetails.Cup with the parsed data.</returns>
        private BusinessObjects.Hattrick.TeamDetails.Cup ParseCupNode(XmlReader reader)
        {
            if (!reader.Name.Equals(XmlTag.Cup, StringComparison.OrdinalIgnoreCase))
            {
                throw new Exception(
                              string.Format(
                                         Localization.Strings.Message_UnexpectedXmlElement,
                                         reader.Name));
            }

            // Skips Cup opening node.
            reader.Read();

            var newCup = new BusinessObjects.Hattrick.TeamDetails.Cup();

            newCup.StillInCup = bool.Parse(reader.ReadElementContentAsString());

            if (newCup.StillInCup)
            {
                newCup.CupId = long.Parse(reader.ReadElementContentAsString());
                newCup.CupName = reader.ReadElementContentAsString();
                newCup.CupLeagueLevel = byte.Parse(reader.ReadElementContentAsString());
                newCup.CupLevel = byte.Parse(reader.ReadElementContentAsString());
                newCup.CupLevelIndex = byte.Parse(reader.ReadElementContentAsString());
                newCup.MatchRound = byte.Parse(reader.ReadElementContentAsString());
                newCup.MatchRoundsLeft = byte.Parse(reader.ReadElementContentAsString());
            }

            // Skips Cup closing node.
            reader.Read();

            return newCup;
        }

        /// <summary>
        /// Parses Fanclub node.
        /// </summary>
        /// <param name="reader">XmlReader object loaded with the Xml file.</param>
        /// <returns>BusinessObjects.Hattrick.TeamDetails.Fanclub with the parsed data.</returns>
        private BusinessObjects.Hattrick.TeamDetails.Fanclub ParseFanclubNode(XmlReader reader)
        {
            if (!reader.Name.Equals(XmlTag.Fanclub, StringComparison.OrdinalIgnoreCase))
            {
                throw new Exception(
                              string.Format(
                                         Localization.Strings.Message_UnexpectedXmlElement,
                                         reader.Name));
            }

            // Skips Fanclub opening node.
            reader.Read();

            var newFanclub = new BusinessObjects.Hattrick.TeamDetails.Fanclub();

            newFanclub.FanclubId = long.Parse(reader.ReadElementContentAsString());
            newFanclub.FanclubName = reader.ReadElementContentAsString();
            newFanclub.FanclubSize = long.Parse(reader.ReadElementContentAsString());

            // Skips Fanclub closing node.
            reader.Read();

            return newFanclub;
        }

        /// <summary>
        /// Parses Flag node.
        /// </summary>
        /// <param name="reader">XmlReader object loaded with the Xml file.</param>
        /// <returns>BusinessObjects.Hattrick.TeamDetails.Flag with the parsed data.</returns>
        private BusinessObjects.Hattrick.TeamDetails.Flag ParseFlagNode(XmlReader reader)
        {
            if (!reader.Name.Equals(XmlTag.Flag, StringComparison.OrdinalIgnoreCase))
            {
                throw new Exception(
                              string.Format(
                                         Localization.Strings.Message_UnexpectedXmlElement,
                                         reader.Name));
            }

            // Skips Flag opening tag.
            reader.Read();

            var newFlag = new BusinessObjects.Hattrick.TeamDetails.Flag();

            newFlag.LeagueId = long.Parse(reader.ReadElementContentAsString());
            newFlag.LeagueName = reader.ReadElementContentAsString();
            newFlag.CountryCode = reader.ReadElementContentAsString();

            // Skips Flag closing tag.
            reader.Read();

            return newFlag;
        }

        /// <summary>
        /// Parses Flags node.
        /// </summary>
        /// <param name="reader">XmlReader object loaded with the Xml file.</param>
        /// <returns>BusinessObjects.Hattrick.TeamDetails.Flags with the parsed data.</returns>
        private BusinessObjects.Hattrick.TeamDetails.Flags ParseFlagsNode(XmlReader reader)
        {
            if (!reader.Name.Equals(XmlTag.Flags, StringComparison.OrdinalIgnoreCase))
            {
                throw new Exception(
                              string.Format(
                                         Localization.Strings.Message_UnexpectedXmlElement,
                                         reader.Name));
            }

            // Skips Flags opening tag.
            reader.Read();

            var flags = new BusinessObjects.Hattrick.TeamDetails.Flags();

            if (reader.Name.Equals(XmlTag.AwayFlags, StringComparison.OrdinalIgnoreCase))
            {
                // Skips AwayFlags opening tag.
                reader.Read();

                flags.AwayFlags = new List<BusinessObjects.Hattrick.TeamDetails.Flag>();

                while (reader.Name.Equals(XmlTag.Flag, StringComparison.OrdinalIgnoreCase))
                {
                    flags.AwayFlags.Add(
                                        this.ParseFlagNode(reader));
                }

                // Skips AwayFlags closing tag.
                reader.Read();
            }

            if (reader.Name.Equals(XmlTag.HomeFlags, StringComparison.OrdinalIgnoreCase))
            {
                // Skips HomeFlags opening tag.
                reader.Read();

                flags.HomeFlags = new List<BusinessObjects.Hattrick.TeamDetails.Flag>();

                while (reader.Name.Equals(XmlTag.Flag, StringComparison.OrdinalIgnoreCase))
                {
                    flags.HomeFlags.Add(
                                        this.ParseFlagNode(reader));
                }

                // Skips HomeFlags closing tag.
                reader.Read();
            }

            // Skips Flags closing tag.
            reader.Read();

            return flags;
        }

        /// <summary>
        /// Parses Guestbook node.
        /// </summary>
        /// <param name="reader">XmlReader object loaded with the Xml file.</param>
        /// <returns>BusinessObjects.Hattrick.TeamDetails.Guestbook with the parsed data.</returns>
        private BusinessObjects.Hattrick.TeamDetails.Guestbook ParseGuestbookNode(XmlReader reader)
        {
            if (!reader.Name.Equals(XmlTag.Guestbook, StringComparison.OrdinalIgnoreCase))
            {
                throw new Exception(
                              string.Format(
                                         Localization.Strings.Message_UnexpectedXmlElement,
                                         reader.Name));
            }

            // Skips Guestbook opening node.
            reader.Read();

            var newGuestbook = new BusinessObjects.Hattrick.TeamDetails.Guestbook();

            newGuestbook.NumberOfGuestbookItems = long.Parse(reader.ReadElementContentAsString());

            // Skips Guestbook closing node.
            reader.Read();

            return newGuestbook;
        }

        /// <summary>
        /// Parses Language node.
        /// </summary>
        /// <param name="reader">XmlReader object loaded with the Xml file.</param>
        /// <returns>BusinessObjects.Hattrick.TeamDetails.Language with the parsed data.</returns>
        private BusinessObjects.Hattrick.TeamDetails.Language ParseLanguageNode(XmlReader reader)
        {
            if (!reader.Name.Equals(XmlTag.Language, StringComparison.OrdinalIgnoreCase))
            {
                throw new Exception(
                              string.Format(
                                         Localization.Strings.Message_UnexpectedXmlElement,
                                         reader.Name));
            }

            // Skips Language opening node.
            reader.Read();

            var newLanguage = new BusinessObjects.Hattrick.TeamDetails.Language();

            newLanguage.LanguageId = long.Parse(reader.ReadElementContentAsString());
            newLanguage.LanguageName = reader.ReadElementContentAsString();

            // Skips Language closing node.
            reader.Read();

            return newLanguage;
        }

        /// <summary>
        /// Parses LastMatch node.
        /// </summary>
        /// <param name="reader">XmlReader object loaded with the Xml file.</param>
        /// <returns>BusinessObjects.Hattrick.TeamDetails.LastMatch with the parsed data.</returns>
        private BusinessObjects.Hattrick.TeamDetails.LastMatch ParseLastMatchNode(XmlReader reader)
        {
            if (!reader.Name.Equals(XmlTag.LastMatch, StringComparison.OrdinalIgnoreCase))
            {
                throw new Exception(
                              string.Format(
                                         Localization.Strings.Message_UnexpectedXmlElement,
                                         reader.Name));
            }

            var lastMatch = new BusinessObjects.Hattrick.TeamDetails.LastMatch();

            // Skips LastMatch opening node.
            reader.Read();

            lastMatch = new BusinessObjects.Hattrick.TeamDetails.LastMatch();

            lastMatch.LastMatchId = long.Parse(reader.ReadElementContentAsString());
            lastMatch.LastMatchDate = DateTime.Parse(reader.ReadElementContentAsString());
            lastMatch.LastMatchHomeTeamId = long.Parse(reader.ReadElementContentAsString());
            lastMatch.LastMatchHomeTeamName = reader.ReadElementContentAsString();
            lastMatch.LastMatchHomeTeamGoals = byte.Parse(reader.ReadElementContentAsString());
            lastMatch.LastMatchAwayTeamId = long.Parse(reader.ReadElementContentAsString());
            lastMatch.LastMatchAwayTeamName = reader.ReadElementContentAsString();
            lastMatch.LastMatchAwayTeamGoals = byte.Parse(reader.ReadElementContentAsString());

            // Skips LastMatch opening node.
            reader.Read();

            return lastMatch;
        }

        /// <summary>
        /// Parses LeagueLevelUnit node.
        /// </summary>
        /// <param name="reader">XmlReader object loaded with the Xml file.</param>
        /// <returns>BusinessObjects.Hattrick.TeamDetails.LeagueLevelUnit with the parsed data.</returns>
        private BusinessObjects.Hattrick.TeamDetails.LeagueLevelUnit ParseLeagueLevelUnitNode(XmlReader reader)
        {
            if (!reader.Name.Equals(XmlTag.LeagueLevelUnit, StringComparison.OrdinalIgnoreCase))
            {
                throw new Exception(
                              string.Format(
                                         Localization.Strings.Message_UnexpectedXmlElement,
                                         reader.Name));
            }

            // Skips LeagueLevelUnit opening node.
            reader.Read();

            var newLeagueLevelUnit = new BusinessObjects.Hattrick.TeamDetails.LeagueLevelUnit();

            newLeagueLevelUnit.LeagueLevelUnitId = long.Parse(reader.ReadElementContentAsString());
            newLeagueLevelUnit.LeagueLevelUnitName = reader.ReadElementContentAsString();
            newLeagueLevelUnit.LeagueLevelUnitLevel = byte.Parse(reader.ReadElementContentAsString());

            // Skips LeagueLevelUnit closing node.
            reader.Read();

            return newLeagueLevelUnit;
        }

        /// <summary>
        /// Parses League node.
        /// </summary>
        /// <param name="reader">XmlReader object loaded with the Xml file.</param>
        /// <returns>BusinessObjects.Hattrick.TeamDetails.League with the parsed data.</returns>
        private BusinessObjects.Hattrick.TeamDetails.League ParseLeagueNode(XmlReader reader)
        {
            if (!reader.Name.Equals(XmlTag.League, StringComparison.OrdinalIgnoreCase))
            {
                throw new Exception(
                              string.Format(
                                         Localization.Strings.Message_UnexpectedXmlElement,
                                         reader.Name));
            }

            // Skips League opening node.
            reader.Read();

            var newLeague = new BusinessObjects.Hattrick.TeamDetails.League();

            newLeague.LeagueId = long.Parse(reader.ReadElementContentAsString());
            newLeague.LeagueName = reader.ReadElementContentAsString();

            // Skips League closing node.
            reader.Read();

            return newLeague;
        }

        /// <summary>
        /// Parses MySupporters node.
        /// </summary>
        /// <param name="reader">XmlReader object loaded with the Xml file.</param>
        /// <returns>BusinessObjects.Hattrick.TeamDetails.MySupporters with the parsed data.</returns>
        private BusinessObjects.Hattrick.TeamDetails.MySupporters ParseMySupportersNode(XmlReader reader)
        {
            if (!reader.Name.Equals(XmlTag.MySupporters, StringComparison.OrdinalIgnoreCase))
            {
                throw new Exception(
                              string.Format(
                                         Localization.Strings.Message_UnexpectedXmlElement,
                                         reader.Name));
            }

            var mySupporters = new BusinessObjects.Hattrick.TeamDetails.MySupporters();

            if (!string.IsNullOrWhiteSpace(reader.GetAttribute(XmlTag.TotalItems)))
            {
                mySupporters.TotalItems = int.Parse(reader.GetAttribute(XmlTag.TotalItems));
            }

            if (!string.IsNullOrWhiteSpace(reader.GetAttribute(XmlTag.MaxItems)))
            {
                mySupporters.MaxItems = int.Parse(reader.GetAttribute(XmlTag.MaxItems));
            }

            // Skips MySupporters opening node.
            reader.Read();

            mySupporters.SupporterTeamList = new List<BusinessObjects.Hattrick.TeamDetails.SupporterTeam>();

            while (reader.Name.Equals(XmlTag.SupporterTeam, StringComparison.OrdinalIgnoreCase))
            {
                mySupporters.SupporterTeamList.Add(
                                                  this.ParseSupporterTeam(reader));
            }

            // Skips MySupporters closing node.
            reader.Read();

            return mySupporters;
        }

        /// <summary>
        /// Parses NationalTeam node.
        /// </summary>
        /// <param name="reader">XmlReader object loaded with the Xml file.</param>
        /// <returns>BusinessObjects.Hattrick.TeamDetails.NationalTeam with the parsed data.</returns>
        private BusinessObjects.Hattrick.TeamDetails.NationalTeam ParseNationalTeamNode(XmlReader reader)
        {
            if (!reader.Name.Equals(XmlTag.NationalTeam, StringComparison.OrdinalIgnoreCase))
            {
                throw new Exception(
                              string.Format(
                                         Localization.Strings.Message_UnexpectedXmlElement,
                                         reader.Name));
            }

            var newNationalTeam = new BusinessObjects.Hattrick.TeamDetails.NationalTeam();

            if (!string.IsNullOrWhiteSpace(reader.GetAttribute(XmlTag.Index)))
            {
                newNationalTeam.Index = int.Parse(reader.GetAttribute(XmlTag.Index));
            }

            // Skips NationalTeam opening node.
            reader.Read();

            newNationalTeam.NationalTeamId = long.Parse(reader.ReadElementContentAsString());
            newNationalTeam.NationalTeamName = reader.ReadElementContentAsString();

            // Skips NationalTeam closing node.
            reader.Read();

            return newNationalTeam;
        }

        /// <summary>
        /// Parses NextMatch node.
        /// </summary>
        /// <param name="reader">XmlReader object loaded with the Xml file.</param>
        /// <returns>BusinessObjects.Hattrick.TeamDetails.NextMatch with the parsed data.</returns>
        private BusinessObjects.Hattrick.TeamDetails.NextMatch ParseNextMatchNode(XmlReader reader)
        {
            if (!reader.Name.Equals(XmlTag.NextMatch, StringComparison.OrdinalIgnoreCase))
            {
                throw new Exception(
                              string.Format(
                                         Localization.Strings.Message_UnexpectedXmlElement,
                                         reader.Name));
            }

            var nextMatch = new BusinessObjects.Hattrick.TeamDetails.NextMatch();

            // Skips NextMatch opening node.
            reader.Read();

            nextMatch = new BusinessObjects.Hattrick.TeamDetails.NextMatch();

            nextMatch.NextMatchId = long.Parse(reader.ReadElementContentAsString());
            nextMatch.NextMatchDate = DateTime.Parse(reader.ReadElementContentAsString());
            nextMatch.NextMatchHomeTeamId = long.Parse(reader.ReadElementContentAsString());
            nextMatch.NextMatchHomeTeamName = reader.ReadElementContentAsString();
            nextMatch.NextMatchAwayTeamId = long.Parse(reader.ReadElementContentAsString());
            nextMatch.NextMatchAwayTeamName = reader.ReadElementContentAsString();

            // Skips NextMatch opening node.
            reader.Read();

            return nextMatch;
        }

        /// <summary>
        /// Parses PressAnnouncement node.
        /// </summary>
        /// <param name="reader">XmlReader object loaded with the Xml file.</param>
        /// <returns>BusinessObjects.Hattrick.TeamDetails.PressAnnouncement with the parsed data.</returns>
        private BusinessObjects.Hattrick.TeamDetails.PressAnnouncement ParsePressAnnouncementNode(XmlReader reader)
        {
            if (!reader.Name.Equals(XmlTag.PressAnnouncement, StringComparison.OrdinalIgnoreCase))
            {
                throw new Exception(
                              string.Format(
                                         Localization.Strings.Message_UnexpectedXmlElement,
                                         reader.Name));
            }

            // Skips PressAnnouncement opening node.
            reader.Read();

            var newPressAnnouncement = new BusinessObjects.Hattrick.TeamDetails.PressAnnouncement();

            // Hattrick sends two different PressAnnouncement nodes, one where the SendDate is in the bottom and another on the top.
            if (reader.Name.Equals(XmlTag.Subject, StringComparison.OrdinalIgnoreCase))
            {
                newPressAnnouncement.Subject = reader.ReadElementContentAsString();
                newPressAnnouncement.Body = reader.ReadElementContentAsString();
                newPressAnnouncement.SendDate = DateTime.Parse(reader.ReadElementContentAsString());
            }
            else
            {
                newPressAnnouncement.SendDate = DateTime.Parse(reader.ReadElementContentAsString());
                newPressAnnouncement.Subject = reader.ReadElementContentAsString();
                newPressAnnouncement.Body = reader.ReadElementContentAsString();
            }

            // Skips PressAnnouncement closing node.
            reader.Read();

            return newPressAnnouncement;
        }

        /// <summary>
        /// Parses Region node.
        /// </summary>
        /// <param name="reader">XmlReader object loaded with the Xml file.</param>
        /// <returns>BusinessObjects.Hattrick.TeamDetails.Region with the parsed data.</returns>
        private BusinessObjects.Hattrick.TeamDetails.Region ParseRegionNode(XmlReader reader)
        {
            if (!reader.Name.Equals(XmlTag.Region, StringComparison.OrdinalIgnoreCase))
            {
                throw new Exception(
                              string.Format(
                                         Localization.Strings.Message_UnexpectedXmlElement,
                                         reader.Name));
            }

            // Skips Region opening node.
            reader.Read();

            var newRegion = new BusinessObjects.Hattrick.TeamDetails.Region();

            newRegion.RegionId = long.Parse(reader.ReadElementContentAsString());
            newRegion.RegionName = reader.ReadElementContentAsString();

            // Skips Region closing node.
            reader.Read();

            return newRegion;
        }

        /// <summary>
        /// Parses SupportedTeam node.
        /// </summary>
        /// <param name="reader">XmlReader object loaded with the Xml file.</param>
        /// <returns>BusinessObjects.Hattrick.TeamDetails.SupportedTeam with the parsed data.</returns>
        private BusinessObjects.Hattrick.TeamDetails.SupportedTeam ParseSupportedTeam(XmlReader reader)
        {
            if (!reader.Name.Equals(XmlTag.SupportedTeam, StringComparison.OrdinalIgnoreCase))
            {
                throw new Exception(
                              string.Format(
                                         Localization.Strings.Message_UnexpectedXmlElement,
                                         reader.Name));
            }

            // Skips SupportedTeam opening node.
            reader.Read();

            var newSupportedTeam = new BusinessObjects.Hattrick.TeamDetails.SupportedTeam();

            newSupportedTeam.UserId = long.Parse(reader.ReadElementContentAsString());
            newSupportedTeam.LoginName = reader.ReadElementContentAsString();
            newSupportedTeam.TeamId = long.Parse(reader.ReadElementContentAsString());
            newSupportedTeam.TeamName = reader.ReadElementContentAsString();
            newSupportedTeam.LeagueId = long.Parse(reader.ReadElementContentAsString());
            newSupportedTeam.LeagueName = reader.ReadElementContentAsString();
            newSupportedTeam.LeagueLevelUnitId = long.Parse(reader.ReadElementContentAsString());
            newSupportedTeam.LeagueLevelUnitName = reader.ReadElementContentAsString();

            if (reader.Name.Equals(XmlTag.LastMatch, StringComparison.OrdinalIgnoreCase))
            {
                newSupportedTeam.LastMatch = this.ParseLastMatchNode(reader);
            }

            if (reader.Name.Equals(XmlTag.NextMatch, StringComparison.OrdinalIgnoreCase))
            {
                newSupportedTeam.NextMatch = this.ParseNextMatchNode(reader);
            }

            if (reader.Name.Equals(XmlTag.PressAnnouncement, StringComparison.OrdinalIgnoreCase))
            {
                newSupportedTeam.PressAnnouncement = this.ParsePressAnnouncementNode(reader);
            }

            // Skips SupportedTeam closing node.
            reader.Read();

            return newSupportedTeam;
        }

        /// <summary>
        /// Parses SupportedTeams node.
        /// </summary>
        /// <param name="reader">XmlReader object loaded with the Xml file.</param>
        /// <returns>BusinessObjects.Hattrick.TeamDetails.SupportedTeams with the parsed data.</returns>
        private BusinessObjects.Hattrick.TeamDetails.SupportedTeams ParseSupportedTeamsNode(XmlReader reader)
        {
            if (!reader.Name.Equals(XmlTag.SupportedTeams, StringComparison.OrdinalIgnoreCase))
            {
                throw new Exception(
                              string.Format(
                                         Localization.Strings.Message_UnexpectedXmlElement,
                                         reader.Name));
            }

            var mySupporters = new BusinessObjects.Hattrick.TeamDetails.SupportedTeams();

            if (!string.IsNullOrWhiteSpace(reader.GetAttribute(XmlTag.TotalItems)))
            {
                mySupporters.TotalItems = int.Parse(reader.GetAttribute(XmlTag.TotalItems));
            }

            if (!string.IsNullOrWhiteSpace(reader.GetAttribute(XmlTag.MaxItems)))
            {
                mySupporters.MaxItems = int.Parse(reader.GetAttribute(XmlTag.MaxItems));
            }

            // Skips SupportedTeams opening node.
            reader.Read();

            mySupporters.SupportedTeamList = new List<BusinessObjects.Hattrick.TeamDetails.SupportedTeam>();

            while (reader.Name.Equals(XmlTag.SupportedTeam, StringComparison.OrdinalIgnoreCase))
            {
                mySupporters.SupportedTeamList.Add(
                                                  this.ParseSupportedTeam(reader));
            }

            // Skips SupportedTeams closing node.
            reader.Read();

            return mySupporters;
        }

        /// <summary>
        /// Parses SupporterTeam node.
        /// </summary>
        /// <param name="reader">XmlReader object loaded with the Xml file.</param>
        /// <returns>BusinessObjects.Hattrick.TeamDetails.SupporterTeam with the parsed data.</returns>
        private BusinessObjects.Hattrick.TeamDetails.SupporterTeam ParseSupporterTeam(XmlReader reader)
        {
            if (!reader.Name.Equals(XmlTag.SupporterTeam, StringComparison.OrdinalIgnoreCase))
            {
                throw new Exception(
                              string.Format(
                                         Localization.Strings.Message_UnexpectedXmlElement,
                                         reader.Name));
            }

            // Skips SupportedTeam opening node.
            reader.Read();

            var newSupporterTeam = new BusinessObjects.Hattrick.TeamDetails.SupporterTeam();

            newSupporterTeam.UserId = long.Parse(reader.ReadElementContentAsString());
            newSupporterTeam.LoginName = reader.ReadElementContentAsString();
            newSupporterTeam.TeamId = long.Parse(reader.ReadElementContentAsString());
            newSupporterTeam.TeamName = reader.ReadElementContentAsString();
            newSupporterTeam.LeagueId = long.Parse(reader.ReadElementContentAsString());
            newSupporterTeam.LeagueName = reader.ReadElementContentAsString();
            newSupporterTeam.LeagueLevelUnitId = long.Parse(reader.ReadElementContentAsString());
            newSupporterTeam.LeagueLevelUnitName = reader.ReadElementContentAsString();

            // Skips SupportedTeam closing node.
            reader.Read();

            return newSupporterTeam;
        }

        /// <summary>
        /// Parses TeamColors node.
        /// </summary>
        /// <param name="reader">XmlReader object loaded with the Xml file.</param>
        /// <returns>BusinessObjects.Hattrick.TeamDetails.TeamColors with the parsed data.</returns>
        private BusinessObjects.Hattrick.TeamDetails.TeamColors ParseTeamColorsNode(XmlReader reader)
        {
            if (!reader.Name.Equals(XmlTag.TeamColors, StringComparison.OrdinalIgnoreCase))
            {
                throw new Exception(
                              string.Format(
                                         Localization.Strings.Message_UnexpectedXmlElement,
                                         reader.Name));
            }

            // Skips TeamColors opening node.
            reader.Read();

            var newTeamColors = new BusinessObjects.Hattrick.TeamDetails.TeamColors();

            newTeamColors.BacgroundColor = reader.ReadElementContentAsString();
            newTeamColors.Color = reader.ReadElementContentAsString();

            // Skips TeamColors closing node.
            reader.Read();

            return newTeamColors;
        }

        /// <summary>
        /// Parses Team node.
        /// </summary>
        /// <param name="reader">XmlReader object loaded with the Xml file.</param>
        /// <returns>BusinessObjects.Hattrick.TeamDetails.Team with the parsed data.</returns>
        private BusinessObjects.Hattrick.TeamDetails.Team ParseTeamNode(XmlReader reader)
        {
            if (!reader.Name.Equals(XmlTag.Team, StringComparison.OrdinalIgnoreCase))
            {
                throw new Exception(
                              string.Format(
                                         Localization.Strings.Message_UnexpectedXmlElement,
                                         reader.Name));
            }

            // Skips Team opening node.
            reader.Read();

            var newTeam = new BusinessObjects.Hattrick.TeamDetails.Team();

            newTeam.TeamId = long.Parse(reader.ReadElementContentAsString());
            newTeam.TeamName = reader.ReadElementContentAsString();
            newTeam.ShortTeamName = reader.ReadElementContentAsString();
            newTeam.IsPrimaryClub = bool.Parse(reader.ReadElementContentAsString());
            newTeam.FoundedDate = DateTime.Parse(reader.ReadElementContentAsString());

            if (reader.Name.Equals(XmlTag.Arena, StringComparison.OrdinalIgnoreCase))
            {
                newTeam.Arena = this.ParseArenaNode(reader);
            }

            if (reader.Name.Equals(XmlTag.League, StringComparison.OrdinalIgnoreCase))
            {
                newTeam.League = this.ParseLeagueNode(reader);
            }

            if (reader.Name.Equals(XmlTag.Country, StringComparison.OrdinalIgnoreCase))
            {
                newTeam.Country = this.ParseCountryNode(reader);
            }

            if (reader.Name.Equals(XmlTag.Region, StringComparison.OrdinalIgnoreCase))
            {
                newTeam.Region = this.ParseRegionNode(reader);
            }

            if (reader.Name.Equals(XmlTag.Trainer, StringComparison.OrdinalIgnoreCase))
            {
                newTeam.Trainer = this.ParseTrainerNode(reader);
            }

            newTeam.HomePage = reader.ReadElementContentAsString();
            newTeam.DressUri = reader.ReadElementContentAsString();
            newTeam.DressAlternateUri = reader.ReadElementContentAsString();

            if (reader.Name.Equals(XmlTag.LeagueLevelUnit, StringComparison.OrdinalIgnoreCase))
            {
                newTeam.LeagueLevelUnit = this.ParseLeagueLevelUnitNode(reader);
            }

            if (reader.Name.Equals(XmlTag.BotStatus, StringComparison.OrdinalIgnoreCase))
            {
                newTeam.BotStatus = this.ParseBotStatusNode(reader);
            }

            if (reader.Name.Equals(XmlTag.Cup, StringComparison.OrdinalIgnoreCase))
            {
                newTeam.Cup = this.ParseCupNode(reader);
            }

            newTeam.FriendlyTeamId = long.Parse(reader.ReadElementContentAsString());
            newTeam.NumberOfVictories = int.Parse(reader.ReadElementContentAsString());
            newTeam.NumberOfUndefeated = int.Parse(reader.ReadElementContentAsString());
            newTeam.TeamRank = int.Parse(reader.ReadElementContentAsString());

            if (reader.Name.Equals(XmlTag.Fanclub, StringComparison.OrdinalIgnoreCase))
            {
                newTeam.Fanclub = this.ParseFanclubNode(reader);
            }

            newTeam.LogoUrl = reader.ReadElementContentAsString();

            if (reader.Name.Equals(XmlTag.Guestbook, StringComparison.OrdinalIgnoreCase))
            {
                newTeam.Guestbook = this.ParseGuestbookNode(reader);
            }

            if (reader.Name.Equals(XmlTag.PressAnnouncement, StringComparison.OrdinalIgnoreCase))
            {
                newTeam.PressAnnouncement = this.ParsePressAnnouncementNode(reader);
            }

            if (reader.Name.Equals(XmlTag.TeamColors, StringComparison.OrdinalIgnoreCase))
            {
                newTeam.TeamColors = this.ParseTeamColorsNode(reader);
            }

            newTeam.YouthTeamId = long.Parse(reader.ReadElementContentAsString());
            newTeam.YouthTeamName = reader.ReadElementContentAsString();
            newTeam.NumberOfVisits = int.Parse(reader.ReadElementContentAsString());

            if (reader.Name.Equals(XmlTag.Flags, StringComparison.OrdinalIgnoreCase))
            {
                newTeam.Flags = this.ParseFlagsNode(reader);
            }

            if (reader.Name.Equals(XmlTag.TrophyList, StringComparison.OrdinalIgnoreCase))
            {
                // Skips TrophyList opening node.
                reader.Read();

                newTeam.TrophyList = new List<BusinessObjects.Hattrick.TeamDetails.Trophy>();

                while (reader.Name.Equals(XmlTag.Trophy, StringComparison.OrdinalIgnoreCase))
                {
                    newTeam.TrophyList.Add(
                                           this.ParseTrophyNode(reader));
                }
            }

            // Skips TrophyList closing node, this is outside the if because the tag is always present, but it can be empty.
            reader.Read();

            if (reader.Name.Equals(XmlTag.SupportedTeams, StringComparison.OrdinalIgnoreCase))
            {
                newTeam.SupportedTeams = this.ParseSupportedTeamsNode(reader);
            }

            if (reader.Name.Equals(XmlTag.MySupporters, StringComparison.OrdinalIgnoreCase))
            {
                newTeam.MySupporters = this.ParseMySupportersNode(reader);
            }

            // Skips Team closing node.
            reader.Read();

            return newTeam;
        }

        /// <summary>
        /// Parses Trainer node.
        /// </summary>
        /// <param name="reader">XmlReader object loaded with the Xml file.</param>
        /// <returns>BusinessObjects.Hattrick.TeamDetails.Trainer with the parsed data.</returns>
        private BusinessObjects.Hattrick.TeamDetails.Trainer ParseTrainerNode(XmlReader reader)
        {
            if (!reader.Name.Equals(XmlTag.Trainer, StringComparison.OrdinalIgnoreCase))
            {
                throw new Exception(
                              string.Format(
                                         Localization.Strings.Message_UnexpectedXmlElement,
                                         reader.Name));
            }

            // Skips Trainer opening node.
            reader.Read();

            var newTrainer = new BusinessObjects.Hattrick.TeamDetails.Trainer();

            newTrainer.PlayerId = long.Parse(reader.ReadElementContentAsString());

            // Skips Trainer closing node.
            reader.Read();

            return newTrainer;
        }

        /// <summary>
        /// Parses Trophy node.
        /// </summary>
        /// <param name="reader">XmlReader object loaded with the Xml file.</param>
        /// <returns>BusinessObjects.Hattrick.TeamDetails.Trophy with the parsed data.</returns>
        private BusinessObjects.Hattrick.TeamDetails.Trophy ParseTrophyNode(XmlReader reader)
        {
            if (!reader.Name.Equals(XmlTag.Trophy, StringComparison.OrdinalIgnoreCase))
            {
                throw new Exception(
                              string.Format(
                                         Localization.Strings.Message_UnexpectedXmlElement,
                                         reader.Name));
            }

            // Skips Trophy opening node.
            reader.Read();

            var newTrophy = new BusinessObjects.Hattrick.TeamDetails.Trophy();

            newTrophy.TrophyTypeId = short.Parse(reader.ReadElementContentAsString());
            newTrophy.Season = short.Parse(reader.ReadElementContentAsString());
            newTrophy.LeagueLevel = byte.Parse(reader.ReadElementContentAsString());
            newTrophy.LeagueLevelUnitName = reader.ReadElementContentAsString();
            newTrophy.GainedDate = DateTime.Parse(reader.ReadElementContentAsString());

            if (reader.Name.Equals(XmlTag.ImageUrl, StringComparison.OrdinalIgnoreCase))
            {
                newTrophy.ImageUrl = reader.ReadElementContentAsString();
            }

            // Skips Trophy closing node.
            reader.Read();

            return newTrophy;
        }

        /// <summary>
        /// Parses User node.
        /// </summary>
        /// <param name="reader">XmlReader object loaded with the Xml file.</param>
        /// <returns>BusinessObjects.Hattrick.TeamDetails.User with the parsed data.</returns>
        private BusinessObjects.Hattrick.TeamDetails.User ParseUserNode(XmlReader reader)
        {
            if (!reader.Name.Equals(XmlTag.User, StringComparison.OrdinalIgnoreCase))
            {
                throw new Exception(
                              string.Format(
                                         Localization.Strings.Message_UnexpectedXmlElement,
                                         reader.Name));
            }

            // Skips User opening node.
            reader.Read();

            var newUser = new BusinessObjects.Hattrick.TeamDetails.User();

            newUser.UserId = long.Parse(reader.ReadElementContentAsString());

            if (reader.Name.Equals(XmlTag.Language, StringComparison.OrdinalIgnoreCase))
            {
                newUser.Language = this.ParseLanguageNode(reader);
            }

            newUser.SupporterTier = reader.ReadElementContentAsString();
            newUser.Loginname = reader.ReadElementContentAsString();
            newUser.Name = reader.ReadElementContentAsString();
            newUser.Icq = reader.ReadElementContentAsString();
            newUser.SignupDate = DateTime.Parse(reader.ReadElementContentAsString());
            newUser.ActivationDate = DateTime.Parse(reader.ReadElementContentAsString());
            newUser.LastLoginDate = DateTime.Parse(reader.ReadElementContentAsString());
            newUser.HasManagerLicense = bool.Parse(reader.ReadElementContentAsString());

            if (reader.Name.Equals(XmlTag.NationalTeamCoach, StringComparison.OrdinalIgnoreCase) &&
                !reader.IsEmptyElement)
            {
                newUser.NationalTeamCoach = new BusinessObjects.Hattrick.TeamDetails.NationalTeamCoach();

                // Skips NationalTeamCoach opening tag.
                reader.Read();

                while (reader.Name.Equals(XmlTag.NationalTeam, StringComparison.OrdinalIgnoreCase))
                {
                    newUser.NationalTeamCoach.NationalTeam.Add(
                                                              this.ParseNationalTeamNode(reader));
                }
            }

            // Skips NationalTeamCoach closing tag. This is outside the if because the tag is always present but it can be empty.
            reader.Read();

            // Skips User closing node.
            reader.Read();

            return newUser;
        }

        #endregion Private Methods
    }
}