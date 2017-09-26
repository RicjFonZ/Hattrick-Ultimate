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
    using System.Linq;
    using System.Xml;
    using Interface;

    /// <summary>
    /// Hattrick ManagerCompendium XML file parser implementation.
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

            // Skips Manager opening node.
            reader.Read();

            result.Manager = new BusinessObjects.Hattrick.ManagerCompendium.Manager();

            result.Manager.UserId = uint.Parse(reader.ReadElementContentAsString());
            result.Manager.LoginName = reader.ReadElementContentAsString();
            result.Manager.SupporterTier = reader.ReadElementContentAsString();

            if (reader.Name.Equals(Constants.XmlTag.LastLogins, StringComparison.OrdinalIgnoreCase))
            {
                // Skips LastLogins opening tag.
                reader.Read();

                result.Manager.LastLogins = new List<string>();

                while (reader.Name.Equals(Constants.XmlTag.LoginTime, StringComparison.OrdinalIgnoreCase))
                {
                    result.Manager.LastLogins.Add(reader.ReadElementContentAsString());
                }

                // Skips LastLogins closing tag.
                reader.Read();
            }

            if (reader.Name.Equals(Constants.XmlTag.Language, StringComparison.OrdinalIgnoreCase))
            {
                // Skips Language opening tag.
                reader.Read();

                result.Manager.Language = new BusinessObjects.Hattrick.ManagerCompendium.Language();

                result.Manager.Language.LanguageId = uint.Parse(reader.ReadElementContentAsString());
                result.Manager.Language.LanguageName = reader.ReadElementContentAsString();

                // Skips Language opening tag.
                reader.Read();
            }

            if (reader.Name.Equals(Constants.XmlTag.Country, StringComparison.OrdinalIgnoreCase))
            {
                // Skips Country opening tag.
                reader.Read();

                result.Manager.Country = new BusinessObjects.Hattrick.ManagerCompendium.Country();

                result.Manager.Country.CountryId = uint.Parse(reader.ReadElementContentAsString());
                result.Manager.Country.CountryName = reader.ReadElementContentAsString();

                // Skips Country opening tag.
                reader.Read();
            }

            if (reader.Name.Equals(Constants.XmlTag.Teams, StringComparison.OrdinalIgnoreCase))
            {
                // Skips Teams opening tag.
                reader.Read();

                result.Manager.Teams = new List<BusinessObjects.Hattrick.ManagerCompendium.Team>();

                while (reader.Name.Equals(Constants.XmlTag.Team, StringComparison.OrdinalIgnoreCase))
                {
                    // Skips Team opening node.
                    reader.Read();

                    var newTeam = new BusinessObjects.Hattrick.ManagerCompendium.Team();

                    newTeam.TeamId = uint.Parse(reader.ReadElementContentAsString());
                    newTeam.TeamName = reader.ReadElementContentAsString();

                    if (reader.Name.Equals(Constants.XmlTag.Arena, StringComparison.OrdinalIgnoreCase))
                    {
                        // Skips Arena opening node.
                        reader.Read();

                        newTeam.Arena = new BusinessObjects.Hattrick.ManagerCompendium.Arena();

                        newTeam.Arena.ArenaId = uint.Parse(reader.ReadElementContentAsString());
                        newTeam.Arena.ArenaName = reader.ReadElementContentAsString();

                        // Skips Arena closing node.
                        reader.Read();
                    }

                    if (reader.Name.Equals(Constants.XmlTag.League, StringComparison.OrdinalIgnoreCase))
                    {
                        // Skips League opening node.
                        reader.Read();

                        newTeam.League = new BusinessObjects.Hattrick.ManagerCompendium.League();

                        newTeam.League.LeagueId = uint.Parse(reader.ReadElementContentAsString());
                        newTeam.League.LeagueName = reader.ReadElementContentAsString();

                        // Skips League closing node.
                        reader.Read();
                    }

                    if (reader.Name.Equals(Constants.XmlTag.LeagueLevelUnit, StringComparison.OrdinalIgnoreCase))
                    {
                        // Skips LeagueLevelUnit opening node.
                        reader.Read();

                        newTeam.LeagueLevelUnit = new BusinessObjects.Hattrick.ManagerCompendium.LeagueLevelUnit();

                        newTeam.LeagueLevelUnit.LeagueLevelUnitId = uint.Parse(reader.ReadElementContentAsString());
                        newTeam.LeagueLevelUnit.LeagueLevelUnitName = reader.ReadElementContentAsString();

                        // Skips LeagueLevelUnit closing node.
                        reader.Read();
                    }

                    if (reader.Name.Equals(Constants.XmlTag.Region, StringComparison.OrdinalIgnoreCase))
                    {
                        // Skips Region opening node.
                        reader.Read();

                        newTeam.Region = new BusinessObjects.Hattrick.ManagerCompendium.Region();

                        newTeam.Region.RegionId = uint.Parse(reader.ReadElementContentAsString());
                        newTeam.Region.RegionName = reader.ReadElementContentAsString();

                        // Skips Region closing node.
                        reader.Read();
                    }

                    if (reader.Name.Equals(Constants.XmlTag.YouthTeam, StringComparison.OrdinalIgnoreCase) &&
                        !reader.IsEmptyElement)
                    {
                        // Skips YouthTeam opening node.
                        reader.Read();

                        newTeam.YouthTeam = new BusinessObjects.Hattrick.ManagerCompendium.YouthTeam();

                        newTeam.YouthTeam.YouthTeamId = uint.Parse(reader.ReadElementContentAsString());
                        newTeam.YouthTeam.YouthTeamName = reader.ReadElementContentAsString();

                        if (reader.Name.Equals(Constants.XmlTag.YouthLeague, StringComparison.OrdinalIgnoreCase) &&
                            !reader.IsEmptyElement)
                        {
                            // Skips YouthLeague opening node.
                            reader.Read();

                            newTeam.YouthTeam.YouthLeague = new BusinessObjects.Hattrick.ManagerCompendium.YouthLeague();

                            newTeam.YouthTeam.YouthLeague.YouthLeagueId = uint.Parse(reader.ReadElementContentAsString());
                            newTeam.YouthTeam.YouthLeague.YouthLeagueName = reader.ReadElementContentAsString();
                        }

                        // Skips YouthLeague closing node.
                        reader.Read();
                    }

                    // Skips YouthTeam closing node.
                    reader.Read();

                    result.Manager.Teams.Add(newTeam);

                    // Skips Team closing node.
                    reader.Read();
                }
            }

            // Skips Teams opening tag.
            reader.Read();

            if (reader.Name.Equals(Constants.XmlTag.NationalTeamCoach, StringComparison.OrdinalIgnoreCase) &&
                !reader.IsEmptyElement)
            {
                // Skips NationalTeamCoach opening tag.
                reader.Read();

                result.Manager.NationalTeamCoach = new List<BusinessObjects.Hattrick.ManagerCompendium.NationalTeam>();

                while (reader.Name.Equals(Constants.XmlTag.NationalTeam, StringComparison.OrdinalIgnoreCase))
                {
                    // Skips NationalTeam opening node.
                    reader.Read();

                    var newNationalTeam = new BusinessObjects.Hattrick.ManagerCompendium.NationalTeam();

                    newNationalTeam = new BusinessObjects.Hattrick.ManagerCompendium.NationalTeam();

                    newNationalTeam.NationalTeamId = uint.Parse(reader.ReadElementContentAsString());
                    newNationalTeam.NationalTeamName = reader.ReadElementContentAsString();

                    result.Manager.NationalTeamCoach.Add(newNationalTeam);

                    // Skips NationalTeam closing node.
                    reader.Read();
                }
            }

            // Skips NationalTeamCoach closing tag.
            reader.Read();

            if (reader.Name.Equals(Constants.XmlTag.Avatar, StringComparison.OrdinalIgnoreCase))
            {
                // Skips Avatar opening tag.
                reader.Read();

                result.Manager.Avatar = new BusinessObjects.Hattrick.ManagerCompendium.Avatar();

                result.Manager.Avatar.BackgroundImage = reader.ReadElementContentAsString();

                result.Manager.Avatar.Layers = new List<BusinessObjects.Hattrick.ManagerCompendium.Layer>();

                while (reader.Name.Equals(Constants.XmlTag.Layer, StringComparison.OrdinalIgnoreCase))
                {
                    var newLayer = new BusinessObjects.Hattrick.ManagerCompendium.Layer();

                    List<KeyValuePair<string, int>> positionAttributes = new List<KeyValuePair<string, int>>();

                    for (int i = 0; i < reader.AttributeCount; i++)
                    {
                        reader.MoveToNextAttribute();

                        positionAttributes.Add(this.ParseLayerAttributes(reader));
                    }

                    if (positionAttributes.Any(p => p.Key.Equals(Constants.XmlTag.X, StringComparison.OrdinalIgnoreCase)))
                    {
                        newLayer.X = positionAttributes.Single(p => p.Key.Equals(Constants.XmlTag.X, StringComparison.OrdinalIgnoreCase)).Value;
                    }

                    if (positionAttributes.Any(p => p.Key.Equals(Constants.XmlTag.Y, StringComparison.OrdinalIgnoreCase)))
                    {
                        newLayer.Y = positionAttributes.Single(p => p.Key.Equals(Constants.XmlTag.Y, StringComparison.OrdinalIgnoreCase)).Value;
                    }

                    // Skips Layer opening tag.
                    reader.Read();

                    newLayer.Image = reader.ReadElementContentAsString();

                    result.Manager.Avatar.Layers.Add(newLayer);

                    // Skips Layer closing tag.
                    reader.Read();
                }
            }
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        /// Parses the attributes on Layer node within Manager Compendium Hattrick XML file.
        /// </summary>
        /// <param name="reader">XmlReader object.</param>
        /// <returns>
        /// A collection of KeyValuePair objects that contain name and value of each attribute.
        /// </returns>
        private KeyValuePair<string, int> ParseLayerAttributes(XmlReader reader)
        {
            string name = reader.Name;

            int value = 0;

            int.TryParse(reader.Value, out value);

            var result = new KeyValuePair<string, int>(name, value);

            return result;
        }

        #endregion Private Methods
    }
}