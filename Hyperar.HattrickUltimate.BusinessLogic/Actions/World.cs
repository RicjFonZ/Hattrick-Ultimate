// -----------------------------------------------------------------------
// <copyright file="World.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
// -----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessLogic.Actions
{
    using System;
    using System.Linq;
    using BusinessObjects.App.Enums;
    using DataAccess.Database.Interface;
    using ExtensionMethods;

    /// <summary>
    /// Hattrick World related business objects actions.
    /// </summary>
    public class World
    {
        #region Private Fields

        /// <summary>
        /// Database context.
        /// </summary>
        private IDatabaseContext context;

        /// <summary>
        /// Continent repository.
        /// </summary>
        private IRepository<BusinessObjects.App.Continent> continentRepository;

        /// <summary>
        /// Country repository.
        /// </summary>
        private IRepository<BusinessObjects.App.Country> countryRepository;

        /// <summary>
        /// Currency repository.
        /// </summary>
        private IRepository<BusinessObjects.App.Currency> currencyRepository;

        /// <summary>
        /// DateFormat repository.
        /// </summary>
        private IRepository<BusinessObjects.App.DateFormat> dateFormatRepository;

        /// <summary>
        /// LeagueCup repository.
        /// </summary>
        private IRepository<BusinessObjects.App.LeagueCup> leagueCupRepository;

        /// <summary>
        /// LeagueNationalTeam repository.
        /// </summary>
        private IRepository<BusinessObjects.App.LeagueNationalTeam> leagueNationalTeamRepository;

        /// <summary>
        /// League repository.
        /// </summary>
        private IRepository<BusinessObjects.App.League> leagueRepository;

        /// <summary>
        /// LeagueSchedule repository.
        /// </summary>
        private IRepository<BusinessObjects.App.LeagueSchedule> leagueScheduleRepository;

        /// <summary>
        /// Manager repository.
        /// </summary>
        private IRepository<BusinessObjects.App.Manager> managerRepository;

        /// <summary>
        /// Region repository.
        /// </summary>
        private IRepository<BusinessObjects.App.Region> regionRepository;

        /// <summary>
        /// TimeFormat repository.
        /// </summary>
        private IRepository<BusinessObjects.App.TimeFormat> timeFormatRepository;

        /// <summary>
        /// User repository.
        /// </summary>
        private IRepository<BusinessObjects.App.User> userRepository;

        /// <summary>
        /// Zone repository.
        /// </summary>
        private IRepository<BusinessObjects.App.Zone> zoneRepository;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="World" /> class.
        /// </summary>
        /// <param name="context">Database context.</param>
        /// <param name="continentRepository">Continent repository.</param>
        /// <param name="countryRepository">Country repository.</param>
        /// <param name="currencyRepository">Currency repository.</param>
        /// <param name="dateFormatRepository">Date Format repository.</param>
        /// <param name="leagueCupRepository">League Cup repository.</param>
        /// <param name="leagueNationalTeamRepository">League National Team repository.</param>
        /// <param name="leagueRepository">League repository.</param>
        /// <param name="leagueScheduleRepository">League Schedule repository.</param>
        /// <param name="managerRepository">Manager repository.</param>
        /// <param name="regionRepository">Region repository.</param>
        /// <param name="timeFormatRepository">Time Format repository.</param>
        /// <param name="userRepository">User repository.</param>
        /// <param name="zoneRepository">Zone repository.</param>
        public World(
                   IDatabaseContext context,
                   IRepository<BusinessObjects.App.Continent> continentRepository,
                   IRepository<BusinessObjects.App.Country> countryRepository,
                   IRepository<BusinessObjects.App.Currency> currencyRepository,
                   IRepository<BusinessObjects.App.DateFormat> dateFormatRepository,
                   IRepository<BusinessObjects.App.LeagueCup> leagueCupRepository,
                   IRepository<BusinessObjects.App.LeagueNationalTeam> leagueNationalTeamRepository,
                   IRepository<BusinessObjects.App.League> leagueRepository,
                   IRepository<BusinessObjects.App.LeagueSchedule> leagueScheduleRepository,
                   IRepository<BusinessObjects.App.Manager> managerRepository,
                   IRepository<BusinessObjects.App.Region> regionRepository,
                   IRepository<BusinessObjects.App.TimeFormat> timeFormatRepository,
                   IRepository<BusinessObjects.App.User> userRepository,
                   IRepository<BusinessObjects.App.Zone> zoneRepository)
        {
            this.context = context;
            this.continentRepository = continentRepository;
            this.countryRepository = countryRepository;
            this.currencyRepository = currencyRepository;
            this.dateFormatRepository = dateFormatRepository;
            this.leagueCupRepository = leagueCupRepository;
            this.leagueNationalTeamRepository = leagueNationalTeamRepository;
            this.leagueRepository = leagueRepository;
            this.leagueScheduleRepository = leagueScheduleRepository;
            this.managerRepository = managerRepository;
            this.regionRepository = regionRepository;
            this.timeFormatRepository = timeFormatRepository;
            this.userRepository = userRepository;
            this.zoneRepository = zoneRepository;
        }

        #endregion Public Constructors

        #region Internal Methods

        /// <summary>
        /// Gets the Country with the specified Hattrick Id.
        /// </summary>
        /// <param name="countryId">Country Hattrick Id.</param>
        /// <returns>BusinessObjects.App.Country object.</returns>
        internal BusinessObjects.App.Country GetCountry(uint countryId)
        {
            return this.countryRepository.Get(l => l.HattrickId == countryId)
                                         .SingleOrDefault();
        }

        /// <summary>
        /// Gets the Country with the specified Id.
        /// </summary>
        /// <param name="countryId">Country Id.</param>
        /// <returns>BusinessObjects.App.Country object.</returns>
        internal BusinessObjects.App.Country GetCountry(int countryId)
        {
            return this.countryRepository.Get(l => l.Id == countryId)
                                         .Single();
        }

        /// <summary>
        /// Gets the League with the specified Hattrick Id.
        /// </summary>
        /// <param name="leagueId">League Hattrick Id.</param>
        /// <returns>BusinessObjects.App.League object.</returns>
        internal BusinessObjects.App.League GetLeague(uint leagueId)
        {
            return this.leagueRepository.Get(l => l.HattrickId == leagueId)
                                        .SingleOrDefault();
        }

        /// <summary>
        /// Gets the League with the specified Id.
        /// </summary>
        /// <param name="leagueId">League Id.</param>
        /// <returns>BusinessObjects.App.League object.</returns>
        internal BusinessObjects.App.League GetLeague(int leagueId)
        {
            return this.leagueRepository.Get(l => l.Id == leagueId)
                                        .Single();
        }

        /// <summary>
        /// Gets the Manager with the specified Hattrick Id.
        /// </summary>
        /// <param name="managerId">Manager Hattrick Id.</param>
        /// <returns>BusinessObjects.App.Manager object.</returns>
        internal BusinessObjects.App.Manager GetManager(uint managerId)
        {
            return this.managerRepository.Get(l => l.HattrickId == managerId)
                                         .SingleOrDefault();
        }

        /// <summary>
        /// Gets the Manager with the specified Id.
        /// </summary>
        /// <param name="managerId">Manager Id.</param>
        /// <returns>BusinessObjects.App.Manager object.</returns>
        internal BusinessObjects.App.Manager GetManager(int managerId)
        {
            return this.managerRepository.Get(l => l.Id == managerId)
                                         .Single();
        }

        /// <summary>
        /// Process the specified Continent name.
        /// </summary>
        /// <param name="continentName">Continent name to process.</param>
        /// <returns>BusinessObjects.App.Continent object.</returns>
        internal BusinessObjects.App.Continent ProcessContinent(string continentName)
        {
            var storedContinent = this.continentRepository.Get()
                                                          .SingleOrDefault(z => z.Name.Equals(
                                                                                           continentName,
                                                                                           StringComparison.OrdinalIgnoreCase));

            if (storedContinent == null)
            {
                storedContinent = new BusinessObjects.App.Continent
                {
                    Name = continentName
                };

                this.continentRepository.Insert(storedContinent);

                this.context.Save();
            }

            return storedContinent;
        }

        /// <summary>
        /// Process Country object.
        /// </summary>
        /// <param name="country">Country to process.</param>
        /// <param name="currencyId">Stored currency.</param>
        /// <param name="dateFormatId">Stored date format.</param>
        /// <param name="timeFormatId">Stored time format.</param>
        /// <param name="leagueId">Stored league.</param>
        /// <returns>Business.App.Country object.</returns>
        internal BusinessObjects.App.Country ProcessCountry(
                                                 BusinessObjects.Hattrick.WorldDetails.Country country,
                                                 int currencyId,
                                                 int dateFormatId,
                                                 int timeFormatId,
                                                 int leagueId)
        {
            var storedCountry = this.countryRepository.Get(c => c.HattrickId == country.CountryId)
                                                      .SingleOrDefault();

            if (storedCountry == null)
            {
                storedCountry = new BusinessObjects.App.Country
                {
                    Code = country.CountryCode,
                    CurrencyId = currencyId,
                    DateFormatId = dateFormatId,
                    HattrickId = country.CountryId,
                    League = this.leagueRepository.Get(leagueId),
                    Name = country.CountryName,
                    TimeFormatId = timeFormatId
                };

                this.countryRepository.Insert(storedCountry);

                this.context.Save();
            }

            return storedCountry;
        }

        /// <summary>
        /// Process Currency object.
        /// </summary>
        /// <param name="currencyName">Currency name.</param>
        /// <param name="currencyRate">Currency exchange rate.</param>
        /// <returns>BusinessObjects.App.Currency object.</returns>
        internal BusinessObjects.App.Currency ProcessCurrency(string currencyName, decimal currencyRate)
        {
            var storedCurrency = this.currencyRepository.Get()
                                                        .SingleOrDefault(z => z.Name.Equals(
                                                                                         currencyName,
                                                                                         StringComparison.OrdinalIgnoreCase)
                                                                           && z.Rate.Equals(currencyRate));

            if (storedCurrency == null)
            {
                storedCurrency = new BusinessObjects.App.Currency
                {
                    Name = currencyName,
                    Rate = currencyRate
                };

                this.currencyRepository.Insert(storedCurrency);

                this.context.Save();
            }

            return storedCurrency;
        }

        /// <summary>
        /// Process the specified DateFormat mask.
        /// </summary>
        /// <param name="dateFormatMask">DateFormat mask to process.</param>
        /// <returns>BusinessObjects.App.DateFormat object.</returns>
        internal BusinessObjects.App.DateFormat ProcessDateFormat(string dateFormatMask)
        {
            var storedDateFormat = this.dateFormatRepository.Get()
                                                            .SingleOrDefault(c => c.Mask.Equals(
                                                                                             dateFormatMask,
                                                                                             StringComparison.OrdinalIgnoreCase));

            if (storedDateFormat == null)
            {
                storedDateFormat = new BusinessObjects.App.DateFormat
                {
                    Mask = dateFormatMask
                };

                this.dateFormatRepository.Insert(storedDateFormat);

                this.context.Save();
            }

            return storedDateFormat;
        }

        /// <summary>
        /// Process the specified League, LeagueSchedule and LeagueNationalTeam.
        /// </summary>
        /// <param name="league">League to process.</param>
        /// <param name="continentId">League continent.</param>
        /// <param name="zoneId">Zone to process</param>
        /// <returns>BusinessObjects.App.League object.</returns>
        internal BusinessObjects.App.League ProcessLeague(
                                                BusinessObjects.Hattrick.WorldDetails.League league,
                                                int continentId,
                                                int zoneId)
        {
            var storedLeague = this.leagueRepository.Get(l => l.HattrickId == league.LeagueId)
                                                    .SingleOrDefault();

            if (storedLeague == null)
            {
                storedLeague = new BusinessObjects.App.League
                {
                    ActiveTeams = league.ActiveTeams,
                    ActiveUsers = league.ActiveUsers,
                    ContinentId = continentId,
                    CurrentRound = league.MatchRound,
                    CurrentSeason = league.Season,
                    Divisions = league.NumberOfLevels,
                    EnglishName = league.EnglishName,
                    FullName = league.LeagueName,
                    HattrickId = league.LeagueId,
                    NationalTeam = new BusinessObjects.App.LeagueNationalTeam
                    {
                        JuniorNationalTeamId = league.U20TeamId,
                        SeniorNationalTeamId = league.NationalTeamId
                    },
                    Schedule = new BusinessObjects.App.LeagueSchedule
                    {
                        CupMatchDayOfWeek = (byte)league.CupMatchDate.DayOfWeek,
                        CupMatchTimeOfDay = league.CupMatchDate.TimeOfDay,
                        EconomyUpdateDayOfWeek = (byte)league.EconomyDate.DayOfWeek,
                        EconomyUpdateTimeOfDay = league.EconomyDate.TimeOfDay,
                        SeriesMatchDayOfWeek = (byte)league.SeriesMatchDate.DayOfWeek,
                        SeriesMatchTimeOfDay = league.SeriesMatchDate.TimeOfDay,
                        TrainingUpdateDayOfWeek = (byte)league.TrainingDate.DayOfWeek,
                        TrainingUpdateTimeOfDay = league.TrainingDate.TimeOfDay
                    },
                    SeasonOffset = league.SeasonOffset,
                    ShortName = league.ShortName,
                    WaitingUsers = league.WaitingUsers,
                    ZoneId = zoneId
                };

                this.leagueRepository.Insert(storedLeague);
            }
            else
            {
                storedLeague.ActiveTeams = league.ActiveTeams;
                storedLeague.ActiveUsers = league.ActiveUsers;
                storedLeague.CurrentRound = league.MatchRound;
                storedLeague.CurrentSeason = league.Season;
                storedLeague.Divisions = league.NumberOfLevels;
                storedLeague.WaitingUsers = league.WaitingUsers;

                this.leagueRepository.Update(storedLeague);

                storedLeague.Schedule.CupMatchDayOfWeek = (byte)league.CupMatchDate.DayOfWeek;
                storedLeague.Schedule.CupMatchTimeOfDay = league.CupMatchDate.TimeOfDay;
                storedLeague.Schedule.EconomyUpdateDayOfWeek = (byte)league.EconomyDate.DayOfWeek;
                storedLeague.Schedule.EconomyUpdateTimeOfDay = league.EconomyDate.TimeOfDay;
                storedLeague.Schedule.SeriesMatchDayOfWeek = (byte)league.SeriesMatchDate.DayOfWeek;
                storedLeague.Schedule.SeriesMatchTimeOfDay = league.SeriesMatchDate.TimeOfDay;
                storedLeague.Schedule.TrainingUpdateDayOfWeek = (byte)league.TrainingDate.DayOfWeek;
                storedLeague.Schedule.TrainingUpdateTimeOfDay = league.TrainingDate.TimeOfDay;

                this.leagueScheduleRepository.Update(storedLeague.Schedule);
            }

            this.context.Save();

            return storedLeague;
        }

        /// <summary>
        /// Process the specified Cup.
        /// </summary>
        /// <param name="cup">Cup to process.</param>
        /// <param name="leagueId">League owning Id.</param>
        internal void ProcessLeagueCup(BusinessObjects.Hattrick.WorldDetails.Cup cup, int leagueId)
        {
            var storedCup = this.leagueCupRepository.Get()
                                                    .SingleOrDefault(l => l.HattrickId == cup.CupId);

            if (storedCup == null)
            {
                storedCup = new BusinessObjects.App.LeagueCup
                {
                    CurrentRound = cup.MatchRound,
                    Division = cup.CupLevel == (byte)LeagueCupType.Official && cup.CupLevelIndex != 0
                             ? (byte?)cup.CupLevelIndex
                             : null,
                    HattrickId = cup.CupId,
                    LeagueId = leagueId,
                    Name = cup.CupName,
                    RoundsLeft = cup.MatchRoundsLeft,
                    Tier = cup.CupLevel == (byte)LeagueCupType.Challenger
                         ? (LeagueCupTier?)cup.CupLevelIndex
                         : null,
                    Type = (LeagueCupType)cup.CupLevel
                };

                this.leagueCupRepository.Insert(storedCup);
            }
            else
            {
                storedCup.CurrentRound = cup.MatchRound;
                storedCup.RoundsLeft = cup.MatchRoundsLeft;

                this.leagueCupRepository.Update(storedCup);
            }

            this.context.Save();
        }

        /// <summary>
        /// Process Manager
        /// </summary>
        /// <param name="manager">ManagerCompendium Manger.</param>
        /// <param name="countryId">Country Id.</param>
        /// <returns>BusinessObjects.App.Manager object.</returns>
        internal BusinessObjects.App.Manager ProcessManager(
                                                         BusinessObjects.Hattrick.ManagerCompendium.Manager manager,
                                                         int countryId)
        {
            if (manager == null)
            {
                throw new ArgumentNullException(nameof(manager));
            }

            var storedManager = this.managerRepository.Get(m => m.HattrickId == manager.UserId)
                                                      .SingleOrDefault();

            if (storedManager == null)
            {
                storedManager = new BusinessObjects.App.Manager
                {
                    CountryId = countryId,
                    HattrickId = manager.UserId,
                    SupporterTier = manager.SupporterTier.GetEnum(),
                    User = this.userRepository.Get().Single(),
                    UserName = manager.LoginName,
                };

                this.managerRepository.Insert(storedManager);
            }
            else
            {
                storedManager.SupporterTier = manager.SupporterTier.GetEnum();
                storedManager.UserName = manager.LoginName;

                this.managerRepository.Update(storedManager);
            }

            this.context.Save();

            return storedManager;
        }

        /// <summary>
        /// Process the specified Region.
        /// </summary>
        /// <param name="region">Region to process.</param>
        /// <param name="countryId">Region owning country.</param>
        /// <returns>BusinessObjects.App.Region object</returns>
        internal BusinessObjects.App.Region ProcessRegion(BusinessObjects.Hattrick.WorldDetails.Region region, int countryId)
        {
            var storedRegion = this.regionRepository.Get()
                                                    .SingleOrDefault(r => r.HattrickId == region.RegionId);

            if (storedRegion == null)
            {
                storedRegion = new BusinessObjects.App.Region
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
        /// Process the specified Region.
        /// </summary>
        /// <param name="region">Region to process.</param>
        /// <param name="countryId">Region owning country.</param>
        /// <returns>BusinessObjects.App.Region object</returns>
        internal BusinessObjects.App.Region ProcessRegion(BusinessObjects.Hattrick.TeamDetails.Region region, int countryId)
        {
            var storedRegion = this.regionRepository.Get()
                                                    .SingleOrDefault(r => r.HattrickId == region.RegionId);

            if (storedRegion == null)
            {
                storedRegion = new BusinessObjects.App.Region
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
        /// Process the specified TimeFormat mask.
        /// </summary>
        /// <param name="timeFormatMask">TimeFormat mask to process.</param>
        /// <returns>BusinessObjects.App.TimeFormat object.</returns>
        internal BusinessObjects.App.TimeFormat ProcessTimeFormat(string timeFormatMask)
        {
            var storedTimeFormat = this.timeFormatRepository.Get()
                                                            .SingleOrDefault(c => c.Mask.Equals(
                                                                                             timeFormatMask,
                                                                                             StringComparison.OrdinalIgnoreCase));

            if (storedTimeFormat == null)
            {
                storedTimeFormat = new BusinessObjects.App.TimeFormat
                {
                    Mask = timeFormatMask
                };

                this.timeFormatRepository.Insert(storedTimeFormat);

                this.context.Save();
            }

            return storedTimeFormat;
        }

        /// <summary>
        /// Process the specified Zone name.
        /// </summary>
        /// <param name="zoneName">Zone name to process.</param>
        /// <returns>BusinessObjects.App.Zone object.</returns>
        internal BusinessObjects.App.Zone ProcessZone(string zoneName)
        {
            var storedZone = this.zoneRepository.Get()
                                                .SingleOrDefault(z => z.Name.Equals(
                                                                                 zoneName,
                                                                                 StringComparison.OrdinalIgnoreCase));

            if (storedZone == null)
            {
                storedZone = new BusinessObjects.App.Zone
                {
                    Name = zoneName
                };

                this.zoneRepository.Insert(storedZone);

                this.context.Save();
            }

            return storedZone;
        }

        #endregion Internal Methods

        #region Private Methods

        /// <summary>
        /// Process the specified Region.
        /// </summary>
        /// <param name="regionId">Region Id.</param>
        /// <param name="regionName">Region name.</param>
        /// <param name="countryId">Owning Country Id.</param>
        /// <returns>BusinessObjects.App.Region object</returns>
        private BusinessObjects.App.Region ProcessRegion(uint regionId, string regionName, int countryId)
        {
            var storedRegion = this.regionRepository.Get()
                                                    .SingleOrDefault(r => r.HattrickId == regionId);

            if (storedRegion == null)
            {
                storedRegion = new BusinessObjects.App.Region
                {
                    HattrickId = regionId,
                    Name = regionName,
                    CountryId = countryId
                };

                this.regionRepository.Insert(storedRegion);

                this.context.Save();
            }

            return storedRegion;
        }

        #endregion Private Methods
    }
}