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
    using DataAccess.Database.Interface;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class TokenManager
    {
        #region Private Fields

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
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// Gets the Access Token stored in the database, if any.
        /// </summary>
        /// <returns>Access Token.</returns>
        public BusinessObjects.App.Token GetToken()
        {
            return this.tokenRepository.Get().SingleOrDefault();
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
    }
}