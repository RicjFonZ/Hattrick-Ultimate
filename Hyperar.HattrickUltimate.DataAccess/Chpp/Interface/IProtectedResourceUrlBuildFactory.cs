// -----------------------------------------------------------------------
// <copyright file="IProtectedResourceUrlBuildFactory.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
// -----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.DataAccess.Chpp.Interface
{
    using BusinessObjects.Hattrick.Enums;

    /// <summary>
    /// Protected Resource Url Build Factory definition.
    /// </summary>
    internal interface IProtectedResourceUrlBuildFactory
    {
        #region Public Methods

        /// <summary>
        /// Gets the correspondent strategy for the specified XmlFile.
        /// </summary>
        /// <param name="file">File to build the URL for.</param>
        /// <returns>Protected Resource URL build strategy.</returns>
        IProtectedResourceUrlBuildStrategy GetFor(XmlFile file);

        #endregion Public Methods
    }
}