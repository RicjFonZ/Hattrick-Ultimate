//-----------------------------------------------------------------------
// <copyright file="WorldManager.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessLogic
{
    using System;
    using System.Linq;
    using BusinessObjects.App.Enums;
    using DataAccess.Database.Interface;

    /// <summary>
    /// Provides functionality to interact with Hattrick World entities.
    /// </summary>
    public class WorldManager
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
        /// Region repository.
        /// </summary>
        private IRepository<BusinessObjects.App.Region> regionRepository;

        /// <summary>
        /// TimeFormat repository.
        /// </summary>
        private IRepository<BusinessObjects.App.TimeFormat> timeFormatRepository;

        /// <summary>
        /// Zone repository.
        /// </summary>
        private IRepository<BusinessObjects.App.Zone> zoneRepository;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="WorldManager" /> class.
        /// </summary>
        /// <param name="context">Database context.</param>
        /// <param name="continentRepository">Continent repository.</param>
        /// <param name="countryRepository">Country repository.</param>
        /// <param name="currencyRepository">Currency repository.</param>
        /// <param name="dateFormatRepository">DateFormat repository.</param>
        /// <param name="leagueCupRepository">LeagueCup repository.</param>
        /// <param name="leagueNationalTeamRepository">LeagueNationalTeam repository.</param>
        /// <param name="leagueRepository">League repository.</param>
        /// <param name="leagueScheduleRepository">LeagueSchedule repository.</param>
        /// <param name="regionRepository">Region repository.</param>
        /// <param name="timeFormatRepository">TimeFormat repository.</param>
        /// <param name="zoneRepository">Zone repository.</param>
        public WorldManager(
                   IDatabaseContext context,
                   IRepository<BusinessObjects.App.Continent> continentRepository,
                   IRepository<BusinessObjects.App.Country> countryRepository,
                   IRepository<BusinessObjects.App.Currency> currencyRepository,
                   IRepository<BusinessObjects.App.DateFormat> dateFormatRepository,
                   IRepository<BusinessObjects.App.LeagueCup> leagueCupRepository,
                   IRepository<BusinessObjects.App.LeagueNationalTeam> leagueNationalTeamRepository,
                   IRepository<BusinessObjects.App.League> leagueRepository,
                   IRepository<BusinessObjects.App.LeagueSchedule> leagueScheduleRepository,
                   IRepository<BusinessObjects.App.Region> regionRepository,
                   IRepository<BusinessObjects.App.TimeFormat> timeFormatRepository,
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
            this.regionRepository = regionRepository;
            this.timeFormatRepository = timeFormatRepository;
            this.zoneRepository = zoneRepository;
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// Process WorldDetails XML File.
        /// </summary>
        /// <param name="worldDetails">Parsed file to process.</param>
        public void ProcessWorldDetails(BusinessObjects.Hattrick.WorldDetails.Root worldDetails)
        {
            if (worldDetails == null)
            {
                throw new ArgumentNullException(nameof(worldDetails));
            }

            if (worldDetails.LeagueList == null)
            {
                throw new ArgumentNullException(nameof(worldDetails.LeagueList));
            }

            try
            {
                this.context.BeginTransaction();

                foreach (var curLeague in worldDetails.LeagueList)
                {
                    var continent = this.ProcessContinent(curLeague.Continent);
                    var zone = this.ProcessZone(curLeague.ZoneName);

                    var league = this.ProcessLeague(curLeague, continent, zone);

                    if (league.Cups != null)
                    {
                        foreach (var cup in curLeague.Cups)
                        {
                            this.ProcessLeagueCup(cup, league);
                        }
                    }

                    // If there's a country to process and wasn't processed before.
                    if (curLeague.Country != null && league.Country == null)
                    {
                        var currency = this.ProcessCurrency(curLeague.Country.CurrencyName, curLeague.Country.CurrencyRate);
                        var dateFormat = this.ProcessDateFormat(curLeague.Country.DateFormat);
                        var timeFormat = this.ProcessTimeFormat(curLeague.Country.TimeFormat);

                        var country = this.ProcessCountry(curLeague.Country, currency, dateFormat, timeFormat, league);

                        if (curLeague.Country.RegionList != null)
                        {
                            foreach (var curRegion in curLeague.Country.RegionList)
                            {
                                this.ProcessRegion(curRegion, country);
                            }
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

        #region Private Methods

        /// <summary>
        /// Process the specified Continent name.
        /// </summary>
        /// <param name="continentName">Continent name to process.</param>
        /// <returns>BusinessObjects.App.Continent object.</returns>
        private BusinessObjects.App.Continent ProcessContinent(string continentName)
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
        /// <param name="currency">Stored currency.</param>
        /// <param name="dateFormat">Stored date format.</param>
        /// <param name="timeFormat">Stored time format.</param>
        /// <param name="league">Stored league.</param>
        /// <returns>Business.App.Country object.</returns>
        private BusinessObjects.App.Country ProcessCountry(
                                                        BusinessObjects.Hattrick.WorldDetails.Country country,
                                                        BusinessObjects.App.Currency currency,
                                                        BusinessObjects.App.DateFormat dateFormat,
                                                        BusinessObjects.App.TimeFormat timeFormat,
                                                        BusinessObjects.App.League league)
        {
            var storedCountry = this.countryRepository.Get(c => c.HattrickId == country.CountryId)
                                                      .SingleOrDefault();

            if (storedCountry == null)
            {
                storedCountry = new BusinessObjects.App.Country
                {
                    Code = country.CountryCode,
                    Currency = currency,
                    DateFormat = dateFormat,
                    HattrickId = country.CountryId,
                    League = league,
                    Name = country.CountryName,
                    TimeFormat = timeFormat
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
        private BusinessObjects.App.Currency ProcessCurrency(string currencyName, decimal currencyRate)
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
        private BusinessObjects.App.DateFormat ProcessDateFormat(string dateFormatMask)
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
        /// <param name="continent">League continent.</param>
        /// <param name="zone">Zone to process</param>
        /// <returns>BusinessObjects.App.League object.</returns>
        private BusinessObjects.App.League ProcessLeague(
                                               BusinessObjects.Hattrick.WorldDetails.League league,
                                               BusinessObjects.App.Continent continent,
                                               BusinessObjects.App.Zone zone)
        {
            var storedLeague = this.leagueRepository.Get(l => l.HattrickId == league.LeagueId)
                                                    .SingleOrDefault();

            if (storedLeague == null)
            {
                storedLeague = new BusinessObjects.App.League
                {
                    ActiveTeams = league.ActiveTeams,
                    ActiveUsers = league.ActiveUsers,
                    Continent = continent,
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
                    Zone = zone
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
        /// <param name="league">Cup owning league.</param>
        private void ProcessLeagueCup(BusinessObjects.Hattrick.WorldDetails.Cup cup, BusinessObjects.App.League league)
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
                    League = league,
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
        /// Process the specified Region.
        /// </summary>
        /// <param name="region">Region to process.</param>
        /// <param name="country">Region owning country.</param>
        private void ProcessRegion(BusinessObjects.Hattrick.WorldDetails.Region region, BusinessObjects.App.Country country)
        {
            var storedRegion = this.regionRepository.Get()
                                                    .SingleOrDefault(r => r.HattrickId == region.RegionId);

            if (storedRegion == null)
            {
                storedRegion = new BusinessObjects.App.Region
                {
                    HattrickId = region.RegionId,
                    Name = region.RegionName,
                    Country = country
                };

                this.regionRepository.Insert(storedRegion);

                this.context.Save();
            }
        }

        /// <summary>
        /// Process the specified TimeFormat mask.
        /// </summary>
        /// <param name="timeFormatMask">TimeFormat mask to process.</param>
        /// <returns>BusinessObjects.App.TimeFormat object.</returns>
        private BusinessObjects.App.TimeFormat ProcessTimeFormat(string timeFormatMask)
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
        private BusinessObjects.App.Zone ProcessZone(string zoneName)
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

        #endregion Private Methods
    }
}