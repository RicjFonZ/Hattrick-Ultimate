// -----------------------------------------------------------------------
// <copyright file="UserManager.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
// -----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessLogic
{
    using System.Linq;
    using System.Net;
    using DataAccess.Database.Interface;

    /// <summary>
    /// User objects business processes.
    /// </summary>
    public class UserManager
    {
        #region Private Fields

        /// <summary>
        /// Provides functionality to interact with Hattrick.
        /// </summary>
        private DataAccess.Chpp.ChppManager chppManager;

        /// <summary>
        /// Database context.
        /// </summary>
        private IDatabaseContext context;

        /// <summary>
        /// Token repository.
        /// </summary>
        private IRepository<BusinessObjects.App.Token> tokenRepository;

        /// <summary>
        /// User repository.
        /// </summary>
        private IRepository<BusinessObjects.App.User> userRepository;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="UserManager" /> class.
        /// </summary>
        /// <param name="context">Database context.</param>
        /// <param name="tokenRepository">Token repository.</param>
        /// <param name="userRepository">User repository.</param>
        public UserManager(
            IDatabaseContext context,
            IRepository<BusinessObjects.App.Token> tokenRepository,
            IRepository<BusinessObjects.App.User> userRepository)
        {
            this.context = context;
            this.tokenRepository = tokenRepository;
            this.userRepository = userRepository;

            this.chppManager = new DataAccess.Chpp.ChppManager();
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// Checks the specified Access Token validity.
        /// </summary>
        /// <param name="accessToken">Access token.</param>
        /// <returns>The valid access token with creation and expiration dates.</returns>
        public BusinessObjects.App.Token CheckToken(BusinessObjects.App.Token accessToken)
        {
            try
            {
                var checkTokenResponse = (BusinessObjects.Hattrick.CheckToken.Root)this.chppManager.CheckToken(accessToken);

                accessToken.CreatedOn = checkTokenResponse.Created;
                accessToken.ExpiresOn = checkTokenResponse.Expires;
            }
            catch (WebException ex)
            {
                if (ex.Response is HttpWebResponse && (ex.Response as HttpWebResponse).StatusCode == HttpStatusCode.Unauthorized)
                {
                    this.RemoveToken(accessToken);
                }

                throw;
            }

            return accessToken;
        }

        /// <summary>
        /// Creates the user.
        /// </summary>
        /// <returns>Created user.</returns>
        public BusinessObjects.App.User CreateUser()
        {
            var user = new BusinessObjects.App.User();

            try
            {
                this.context.BeginTransaction();

                this.userRepository.Insert(user);

                this.context.Save();
            }
            catch
            {
                this.context.Cancel();
                throw;
            }
            finally
            {
                this.context.EndTransaction();
            }

            return user;
        }

        /// <summary>
        /// Gets the Access Token from Hattrick.
        /// </summary>
        /// <param name="request">Request token and verification code.</param>
        /// <returns>Access Token.</returns>
        public BusinessObjects.App.Token GetAccessToken(BusinessObjects.OAuth.GetAccessTokenRequest request)
        {
            var token = this.chppManager.GetAccessToken(request);

            return token;
        }

        /// <summary>
        /// Gets a request token and the authorization URL.
        /// </summary>
        /// <returns>Request token and Authorization URL.</returns>
        public BusinessObjects.OAuth.GetAuthorizationUrlResponse GetAuthorizationUrl()
        {
            return this.chppManager.GetAuthorizationUrl();
        }

        /// <summary>
        /// Gets the user.
        /// </summary>
        /// <returns>Stored user.</returns>
        public BusinessObjects.App.User GetUser()
        {
            return this.userRepository.Get().SingleOrDefault();
        }

        /// <summary>
        /// Revokes the Access Token in Hattrick and deletes it from the database.
        /// </summary>
        /// <param name="accessToken">Access Token to revoke.</param>
        public void RevokeToken(BusinessObjects.App.Token accessToken)
        {
            try
            {
                this.chppManager.RevokeToken(accessToken);

                this.RemoveToken(accessToken);
            }
            catch (WebException ex)
            {
                // Already invalid token.
                if (ex.Response is HttpWebResponse && (ex.Response as HttpWebResponse).StatusCode == HttpStatusCode.Unauthorized)
                {
                    this.RemoveToken(accessToken);
                }
                else
                {
                    throw;
                }
            }
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        /// Deletes user access token.
        /// </summary>
        /// <param name="accessToken">Access token to remove.</param>
        private void RemoveToken(BusinessObjects.App.Token accessToken)
        {
            try
            {
                this.context.BeginTransaction();

                this.tokenRepository.Delete(accessToken.Id);

                this.context.Save();

                accessToken = null;
            }
            catch
            {
                this.context.Cancel();

                throw;
            }
            finally
            {
                this.context.EndTransaction();
            }
        }

        #endregion Private Methods
    }
}