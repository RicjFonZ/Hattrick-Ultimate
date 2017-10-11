//-----------------------------------------------------------------------
// <copyright file="Players.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.DataAccess.Chpp.Strategy.XmlParser
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Xml;
    using Constants;
    using Interface;

    /// <summary>
    /// Hattrick Players XML file parser implementation.
    /// </summary>
    internal class Players : IXmlParserStrategy
    {
        #region Public Methods

        /// <summary>
        /// Parse XML file specific nodes.
        /// </summary>
        /// <param name="reader">Reader initialized with XML file.</param>
        /// <param name="entity">IHattrickEntity object to store read data.</param>
        public void Parse(XmlReader reader, ref BusinessObjects.Hattrick.Interface.IXmlEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            var result = (BusinessObjects.Hattrick.Players.Root)entity;

            result.UserSupporterTier = reader.ReadElementContentAsString();
            result.IsYouth = bool.Parse(reader.ReadElementContentAsString());
            result.UserSupporterTier = reader.ReadElementContentAsString();
            result.IsPlayingMatch = bool.Parse(reader.ReadElementContentAsString());
            result.Team = this.ParseTeamNode(reader);
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        /// Parses LastMatch node.
        /// </summary>
        /// <param name="reader">XmlReader object loaded with the Xml file.</param>
        /// <returns>BusinessObjects.Hattrick.Players.LastMatch with the parsed data.</returns>
        private BusinessObjects.Hattrick.Players.LastMatch ParseLastMatchNode(XmlReader reader)
        {
            if (!reader.Name.Equals(XmlTag.LastMatch, StringComparison.OrdinalIgnoreCase))
            {
                throw new Exception(
                              string.Format(
                                         Localization.Strings.Message_UnexpectedXmlElement,
                                         reader.Name));
            }

            var lastMatch = new BusinessObjects.Hattrick.Players.LastMatch();

            // Skips LastMatch opening node.
            reader.Read();

            lastMatch = new BusinessObjects.Hattrick.Players.LastMatch();

            lastMatch.Date = DateTime.Parse(reader.ReadElementContentAsString());
            lastMatch.MatchId = uint.Parse(reader.ReadElementContentAsString());
            lastMatch.PositionCode = ushort.Parse(reader.ReadElementContentAsString());
            lastMatch.PlayedMinutes = byte.Parse(reader.ReadElementContentAsString());
            lastMatch.Rating = decimal.Parse(
                                           reader.ReadElementContentAsString()
                                                 .Replace(
                                                      Generic.Dot,
                                                      CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator));
            lastMatch.RatingEndOfGame = decimal.Parse(
                                                    reader.ReadElementContentAsString()
                                                          .Replace(
                                                               Generic.Dot,
                                                               CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator));

            // Skips LastMatch opening node.
            reader.Read();

            return lastMatch;
        }

        /// <summary>
        /// Parses Player node.
        /// </summary>
        /// <param name="reader">XmlReader object loaded with the Xml file.</param>
        /// <returns>BusinessObjects.Hattrick.Players.Player with the parsed data.</returns>
        private BusinessObjects.Hattrick.Players.Player ParsePlayerNode(XmlReader reader)
        {
            if (!reader.Name.Equals(XmlTag.Player, StringComparison.OrdinalIgnoreCase))
            {
                throw new Exception(
                              string.Format(
                                         Localization.Strings.Message_UnexpectedXmlElement,
                                         reader.Name));
            }

            // Skips Player opening node.
            reader.Read();

            var newPlayer = new BusinessObjects.Hattrick.Players.Player();

            newPlayer.PlayerId = uint.Parse(reader.ReadElementContentAsString());
            newPlayer.FirstName = reader.ReadElementContentAsString();
            newPlayer.NickName = reader.ReadElementContentAsString();
            newPlayer.LastName = reader.ReadElementContentAsString();
            newPlayer.PlayerNumber = byte.Parse(reader.ReadElementContentAsString());
            newPlayer.Age = byte.Parse(reader.ReadElementContentAsString());
            newPlayer.AgeDays = byte.Parse(reader.ReadElementContentAsString());
            newPlayer.TSI = uint.Parse(reader.ReadElementContentAsString());
            newPlayer.PlayerForm = byte.Parse(reader.ReadElementContentAsString());
            newPlayer.Statement = reader.ReadElementContentAsString();
            newPlayer.Experience = byte.Parse(reader.ReadElementContentAsString());
            newPlayer.Loyalty = byte.Parse(reader.ReadElementContentAsString());
            newPlayer.MotherClubBonus = bool.Parse(reader.ReadElementContentAsString());
            newPlayer.Leadership = byte.Parse(reader.ReadElementContentAsString());
            newPlayer.Salary = uint.Parse(reader.ReadElementContentAsString());
            newPlayer.IsAbroad = reader.ReadElementContentAsString() == "1";
            newPlayer.Agreeability = byte.Parse(reader.ReadElementContentAsString());
            newPlayer.Aggressiveness = byte.Parse(reader.ReadElementContentAsString());
            newPlayer.Honesty = byte.Parse(reader.ReadElementContentAsString());
            newPlayer.LeagueGoals = byte.Parse(reader.ReadElementContentAsString());
            newPlayer.CupGoals = byte.Parse(reader.ReadElementContentAsString());
            newPlayer.FriendliesGoals = byte.Parse(reader.ReadElementContentAsString());
            newPlayer.CareerGoals = ushort.Parse(reader.ReadElementContentAsString());
            newPlayer.CareerHattricks = ushort.Parse(reader.ReadElementContentAsString());
            newPlayer.Specialty = byte.Parse(reader.ReadElementContentAsString());
            newPlayer.TransferListed = reader.ReadElementContentAsString() == "1";
            newPlayer.NationalTeamId = uint.Parse(reader.ReadElementContentAsString());
            newPlayer.CountryId = uint.Parse(reader.ReadElementContentAsString());
            newPlayer.Caps = ushort.Parse(reader.ReadElementContentAsString());
            newPlayer.CapsU20 = ushort.Parse(reader.ReadElementContentAsString());
            newPlayer.Cards = byte.Parse(reader.ReadElementContentAsString());
            newPlayer.InjuryLevel = sbyte.Parse(reader.ReadElementContentAsString());
            newPlayer.StaminaSkill = byte.Parse(reader.ReadElementContentAsString());

            if (reader.Name.Equals(XmlTag.KeeperSkill, StringComparison.OrdinalIgnoreCase))
            {
                newPlayer.KeeperSkill = byte.Parse(reader.ReadElementContentAsString());
            }

            if (reader.Name.Equals(XmlTag.PlaymakerSkill, StringComparison.OrdinalIgnoreCase))
            {
                newPlayer.PlaymakerSkill = byte.Parse(reader.ReadElementContentAsString());
            }

            if (reader.Name.Equals(XmlTag.ScorerSkill, StringComparison.OrdinalIgnoreCase))
            {
                newPlayer.ScorerSkill = byte.Parse(reader.ReadElementContentAsString());
            }

            if (reader.Name.Equals(XmlTag.PassingSkill, StringComparison.OrdinalIgnoreCase))
            {
                newPlayer.PassingSkill = byte.Parse(reader.ReadElementContentAsString());
            }

            if (reader.Name.Equals(XmlTag.WingerSkill, StringComparison.OrdinalIgnoreCase))
            {
                newPlayer.WingerSkill = byte.Parse(reader.ReadElementContentAsString());
            }

            if (reader.Name.Equals(XmlTag.DefenderSkill, StringComparison.OrdinalIgnoreCase))
            {
                newPlayer.DefenderSkill = byte.Parse(reader.ReadElementContentAsString());
            }

            if (reader.Name.Equals(XmlTag.SetPiecesSkill, StringComparison.OrdinalIgnoreCase))
            {
                newPlayer.SetPiecesSkill = byte.Parse(reader.ReadElementContentAsString());
            }

            if (reader.Name.Equals(XmlTag.PlayerCategoryId, StringComparison.OrdinalIgnoreCase))
            {
                newPlayer.PlayerCategoryId = byte.Parse(reader.ReadElementContentAsString());
            }

            if (reader.Name.Equals(XmlTag.TrainerData, StringComparison.OrdinalIgnoreCase))
            {
                newPlayer.TrainerData = this.ParseTrainerDataNode(reader);
            }

            if (reader.Name.Equals(XmlTag.LastMatch, StringComparison.OrdinalIgnoreCase))
            {
                newPlayer.LastMatch = this.ParseLastMatchNode(reader);
            }

            // Skips Player closing node.
            reader.Read();

            return newPlayer;
        }

        /// <summary>
        /// Parses Team node.
        /// </summary>
        /// <param name="reader">XmlReader object loaded with the Xml file.</param>
        /// <returns>BusinessObjects.Hattrick.Teams.Team with the parsed data.</returns>
        private BusinessObjects.Hattrick.Players.Team ParseTeamNode(XmlReader reader)
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

            var newTeam = new BusinessObjects.Hattrick.Players.Team();

            newTeam.TeamId = uint.Parse(reader.ReadElementContentAsString());
            newTeam.TeamName = reader.ReadElementContentAsString();

            if (reader.Name.Equals(XmlTag.PlayerList, StringComparison.OrdinalIgnoreCase))
            {
                // Skips PlayerList opening node.
                reader.Read();

                newTeam.PlayerList = new List<BusinessObjects.Hattrick.Players.Player>();

                while (reader.Name.Equals(XmlTag.Player, StringComparison.OrdinalIgnoreCase))
                {
                    newTeam.PlayerList.Add(
                                           this.ParsePlayerNode(reader));
                }

                // Skips PlayerList opening node.
                reader.Read();
            }

            // Skips Team closing node.
            reader.Read();

            return newTeam;
        }

        /// <summary>
        /// Parses LastMatch node.
        /// </summary>
        /// <param name="reader">XmlReader object loaded with the Xml file.</param>
        /// <returns>BusinessObjects.Hattrick.Players.LastMatch with the parsed data.</returns>
        private BusinessObjects.Hattrick.Players.TrainerData ParseTrainerDataNode(XmlReader reader)
        {
            if (!reader.Name.Equals(XmlTag.TrainerData, StringComparison.OrdinalIgnoreCase))
            {
                throw new Exception(
                              string.Format(
                                         Localization.Strings.Message_UnexpectedXmlElement,
                                         reader.Name));
            }

            var trainerData = new BusinessObjects.Hattrick.Players.TrainerData();

            // Skips TrainerData opening node.
            reader.Read();

            trainerData = new BusinessObjects.Hattrick.Players.TrainerData();

            trainerData.TrainerType = byte.Parse(reader.ReadElementContentAsString());
            trainerData.TrainerSkill = byte.Parse(reader.ReadElementContentAsString());

            // Skips TrainerData closing node.
            reader.Read();

            return trainerData;
        }

        #endregion Private Methods
    }
}