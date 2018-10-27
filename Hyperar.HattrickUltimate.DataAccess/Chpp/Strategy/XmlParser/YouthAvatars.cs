//-----------------------------------------------------------------------
// <copyright file="YouthAvatars.cs" company="Hyperar">
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
    /// YouthAvatars XML file parser strategy.
    /// </summary>
    internal class YouthAvatars : IXmlParserStrategy
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

            var result = (BusinessObjects.Hattrick.YouthAvatars.Root)entity;

            result.YouthTeam = this.ParseYouthTeamNode(reader);
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        /// Parses Avatar node.
        /// </summary>
        /// <param name="reader">XmlReader object loaded with the Xml file.</param>
        /// <returns>BusinessObjects.Hattrick.YouthAvatars.Avatar with the parsed data.</returns>
        private BusinessObjects.Hattrick.YouthAvatars.Avatar ParseAvatarNode(XmlReader reader)
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

            var newAvatar = new BusinessObjects.Hattrick.YouthAvatars.Avatar();

            newAvatar.BackgroundImage = reader.ReadElementContentAsString();

            newAvatar.Layers = new List<BusinessObjects.Hattrick.YouthAvatars.Layer>();

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
        /// <returns>BusinessObjects.Hattrick.YouthAvatars.Layer with the parsed data.</returns>
        private BusinessObjects.Hattrick.YouthAvatars.Layer ParseLayerNode(XmlReader reader)
        {
            if (!reader.Name.Equals(XmlTag.Layer, StringComparison.OrdinalIgnoreCase))
            {
                throw new Exception(
                              string.Format(
                                         Localization.Messages.UnexpectedXmlElement,
                                         reader.Name));
            }

            var newLayer = new BusinessObjects.Hattrick.YouthAvatars.Layer();

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
        /// Parses YouthPlayer node.
        /// </summary>
        /// <param name="reader">XmlReader object loaded with the Xml file.</param>
        /// <returns>BusinessObjects.Hattrick.YouthAvatars.YouthPlayer with the parsed data.</returns>
        private BusinessObjects.Hattrick.YouthAvatars.YouthPlayer ParseYouthPlayerNode(XmlReader reader)
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

            var newYouthPlayer = new BusinessObjects.Hattrick.YouthAvatars.YouthPlayer();

            newYouthPlayer.YouthPlayerId = long.Parse(reader.ReadElementContentAsString());
            newYouthPlayer.Avatar = this.ParseAvatarNode(reader);

            // Skips YouthPlayer closing node.
            reader.Read();

            return newYouthPlayer;
        }

        /// <summary>
        /// Parses YouthTeam node.
        /// </summary>
        /// <param name="reader">XmlReader object loaded with the Xml file.</param>
        /// <returns>BusinessObjects.Hattrick.YouthAvatars.YouthTeam with the parsed data.</returns>
        private BusinessObjects.Hattrick.YouthAvatars.YouthTeam ParseYouthTeamNode(XmlReader reader)
        {
            if (!reader.Name.Equals(XmlTag.YouthTeam, StringComparison.OrdinalIgnoreCase))
            {
                throw new Exception(
                              string.Format(
                                         Localization.Messages.UnexpectedXmlElement,
                                         reader.Name));
            }

            var newYouthTeam = new BusinessObjects.Hattrick.YouthAvatars.YouthTeam();

            // Skips YouthTeam opening node.
            reader.Read();

            newYouthTeam.YouthTeamId = long.Parse(reader.ReadElementContentAsString());

            newYouthTeam.YouthPlayers = new List<BusinessObjects.Hattrick.YouthAvatars.YouthPlayer>();

            // Skips YouthPlayers opening node.
            reader.Read();

            while (reader.Name.Equals(XmlTag.YouthPlayer, StringComparison.OrdinalIgnoreCase))
            {
                newYouthTeam.YouthPlayers.Add(
                                              this.ParseYouthPlayerNode(reader));
            }

            // Skips YouthPlayers closing node.
            reader.Read();

            // Skips YouthTeam closing node.
            reader.Read();

            return newYouthTeam;
        }

        #endregion Private Methods
    }
}