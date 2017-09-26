// -----------------------------------------------------------------------
// <copyright file="GetAccessTokenRequest.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
// -----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessObjects.OAuth
{
    /// <summary>
    /// GetAccessToken request.
    /// </summary>
    public class GetAccessTokenRequest
    {
        #region Private Fields

        /// <summary>
        /// Request token.
        /// </summary>
        private readonly string token;

        /// <summary>
        /// Request token secret.
        /// </summary>
        private readonly string tokenSecret;

        /// <summary>
        /// Verification code.
        /// </summary>
        private readonly string verificationCode;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAccessTokenRequest" /> class.
        /// </summary>
        /// <param name="verificationCode">Verification code</param>
        /// <param name="token">Request token</param>
        /// <param name="tokenSecret">Request token secret</param>
        public GetAccessTokenRequest(string verificationCode, string token, string tokenSecret)
        {
            this.verificationCode = verificationCode;
            this.token = token;
            this.tokenSecret = tokenSecret;
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>
        /// Gets the token.
        /// </summary>
        public string Token
        {
            get
            {
                return this.token;
            }
        }

        /// <summary>
        /// Gets the token secret.
        /// </summary>
        public string TokenSecret
        {
            get
            {
                return this.tokenSecret;
            }
        }

        /// <summary>
        /// Gets the verification code.
        /// </summary>
        public string VerificationCode
        {
            get
            {
                return this.verificationCode;
            }
        }

        #endregion Public Properties
    }
}