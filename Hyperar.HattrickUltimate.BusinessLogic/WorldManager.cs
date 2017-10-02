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
    using DataAccess.Database.Interface;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class WorldManager
    {
        #region Private Fields

        private IDatabaseContext context;
        private IRepository<BusinessObjects.App.Continent> continentRepository;
        private IRepository<BusinessObjects.App.Country> countryRepository;
        private IRepository<BusinessObjects.App.Currency> currencyRepository;
        private IRepository<BusinessObjects.App.DateFormat> dateFormatRepository;
        private IRepository<BusinessObjects.App.League> leagueRepository;
        private IRepository<BusinessObjects.App.Region> regionRepository;
        private IRepository<BusinessObjects.App.TimeFormat> timeFormatRepository;
        private IRepository<BusinessObjects.App.Zone> zoneRepository;

        #endregion Private Fields

        #region Public Constructors

        public WorldManager(
                   IDatabaseContext context,
                   IRepository<BusinessObjects.App.Continent> continentRepository,
                   IRepository<BusinessObjects.App.Country> countryRepository,
                   IRepository<BusinessObjects.App.Currency> currencyRepository,
                   IRepository<BusinessObjects.App.DateFormat> dateFormatRepository,
                   IRepository<BusinessObjects.App.League> leagueRepository,
                   IRepository<BusinessObjects.App.Region> regionRepository,
                   IRepository<BusinessObjects.App.TimeFormat> timeFormatRepository,
                   IRepository<BusinessObjects.App.Zone> zoneRepository)
        {
            this.context = context;
            this.continentRepository = continentRepository;
            this.countryRepository = countryRepository;
            this.currencyRepository = currencyRepository;
            this.dateFormatRepository = dateFormatRepository;
            this.leagueRepository = leagueRepository;
            this.regionRepository = regionRepository;
            this.timeFormatRepository = timeFormatRepository;
            this.zoneRepository = zoneRepository;
        }

        #endregion Public Constructors

        #region Public Methods

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

                    if (curLeague.Country != null)
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

        private BusinessObjects.App.Continent ProcessContinent(string continentName)
        {
            var storedContinent = this.continentRepository.Get()
                                                          .SingleOrDefault(c => c.Name.Equals(
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
                    Divisions = league.NumberOfLevels,
                    EnglishName = league.EnglishName,
                    FullName = league.LeagueName,
                    HattrickId = league.LeagueId,
                    JuniorNationalTeamId = league.U20TeamId,
                    SeasonOffset = league.SeasonOffset,
                    SeniorNationalTeamId = league.NationalTeamId,
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
                storedLeague.Divisions = league.NumberOfLevels;
                storedLeague.WaitingUsers = league.WaitingUsers;

                this.leagueRepository.Update(storedLeague);
            }

            this.context.Save();

            return storedLeague;
        }

        private BusinessObjects.App.Region ProcessRegion(BusinessObjects.Hattrick.WorldDetails.Region region, BusinessObjects.App.Country country)
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

            return storedRegion;
        }

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