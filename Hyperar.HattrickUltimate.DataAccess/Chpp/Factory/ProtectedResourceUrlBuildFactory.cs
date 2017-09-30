﻿// -----------------------------------------------------------------------
// <copyright file="ProtectedResourceUrlBuildFactory.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
// -----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.DataAccess.Chpp.Factory
{
    using System;
    using BusinessObjects.Hattrick.Enums;
    using Interface;

    /// <summary>
    /// Protected Resource Url Build factory implementation.
    /// </summary>
    internal class ProtectedResourceUrlBuildFactory : IProtectedResourceUrlBuildFactory
    {
        #region Public Methods

        /// <summary>
        /// Gets the correspondent strategy for the specified XmlFile.
        /// </summary>
        /// <param name="file">File to build the URL for.</param>
        /// <returns>Protected Resource URL build strategy.</returns>
        public IProtectedResourceUrlBuildStrategy GetFor(XmlFile file)
        {
            switch (file)
            {
                case XmlFile.ManagerCompendium:
                    return new Strategy.ProtectedResourceUrlBuild.ManagerCompendium();

                case XmlFile.WorldDetails:
                    return new Strategy.ProtectedResourceUrlBuild.WorldDetails();

                default:
                    throw new NotImplementedException(
                              string.Format(
                                         Localization.Strings.Message_NotImplemented,
                                         "IProtectedResourceUrlBuildStrategy",
                                         file.ToString()));
            }
        }

        #endregion Public Methods
    }
}