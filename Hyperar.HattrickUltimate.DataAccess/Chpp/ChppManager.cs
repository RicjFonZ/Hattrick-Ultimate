// -----------------------------------------------------------------------
// <copyright file="ChppManager.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
// -----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.DataAccess.Chpp
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using BusinessObjects.Hattrick.Enums;
    using BusinessObjects.Hattrick.Interface;
    using DevDefined.OAuth.Consumer;
    using DevDefined.OAuth.Framework;

    /// <summary>
    /// Provides functionality to interact with Hattrick.
    /// </summary>
    public class ChppManager
    {
        #region Private Fields

        /// <summary>
        /// Hattrick OAuth URL builder.
        /// </summary>
        private readonly ChppUrlBuilder chppUrlBuilder;

        /// <summary>
        /// Hattrick XML file parser.
        /// </summary>
        private readonly ChppXmlParser chppXmlParser;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ChppManager"/> class.
        /// </summary>
        public ChppManager()
        {
            // Force TLS 1.2 to avoid authentcation exception.
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
            ServicePointManager.DefaultConnectionLimit = 9999;

            this.chppXmlParser = new ChppXmlParser();
            this.chppUrlBuilder = new ChppUrlBuilder();
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// Checks the specified Access Token validity.
        /// </summary>
        /// <param name="accessToken">Access token.</param>
        /// <returns>An IXmlEntity objects with the Hattrick response.</returns>
        public IXmlEntity CheckToken(BusinessObjects.App.Token accessToken)
        {
            if (accessToken == null ||
                string.IsNullOrWhiteSpace(accessToken.Key) ||
                string.IsNullOrWhiteSpace(accessToken.Key))
            {
                throw new ArgumentNullException(nameof(accessToken));
            }

            var session = this.CreateOAuthSession(accessToken);

            return this.chppXmlParser.Parse(
                                          this.GetResponseContentForUrl(
                                                   Constants.Url.CheckToken,
                                                   session));
        }

        /// <summary>
        /// Downloads Resource file.
        /// </summary>
        /// <param name="url">Resource's URL.</param>
        /// <returns>File content bytes.</returns>
        public byte[] DownloadResourceFile(string url)
        {
            byte[] result = null;

            using (WebClient webClient = new WebClient())
            {
                result = webClient.DownloadData(url);
            }

            return result;
        }

        /// <summary>
        /// Gets the Access Token from Hattrick.
        /// </summary>
        /// <param name="request">Request token and verification code.</param>
        /// <returns>Access Token.</returns>
        public BusinessObjects.App.Token GetAccessToken(BusinessObjects.OAuth.GetAccessTokenRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            if (string.IsNullOrWhiteSpace(request.VerificationCode))
            {
                throw new ArgumentNullException(nameof(request.VerificationCode));
            }

            if (string.IsNullOrWhiteSpace(request.Token))
            {
                throw new ArgumentNullException(nameof(request.Token));
            }

            if (string.IsNullOrWhiteSpace(request.TokenSecret))
            {
                throw new ArgumentNullException(nameof(request.TokenSecret));
            }

            var session = this.CreateOAuthSession();

            var requestToken = new TokenBase
            {
                Token = request.Token,
                TokenSecret = request.TokenSecret
            };

            var accessToken = session.ExchangeRequestTokenForAccessToken(
                                          requestToken,
                                          WebRequestMethods.Http.Get,
                                          request.VerificationCode);

            return new BusinessObjects.App.Token
            {
                Key = accessToken.Token,
                Secret = accessToken.TokenSecret,
                CreatedOn = DateTime.Now,
                ExpiresOn = DateTime.MaxValue
            };
        }

        /// <summary>
        /// Gets a request token and the authorization URL.
        /// </summary>
        /// <returns>Request token and Authorization URL.</returns>
        public BusinessObjects.OAuth.GetAuthorizationUrlResponse GetAuthorizationUrl()
        {
            BusinessObjects.OAuth.GetAuthorizationUrlResponse response = null;

            var session = this.CreateOAuthSession();

            var requestToken = session.GetRequestToken(WebRequestMethods.Http.Get);
            string url = session.GetUserAuthorizationUrlForToken(requestToken);

            response = new BusinessObjects.OAuth.GetAuthorizationUrlResponse(
                          url,
                          requestToken.Token,
                          requestToken.TokenSecret);

            return response;
        }

        /// <summary>
        /// Access the specified protected resource file with the specified parameters.
        /// </summary>
        /// <param name="accessToken">Access token.</param>
        /// <param name="file">File to fetch.</param>
        /// <param name="parameters">File fetch parameters.</param>
        /// <returns>IXmlEntity object with the Hattrick response.</returns>
        public IXmlEntity GetProtectedResource(BusinessObjects.App.Token accessToken, XmlFile file, params KeyValuePair<string, string>[] parameters)
        {
            string url = this.chppUrlBuilder.GetUrlFor(file, parameters);
            var session = this.CreateOAuthSession(accessToken);

            return this.chppXmlParser.Parse(
                                          this.GetResponseContentForUrl(url, session));
        }

        /// <summary>
        /// Revokes the specified Access Token.
        /// </summary>
        /// <param name="accessToken">Access token to revoke.</param>
        /// <returns>A string object with the Hattrick response.</returns>
        public string RevokeToken(BusinessObjects.App.Token accessToken)
        {
            var session = this.CreateOAuthSession(accessToken);

            return this.ReadResponseStream(
                            this.GetResponseContentForUrl(
                                     Constants.Url.RevokeToken,
                                     session));
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        /// Creates an unauthorized OAuthSession.
        /// </summary>
        /// <returns>Unauthorized OAuthSession object.</returns>
        private OAuthSession CreateOAuthSession()
        {
            return new OAuthSession(
                       new OAuthConsumerContext
                       {
                           ConsumerKey = Constants.OAuth.Key,
                           ConsumerSecret = Constants.OAuth.Secret,
                           SignatureMethod = SignatureMethod.HmacSha1,
                           UserAgent = AppDomain.CurrentDomain.GetData("AppName").ToString()
                       },
                       Constants.Url.RequestToken,
                       Constants.Url.Authorize,
                       Constants.Url.AccessToken,
                       Constants.Url.Callback);
        }

        /// <summary>
        /// Creates an authorized OAuthSession.
        /// </summary>
        /// <param name="accessToken">Access token.</param>
        /// <returns>Authorized OAuthSession object.</returns>
        private OAuthSession CreateOAuthSession(BusinessObjects.App.Token accessToken)
        {
            var session = this.CreateOAuthSession();

            session.AccessToken = new TokenBase
            {
                Token = accessToken.Key,
                TokenSecret = accessToken.Secret
            };

            return session;
        }

        /// <summary>
        /// Makes an OAuth request to the specified URL and returns the response in a string object.
        /// </summary>
        /// <param name="url">URL to make the request to.</param>
        /// <param name="session">Authorized OAuth session.</param>
        /// <returns>Response content.</returns>
        private Stream GetResponseContentForUrl(string url, OAuthSession session)
        {
            if (string.IsNullOrWhiteSpace(url))
            {
                throw new ArgumentNullException(nameof(url));
            }

            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            if (session.AccessToken == null ||
                string.IsNullOrWhiteSpace(session.AccessToken.Token) ||
                string.IsNullOrWhiteSpace(session.AccessToken.TokenSecret))
            {
                throw new Exception(Localization.Messages.AuthorizedOAuthSessionExpected);
            }

            return session.Request()
                          .ForUrl(url)
                          .ForMethod(WebRequestMethods.Http.Get)
                          .ToWebResponse()
                          .GetResponseStream();
        }

        /// <summary>
        /// Reads a response stream into a string.
        /// </summary>
        /// <param name="stream">Stream to read.</param>
        /// <returns>A string object with the response content.</returns>
        private string ReadResponseStream(Stream stream)
        {
            if (stream == null)
            {
                throw new ArgumentNullException(nameof(stream));
            }

            string result = null;

            using (var reader = new StreamReader(stream))
            {
                result = reader.ReadToEnd();
            }

            return result;
        }

        #endregion Private Methods
    }
}