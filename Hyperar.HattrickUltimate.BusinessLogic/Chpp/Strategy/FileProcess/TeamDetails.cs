// -----------------------------------------------------------------------
// <copyright file="TeamDetails.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
// -----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessLogic.Chpp.Strategy.FileProcess
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using BusinessObjects.App;
    using BusinessObjects.Hattrick.Interface;
    using DataAccess.Database.Interface;
    using Interface;

    /// <summary>
    /// Provides functionality to process TeamDetails file.
    /// </summary>
    public class TeamDetails : IFileProcessStrategy
    {
        #region Private Fields

        /// <summary>
        /// Database context.
        /// </summary>
        private IDatabaseContext context;

        /// <summary>
        /// Country repository.
        /// </summary>
        private IRepository<Country> countryRepository;

        /// <summary>
        /// Junior Team repository.
        /// </summary>
        private IRepository<JuniorTeam> juniorTeamRepository;

        /// <summary>
        /// League repository.
        /// </summary>
        private IRepository<League> leagueRepository;

        /// <summary>
        /// Manager repository.
        /// </summary>
        private IRepository<Manager> managerRepository;

        /// <summary>
        /// Region repository.
        /// </summary>
        private IRepository<Region> regionRepository;

        /// <summary>
        /// Senior Arena repository.
        /// </summary>
        private IRepository<SeniorArena> seniorArenaRepository;

        /// <summary>
        /// Senior Series repository.
        /// </summary>
        private IRepository<SeniorSeries> seniorSeriesRepository;

        /// <summary>
        /// Senior Team repository.
        /// </summary>
        private IRepository<SeniorTeam> seniorTeamRepository;

        /// <summary>
        /// User repository.
        /// </summary>
        private IRepository<User> userRepository;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TeamDetails" /> class.
        /// </summary>
        /// <param name="context">Database context</param>
        /// <param name="countryRepository">Country repository</param>
        /// <param name="juniorTeamRepository">Junior Team repository</param>
        /// <param name="leagueRepository">League repository</param>
        /// <param name="managerRepository">Manager repository</param>
        /// <param name="regionRepository">Region repository</param>
        /// <param name="seniorArenaRepository">Senior Arena repository</param>
        /// <param name="seniorSeriesRepository">Senior Series repository</param>
        /// <param name="seniorTeamRepository">Senior Team repository</param>
        /// <param name="userRepository">User repository.</param>
        public TeamDetails(
                   IDatabaseContext context,
                   IRepository<Country> countryRepository,
                   IRepository<JuniorTeam> juniorTeamRepository,
                   IRepository<League> leagueRepository,
                   IRepository<Manager> managerRepository,
                   IRepository<Region> regionRepository,
                   IRepository<SeniorArena> seniorArenaRepository,
                   IRepository<SeniorSeries> seniorSeriesRepository,
                   IRepository<SeniorTeam> seniorTeamRepository,
                   IRepository<User> userRepository)
        {
            this.context = context;
            this.countryRepository = countryRepository;
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

        #region Public Methods

        /// <summary>
        /// Process Team Details file.
        /// </summary>
        /// <param name="fileToProcess">File to process.</param>
        /// <param name="parameters">Process parameters.</param>
        public void ProcessFile(IXmlEntity fileToProcess, Dictionary<string, object> parameters = null)
        {
            if (fileToProcess == null)
            {
                throw new ArgumentNullException(nameof(fileToProcess));
            }

            var file = fileToProcess as BusinessObjects.Hattrick.TeamDetails.Root;

            if (file == null)
            {
                throw new ArgumentException(Localization.Strings.Message_UnexpectedObjectType, nameof(fileToProcess));
            }

            var manager = this.managerRepository.Get(m => m.HattrickId == file.User.UserId)
                                                .Single();

            foreach (var curTeam in file.Teams)
            {
                var league = this.leagueRepository.Get(l => l.HattrickId == curTeam.League.LeagueId).Single();
                var country = this.countryRepository.Get(l => l.HattrickId == curTeam.Country.CountryId).Single();

                var region = this.ProcessRegion(curTeam.Region, country.Id);
                var seniorSeries = this.ProcessLeagueLevelUnit(curTeam.LeagueLevelUnit, league.Id);
                var seniorTeam = this.ProcessSeniorTeam(curTeam, manager.Id, region.Id, seniorSeries.Id);
                var seniorArena = this.ProcessSeniorArena(curTeam.Arena, seniorTeam.Id);

                this.ProcessYouthTeam(curTeam.YouthTeamId, curTeam.YouthTeamName, seniorTeam.Id);
            }
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        /// Create Junior Team.
        /// </summary>
        /// <param name="juniorTeamId">Junior Team Id.</param>
        /// <param name="juniorTeamName">Junior Team Name</param>
        /// <param name="seniorTeamId">Senior Team Id.</param>
        private void CreateJuniorTeam(uint juniorTeamId, string juniorTeamName, int seniorTeamId)
        {
            var juniorTeam = new JuniorTeam
            {
                FullName = juniorTeamName,
                HattrickId = juniorTeamId,
                SeniorTeam = this.seniorTeamRepository.Get(seniorTeamId)
            };

            this.juniorTeamRepository.Insert(juniorTeam);

            this.context.Save();
        }

        /// <summary>
        /// Deletes the Junior Team.
        /// </summary>
        /// <param name="juniorTeamId">Junior Team Id.</param>
        private void DeleteJuniorTeam(int juniorTeamId)
        {
            this.juniorTeamRepository.Delete(juniorTeamId);

            this.context.Save();
        }

        /// <summary>
        /// Process League Level Unit
        /// </summary>
        /// <param name="leagueLevelUnit">League Level Unit.</param>
        /// <param name="leagueId">League Id.</param>
        /// <returns>BusinessObjects.App.SeniorSeries object.</returns>
        private SeniorSeries ProcessLeagueLevelUnit(BusinessObjects.Hattrick.TeamDetails.LeagueLevelUnit leagueLevelUnit, int leagueId)
        {
            var seniorSeries = this.seniorSeriesRepository.Get(ss => ss.HattrickId == leagueLevelUnit.LeagueLevelUnitId)
                                                          .SingleOrDefault();

            if (seniorSeries == null)
            {
                seniorSeries = new SeniorSeries
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
        /// Process the specified Region.
        /// </summary>
        /// <param name="region">Region to process.</param>
        /// <param name="countryId">Region owning country.</param>
        /// <returns>BusinessObjects.App.Region object</returns>
        private Region ProcessRegion(BusinessObjects.Hattrick.TeamDetails.Region region, int countryId)
        {
            var storedRegion = this.regionRepository.Get()
                                                    .SingleOrDefault(r => r.HattrickId == region.RegionId);

            if (storedRegion == null)
            {
                storedRegion = new Region
                {
                    HattrickId = region.RegionId,
                    Name = region.RegionName,
                    CountryId = countryId
                };

                this.regionRepository.Insert(storedRegion);

                this.context.Save();
            }

            return storedRegion;
        }

        /// <summary>
        /// Process Senior Arena.
        /// </summary>
        /// <param name="arena">Senior Arena.</param>
        /// <param name="seniorTeamId">Senior Team Id.</param>
        /// <returns>BusinessObjects.App.SeniorArena object.</returns>
        private SeniorArena ProcessSeniorArena(BusinessObjects.Hattrick.TeamDetails.Arena arena, int seniorTeamId)
        {
            if (arena == null)
            {
                throw new ArgumentNullException(nameof(arena));
            }

            var seniorArena = this.seniorArenaRepository.Get(ss => ss.HattrickId == arena.ArenaId)
                                                        .SingleOrDefault();

            if (seniorArena == null)
            {
                seniorArena = new SeniorArena
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
        private SeniorTeam ProcessSeniorTeam(
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
                seniorTeam = new SeniorTeam
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

        /// <summary>
        /// Process Youth Team.
        /// </summary>
        /// <param name="youthTeamId">Youth Team Id.</param>
        /// <param name="youthTeamName">Youth Team Name.</param>
        /// <param name="seniorTeamId">Senior Team Id.</param>
        private void ProcessYouthTeam(uint? youthTeamId, string youthTeamName, int seniorTeamId)
        {
            var juniorTeam = this.juniorTeamRepository.Get(jt => jt.SeniorTeamId == seniorTeamId)
                                                      .SingleOrDefault();

            if (youthTeamId.HasValue)
            {
                // Changed the Junior Team, delete old one.
                if (juniorTeam != null && juniorTeam.HattrickId != youthTeamId.Value)
                {
                    this.DeleteJuniorTeam(juniorTeam.Id);
                }

                // Create new Junior Team, else, update it.
                if (juniorTeam == null)
                {
                    this.CreateJuniorTeam(youthTeamId.Value, youthTeamName, seniorTeamId);
                }
                else
                {
                    this.UpdateJuniorTeam(youthTeamId.Value, youthTeamName);
                }
            }
            else
            {
                if (juniorTeam != null)
                {
                    this.DeleteJuniorTeam(juniorTeam.Id);
                }
            }
        }

        /// <summary>
        /// Updates the Junior Team.
        /// </summary>
        /// <param name="youthTeamId">Junior Team Id.</param>
        /// <param name="youthTeamName">Junior Team Name.</param>
        private void UpdateJuniorTeam(uint youthTeamId, string youthTeamName)
        {
            var juniorTeam = this.juniorTeamRepository.Get(jt => jt.HattrickId == youthTeamId)
                                                      .Single();

            juniorTeam.FullName = youthTeamName;

            this.juniorTeamRepository.Update(juniorTeam);

            this.context.Save();
        }

        #endregion Private Methods
    }
}