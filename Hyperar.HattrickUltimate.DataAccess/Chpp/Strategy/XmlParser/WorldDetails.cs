//-----------------------------------------------------------------------
// <copyright file="WorldDetails.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.DataAccess.Chpp.Strategy.XmlParser
{
    using System;
    using System.Globalization;
    using System.Xml;
    using BusinessObjects.Hattrick.Interface;
    using Constants;
    using Interface;

    /// <summary>
    /// Hattrick WorldDetails XML file parser implementation.
    /// </summary>
    internal class WorldDetails : IXmlParserStrategy
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

            var result = (BusinessObjects.Hattrick.WorldDetails.Root)entity;

            // Skips LeagueList opening node.
            reader.Read();

            while (reader.Name.Equals(XmlTag.League, StringComparison.OrdinalIgnoreCase))
            {
                result.LeagueList.Add(
                                      this.ParseLeagueNode(reader));
            }
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        /// Parses Country node.
        /// </summary>
        /// <param name="reader">XmlReader object loaded with the Xml file.</param>
        /// <returns>BusinessObjects.Hattrick.WorldDetails.Country with the parsed data.</returns>
        private BusinessObjects.Hattrick.WorldDetails.Country ParseCountryNode(XmlReader reader)
        {
            if (!reader.Name.Equals(XmlTag.Country, StringComparison.OrdinalIgnoreCase))
            {
                throw new Exception(
                              string.Format(
                                         Localization.Strings.Message_UnexpectedXmlElement,
                                         reader.Name));
            }

            // If Available attribute not present or false, no Country node to parse.
            if (string.IsNullOrWhiteSpace(reader.GetAttribute(XmlTag.Available)) ||
                !bool.Parse(reader.GetAttribute(XmlTag.Available)))
            {
                return null;
            }

            // Skips Country opening tag.
            reader.Read();

            var newCountry = new BusinessObjects.Hattrick.WorldDetails.Country();

            newCountry.CountryId = uint.Parse(reader.ReadElementContentAsString());
            newCountry.CountryName = reader.ReadElementContentAsString();
            newCountry.CurrencyName = reader.ReadElementContentAsString();

            newCountry.CurrencyRate = decimal.Parse(
                                                  reader.ReadElementContentAsString()
                                                        .Replace(
                                                             Generic.Comma,
                                                             CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator));

            newCountry.CountryCode = reader.ReadElementContentAsString();
            newCountry.DateFormat = reader.ReadElementContentAsString();
            newCountry.TimeFormat = reader.ReadElementContentAsString();

            if (reader.Name.Equals(XmlTag.RegionList, StringComparison.OrdinalIgnoreCase))
            {
                // Skips RegionList opening node.
                reader.Read();

                newCountry.RegionList = new System.Collections.Generic.List<BusinessObjects.Hattrick.WorldDetails.Region>();

                while (reader.Name.Equals(XmlTag.Region, StringComparison.OrdinalIgnoreCase))
                {
                    newCountry.RegionList.Add(
                                             this.ParseRegionNode(reader));
                }

                // Skips RegionList closing node.
                reader.Read();
            }

            return newCountry;
        }

        /// <summary>
        /// Parses Cup node.
        /// </summary>
        /// <param name="reader">XmlReader object loaded with the Xml file.</param>
        /// <returns>BusinessObjects.Hattrick.WorldDetails.Cup with the parsed data.</returns>
        private BusinessObjects.Hattrick.WorldDetails.Cup ParseCupNode(XmlReader reader)
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

            var newCup = new BusinessObjects.Hattrick.WorldDetails.Cup();

            newCup.CupId = uint.Parse(reader.ReadElementContentAsString());
            newCup.CupName = reader.ReadElementContentAsString();
            newCup.CupLeagueLevel = byte.Parse(reader.ReadElementContentAsString());
            newCup.CupLevel = byte.Parse(reader.ReadElementContentAsString());
            newCup.CupLevelIndex = byte.Parse(reader.ReadElementContentAsString());
            newCup.MatchRound = byte.Parse(reader.ReadElementContentAsString());
            newCup.MatchRoundsLeft = byte.Parse(reader.ReadElementContentAsString());

            // Skips Cup closing node.
            reader.Read();

            return newCup;
        }

        /// <summary>
        /// Parses League node.
        /// </summary>
        /// <param name="reader">XmlReader object loaded with the Xml file.</param>
        /// <returns>BusinessObjects.Hattrick.WorldDetails.League with the parsed data.</returns>
        private BusinessObjects.Hattrick.WorldDetails.League ParseLeagueNode(XmlReader reader)
        {
            if (!reader.Name.Equals(XmlTag.League, StringComparison.OrdinalIgnoreCase))
            {
                throw new Exception(
                              string.Format(
                                         Localization.Strings.Message_UnexpectedXmlElement,
                                         reader.Name));
            }

            var newLeague = new BusinessObjects.Hattrick.WorldDetails.League();

            // Skips League opening node.
            reader.Read();

            newLeague.LeagueId = uint.Parse(reader.ReadElementContentAsString());
            newLeague.LeagueName = reader.ReadElementContentAsString();
            newLeague.Season = reader.ReadElementContentAsInt();
            newLeague.SeasonOffset = reader.ReadElementContentAsInt();
            newLeague.MatchRound = byte.Parse(reader.ReadElementContentAsString());
            newLeague.ShortName = reader.ReadElementContentAsString();
            newLeague.Continent = reader.ReadElementContentAsString();
            newLeague.ZoneName = reader.ReadElementContentAsString();
            newLeague.EnglishName = reader.ReadElementContentAsString();

            if (reader.Name.Equals(XmlTag.Country, StringComparison.OrdinalIgnoreCase))
            {
                newLeague.Country = this.ParseCountryNode(reader);
            }

            // Skips Country closing tag.
            reader.Read();

            if (reader.Name.Equals(XmlTag.Cups, StringComparison.OrdinalIgnoreCase))
            {
                // Skips Cups opening node.
                reader.Read();

                while (reader.Name.Equals(XmlTag.Cup, StringComparison.OrdinalIgnoreCase))
                {
                    newLeague.Cups.Add(
                                       this.ParseCupNode(reader));
                }

                // Skips Cups closing node.
                reader.Read();
            }

            newLeague.NationalTeamId = uint.Parse(reader.ReadElementContentAsString());
            newLeague.U20TeamId = uint.Parse(reader.ReadElementContentAsString());
            newLeague.ActiveTeams = reader.ReadElementContentAsInt();
            newLeague.ActiveUsers = reader.ReadElementContentAsInt();
            newLeague.WaitingUsers = reader.ReadElementContentAsInt();
            newLeague.TrainingDate = DateTime.Parse(reader.ReadElementContentAsString());
            newLeague.EconomyDate = DateTime.Parse(reader.ReadElementContentAsString());
            newLeague.CupMatchDate = DateTime.Parse(reader.ReadElementContentAsString());
            newLeague.SeriesMatchDate = DateTime.Parse(reader.ReadElementContentAsString());
            newLeague.NumberOfLevels = byte.Parse(reader.ReadElementContentAsString());

            // Skips League closing node.
            reader.Read();

            return newLeague;
        }

        /// <summary>
        /// Parses Region node.
        /// </summary>
        /// <param name="reader">XmlReader object loaded with the Xml file.</param>
        /// <returns>BusinessObjects.Hattrick.WorldDetails.Region with the parsed data.</returns>
        private BusinessObjects.Hattrick.WorldDetails.Region ParseRegionNode(XmlReader reader)
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

            var newRegion = new BusinessObjects.Hattrick.WorldDetails.Region();

            newRegion.RegionId = uint.Parse(reader.ReadElementContentAsString());
            newRegion.RegionName = reader.ReadElementContentAsString();

            // Skips Region closing node.
            reader.Read();

            return newRegion;
        }

        #endregion Private Methods
    }
}