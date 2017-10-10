//-----------------------------------------------------------------------
// <copyright file="TokenManager.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessLogic
{
    using System;
    using System.Linq;
    using System.Net;
    using DataAccess.Database.Interface;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class TokenManager
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

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TokenManager" /> class.
        /// </summary>
        /// <param name="context">Database context.</param>
        /// <param name="tokenRepository">Token repository.</param>
        public TokenManager(
                   IDatabaseContext context,
                   IRepository<BusinessObjects.App.Token> tokenRepository)
        {
            this.context = context;
            this.tokenRepository = tokenRepository;
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
        /// Gets the Access Token stored in the database, if any.
        /// </summary>
        /// <returns>Access Token.</returns>
        public BusinessObjects.App.Token GetToken()
        {
            return this.tokenRepository.Get().SingleOrDefault();
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

        /// <summary>
        /// Creates an user with an access token.
        /// </summary>
        /// <param name="accessToken">Access token.</param>
        /// <param name="user">User linked to the token.</param>
        public void SetUserToken(BusinessObjects.App.Token accessToken, BusinessObjects.App.User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            if (accessToken == null ||
                string.IsNullOrWhiteSpace(accessToken.Key) ||
                string.IsNullOrWhiteSpace(accessToken.Secret))
            {
                throw new ArgumentNullException(nameof(accessToken));
            }

            try
            {
                this.context.BeginTransaction();

                var existingToken = this.tokenRepository.Get().SingleOrDefault();

                if (existingToken == null)
                {
                    accessToken.User = user;

                    this.tokenRepository.Insert(accessToken);
                }
                else
                {
                    existingToken.CreatedOn = accessToken.CreatedOn;
                    existingToken.ExpiresOn = accessToken.ExpiresOn;
                    existingToken.Key = accessToken.Key;
                    existingToken.Scope = accessToken.Scope;
                    existingToken.Secret = accessToken.Secret;

                    this.tokenRepository.Update(existingToken);
                }

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