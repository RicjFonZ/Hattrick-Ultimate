// -----------------------------------------------------------------------
// <copyright file="WorldDetails.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
// -----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessLogic.Chpp.Strategy.FileProcess
{
    using System;
    using System.Linq;
    using BusinessObjects.App;
    using BusinessObjects.App.Enums;
    using BusinessObjects.Hattrick.Interface;
    using DataAccess.Database.Interface;
    using ExtensionMethods;
    using Interface;

    /// <summary>
    /// Provides functionality to process WorldDetails file.
    /// </summary>
    public class WorldDetails : IFileProcessStrategy
    {
        #region Private Fields

        /// <summary>
        /// Database context.
        /// </summary>
        private IDatabaseContext context;

        /// <summary>
        /// Continent repository.
        /// </summary>
        private IRepository<Continent> continentRepository;

        /// <summary>
        /// Country repository.
        /// </summary>
        private IHattrickRepository<Country> countryRepository;

        /// <summary>
        /// Currency repository.
        /// </summary>
        private IRepository<Currency> currencyRepository;

        /// <summary>
        /// DateFormat repository.
        /// </summary>
        private IRepository<DateFormat> dateFormatRepository;

        /// <summary>
        /// LeagueCup repository.
        /// </summary>
        private IHattrickRepository<LeagueCup> leagueCupRepository;

        /// <summary>
        /// LeagueNationalTeam repository.
        /// </summary>
        private IRepository<LeagueNationalTeam> leagueNationalTeamRepository;

        /// <summary>
        /// League repository.
        /// </summary>
        private IHattrickRepository<League> leagueRepository;

        /// <summary>
        /// LeagueSchedule repository.
        /// </summary>
        private IRepository<LeagueSchedule> leagueScheduleRepository;

        /// <summary>
        /// Manager repository.
        /// </summary>
        private IHattrickRepository<Manager> managerRepository;

        /// <summary>
        /// Region repository.
        /// </summary>
        private IHattrickRepository<Region> regionRepository;

        /// <summary>
        /// TimeFormat repository.
        /// </summary>
        private IRepository<TimeFormat> timeFormatRepository;

        /// <summary>
        /// User repository.
        /// </summary>
        private IRepository<User> userRepository;

        /// <summary>
        /// Zone repository.
        /// </summary>
        private IRepository<Zone> zoneRepository;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="WorldDetails" /> class.
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
        public WorldDetails(
                   IDatabaseContext context,
                   IRepository<Continent> continentRepository,
                   IHattrickRepository<Country> countryRepository,
                   IRepository<Currency> currencyRepository,
                   IRepository<DateFormat> dateFormatRepository,
                   IHattrickRepository<LeagueCup> leagueCupRepository,
                   IRepository<LeagueNationalTeam> leagueNationalTeamRepository,
                   IHattrickRepository<League> leagueRepository,
                   IRepository<LeagueSchedule> leagueScheduleRepository,
                   IHattrickRepository<Manager> managerRepository,
                   IHattrickRepository<Region> regionRepository,
                   IRepository<TimeFormat> timeFormatRepository,
                   IRepository<User> userRepository,
                   IRepository<Zone> zoneRepository)
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

        #region Public Methods

        /// <summary>
        /// Process World Details file.
        /// </summary>
        /// <param name="fileToProcess">File to process.</param>
        public void ProcessFile(IXmlEntity fileToProcess)
        {
            if (fileToProcess == null)
            {
                throw new ArgumentNullException(nameof(fileToProcess));
            }

            var file = fileToProcess as BusinessObjects.Hattrick.WorldDetails.Root;

            if (file == null)
            {
                throw new ArgumentException(Localization.Strings.Message_UnexpectedObjectType, nameof(fileToProcess));
            }

            foreach (var curLeague in file.LeagueList)
            {
                var continent = this.ProcessContinent(curLeague.Continent);
                var zone = this.ProcessZone(curLeague.ZoneName);
                var league = this.ProcessLeague(curLeague, continent.Id, zone.Id);

                if (league.Cups != null)
                {
                    foreach (var cup in curLeague.Cups)
                    {
                        this.ProcessLeagueCup(cup, league.Id);
                    }
                }

                if (curLeague.Country != null)
                {
                    var currency = this.ProcessCurrency(
                                            curLeague.Country.CurrencyName,
                                            curLeague.Country.CurrencyRate);

                    var dateFormat = this.ProcessDateFormat(curLeague.Country.DateFormat);
                    var timeFormat = this.ProcessTimeFormat(curLeague.Country.TimeFormat);

                    var country = this.ProcessCountry(
                                           curLeague.Country,
                                           currency.Id,
                                           dateFormat.Id,
                                           timeFormat.Id,
                                           league.Id);

                    if (curLeague.Country.RegionList != null)
                    {
                        foreach (var curRegion in curLeague.Country.RegionList)
                        {
                            this.ProcessRegion(curRegion, country.Id);
                        }
                    }
                }
            }
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        /// Process the specified Continent name.
        /// </summary>
        /// <param name="continentName">Continent name to process.</param>
        /// <returns>Continent object.</returns>
        private Continent ProcessContinent(string continentName)
        {
            var storedContinent = this.continentRepository.Query()
                                                          .SingleOrDefault(z => z.Name.Equals(
                                                                                           continentName,
                                                                                           StringComparison.OrdinalIgnoreCase));

            if (storedContinent == null)
            {
                storedContinent = new Continent
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
        private Country ProcessCountry(
                            BusinessObjects.Hattrick.WorldDetails.Country country,
                            int currencyId,
                            int dateFormatId,
                            int timeFormatId,
                            int leagueId)
        {
            var storedCountry = this.countryRepository.GetByHattrickId(country.CountryId);

            if (storedCountry == null)
            {
                storedCountry = new Country
                {
                    Code = country.CountryCode,
                    CurrencyId = currencyId,
                    DateFormatId = dateFormatId,
                    HattrickId = country.CountryId,
                    League = this.leagueRepository.GetById(leagueId),
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
        /// <returns>Currency object.</returns>
        private Currency ProcessCurrency(string currencyName, decimal currencyRate)
        {
            var storedCurrency = this.currencyRepository.Query()
                                                        .SingleOrDefault(z => z.Name.Equals(
                                                                                         currencyName,
                                                                                         StringComparison.OrdinalIgnoreCase)
                                                                           && z.Rate.Equals(currencyRate));

            if (storedCurrency == null)
            {
                storedCurrency = new Currency
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
        /// <returns>DateFormat object.</returns>
        private DateFormat ProcessDateFormat(string dateFormatMask)
        {
            var storedDateFormat = this.dateFormatRepository.Query()
                                                            .SingleOrDefault(c => c.Mask.Equals(
                                                                                             dateFormatMask,
                                                                                             StringComparison.OrdinalIgnoreCase));

            if (storedDateFormat == null)
            {
                storedDateFormat = new DateFormat
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
        /// <param name="zoneId">Zone to process.</param>
        /// <returns>League object.</returns>
        private League ProcessLeague(
                           BusinessObjects.Hattrick.WorldDetails.League league,
                           int continentId,
                           int zoneId)
        {
            var storedLeague = this.leagueRepository.GetByHattrickId(league.LeagueId);

            if (storedLeague == null)
            {
                storedLeague = new League
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
                    NationalTeam = new LeagueNationalTeam
                    {
                        JuniorNationalTeamId = league.U20TeamId,
                        SeniorNationalTeamId = league.NationalTeamId
                    },
                    Schedule = new LeagueSchedule
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
        private void ProcessLeagueCup(BusinessObjects.Hattrick.WorldDetails.Cup cup, int leagueId)
        {
            var storedCup = this.leagueCupRepository.GetByHattrickId(cup.CupId);

            if (storedCup == null)
            {
                storedCup = new LeagueCup
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
        /// Process Manager.
        /// </summary>
        /// <param name="manager">ManagerCompendium Manager.</param>
        /// <param name="countryId">Country Id.</param>
        /// <returns>Manager object.</returns>
        private Manager ProcessManager(
                            BusinessObjects.Hattrick.ManagerCompendium.Manager manager,
                            int countryId)
        {
            if (manager == null)
            {
                throw new ArgumentNullException(nameof(manager));
            }

            var storedManager = this.managerRepository.GetByHattrickId(manager.UserId);

            if (storedManager == null)
            {
                storedManager = new Manager
                {
                    CountryId = countryId,
                    HattrickId = manager.UserId,
                    SupporterTier = manager.SupporterTier.GetEnum(),
                    User = this.userRepository.Query().Single(),
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
        /// <returns>Region object.</returns>
        private Region ProcessRegion(BusinessObjects.Hattrick.WorldDetails.Region region, int countryId)
        {
            var storedRegion = this.regionRepository.GetByHattrickId(region.RegionId);

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
        /// Process the specified Region.
        /// </summary>
        /// <param name="regionId">Region Id.</param>
        /// <param name="regionName">Region name.</param>
        /// <param name="countryId">Owning Country Id.</param>
        /// <returns>Region object.</returns>
        private Region ProcessRegion(long regionId, string regionName, int countryId)
        {
            var storedRegion = this.regionRepository.GetByHattrickId(regionId);

            if (storedRegion == null)
            {
                storedRegion = new Region
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

        /// <summary>
        /// Process the specified TimeFormat mask.
        /// </summary>
        /// <param name="timeFormatMask">TimeFormat mask to process.</param>
        /// <returns>TimeFormat object.</returns>
        private TimeFormat ProcessTimeFormat(string timeFormatMask)
        {
            var storedTimeFormat = this.timeFormatRepository.Query()
                                                            .SingleOrDefault(c => c.Mask.Equals(
                                                                                             timeFormatMask,
                                                                                             StringComparison.OrdinalIgnoreCase));

            if (storedTimeFormat == null)
            {
                storedTimeFormat = new TimeFormat
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
        /// <returns>Zone object.</returns>
        private Zone ProcessZone(string zoneName)
        {
            var storedZone = this.zoneRepository.Query()
                                                .SingleOrDefault(z => z.Name.Equals(
                                                                                 zoneName,
                                                                                 StringComparison.OrdinalIgnoreCase));

            if (storedZone == null)
            {
                storedZone = new Zone
                {
                    Name = zoneName
                };

                this.zoneRepository.Insert(storedZone);

                this.context.Save();
            }

            return storedZone;
        }

        #endregion Private Methods
    }
}