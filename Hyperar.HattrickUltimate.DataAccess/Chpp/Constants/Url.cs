//-----------------------------------------------------------------------
// <copyright file="Url.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.DataAccess.Chpp.Constants
{
    /// <summary>
    /// Web constants.
    /// </summary>
    internal class Url
    {
        #region Internal Fields

        /// <summary>
        /// Access Token URL.
        /// </summary>
        internal const string AccessToken = "https://chpp.hattrick.org/oauth/access_token.ashx";

        /// <summary>
        /// Authenticate URL.
        /// <remarks>Temporary token URL, should be used for testing purposes only.</remarks>
        /// </summary>
        internal const string Authenticate = "https://chpp.hattrick.org/oauth/authenticate.aspx";

        /// <summary>
        /// Authorize URL.
        /// </summary>
        internal const string Authorize = "https://chpp.hattrick.org/oauth/authorize.aspx";

        /// <summary>
        /// Callback URL.
        /// </summary>
        /// <remarks>
        /// As a desktop app, there's no Callback URL, in that situation, "oob" should be send as
        /// Callback URL as specified in Hattrick OAuth documentation.
        /// </remarks>
        internal const string Callback = "oob";

        /// <summary>
        /// Check Token URL.
        /// </summary>
        internal const string CheckToken = "https://chpp.hattrick.org/oauth/check_token.ashx";

        /// <summary>
        /// Protected Resources URL.
        /// </summary>
        internal const string ProtectedResources = "http://chpp.hattrick.org/chppxml.ashx";

        /// <summary>
        /// Request Token URL.
        /// </summary>
        internal const string RequestToken = "https://chpp.hattrick.org/oauth/request_token.ashx";

        /// <summary>
        /// Revoke Token URL.
        /// </summary>
        internal const string RevokeToken = "https://chpp.hattrick.org/oauth/invalidate_token.ashx";

        #endregion Internal Fields
    }
}