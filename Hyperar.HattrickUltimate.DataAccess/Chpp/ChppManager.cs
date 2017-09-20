// -----------------------------------------------------------------------
// <copyright file="ChppManager.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
// -----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.DataAccess.Chpp
{
    using System;
    using System.IO;
    using System.Net;
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
        /// Hattrick XML file parser.
        /// </summary>
        private XmlParserBase baseParser;

        /// <summary>
        /// OAuth request token.
        /// </summary>
        private IToken requestToken;

        /// <summary>
        /// OAuth Session.
        /// </summary>
        private OAuthSession session;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ChppManager"/> class.
        /// </summary>
        public ChppManager()
        {
            this.session = new OAuthSession(
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

            this.baseParser = new XmlParserBase();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ChppManager"/> class.
        /// </summary>
        /// <param name="token">OAuth access token.</param>
        public ChppManager(BusinessObjects.App.Token token) : this()
        {
            this.session.AccessToken = new TokenBase
            {
                Token = token.Key,
                TokenSecret = token.Secret
            };
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// Checks the current Access Token and returns the response content in a string object.
        /// </summary>
        /// <returns>Response content.</returns>
        public IXmlEntity CheckToken()
        {
            return this.baseParser.Parse(this.GetResponseContentForUrl(Constants.Url.CheckToken));
        }

        /// <summary>
        /// Gets OAuth Access Token with the Request Token and the Verification Code.
        /// </summary>
        /// <param name="verificationCode">Verification Code.</param>
        /// <param name="token">OAuth token.</param>
        public void GetAccessToken(string verificationCode, ref BusinessObjects.App.Token token)
        {
            if (string.IsNullOrWhiteSpace(verificationCode))
            {
                throw new ArgumentNullException(nameof(verificationCode));
            }

            this.session.AccessToken = this.session.ExchangeRequestTokenForAccessToken(
                                                       this.requestToken,
                                                       WebRequestMethods.Http.Get,
                                                       verificationCode);

            token.Key = this.session.AccessToken.Token;
            token.Secret = this.session.AccessToken.TokenSecret;
        }

        /// <summary>
        /// Gets a request token and the authorization URL.
        /// </summary>
        /// <returns>Request token and Authorization URL.</returns>
        public string GetAuthorizationUrl()
        {
            this.requestToken = this.session.GetRequestToken(WebRequestMethods.Http.Get);

            return this.session.GetUserAuthorizationUrlForToken(this.requestToken);
        }

        /// <summary>
        /// Revokes the current Access Token and returns the response content in a string object.
        /// </summary>
        /// <returns>Response content.</returns>
        public string RevokeToken()
        {
            return this.ReadResponseStream(
                           this.GetResponseContentForUrl(
                                   Constants.Url.RevokeToken));
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        /// Makes an OAuth request to the specified URL and returns the response in a string object.
        /// </summary>
        /// <param name="url">URL to make the request to.</param>
        /// <returns>Response content.</returns>
        private Stream GetResponseContentForUrl(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
            {
                throw new ArgumentNullException(nameof(url));
            }

            return this.session.Request()
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