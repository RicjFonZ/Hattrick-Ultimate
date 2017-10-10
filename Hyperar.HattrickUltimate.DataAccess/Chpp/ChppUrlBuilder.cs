// -----------------------------------------------------------------------
// <copyright file="ChppUrlBuilder.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
// -----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.DataAccess.Chpp
{
    using System;
    using System.Collections.Generic;
    using BusinessObjects.Hattrick.Enums;
    using Interface;

    /// <summary>
    /// CHPP URL builder.
    /// </summary>
    internal class ChppUrlBuilder
    {
        #region Private Fields

        /// <summary>
        /// URL building strategy collection.
        /// </summary>
        private Dictionary<XmlFile, IProtectedResourceUrlBuildStrategy> strategies;

        /// <summary>
        /// URL building strategy factory.
        /// </summary>
        private Factory.ProtectedResourceUrlBuildFactory urlBuilderFactory;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ChppUrlBuilder" /> class.
        /// </summary>
        internal ChppUrlBuilder()
        {
            this.urlBuilderFactory = new Factory.ProtectedResourceUrlBuildFactory();
            this.strategies = new Dictionary<XmlFile, IProtectedResourceUrlBuildStrategy>();
        }

        #endregion Internal Constructors

        #region Internal Methods

        /// <summary>
        /// Gets the URL for the specified parameters.
        /// </summary>
        /// <param name="file">Xml file to fetch.</param>
        /// <param name="parameters">Query string parameters.</param>
        /// <returns>OAuth url.</returns>
        internal string GetUrlFor(XmlFile file, params KeyValuePair<string, string>[] parameters)
        {
            var fixedParameters = this.GetBaseParameters(file);

            if (parameters == null)
            {
                parameters = new KeyValuePair<string, string>[] { };
            }

            int originalParameterLength = parameters.Length;

            Array.Resize(ref parameters, parameters.Length + fixedParameters.Length);
            Array.Copy(fixedParameters, 0, parameters, originalParameterLength, fixedParameters.Length);

            if (!this.strategies.ContainsKey(file))
            {
                this.strategies.Add(file, this.urlBuilderFactory.GetFor(file));
            }

            return this.strategies[file].GetUrl(Constants.Url.ProtectedResources, parameters);
        }

        #endregion Internal Methods

        #region Private Methods

        /// <summary>
        /// Gets the basic parameters for the URL.
        /// </summary>
        /// <param name="file">Xml file to fetch.</param>
        /// <returns>Basic parameters.</returns>
        private KeyValuePair<string, string>[] GetBaseParameters(XmlFile file)
        {
            switch (file)
            {
                case XmlFile.ManagerCompendium:
                    return new KeyValuePair<string, string>[]
                    {
                        new KeyValuePair<string, string>(Constants.QueryStringParameterName.File, Constants.QueryStringParameterValue.File.ManagerCompendium),
                        new KeyValuePair<string, string>(Constants.QueryStringParameterName.Version, Constants.QueryStringParameterValue.Version.ManagerCompendium)
                    };

                case XmlFile.TeamDetails:
                    return new KeyValuePair<string, string>[]
                    {
                        new KeyValuePair<string, string>(Constants.QueryStringParameterName.File, Constants.QueryStringParameterValue.File.TeamDetails),
                        new KeyValuePair<string, string>(Constants.QueryStringParameterName.Version, Constants.QueryStringParameterValue.Version.TeamDetails)
                    };

                case XmlFile.WorldDetails:
                    return new KeyValuePair<string, string>[]
                    {
                        new KeyValuePair<string, string>(Constants.QueryStringParameterName.File, Constants.QueryStringParameterValue.File.WorldDetails),
                        new KeyValuePair<string, string>(Constants.QueryStringParameterName.Version, Constants.QueryStringParameterValue.Version.WorldDetails)
                    };

                default:
                    throw new NotImplementedException(Localization.Strings.Message_UnknownParametersForFile);
            }
        }

        #endregion Private Methods
    }
}