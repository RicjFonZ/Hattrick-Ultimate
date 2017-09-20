//-----------------------------------------------------------------------
// <copyright file="IEntityFactory.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.DataAccess.Chpp.Interface
{
    using BusinessObjects.Hattrick.Interface;

    /// <summary>
    /// Hattrick Entity factory definition.
    /// </summary>
    internal interface IEntityFactory
    {
        #region Public Methods

        /// <summary>
        /// Gets the corresponding Hattrick entity for the specified file name.
        /// </summary>
        /// <param name="fileName">Hattrick XML file name (from the FileName tag).</param>
        /// <returns>IHattrickEntity object.</returns>
        IXmlEntity GetEntity(string fileName);

        #endregion Public Methods
    }
}