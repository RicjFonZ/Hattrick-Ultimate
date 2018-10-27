//-----------------------------------------------------------------------
// <copyright file="Avatars.cs" company="Hyperar">
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
    /// Avatars XML file parser strategy.
    /// </summary>
    internal class Avatars : IXmlParserStrategy
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

            var result = (BusinessObjects.Hattrick.Avatars.Root)entity;

            result.Team = this.ParseTeamNode(reader);
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        /// Parses Avatar node.
        /// </summary>
        /// <param name="reader">XmlReader object loaded with the Xml file.</param>
        /// <returns>BusinessObjects.Hattrick.Avatars.Avatar with the parsed data.</returns>
        private BusinessObjects.Hattrick.Avatars.Avatar ParseAvatarNode(XmlReader reader)
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

            var newAvatar = new BusinessObjects.Hattrick.Avatars.Avatar();

            newAvatar.BackgroundImage = reader.ReadElementContentAsString();

            newAvatar.Layers = new List<BusinessObjects.Hattrick.Avatars.Layer>();

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
        /// Parses Layer node.
        /// </summary>
        /// <param name="reader">XmlReader object loaded with the Xml file.</param>
        /// <returns>BusinessObjects.Hattrick.Avatars.Layer with the parsed data.</returns>
        private BusinessObjects.Hattrick.Avatars.Layer ParseLayerNode(XmlReader reader)
        {
            if (!reader.Name.Equals(XmlTag.Layer, StringComparison.OrdinalIgnoreCase))
            {
                throw new Exception(
                              string.Format(
                                         Localization.Messages.UnexpectedXmlElement,
                                         reader.Name));
            }

            var newLayer = new BusinessObjects.Hattrick.Avatars.Layer();

            var positionAttributes = new List<KeyValuePair<string, int>>();

            if (!string.IsNullOrWhiteSpace(reader.GetAttribute(XmlTag.X.ToLower())))
            {
                newLayer.X = int.Parse(reader.GetAttribute(XmlTag.X.ToLower()));
            }

            if (!string.IsNullOrWhiteSpace(reader.GetAttribute(XmlTag.Y.ToLower())))
            {
                newLayer.Y = int.Parse(reader.GetAttribute(XmlTag.Y.ToLower()));
            }

            // Skips Layer opening tag.
            reader.Read();

            newLayer.Image = reader.ReadElementContentAsString();

            // Skips Layer closing tag.
            reader.Read();

            return newLayer;
        }

        /// <summary>
        /// Parses Player node.
        /// </summary>
        /// <param name="reader">XmlReader object loaded with the Xml file.</param>
        /// <returns>BusinessObjects.Hattrick.Avatars.Player with the parsed data.</returns>
        private BusinessObjects.Hattrick.Avatars.Player ParsePlayerNode(XmlReader reader)
        {
            if (!reader.Name.Equals(XmlTag.Player, StringComparison.OrdinalIgnoreCase))
            {
                throw new Exception(
                              string.Format(
                                         Localization.Messages.UnexpectedXmlElement,
                                         reader.Name));
            }

            // Skips Player opening node.
            reader.Read();

            var newPlayer = new BusinessObjects.Hattrick.Avatars.Player();

            newPlayer.PlayerId = long.Parse(reader.ReadElementContentAsString());
            newPlayer.Avatar = this.ParseAvatarNode(reader);

            // Skips Player closing node.
            reader.Read();

            return newPlayer;
        }

        /// <summary>
        /// Parses Team node.
        /// </summary>
        /// <param name="reader">XmlReader object loaded with the Xml file.</param>
        /// <returns>BusinessObjects.Hattrick.Avatars.Team with the parsed data.</returns>
        private BusinessObjects.Hattrick.Avatars.Team ParseTeamNode(XmlReader reader)
        {
            if (!reader.Name.Equals(XmlTag.Team, StringComparison.OrdinalIgnoreCase))
            {
                throw new Exception(
                              string.Format(
                                         Localization.Messages.UnexpectedXmlElement,
                                         reader.Name));
            }

            var newTeam = new BusinessObjects.Hattrick.Avatars.Team();

            // Skips Team opening node.
            reader.Read();

            newTeam.TeamId = long.Parse(reader.ReadElementContentAsString());

            newTeam.Players = new List<BusinessObjects.Hattrick.Avatars.Player>();

            // Skips Players opening node.
            reader.Read();

            while (reader.Name.Equals(XmlTag.Player, StringComparison.OrdinalIgnoreCase))
            {
                newTeam.Players.Add(
                                    this.ParsePlayerNode(reader));
            }

            // Skips Players closing node.
            reader.Read();

            // Skips Team closing node.
            reader.Read();

            return newTeam;
        }

        #endregion Private Methods
    }
}