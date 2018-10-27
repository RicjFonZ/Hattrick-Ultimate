//-----------------------------------------------------------------------
// <copyright file="ManagerCompendium.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.DataAccess.Chpp.Strategy.XmlParser
{
    using System;
    using System.Collections.Generic;
    using System.Xml;
    using Constants;
    using Interface;

    /// <summary>
    /// Manager Compendium XML file parser strategy.
    /// </summary>
    internal class ManagerCompendium : IXmlParserStrategy
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

            var result = (BusinessObjects.Hattrick.ManagerCompendium.Root)entity;

            if (reader.Name.Equals(XmlTag.Manager, StringComparison.OrdinalIgnoreCase))
            {
                result.Manager = this.ParseManagerNode(reader);
            }
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        /// Parses Arena node.
        /// </summary>
        /// <param name="reader">XmlReader object loaded with the Xml file.</param>
        /// <returns>BusinessObjects.Hattrick.ManagerCompendium.Arena with the parsed data.</returns>
        private BusinessObjects.Hattrick.ManagerCompendium.Arena ParseArenaNode(XmlReader reader)
        {
            if (!reader.Name.Equals(XmlTag.Arena, StringComparison.OrdinalIgnoreCase))
            {
                throw new Exception(
                              string.Format(
                                         Localization.Messages.UnexpectedXmlElement,
                                         reader.Name));
            }

            // Skips Arena opening node.
            reader.Read();

            var newArena = new BusinessObjects.Hattrick.ManagerCompendium.Arena();

            newArena.ArenaId = long.Parse(reader.ReadElementContentAsString());
            newArena.ArenaName = reader.ReadElementContentAsString();

            // Skips Arena closing node.
            reader.Read();

            return newArena;
        }

        /// <summary>
        /// Parses Avatar node.
        /// </summary>
        /// <param name="reader">XmlReader object loaded with the Xml file.</param>
        /// <returns>BusinessObjects.Hattrick.ManagerCompendium.Avatar with the parsed data.</returns>
        private BusinessObjects.Hattrick.ManagerCompendium.Avatar ParseAvatarNode(XmlReader reader)
        {
            if (!reader.Name.Equals(XmlTag.Avatar, StringComparison.OrdinalIgnoreCase))
            {
                throw new Exception(
                              string.Format(
                                         Localization.Messages.UnexpectedXmlElement,
                                         reader.Name));
            }

            // Skips Avatar opening tag.
            reader.Read();

            var newAvatar = new BusinessObjects.Hattrick.ManagerCompendium.Avatar();

            newAvatar.BackgroundImage = reader.ReadElementContentAsString();

            newAvatar.Layers = new List<BusinessObjects.Hattrick.ManagerCompendium.Layer>();

            while (reader.Name.Equals(XmlTag.Layer, StringComparison.OrdinalIgnoreCase))
            {
                newAvatar.Layers.Add(
                                     this.ParseLayerNode(reader));
            }

            // Skips Avatar closing tag.
            reader.Read();

            return newAvatar;
        }

        /// <summary>
        /// Parses Country node.
        /// </summary>
        /// <param name="reader">XmlReader object loaded with the Xml file.</param>
        /// <returns>BusinessObjects.Hattrick.ManagerCompendium.Country with the parsed data.</returns>
        private BusinessObjects.Hattrick.ManagerCompendium.Country ParseCountryNode(XmlReader reader)
        {
            if (!reader.Name.Equals(XmlTag.Country, StringComparison.OrdinalIgnoreCase))
            {
                throw new Exception(
                              string.Format(
                                         Localization.Messages.UnexpectedXmlElement,
                                         reader.Name));
            }

            // Skips Country opening node.
            reader.Read();

            var newCountry = new BusinessObjects.Hattrick.ManagerCompendium.Country();

            newCountry.CountryId = long.Parse(reader.ReadElementContentAsString());
            newCountry.CountryName = reader.ReadElementContentAsString();

            // Skips Country closing node.
            reader.Read();

            return newCountry;
        }

        /// <summary>
        /// Parses Language node.
        /// </summary>
        /// <param name="reader">XmlReader object loaded with the Xml file.</param>
        /// <returns>BusinessObjects.Hattrick.ManagerCompendium.Language with the parsed data.</returns>
        private BusinessObjects.Hattrick.ManagerCompendium.Language ParseLanguageNode(XmlReader reader)
        {
            if (!reader.Name.Equals(XmlTag.Language, StringComparison.OrdinalIgnoreCase))
            {
                throw new Exception(
                              string.Format(
                                         Localization.Messages.UnexpectedXmlElement,
                                         reader.Name));
            }

            // Skips Language opening node.
            reader.Read();

            var newLanguage = new BusinessObjects.Hattrick.ManagerCompendium.Language();

            newLanguage.LanguageId = long.Parse(reader.ReadElementContentAsString());
            newLanguage.LanguageName = reader.ReadElementContentAsString();

            // Skips Language closing node.
            reader.Read();

            return newLanguage;
        }

        /// <summary>
        /// Parses Layer node.
        /// </summary>
        /// <param name="reader">XmlReader object loaded with the Xml file.</param>
        /// <returns>BusinessObjects.Hattrick.ManagerCompendium.Layer with the parsed data.</returns>
        private BusinessObjects.Hattrick.ManagerCompendium.Layer ParseLayerNode(XmlReader reader)
        {
            if (!reader.Name.Equals(XmlTag.Layer, StringComparison.OrdinalIgnoreCase))
            {
                throw new Exception(
                              string.Format(
                                         Localization.Messages.UnexpectedXmlElement,
                                         reader.Name));
            }

            var newLayer = new BusinessObjects.Hattrick.ManagerCompendium.Layer();

            var positionAttributes = new List<KeyValuePair<string, int>>();

            if (!string.IsNullOrWhiteSpace(reader.GetAttribute(XmlTag.X)))
            {
                newLayer.X = int.Parse(reader.GetAttribute(XmlTag.X));
            }

            if (!string.IsNullOrWhiteSpace(reader.GetAttribute(XmlTag.Y)))
            {
                newLayer.X = int.Parse(reader.GetAttribute(XmlTag.Y));
            }

            // Skips Layer opening tag.
            reader.Read();

            newLayer.Image = reader.ReadElementContentAsString();

            // Skips Layer closing tag.
            reader.Read();

            return newLayer;
        }

        /// <summary>
        /// Parses LeagueLevelUnit node.
        /// </summary>
        /// <param name="reader">XmlReader object loaded with the Xml file.</param>
        /// <returns>
        /// BusinessObjects.Hattrick.ManagerCompendium.LeagueLevelUnit with the parsed data.
        /// </returns>
        private BusinessObjects.Hattrick.ManagerCompendium.LeagueLevelUnit ParseLeagueLevelUnitNode(XmlReader reader)
        {
            if (!reader.Name.Equals(XmlTag.LeagueLevelUnit, StringComparison.OrdinalIgnoreCase))
            {
                throw new Exception(
                              string.Format(
                                         Localization.Messages.UnexpectedXmlElement,
                                         reader.Name));
            }

            // Skips LeagueLevelUnit opening node.
            reader.Read();

            var newLeagueLevelUnit = new BusinessObjects.Hattrick.ManagerCompendium.LeagueLevelUnit();

            newLeagueLevelUnit.LeagueLevelUnitId = long.Parse(reader.ReadElementContentAsString());
            newLeagueLevelUnit.LeagueLevelUnitName = reader.ReadElementContentAsString();

            // Skips LeagueLevelUnit closing node.
            reader.Read();

            return newLeagueLevelUnit;
        }

        /// <summary>
        /// Parses League node.
        /// </summary>
        /// <param name="reader">XmlReader object loaded with the Xml file.</param>
        /// <returns>BusinessObjects.Hattrick.ManagerCompendium.League with the parsed data.</returns>
        private BusinessObjects.Hattrick.ManagerCompendium.League ParseLeagueNode(XmlReader reader)
        {
            if (!reader.Name.Equals(XmlTag.League, StringComparison.OrdinalIgnoreCase))
            {
                throw new Exception(
                              string.Format(
                                         Localization.Messages.UnexpectedXmlElement,
                                         reader.Name));
            }

            // Skips League opening node.
            reader.Read();

            var newLeague = new BusinessObjects.Hattrick.ManagerCompendium.League();

            newLeague.LeagueId = long.Parse(reader.ReadElementContentAsString());
            newLeague.LeagueName = reader.ReadElementContentAsString();

            // Skips League closing node.
            reader.Read();

            return newLeague;
        }

        /// <summary>
        /// Parses Manager node.
        /// </summary>
        /// <param name="reader">XmlReader object loaded with the Xml file.</param>
        /// <returns>BusinessObjects.Hattrick.ManagerCompendium.Manager with the parsed data.</returns>
        private BusinessObjects.Hattrick.ManagerCompendium.Manager ParseManagerNode(XmlReader reader)
        {
            if (!reader.Name.Equals(XmlTag.Manager, StringComparison.OrdinalIgnoreCase))
            {
                throw new Exception(
                              string.Format(
                                         Localization.Messages.UnexpectedXmlElement,
                                         reader.Name));
            }

            // Skips Manager opening node.
            reader.Read();

            var newManager = new BusinessObjects.Hattrick.ManagerCompendium.Manager();

            newManager.UserId = long.Parse(reader.ReadElementContentAsString());
            newManager.LoginName = reader.ReadElementContentAsString();
            newManager.SupporterTier = reader.ReadElementContentAsString();

            if (reader.Name.Equals(XmlTag.LastLogins, StringComparison.OrdinalIgnoreCase))
            {
                // Skips LastLogins opening tag.
                reader.Read();

                newManager.LastLogins = new List<string>();

                while (reader.Name.Equals(XmlTag.LoginTime, StringComparison.OrdinalIgnoreCase))
                {
                    newManager.LastLogins.Add(reader.ReadElementContentAsString());
                }

                // Skips LastLogins closing tag.
                reader.Read();
            }

            if (reader.Name.Equals(XmlTag.Language, StringComparison.OrdinalIgnoreCase))
            {
                newManager.Language = this.ParseLanguageNode(reader);
            }

            if (reader.Name.Equals(XmlTag.Country, StringComparison.OrdinalIgnoreCase))
            {
                newManager.Country = this.ParseCountryNode(reader);
            }

            if (reader.Name.Equals(XmlTag.Teams, StringComparison.OrdinalIgnoreCase) &&
                !reader.IsEmptyElement)
            {
                // Skips Teams opening tag.
                reader.Read();

                newManager.Teams = new List<BusinessObjects.Hattrick.ManagerCompendium.Team>();

                while (reader.Name.Equals(XmlTag.Team, StringComparison.OrdinalIgnoreCase))
                {
                    newManager.Teams.Add(
                                         this.ParseTeamNode(reader));
                }
            }

            // Skips Teams opening tag.
            reader.Read();

            if (reader.Name.Equals(XmlTag.NationalTeamCoach, StringComparison.OrdinalIgnoreCase) &&
                !reader.IsEmptyElement)
            {
                newManager.NationalTeamCoach = new List<BusinessObjects.Hattrick.ManagerCompendium.NationalTeam>();

                // Skips NationalTeamCoach opening tag.
                reader.Read();

                while (reader.Name.Equals(XmlTag.NationalTeam, StringComparison.OrdinalIgnoreCase))
                {
                    newManager.NationalTeamCoach.Add(
                                                     this.ParseNationalTeamNode(reader));
                }
            }

            // Skips NationalTeamCoach closing tag.
            reader.Read();

            if (reader.Name.Equals(XmlTag.Avatar, StringComparison.OrdinalIgnoreCase))
            {
                newManager.Avatar = this.ParseAvatarNode(reader);
            }

            // Skips Manager closing tag.
            reader.Read();

            return newManager;
        }

        /// <summary>
        /// Parses NationalTeam node.
        /// </summary>
        /// <param name="reader">XmlReader object loaded with the Xml file.</param>
        /// <returns>
        /// BusinessObjects.Hattrick.ManagerCompendium.NationalTeam with the parsed data.
        /// </returns>
        private BusinessObjects.Hattrick.ManagerCompendium.NationalTeam ParseNationalTeamNode(XmlReader reader)
        {
            if (!reader.Name.Equals(XmlTag.NationalTeam, StringComparison.OrdinalIgnoreCase))
            {
                throw new Exception(
                              string.Format(
                                         Localization.Messages.UnexpectedXmlElement,
                                         reader.Name));
            }

            var newNationalTeam = new BusinessObjects.Hattrick.ManagerCompendium.NationalTeam();

            // Skips NationalTeam opening node.
            reader.Read();

            newNationalTeam.NationalTeamId = long.Parse(reader.ReadElementContentAsString());
            newNationalTeam.NationalTeamName = reader.ReadElementContentAsString();

            // Skips NationalTeam closing node.
            reader.Read();

            return newNationalTeam;
        }

        /// <summary>
        /// Parses Region node.
        /// </summary>
        /// <param name="reader">XmlReader object loaded with the Xml file.</param>
        /// <returns>BusinessObjects.Hattrick.ManagerCompendium.Region with the parsed data.</returns>
        private BusinessObjects.Hattrick.ManagerCompendium.Region ParseRegionNode(XmlReader reader)
        {
            if (!reader.Name.Equals(XmlTag.Region, StringComparison.OrdinalIgnoreCase))
            {
                throw new Exception(
                              string.Format(
                                         Localization.Messages.UnexpectedXmlElement,
                                         reader.Name));
            }

            // Skips Region opening node.
            reader.Read();

            var newRegion = new BusinessObjects.Hattrick.ManagerCompendium.Region();

            newRegion.RegionId = long.Parse(reader.ReadElementContentAsString());
            newRegion.RegionName = reader.ReadElementContentAsString();

            // Skips Region closing node.
            reader.Read();

            return newRegion;
        }

        /// <summary>
        /// Parses Team node.
        /// </summary>
        /// <param name="reader">XmlReader object loaded with the Xml file.</param>
        /// <returns>BusinessObjects.Hattrick.ManagerCompendium.Team with the parsed data.</returns>
        private BusinessObjects.Hattrick.ManagerCompendium.Team ParseTeamNode(XmlReader reader)
        {
            if (!reader.Name.Equals(XmlTag.Team, StringComparison.OrdinalIgnoreCase))
            {
                throw new Exception(
                              string.Format(
                                         Localization.Messages.UnexpectedXmlElement,
                                         reader.Name));
            }

            // Skips Team opening node.
            reader.Read();

            var newTeam = new BusinessObjects.Hattrick.ManagerCompendium.Team();

            newTeam.TeamId = long.Parse(reader.ReadElementContentAsString());
            newTeam.TeamName = reader.ReadElementContentAsString();

            if (reader.Name.Equals(XmlTag.Arena, StringComparison.OrdinalIgnoreCase))
            {
                newTeam.Arena = this.ParseArenaNode(reader);
            }

            if (reader.Name.Equals(XmlTag.League, StringComparison.OrdinalIgnoreCase))
            {
                newTeam.League = this.ParseLeagueNode(reader);
            }

            if (reader.Name.Equals(XmlTag.LeagueLevelUnit, StringComparison.OrdinalIgnoreCase))
            {
                newTeam.LeagueLevelUnit = this.ParseLeagueLevelUnitNode(reader);
            }

            if (reader.Name.Equals(XmlTag.Region, StringComparison.OrdinalIgnoreCase))
            {
                newTeam.Region = this.ParseRegionNode(reader);
            }

            if (reader.Name.Equals(XmlTag.YouthTeam, StringComparison.OrdinalIgnoreCase) &&
                !reader.IsEmptyElement)
            {
                newTeam.YouthTeam = this.ParseYouthTeamNode(reader);
            }

            // Skips Team closing node.
            reader.Read();

            return newTeam;
        }

        /// <summary>
        /// Parses YouthLeague node.
        /// </summary>
        /// <param name="reader">XmlReader object loaded with the Xml file.</param>
        /// <returns>BusinessObjects.Hattrick.ManagerCompendium.YouthLeague with the parsed data.</returns>
        private BusinessObjects.Hattrick.ManagerCompendium.YouthLeague ParseYouthLeagueNode(XmlReader reader)
        {
            if (!reader.Name.Equals(XmlTag.YouthLeague, StringComparison.OrdinalIgnoreCase))
            {
                throw new Exception(
                              string.Format(
                                         Localization.Messages.UnexpectedXmlElement,
                                         reader.Name));
            }

            // Skips YouthLeague opening node.
            reader.Read();

            var newYouthLeague = new BusinessObjects.Hattrick.ManagerCompendium.YouthLeague();

            newYouthLeague.YouthLeagueId = long.Parse(reader.ReadElementContentAsString());
            newYouthLeague.YouthLeagueName = reader.ReadElementContentAsString();

            // Skips YouthLeague closing node.
            reader.Read();

            return newYouthLeague;
        }

        /// <summary>
        /// Parses YouthTeam node.
        /// </summary>
        /// <param name="reader">XmlReader object loaded with the Xml file.</param>
        /// <returns>BusinessObjects.Hattrick.ManagerCompendium.YouthTeam with the parsed data.</returns>
        private BusinessObjects.Hattrick.ManagerCompendium.YouthTeam ParseYouthTeamNode(XmlReader reader)
        {
            if (!reader.Name.Equals(XmlTag.YouthTeam, StringComparison.OrdinalIgnoreCase))
            {
                throw new Exception(
                              string.Format(
                                         Localization.Messages.UnexpectedXmlElement,
                                         reader.Name));
            }

            // Skips YouthTeam opening node.
            reader.Read();

            var newYouthTeam = new BusinessObjects.Hattrick.ManagerCompendium.YouthTeam();

            newYouthTeam.YouthTeamId = long.Parse(reader.ReadElementContentAsString());
            newYouthTeam.YouthTeamName = reader.ReadElementContentAsString();

            if (reader.Name.Equals(XmlTag.YouthLeague, StringComparison.OrdinalIgnoreCase) &&
                !reader.IsEmptyElement)
            {
                newYouthTeam.YouthLeague = this.ParseYouthLeagueNode(reader);
            }

            // Skips YouthTeam closing node.
            reader.Read();

            return newYouthTeam;
        }

        #endregion Private Methods
    }
}