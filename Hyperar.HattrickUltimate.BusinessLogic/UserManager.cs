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
        /// Junior actions.
        /// </summary>
        private Actions.Junior juniorActions;

        /// <summary>
        /// Senior actions.
        /// </summary>
        private Actions.Senior seniorActions;

        /// <summary>
        /// User repository.
        /// </summary>
        private IRepository<BusinessObjects.App.User> userRepository;

        /// <summary>
        /// World actions.
        /// </summary>
        private Actions.World worldActions;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="UserManager" /> class.
        /// </summary>
        /// <param name="context">Database context.</param>
        /// <param name="userRepository">User repository.</param>
        /// <param name="juniorActions">Junior Actions.</param>
        /// <param name="seniorActions">Senior Actions.</param>
        /// <param name="worldActions">World Actions.</param>
        public UserManager(
                   IDatabaseContext context,
                   IRepository<BusinessObjects.App.User> userRepository,
                   Actions.Junior juniorActions,
                   Actions.Senior seniorActions,
                   Actions.World worldActions)
        {
            this.context = context;
            this.userRepository = userRepository;
            this.juniorActions = juniorActions;
            this.seniorActions = seniorActions;
            this.worldActions = worldActions;

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
            return this.userRepository.Get().SingleOrDefault();
        }

        /// <summary>
        /// Process Manager Compendium XML file.
        /// </summary>
        /// <param name="managerCompendium">Manager Compendium XML file.</param>
        public void ProcessManagerCompendium(BusinessObjects.Hattrick.ManagerCompendium.Root managerCompendium)
        {
            try
            {
                this.context.BeginTransaction();

                var country = this.worldActions.GetCountry(managerCompendium.Manager.Country.CountryId);
                var storedManager = this.worldActions.ProcessManager(managerCompendium.Manager, country.Id);

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

        /// <summary>
        /// Process Team Details XML file.
        /// </summary>
        /// <param name="teamDetails">Team Details XML file.</param>
        public void ProcessTeamDetails(BusinessObjects.Hattrick.TeamDetails.Root teamDetails)
        {
            if (teamDetails == null)
            {
                throw new ArgumentNullException(nameof(teamDetails));
            }

            try
            {
                this.context.BeginTransaction();

                var manager = this.worldActions.GetManager(teamDetails.User.UserId);

                foreach (var curTeam in teamDetails.Teams)
                {
                    var league = this.worldActions.GetLeague(curTeam.League.LeagueId);
                    var country = this.worldActions.GetCountry(curTeam.Country.CountryId);
                    var region = this.worldActions.ProcessRegion(curTeam.Region, country.Id);
                    var seniorSeries = this.seniorActions.ProcessLeagueLevelUnit(curTeam.LeagueLevelUnit, league.Id);
                    var seniorTeam = this.seniorActions.ProcessSeniorTeam(curTeam, manager.Id, region.Id, seniorSeries.Id);
                    var seniorArena = this.seniorActions.ProcessSeniorArena(curTeam.Arena, seniorTeam.Id);

                    this.juniorActions.ProcessYouthTeam(curTeam.YouthTeamId, curTeam.YouthTeamName, seniorTeam.Id);
                }
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