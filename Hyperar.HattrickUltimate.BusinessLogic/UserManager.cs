// -----------------------------------------------------------------------
// <copyright file="UserManager.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
// -----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessLogic
{
    using System;
    using System.Linq;
    using System.Web;
    using BusinessObjects.App.Enums;
    using DataAccess.Database.Interface;
    using ExtensionMethods;

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

            var user = this.userRepository.Get().SingleOrDefault();

            if (user.Token == null)
            {
                this.chppManager = new DataAccess.Chpp.ChppManager();
            }
            else
            {
                this.chppManager = new DataAccess.Chpp.ChppManager(user.Token);
            }
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// Checks the current token.
        /// </summary>
        /// <returns>CheckToken.Root object.</returns>
        public BusinessObjects.App.Token CheckToken()
        {
            BusinessObjects.App.Token result = null;

            try
            {
                var checkTokenResponse = (BusinessObjects.Hattrick.CheckToken.Root)this.chppManager.CheckToken();

                result = new BusinessObjects.App.Token
                {
                    Key = checkTokenResponse.Token,
                };
            }
            catch
            {
                throw;
            }

            return result;
        }

        /// <summary>
        /// Deletes the specified token.
        /// </summary>
        /// <param name="token">Token to delete.</param>
        public void DeleteToken(BusinessObjects.App.Token token)
        {
            this.tokenRepository.Delete(token.Id);

            this.context.Save();
        }

        /// <summary>
        /// Gets OAuth Access Token with the Request Token and the Verification Code.
        /// </summary>
        /// <param name="verificationCode">Verification Code.</param>
        /// <param name="token">OAuth token.</param>
        public void GetAccessToken(string verificationCode, ref BusinessObjects.App.Token token)
        {
            this.chppManager.GetAccessToken(verificationCode, ref token);
        }

        /// <summary>
        /// Gets a request token and the authorization URL.
        /// </summary>
        /// <param name="scope">OAuth scope.</param>
        /// <returns>Request token and Authorization URL.</returns>
        public string GetAuthorizationUrl(OAuthScope scope)
        {
            string url = this.chppManager.GetAuthorizationUrl();

            var uriBuilder = new UriBuilder(url);

            var query = HttpUtility.ParseQueryString(uriBuilder.Query);

            query.Add(Constants.OAuthScope.QueryStringParameter, scope.GetQueryStringValue());

            uriBuilder.Query = query.ToString();

            return uriBuilder.ToString();
        }

        /// <summary>
        /// Gets the application User.
        /// </summary>
        /// <returns>The application user.</returns>
        public BusinessObjects.App.User GetUser()
        {
            var user = this.userRepository.Get().SingleOrDefault();

            if (user == null)
            {
                user = new BusinessObjects.App.User();

                this.CreateUser(user);
            }

            return user;
        }

        /// <summary>
        /// Revokes the current token.
        /// </summary>
        /// <param name="token">OAuth token.</param>
        /// <returns>A value indicating whether the operation was successful or not.</returns>
        public bool RevokeToken(BusinessObjects.App.Token token)
        {
            string expectedMessage = $"Invalidated token {token.Key}";

            var response = this.chppManager.RevokeToken();

            var result = expectedMessage.Equals(response, StringComparison.OrdinalIgnoreCase);

            if (result)
            {
                this.DeleteToken(token);
            }

            return result;
        }

        /// <summary>
        /// Sets the User token.
        /// </summary>
        /// <param name="newToken">OAuth token.</param>
        public void SetUserToken(BusinessObjects.App.Token newToken)
        {
            var token = this.tokenRepository.Get()
                                            .SingleOrDefault();

            if (token == null)
            {
                this.CreateToken(newToken);
            }
            else
            {
                this.UpdateToken(newToken);
            }
        }

        /// <summary>
        /// Toggles the specified scope on the given token.
        /// </summary>
        /// <param name="token">OAuth token.</param>
        /// <param name="toggleScope">Scope name.</param>
        public void ToggleScope(ref BusinessObjects.App.Token token, string toggleScope)
        {
            OAuthScope selectedScope = OAuthScope.None;

            switch (toggleScope)
            {
                case Constants.OAuthScope.ManagerChallenges:
                    selectedScope = OAuthScope.ManageChallenges;
                    break;

                case Constants.OAuthScope.ManageYouthPlayers:
                    selectedScope = OAuthScope.ManageYouthPlayers;
                    break;

                case Constants.OAuthScope.PlaceBid:
                    selectedScope = OAuthScope.PlaceBid;
                    break;

                case Constants.OAuthScope.SetMatchOrders:
                    selectedScope = OAuthScope.SetMatchOrders;
                    break;

                case Constants.OAuthScope.SetTraining:
                    selectedScope = OAuthScope.SetTraining;
                    break;
            }

            if (token.Scope.HasFlag(selectedScope))
            {
                token.Scope &= ~selectedScope;
            }
            else
            {
                token.Scope |= selectedScope;
            }
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        /// Creates a new token.
        /// </summary>
        /// <param name="newToken">OAuth token.</param>
        private void CreateToken(BusinessObjects.App.Token newToken)
        {
            try
            {
                this.context.BeginTransaction();

                newToken.User = this.GetUser();

                this.tokenRepository.Insert(newToken);
            }
            catch
            {
                this.context.Cancel();
            }
            finally
            {
                this.context.EndTransaction();
            }
        }

        /// <summary>
        /// Creates a new User.
        /// </summary>
        /// <param name="user">Application user.</param>
        private void CreateUser(BusinessObjects.App.User user)
        {
            try
            {
                this.context.BeginTransaction();

                this.userRepository.Insert(user);
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

        /// <summary>
        /// Updates an existing token.
        /// </summary>
        /// <param name="token">OAuth token.</param>
        private void UpdateToken(BusinessObjects.App.Token token)
        {
            try
            {
                this.context.BeginTransaction();

                this.tokenRepository.Update(token);
            }
            catch
            {
                this.context.Cancel();
            }
            finally
            {
                this.context.EndTransaction();
            }
        }

        #endregion Private Methods
    }
}