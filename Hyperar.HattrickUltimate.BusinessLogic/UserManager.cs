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
        /// Country repository.
        /// </summary>
        private IRepository<BusinessObjects.App.Country> countryRepository;

        /// <summary>
        /// JuniorSeries repository.
        /// </summary>
        private IRepository<BusinessObjects.App.JuniorSeries> juniorSeriesRepository;

        /// <summary>
        /// JuniorTeam repository.
        /// </summary>
        private IRepository<BusinessObjects.App.JuniorTeam> juniorTeamRepository;

        /// <summary>
        /// League repository.
        /// </summary>
        private IRepository<BusinessObjects.App.League> leagueRepository;

        /// <summary>
        /// Manager repository.
        /// </summary>
        private IRepository<BusinessObjects.App.Manager> managerRepository;

        /// <summary>
        /// Region repository.
        /// </summary>
        private IRepository<BusinessObjects.App.Region> regionRepository;

        /// <summary>
        /// SeniorArena repository.
        /// </summary>
        private IRepository<BusinessObjects.App.SeniorArena> seniorArenaRepository;

        /// <summary>
        /// SeniorSeries repository.
        /// </summary>
        private IRepository<BusinessObjects.App.SeniorSeries> seniorSeriesRepository;

        /// <summary>
        /// SeniorTeam repository.
        /// </summary>
        private IRepository<BusinessObjects.App.SeniorTeam> seniorTeamRepository;

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
        /// <param name="countryRepository">Country repository.</param>
        /// <param name="juniorSeriesRepository">JuniorSeries repository.</param>
        /// <param name="juniorTeamRepository">JuniorTeam repository.</param>
        /// <param name="leagueRepository">League repository.</param>
        /// <param name="managerRepository">Manager repository.</param>
        /// <param name="regionRepository">Region repository.</param>
        /// <param name="seniorArenaRepository">SeniorArena repository.</param>
        /// <param name="seniorSeriesRepository">SeniorSeries repository.</param>
        /// <param name="seniorTeamRepository">SeniorTeam repository.</param>
        /// <param name="userRepository">User repository.</param>
        public UserManager(
                   IDatabaseContext context,
                   IRepository<BusinessObjects.App.Country> countryRepository,
                   IRepository<BusinessObjects.App.JuniorSeries> juniorSeriesRepository,
                   IRepository<BusinessObjects.App.JuniorTeam> juniorTeamRepository,
                   IRepository<BusinessObjects.App.League> leagueRepository,
                   IRepository<BusinessObjects.App.Manager> managerRepository,
                   IRepository<BusinessObjects.App.Region> regionRepository,
                   IRepository<BusinessObjects.App.SeniorArena> seniorArenaRepository,
                   IRepository<BusinessObjects.App.SeniorSeries> seniorSeriesRepository,
                   IRepository<BusinessObjects.App.SeniorTeam> seniorTeamRepository,
                   IRepository<BusinessObjects.App.User> userRepository)
        {
            this.context = context;
            this.countryRepository = countryRepository;
            this.juniorSeriesRepository = juniorSeriesRepository;
            this.juniorTeamRepository = juniorTeamRepository;
            this.leagueRepository = leagueRepository;
            this.managerRepository = managerRepository;
            this.regionRepository = regionRepository;
            this.seniorArenaRepository = seniorArenaRepository;
            this.seniorSeriesRepository = seniorSeriesRepository;
            this.seniorTeamRepository = seniorTeamRepository;
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

                var storedManager = this.managerRepository.Get(m => m.HattrickId == managerCompendium.Manager.UserId)
                                                          .SingleOrDefault();

                if (storedManager == null)
                {
                    var country = this.countryRepository.Get(c => c.HattrickId == managerCompendium.Manager.Country.CountryId)
                                                        .SingleOrDefault();

                    var user = this.userRepository.Get().SingleOrDefault();

                    storedManager = new BusinessObjects.App.Manager
                    {
                        Country = country,
                        HattrickId = managerCompendium.Manager.UserId,
                        SupporterTier = managerCompendium.Manager.SupporterTier.GetEnum(),
                        User = user,
                        UserName = managerCompendium.Manager.LoginName,
                    };

                    this.managerRepository.Insert(storedManager);
                }
                else
                {
                    storedManager.UserName = managerCompendium.Manager.LoginName;

                    this.managerRepository.Update(storedManager);
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

                var storedManager = this.managerRepository.Get(m => m.HattrickId == teamDetails.User.UserId)
                                                          .Single();

                foreach (var curTeam in teamDetails.Teams)
                {
                    var storedSeniorSeries = this.seniorSeriesRepository.Get(ss => ss.HattrickId == curTeam.LeagueLevelUnit.LeagueLevelUnitId)
                                                                  .SingleOrDefault();

                    if (storedSeniorSeries == null)
                    {
                        var storedLeague = this.leagueRepository.Get(l => l.HattrickId == curTeam.League.LeagueId)
                                                                .Single();

                        storedSeniorSeries = new BusinessObjects.App.SeniorSeries
                        {
                            Division = curTeam.LeagueLevelUnit.LeagueLevelUnitLevel,
                            HattrickId = curTeam.LeagueLevelUnit.LeagueLevelUnitId,
                            League = storedLeague,
                            Name = curTeam.LeagueLevelUnit.LeagueLevelUnitName
                        };

                        this.seniorSeriesRepository.Insert(storedSeniorSeries);

                        this.context.Save();
                    }

                    var storedSeniorTeam = this.seniorTeamRepository.Get(st => st.HattrickId == curTeam.TeamId)
                                                                    .SingleOrDefault();

                    var storedRegion = this.regionRepository.Get(r => r.HattrickId == curTeam.Region.RegionId)
                                                            .SingleOrDefault();

                    if (storedRegion == null)
                    {
                        var storedCountry = this.countryRepository.Get(c => c.HattrickId == curTeam.Country.CountryId)
                                                                  .Single();

                        storedRegion = new BusinessObjects.App.Region
                        {
                            Country = storedCountry,
                            HattrickId = curTeam.Region.RegionId,
                            Name = curTeam.Region.RegionName
                        };

                        this.regionRepository.Insert(storedRegion);

                        this.context.Save();
                    }

                    if (storedSeniorTeam == null)
                    {
                        storedSeniorTeam = new BusinessObjects.App.SeniorTeam
                        {
                            EstablishedOn = curTeam.FoundedDate,
                            FullName = curTeam.TeamName,
                            HattrickId = curTeam.TeamId,
                            IsPrimary = curTeam.IsPrimaryClub,
                            LeagueRank = curTeam.TeamRank,
                            Manager = storedManager,
                            Region = storedRegion,
                            SeniorSeries = storedSeniorSeries,
                            ShortName = curTeam.ShortTeamName,
                            UndefeatedInRow = curTeam.NumberOfUndefeated,
                            WinsInRow = curTeam.NumberOfVictories
                        };

                        this.seniorTeamRepository.Insert(storedSeniorTeam);
                    }
                    else
                    {
                        storedSeniorTeam.FullName = curTeam.TeamName;
                        storedSeniorTeam.LeagueRank = curTeam.TeamRank;
                        storedSeniorTeam.Region = storedRegion;
                        storedSeniorTeam.SeniorSeries = storedSeniorSeries;
                        storedSeniorTeam.ShortName = curTeam.ShortTeamName;
                        storedSeniorTeam.UndefeatedInRow = curTeam.NumberOfUndefeated;
                        storedSeniorTeam.WinsInRow = curTeam.NumberOfVictories;

                        this.seniorTeamRepository.Update(storedSeniorTeam);
                    }

                    this.context.Save();

                    var storedSeniorArena = this.seniorArenaRepository.Get(sa => sa.HattrickId == curTeam.Arena.ArenaId)
                                                                .SingleOrDefault();

                    if (storedSeniorArena == null)
                    {
                        storedSeniorArena = new BusinessObjects.App.SeniorArena
                        {
                            HattrickId = curTeam.Arena.ArenaId,
                            Name = curTeam.Arena.ArenaName,
                            SeniorTeam = storedSeniorTeam
                        };

                        this.seniorArenaRepository.Insert(storedSeniorArena);

                        this.context.Save();
                    }

                    if (curTeam.YouthTeamId.HasValue && storedSeniorTeam.JuniorTeam != null)
                    {
                        this.juniorTeamRepository.Delete(storedSeniorTeam.JuniorTeam.Id);

                        this.context.Save();
                    }

                    if (curTeam.YouthTeamId.HasValue)
                    {
                        var juniorTeam = this.juniorTeamRepository.Get(jt => jt.HattrickId == curTeam.YouthTeamId.Value)
                                                                    .SingleOrDefault();

                        if (juniorTeam == null)
                        {
                            juniorTeam = new BusinessObjects.App.JuniorTeam
                            {
                                FullName = curTeam.YouthTeamName,
                                HattrickId = curTeam.YouthTeamId.Value,
                                SeniorTeam = storedSeniorTeam
                            };

                            this.juniorTeamRepository.Insert(juniorTeam);

                            this.context.Save();
                        }
                    }
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