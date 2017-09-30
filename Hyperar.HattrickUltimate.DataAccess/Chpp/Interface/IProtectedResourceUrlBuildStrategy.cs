//-----------------------------------------------------------------------
// <copyright file="IProtectedResourceUrlBuildStrategy.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.DataAccess.Chpp.Interface
{
    using System.Collections.Generic;

    /// <summary>
    /// Protected Resource URL Builder strategy definition.
    /// </summary>
    internal interface IProtectedResourceUrlBuildStrategy
    {
        #region Public Methods

        /// <summary>
        /// Builds the URL with the specified base URL and Query String parameters.
        /// </summary>
        /// <param name="baseUrl">Base URL.</param>
        /// <param name="parameters">Query String key and value array.</param>
        /// <returns>Built URL with the specified parameters.</returns>
        string GetUrl(string baseUrl, params KeyValuePair<string, string>[] parameters);

        #endregion Public Methods
    }
}