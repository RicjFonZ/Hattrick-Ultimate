// -----------------------------------------------------------------------
// <copyright file="UserManager.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
// -----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessLogic
{
    using System.Linq;
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
        /// User repository.
        /// </summary>
        private IRepository<BusinessObjects.App.User> userRepository;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="UserManager" /> class.
        /// </summary>
        /// <param name="context">Database context.</param>
        /// <param name="userRepository">User repository.</param>
        public UserManager(
                   IDatabaseContext context,
                   IRepository<BusinessObjects.App.User> userRepository)
        {
            this.context = context;
            this.userRepository = userRepository;

            this.chppManager = new DataAccess.Chpp.ChppManager();
        }

        #endregion Public Constructors

        #region Public Methods

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
            return this.userRepository.Get()
                                      .SingleOrDefault();
        }

        #endregion Public Methods
    }
}