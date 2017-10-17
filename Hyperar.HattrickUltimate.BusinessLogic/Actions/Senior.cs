// -----------------------------------------------------------------------
// <copyright file="Senior.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
// -----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessLogic.Actions
{
    using System;
    using System.Linq;
    using DataAccess.Database.Interface;

    /// <summary>
    /// Senior business objects related actions
    /// </summary>
    public class Senior
    {
        #region Private Fields

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
        /// Initializes a new instance of the <see cref="Senior" /> class.
        /// </summary>
        /// <param name="context">Database context.</param>
        /// <param name="countryRepository">Country repository.</param>
        /// <param name="juniorSeriesRepository">Junior Series repository.</param>
        /// <param name="juniorTeamRepository">Junior Team repository.</param>
        /// <param name="leagueRepository">League repository.</param>
        /// <param name="managerRepository">Manager repository.</param>
        /// <param name="regionRepository">Region repository.</param>
        /// <param name="seniorArenaRepository">Senior Arena repository.</param>
        /// <param name="seniorSeriesRepository">Senior Series repository.</param>
        /// <param name="seniorTeamRepository">Senior Team repository.</param>
        /// <param name="userRepository">User repository.</param>
        public Senior(
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
        }

        #endregion Public Constructors

        #region Internal Methods

        /// <summary>
        /// Process League Level Unit
        /// </summary>
        /// <param name="leagueLevelUnit">League Level Unit.</param>
        /// <param name="leagueId">League Id.</param>
        /// <returns>BusinessObjects.App.SeniorSeries object.</returns>
        internal BusinessObjects.App.SeniorSeries ProcessLeagueLevelUnit(BusinessObjects.Hattrick.TeamDetails.LeagueLevelUnit leagueLevelUnit, int leagueId)
        {
            var seniorSeries = this.seniorSeriesRepository.Get(ss => ss.HattrickId == leagueLevelUnit.LeagueLevelUnitId)
                                                          .SingleOrDefault();

            if (seniorSeries == null)
            {
                seniorSeries = new BusinessObjects.App.SeniorSeries
                {
                    Division = leagueLevelUnit.LeagueLevelUnitLevel,
                    HattrickId = leagueLevelUnit.LeagueLevelUnitId,
                    LeagueId = leagueId,
                    Name = leagueLevelUnit.LeagueLevelUnitName
                };

                this.seniorSeriesRepository.Insert(seniorSeries);

                this.context.Save();
            }

            return seniorSeries;
        }

        /// <summary>
        /// Process Senior Arena.
        /// </summary>
        /// <param name="arena">Senior Arena.</param>
        /// <param name="seniorTeamId">Senior Team Id.</param>
        /// <returns>BusinessObjects.App.SeniorArena object.</returns>
        internal BusinessObjects.App.SeniorArena ProcessSeniorArena(BusinessObjects.Hattrick.TeamDetails.Arena arena, int seniorTeamId)
        {
            if (arena == null)
            {
                throw new ArgumentNullException(nameof(arena));
            }

            var seniorArena = this.seniorArenaRepository.Get(ss => ss.HattrickId == arena.ArenaId)
                                                        .SingleOrDefault();

            if (seniorArena == null)
            {
                seniorArena = new BusinessObjects.App.SeniorArena
                {
                    HattrickId = arena.ArenaId,
                    Name = arena.ArenaName,
                    SeniorTeam = this.seniorTeamRepository.Get(seniorTeamId)
                };

                this.seniorArenaRepository.Insert(seniorArena);

                this.context.Save();
            }

            return seniorArena;
        }

        /// <summary>
        /// Process Senior Team.
        /// </summary>
        /// <param name="team">Senior Team.</param>
        /// <param name="managerId">Manager Id.</param>
        /// <param name="regionId">Region Id.</param>
        /// <param name="seniorSeriesId">Senior Series Id.</param>
        /// <returns>BusinessObjects.App.SeniorTeam object.</returns>
        internal BusinessObjects.App.SeniorTeam ProcessSeniorTeam(
                                           BusinessObjects.Hattrick.TeamDetails.Team team,
                                           int managerId,
                                           int regionId,
                                           int seniorSeriesId)
        {
            if (team == null)
            {
                throw new ArgumentNullException(nameof(team));
            }

            var seniorTeam = this.seniorTeamRepository.Get(st => st.HattrickId == team.TeamId)
                                                      .SingleOrDefault();

            if (seniorTeam == null)
            {
                seniorTeam = new BusinessObjects.App.SeniorTeam
                {
                    EstablishedOn = team.FoundedDate,
                    FullName = team.TeamName,
                    HattrickId = team.TeamId,
                    IsPrimary = team.IsPrimaryClub,
                    LeagueRank = team.TeamRank,
                    ManagerId = managerId,
                    RegionId = regionId,
                    SeniorSeriesId = seniorSeriesId,
                    ShortName = team.ShortTeamName,
                    UndefeatedInRow = team.NumberOfUndefeated,
                    WinsInRow = team.NumberOfVictories
                };

                this.seniorTeamRepository.Insert(seniorTeam);
            }
            else
            {
                seniorTeam.FullName = team.TeamName;
                seniorTeam.LeagueRank = team.TeamRank;
                seniorTeam.RegionId = regionId;
                seniorTeam.SeniorSeriesId = seniorSeriesId;
                seniorTeam.ShortName = team.ShortTeamName;
                seniorTeam.UndefeatedInRow = team.NumberOfUndefeated;
                seniorTeam.WinsInRow = team.NumberOfVictories;

                this.seniorTeamRepository.Update(seniorTeam);
            }

            this.context.Save();

            return seniorTeam;
        }

        #endregion Internal Methods
    }
}