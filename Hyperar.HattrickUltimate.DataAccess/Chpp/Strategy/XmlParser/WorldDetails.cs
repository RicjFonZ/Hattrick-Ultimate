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
                var newLeague = new BusinessObjects.Hattrick.WorldDetails.League();

                // Skips League opening node.
                reader.Read();

                newLeague.LeagueId = uint.Parse(reader.ReadElementContentAsString());
                newLeague.LeagueName = reader.ReadElementContentAsString();
                newLeague.Season = reader.ReadElementContentAsInt();
                newLeague.SeasonOffset = reader.ReadElementContentAsInt();
                newLeague.MatchRound = reader.ReadElementContentAsInt();
                newLeague.ShortName = reader.ReadElementContentAsString();
                newLeague.Continent = reader.ReadElementContentAsString();
                newLeague.ZoneName = reader.ReadElementContentAsString();
                newLeague.EnglishName = reader.ReadElementContentAsString();

                if (reader.Name.Equals(XmlTag.Country, StringComparison.OrdinalIgnoreCase) &&
                    reader.MoveToFirstAttribute() &&
                    reader.Name.Equals(XmlTag.Available, StringComparison.OrdinalIgnoreCase) &&
                    bool.Parse(reader.Value))
                {
                    // Skips Country opening node.
                    reader.Read();

                    newLeague.Country = new BusinessObjects.Hattrick.WorldDetails.Country();

                    newLeague.Country.CountryId = uint.Parse(reader.ReadElementContentAsString());
                    newLeague.Country.CountryName = reader.ReadElementContentAsString();
                    newLeague.Country.CurrencyName = reader.ReadElementContentAsString();

                    newLeague.Country.CurrencyRate = decimal.Parse(
                                                                reader.ReadElementContentAsString()
                                                                      .Replace(
                                                                          Generic.Comma,
                                                                          CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator));

                    newLeague.Country.CountryCode = reader.ReadElementContentAsString();
                    newLeague.Country.DateFormat = reader.ReadElementContentAsString();
                    newLeague.Country.TimeFormat = reader.ReadElementContentAsString();

                    if (reader.Name.Equals(XmlTag.RegionList, StringComparison.OrdinalIgnoreCase))
                    {
                        // Skips RegionList opening node.
                        reader.Read();

                        while (reader.Name.Equals(XmlTag.Region, StringComparison.OrdinalIgnoreCase))
                        {
                            // Skips Region opening node.
                            reader.Read();

                            newLeague.Country.RegionList = new System.Collections.Generic.List<BusinessObjects.Hattrick.WorldDetails.Region>();

                            var newRegion = new BusinessObjects.Hattrick.WorldDetails.Region();

                            newRegion.RegionId = uint.Parse(reader.ReadElementContentAsString());
                            newRegion.RegionName = reader.ReadElementContentAsString();

                            newLeague.Country.RegionList.Add(newRegion);

                            // Skips Region closing node.
                            reader.Read();
                        }

                        // Skips RegionList closing node.
                        reader.Read();
                    }
                }

                // Skips Country closing node.
                // REMARK: This skip in particular is outside the if block because the Country tag
                // ALWAYS exists but in case of Hattrick International, it's empty, so we need to
                // skip the tag to move to the Cups node.
                reader.Read();

                if (reader.Name.Equals(XmlTag.Cups, StringComparison.OrdinalIgnoreCase))
                {
                    // Skips Cups opening node.
                    reader.Read();

                    while (reader.Name.Equals(XmlTag.Cup, StringComparison.OrdinalIgnoreCase))
                    {
                        // Skips Cup opening node.
                        reader.Read();

                        var newCup = new BusinessObjects.Hattrick.WorldDetails.Cup();

                        newCup.CupId = uint.Parse(reader.ReadElementContentAsString());
                        newCup.CupName = reader.ReadElementContentAsString();
                        newCup.CupLeagueLevel = reader.ReadElementContentAsInt();
                        newCup.CupLevel = reader.ReadElementContentAsInt();
                        newCup.CupLevelIndex = reader.ReadElementContentAsInt();
                        newCup.MatchRound = reader.ReadElementContentAsInt();
                        newCup.MatchRoundsLeft = reader.ReadElementContentAsInt();

                        newLeague.Cups.Add(newCup);

                        // Skips Cup closing node.
                        reader.Read();
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
                newLeague.NumberOfLevels = reader.ReadElementContentAsInt();

                result.LeagueList.Add(newLeague);

                // Skips League closing node.
                reader.Read();
            }
        }

        #endregion Public Methods
    }
}