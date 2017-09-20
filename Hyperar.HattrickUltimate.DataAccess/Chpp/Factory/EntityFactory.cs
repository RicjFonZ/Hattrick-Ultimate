//-----------------------------------------------------------------------
// <copyright file="EntityFactory.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.DataAccess.Chpp.Factory
{
    using System;
    using BusinessObjects.Hattrick.Interface;
    using Constants;
    using Interface;

    /// <summary>
    /// Hattrick Entity factory implementation.
    /// </summary>
    internal class EntityFactory : IEntityFactory
    {
        #region Public Methods

        /// <summary>
        /// Gets the corresponding Hattrick entity for the specified file name.
        /// </summary>
        /// <param name="fileName">Hattrick XML file name (from the FileName tag).</param>
        /// <returns>IHattrickEntity object.</returns>
        public IXmlEntity GetEntity(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                throw new ArgumentNullException(nameof(fileName));
            }

            IXmlEntity result = null;

            switch (fileName)
            {
                case XmlFileName.CheckToken:
                    result = new BusinessObjects.Hattrick.CheckToken.Root();
                    break;

                case XmlFileName.ManagerCompendium:
                    result = new BusinessObjects.Hattrick.ManagerCompendium.Root();
                    break;

                case XmlFileName.WorldDetails:
                    result = new BusinessObjects.Hattrick.WorldDetails.Root();
                    break;

                default:
                    throw new NotImplementedException($"No IHattrickEntity class found for file: {fileName}.");
            }

            result.FileName = fileName;

            return result;
        }

        #endregion Public Methods
    }
}