//-----------------------------------------------------------------------
// <copyright file="YouthTeamDetails.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.DataAccess.Chpp.Strategy.ProtectedResourceUrlBuild
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using Constants;
    using Interface;

    /// <summary>
    /// Manager Compendium URL build strategy.
    /// </summary>
    internal class YouthTeamDetails : IProtectedResourceUrlBuildStrategy
    {
        #region Private Fields

        /// <summary>
        /// Expected parameter names.
        /// </summary>
        private readonly string[] expectedParameterNames;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="YouthTeamDetails" /> class.
        /// </summary>
        public YouthTeamDetails()
        {
            this.expectedParameterNames = new string[]
            {
                QueryStringParameterName.File,
                QueryStringParameterName.Version,
                QueryStringParameterName.YouthTeamId,
                QueryStringParameterName.ShowScouts
            };
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// Builds the URL with the specified base URL and Query String parameters.
        /// </summary>
        /// <param name="baseUrl">Base URL.</param>
        /// <param name="parameters">Query String key and value array.</param>
        /// <returns>Built URL with the specified parameters.</returns>
        public string GetUrl(string baseUrl, params KeyValuePair<string, string>[] parameters)
        {
            if (string.IsNullOrWhiteSpace(baseUrl))
            {
                throw new ArgumentNullException(nameof(baseUrl));
            }

            if (parameters == null || parameters.Length == 0)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            var uriBuilder = new UriBuilder(baseUrl);

            if (!parameters.Any(kvp => kvp.Key.Equals(QueryStringParameterName.File, StringComparison.OrdinalIgnoreCase)))
            {
                throw new Exception(
                          string.Format(
                                     Localization.Messages.RequiredParameterMissing,
                                     QueryStringParameterName.File));
            }

            if (!parameters.Any(kvp => kvp.Key.Equals(QueryStringParameterName.Version, StringComparison.OrdinalIgnoreCase)))
            {
                throw new Exception(
                          string.Format(
                                     Localization.Messages.RequiredParameterMissing,
                                     QueryStringParameterName.Version));
            }

            var query = HttpUtility.ParseQueryString(uriBuilder.Uri.Query);

            foreach (var parameter in parameters)
            {
                if (string.IsNullOrWhiteSpace(parameter.Value))
                {
                    throw new Exception(
                              string.Format(
                                         Localization.Messages.NullValueParameter,
                                         parameter.Key));
                }

                if (this.expectedParameterNames.Any(p => p.Equals(parameter.Key, StringComparison.OrdinalIgnoreCase)))
                {
                    query.Add(parameter.Key, parameter.Value);
                }
                else
                {
                    throw new Exception(
                              string.Format(
                                         Localization.Messages.UnknownParameter,
                                         parameter.Key));
                }
            }

            uriBuilder.Query = query.ToString();

            return uriBuilder.Uri.ToString();
        }

        #endregion Public Methods
    }
}