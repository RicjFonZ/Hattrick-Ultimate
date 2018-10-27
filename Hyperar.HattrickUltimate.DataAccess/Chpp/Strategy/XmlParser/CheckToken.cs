//-----------------------------------------------------------------------
// <copyright file="CheckToken.cs" company="Hyperar">
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
    /// Check Token XML file parser strategy.
    /// </summary>
    internal class CheckToken : IXmlParserStrategy
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

            var result = (BusinessObjects.Hattrick.CheckToken.Root)entity;

            result.Token = reader.ReadElementContentAsString();
            result.Created = DateTime.Parse(reader.ReadElementContentAsString());
            result.User = long.Parse(reader.ReadElementContentAsString());
            result.Expires = DateTime.Parse(reader.ReadElementContentAsString());
            result.ExtendedPermissions = new List<string>(
                                            reader.ReadElementContentAsString()
                                                  .Split(
                                                       new char[] { Constants.Generic.Comma[0] },
                                                       StringSplitOptions.RemoveEmptyEntries)
                                                  .Where(p => !string.IsNullOrWhiteSpace(p)));
        }

        #endregion Public Methods
    }
}