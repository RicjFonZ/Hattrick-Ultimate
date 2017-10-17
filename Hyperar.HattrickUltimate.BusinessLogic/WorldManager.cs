//-----------------------------------------------------------------------
// <copyright file="WorldManager.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessLogic
{
    using System;

    /// <summary>
    /// Provides functionality to interact with Hattrick World entities.
    /// </summary>
    public class WorldManager
    {
        #region Private Fields

        /// <summary>
        /// World Actions.
        /// </summary>
        private Actions.World worldActions;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="WorldManager" /> class.
        /// </summary>
        /// <param name="worldActions">World Actions.</param>
        public WorldManager(
                   Actions.World worldActions)
        {
            this.worldActions = worldActions;
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

            foreach (var curLeague in worldDetails.LeagueList)
            {
                var continent = this.worldActions.ProcessContinent(curLeague.Continent);
                var zone = this.worldActions.ProcessZone(curLeague.ZoneName);

                var league = this.worldActions.ProcessLeague(curLeague, continent.Id, zone.Id);

                if (league.Cups != null)
                {
                    foreach (var cup in curLeague.Cups)
                    {
                        this.worldActions.ProcessLeagueCup(cup, league.Id);
                    }
                }

                // If there's a country to process and wasn't processed before.
                if (curLeague.Country != null)
                {
                    var currency = this.worldActions.ProcessCurrency(
                                                         curLeague.Country.CurrencyName,
                                                         curLeague.Country.CurrencyRate);

                    var dateFormat = this.worldActions.ProcessDateFormat(curLeague.Country.DateFormat);
                    var timeFormat = this.worldActions.ProcessTimeFormat(curLeague.Country.TimeFormat);

                    var country = this.worldActions.ProcessCountry(
                                                        curLeague.Country,
                                                        currency.Id,
                                                        dateFormat.Id,
                                                        timeFormat.Id,
                                                        league.Id);

                    if (curLeague.Country.RegionList != null)
                    {
                        foreach (var curRegion in curLeague.Country.RegionList)
                        {
                            this.worldActions.ProcessRegion(curRegion, country.Id);
                        }
                    }
                }
            }
        }

        #endregion Public Methods
    }
}