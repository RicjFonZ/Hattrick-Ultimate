//-----------------------------------------------------------------------
// <copyright file="YouthTeamDetails.cs" company="Hyperar">
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
    /// Youth Team Details XML file parser strategy.
    /// </summary>
    internal class YouthTeamDetails : IXmlParserStrategy
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

            var result = (BusinessObjects.Hattrick.YouthTeamDetails.Root)entity;

            if (reader.Name.Equals(XmlTag.YouthTeam, StringComparison.OrdinalIgnoreCase))
            {
                result.YouthTeam = this.ParseYouthTeamNode(reader);
            }
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        /// Parses Country node.
        /// </summary>
        /// <param name="reader">XmlReader object loaded with the Xml file.</param>
        /// <returns>BusinessObjects.Hattrick.YouthTeamDetails.Country with the parsed data.</returns>
        private BusinessObjects.Hattrick.YouthTeamDetails.Country ParseCountryNode(XmlReader reader)
        {
            if (!reader.Name.Equals(XmlTag.Country, StringComparison.OrdinalIgnoreCase) &&
                !reader.Name.Equals(XmlTag.InCountry, StringComparison.OrdinalIgnoreCase))
            {
                throw new Exception(
                              string.Format(
                                         Localization.Messages.UnexpectedXmlElement,
                                         reader.Name));
            }

            // Skips Country/InCountry opening tag.
            reader.Read();

            var newCountry = new BusinessObjects.Hattrick.YouthTeamDetails.Country();

            newCountry.CountryId = long.Parse(reader.ReadElementContentAsString());
            newCountry.CountryName = reader.ReadElementContentAsString();

            // Skips Country/InCountry closing tag.
            reader.Read();

            return newCountry;
        }

        /// <summary>
        /// Parses OwningTeam node.
        /// </summary>
        /// <param name="reader">XmlReader object loaded with the Xml file.</param>
        /// <returns>BusinessObjects.Hattrick.YouthTeamDetails.OwningTeam with the parsed data.</returns>
        private BusinessObjects.Hattrick.YouthTeamDetails.OwningTeam ParseOwningTeamNode(XmlReader reader)
        {
            if (!reader.Name.Equals(XmlTag.OwningTeam, StringComparison.OrdinalIgnoreCase))
            {
                throw new Exception(
                              string.Format(
                                         Localization.Messages.UnexpectedXmlElement,
                                         reader.Name));
            }

            // Skips OwningTeam opening tag.
            reader.Read();

            var newOwningTeam = new BusinessObjects.Hattrick.YouthTeamDetails.OwningTeam();

            newOwningTeam.MotherTeamId = long.Parse(reader.ReadElementContentAsString());
            newOwningTeam.MotherTeamName = reader.ReadElementContentAsString();

            // Skips OwningTeam closing tag.
            reader.Read();

            return newOwningTeam;
        }

        /// <summary>
        /// Parses Region node.
        /// </summary>
        /// <param name="reader">XmlReader object loaded with the Xml file.</param>
        /// <returns>BusinessObjects.Hattrick.YouthTeamDetails.Region with the parsed data.</returns>
        private BusinessObjects.Hattrick.YouthTeamDetails.Region ParseRegionNode(XmlReader reader)
        {
            if (!reader.Name.Equals(XmlTag.Region, StringComparison.OrdinalIgnoreCase) &&
                !reader.Name.Equals(XmlTag.InRegion, StringComparison.OrdinalIgnoreCase))
            {
                throw new Exception(
                              string.Format(
                                         Localization.Messages.UnexpectedXmlElement,
                                         reader.Name));
            }

            // Skips Region/InRegion opening tag.
            reader.Read();

            var newRegion = new BusinessObjects.Hattrick.YouthTeamDetails.Region();

            newRegion.RegionId = long.Parse(reader.ReadElementContentAsString());
            newRegion.RegionName = reader.ReadElementContentAsString();

            // Skips Region/InRegion closing tag.
            reader.Read();

            return newRegion;
        }

        /// <summary>
        /// Parses Scout node.
        /// </summary>
        /// <param name="reader">XmlReader object loaded with the Xml file.</param>
        /// <returns>BusinessObjects.Hattrick.YouthTeamDetails.Scout with the parsed data.</returns>
        private BusinessObjects.Hattrick.YouthTeamDetails.Scout ParseScoutNode(XmlReader reader)
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

            var newScout = new BusinessObjects.Hattrick.YouthTeamDetails.Scout();

            newScout.YouthScoutId = long.Parse(reader.ReadElementContentAsString());
            newScout.ScoutName = reader.ReadElementContentAsString();
            newScout.Age = byte.Parse(reader.ReadElementContentAsString());
            newScout.Country = this.ParseCountryNode(reader);
            newScout.Region = this.ParseRegionNode(reader);
            newScout.InCountry = this.ParseCountryNode(reader);
            newScout.InRegion = this.ParseRegionNode(reader);
            newScout.HiredDate = DateTime.Parse(reader.ReadElementContentAsString());
            newScout.LastCalled = DateTime.Parse(reader.ReadElementContentAsString());
            newScout.PlayerSearchType = byte.Parse(reader.ReadElementContentAsString());
            newScout.HofPlayerId = long.Parse(reader.ReadElementContentAsString());

            if (reader.Name.Equals(XmlTag.Travel, StringComparison.OrdinalIgnoreCase) && !reader.IsEmptyElement)
            {
                newScout.Travel = this.ParseTravelNode(reader);
            }

            // Skips Scout closing tag.
            reader.Read();

            return newScout;
        }

        /// <summary>
        /// Parses Travel node.
        /// </summary>
        /// <param name="reader">XmlReader object loaded with the Xml file.</param>
        /// <returns>BusinessObjects.Hattrick.YouthTeamDetails.Travel with the parsed data.</returns>
        private BusinessObjects.Hattrick.YouthTeamDetails.Travel ParseTravelNode(XmlReader reader)
        {
            if (!reader.Name.Equals(XmlTag.Travel, StringComparison.OrdinalIgnoreCase))
            {
                throw new Exception(
                              string.Format(
                                         Localization.Messages.UnexpectedXmlElement,
                                         reader.Name));
            }

            // Skips Travel opening tag.
            reader.Read();

            var newTravel = new BusinessObjects.Hattrick.YouthTeamDetails.Travel();

            newTravel.TravelStartDate = DateTime.Parse(reader.ReadElementContentAsString());
            newTravel.TravelLength = int.Parse(reader.ReadElementContentAsString());
            newTravel.TravelType = byte.Parse(reader.ReadElementContentAsString());

            // Skips Travel closing tag.
            reader.Read();

            return newTravel;
        }

        /// <summary>
        /// Parses YouthArena node.
        /// </summary>
        /// <param name="reader">XmlReader object loaded with the Xml file.</param>
        /// <returns>BusinessObjects.Hattrick.YouthTeamDetails.YouthArena with the parsed data.</returns>
        private BusinessObjects.Hattrick.YouthTeamDetails.YouthArena ParseYouthArenaNode(XmlReader reader)
        {
            if (!reader.Name.Equals(XmlTag.YouthArena, StringComparison.OrdinalIgnoreCase))
            {
                throw new Exception(
                              string.Format(
                                         Localization.Messages.UnexpectedXmlElement,
                                         reader.Name));
            }

            // Skips YouthArena opening tag.
            reader.Read();

            var newYouthArena = new BusinessObjects.Hattrick.YouthTeamDetails.YouthArena();

            newYouthArena.YouthArenaId = long.Parse(reader.ReadElementContentAsString());
            newYouthArena.YouthArenaName = reader.ReadElementContentAsString();

            // Skips YouthArena closing tag.
            reader.Read();

            return newYouthArena;
        }

        /// <summary>
        /// Parses YouthLeague node.
        /// </summary>
        /// <param name="reader">XmlReader object loaded with the Xml file.</param>
        /// <returns>BusinessObjects.Hattrick.YouthTeamDetails.YouthLeague with the parsed data.</returns>
        private BusinessObjects.Hattrick.YouthTeamDetails.YouthLeague ParseYouthLeagueNode(XmlReader reader)
        {
            if (!reader.Name.Equals(XmlTag.YouthLeague, StringComparison.OrdinalIgnoreCase))
            {
                throw new Exception(
                              string.Format(
                                         Localization.Messages.UnexpectedXmlElement,
                                         reader.Name));
            }

            // Skips YouthLeague opening tag.
            reader.Read();

            var newYouthLeague = new BusinessObjects.Hattrick.YouthTeamDetails.YouthLeague();

            newYouthLeague.YouthLeagueId = long.Parse(reader.ReadElementContentAsString());
            newYouthLeague.YouthLeagueName = reader.ReadElementContentAsString();
            newYouthLeague.YouthLeagueStatus = byte.Parse(reader.ReadElementContentAsString());

            // Skips YouthLeague closing tag.
            reader.Read();

            return newYouthLeague;
        }

        /// <summary>
        /// Parses YouthTeam node.
        /// </summary>
        /// <param name="reader">XmlReader object loaded with the Xml file.</param>
        /// <returns>BusinessObjects.Hattrick.YouthTeamDetails.YouthTeam with the parsed data.</returns>
        private BusinessObjects.Hattrick.YouthTeamDetails.YouthTeam ParseYouthTeamNode(XmlReader reader)
        {
            if (!reader.Name.Equals(XmlTag.YouthTeam, StringComparison.OrdinalIgnoreCase))
            {
                throw new Exception(
                              string.Format(
                                         Localization.Messages.UnexpectedXmlElement,
                                         reader.Name));
            }

            // Skips YouthTeam opening tag.
            reader.Read();

            var newYouthTeam = new BusinessObjects.Hattrick.YouthTeamDetails.YouthTeam();

            newYouthTeam.YouthTeamId = long.Parse(reader.ReadElementContentAsString());
            newYouthTeam.YouthTeamName = reader.ReadElementContentAsString();
            newYouthTeam.ShortTeamName = reader.ReadElementContentAsString();
            newYouthTeam.CreatedDate = DateTime.Parse(reader.ReadElementContentAsString());
            newYouthTeam.Country = this.ParseCountryNode(reader);
            newYouthTeam.Region = this.ParseRegionNode(reader);
            newYouthTeam.YouthArena = this.ParseYouthArenaNode(reader);
            newYouthTeam.YouthLeague = this.ParseYouthLeagueNode(reader);
            newYouthTeam.OwningTeam = this.ParseOwningTeamNode(reader);

            if (reader.Name.Equals(XmlTag.YouthTrainer, StringComparison.OrdinalIgnoreCase))
            {
                // Skips YouthTrainer opening tag.
                reader.Read();

                newYouthTeam.YouthTrainer = new BusinessObjects.Hattrick.YouthTeamDetails.YouthTrainer();

                newYouthTeam.YouthTrainer.YouthPlayerId = long.Parse(reader.ReadElementContentAsString());

                // Skips YouthTrainer closing tag.
                reader.Read();
            }

            newYouthTeam.NextTrainingMatchDate = DateTime.Parse(reader.ReadElementContentAsString());

            if (reader.Name.Equals(XmlTag.ScoutList, StringComparison.OrdinalIgnoreCase) &&
                !reader.IsEmptyElement)
            {
                newYouthTeam.ScoutList = new List<BusinessObjects.Hattrick.YouthTeamDetails.Scout>();

                // Skips ScoutList opening tag.
                reader.Read();

                while (reader.Name.Equals(XmlTag.Scout, StringComparison.OrdinalIgnoreCase))
                {
                    newYouthTeam.ScoutList.Add(
                                               this.ParseScoutNode(reader));
                }

                // Skips ScoutList closing tag.
                reader.Read();
            }

            // Skips YouthTeam closing tag.
            reader.Read();

            return newYouthTeam;
        }

        #endregion Private Methods
    }
}