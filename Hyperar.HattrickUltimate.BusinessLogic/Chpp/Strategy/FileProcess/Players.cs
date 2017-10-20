// -----------------------------------------------------------------------
// <copyright file="Players.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
// -----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessLogic.Chpp.Strategy.FileProcess
{
    using System;
    using System.Globalization;
    using System.Linq;
    using BusinessObjects.App;
    using BusinessObjects.Hattrick.Interface;
    using DataAccess.Database.Interface;
    using Interface;

    /// <summary>
    /// Provides functionality to process Players file.
    /// </summary>
    public class Players : IFileProcessStrategy
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
        /// League repository.
        /// </summary>
        private IRepository<League> leagueRepository;

        /// <summary>
        /// Global season number.
        /// </summary>
        private short seasonNumber;

        /// <summary>
        /// Senior Player repository.
        /// </summary>
        private IRepository<SeniorPlayer> seniorPlayerRepository;

        /// <summary>
        /// Senior Player Season Goals repository.
        /// </summary>
        private IRepository<SeniorPlayerSeasonGoals> seniorPlayerSeasonGoalsRepository;

        /// <summary>
        /// Senior Player Skills repository.
        /// </summary>
        private IRepository<SeniorPlayerSkills> seniorPlayerSkillsRepository;

        /// <summary>
        /// Senior Team repository.
        /// </summary>
        private IRepository<SeniorTeam> seniorTeamRepository;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Players" /> class.
        /// </summary>
        /// <param name="context">Database context.</param>
        /// <param name="countryRepository">Country repository.</param>
        /// <param name="leagueRepository">League repository.</param>
        /// <param name="seniorPlayerRepository">Senior Player repository.</param>
        /// <param name="seniorPlayerSeasonGoalsRepository">Senior Player Season Goals repository.</param>
        /// <param name="seniorPlayerSkillsRepository">Senior Player Skills repository.</param>
        /// <param name="seniorTeamRepository">Senior Team repository.</param>
        public Players(
                   IDatabaseContext context,
                   IRepository<Country> countryRepository,
                   IRepository<League> leagueRepository,
                   IRepository<SeniorPlayer> seniorPlayerRepository,
                   IRepository<SeniorPlayerSeasonGoals> seniorPlayerSeasonGoalsRepository,
                   IRepository<SeniorPlayerSkills> seniorPlayerSkillsRepository,
                   IRepository<SeniorTeam> seniorTeamRepository)
        {
            this.context = context;
            this.countryRepository = countryRepository;
            this.leagueRepository = leagueRepository;
            this.seniorPlayerRepository = seniorPlayerRepository;
            this.seniorPlayerSeasonGoalsRepository = seniorPlayerSeasonGoalsRepository;
            this.seniorPlayerSkillsRepository = seniorPlayerSkillsRepository;
            this.seniorTeamRepository = seniorTeamRepository;
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// Process Players file.
        /// </summary>
        /// <param name="fileToProcess">File to process.</param>
        public void ProcessFile(IXmlEntity fileToProcess)
        {
            if (fileToProcess == null)
            {
                throw new ArgumentNullException(nameof(fileToProcess));
            }

            var file = fileToProcess as BusinessObjects.Hattrick.Players.Root;

            if (file == null)
            {
                throw new ArgumentException(Localization.Strings.Message_UnexpectedObjectType, nameof(fileToProcess));
            }

            if (file.IsPlayingMatch)
            {
                throw new InvalidOperationException(
                          string.Format(
                                     Localization.Strings.Message_TeamIsPlayingMatchCannotProcessPlayers,
                                     file.Team.TeamName));
            }

            this.seasonNumber = this.leagueRepository.Get(1).CurrentSeason;

            var seniorTeam = this.seniorTeamRepository.Get(st => st.HattrickId == file.Team.TeamId)
                                                       .Single();

            foreach (var curPlayer in file.Team.PlayerList)
            {
                this.ProcessPlayer(curPlayer, seniorTeam.Id);
            }
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        /// Process Player.
        /// </summary>
        /// <param name="player">Player to process.</param>
        /// <param name="seniorTeamId">Senior Team Id.</param>
        private void ProcessPlayer(BusinessObjects.Hattrick.Players.Player player, int seniorTeamId)
        {
            if (player == null)
            {
                throw new ArgumentNullException(nameof(player));
            }

            var seniorPlayer = this.seniorPlayerRepository.Get(sp => sp.HattrickId == player.PlayerId)
                                                          .SingleOrDefault();

            if (seniorPlayer == null)
            {
                seniorPlayer = new SeniorPlayer
                {
                    Age = decimal.Parse(
                                      player.Age +
                                      CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator +
                                      player.AgeDays),
                    Aggressiveness = player.Aggressiveness,
                    Agreeability = player.Agreeability,
                    BookingStatus = player.Cards,
                    CareerGoals = player.CareerGoals,
                    CareerHattricks = player.CareerHattricks,
                    Category = player.PlayerCategoryId.HasValue && player.PlayerCategoryId.Value != 0
                             ? player.PlayerCategoryId
                             : null,
                    CountryId = this.countryRepository.Get(c => c.HattrickId == player.CountryId).Single().Id,
                    FirstName = player.FirstName,
                    HasHomegrownBonus = player.MotherClubBonus,
                    HattrickId = player.PlayerId,
                    Honesty = player.Honesty,
                    InjuryStatus = player.InjuryLevel > -1
                                 ? (byte?)player.InjuryLevel
                                 : null,
                    IsOnTransferMarket = player.TransferListed,
                    LastName = player.LastName,
                    Leadership = player.Leadership,
                    MatchesOnJuniorNationalTeam = player.CapsU20,
                    MatchesOnSeniorNationalTeam = player.Caps,
                    NickName = player.NickName,
                    PlaysOnNationalTeam = player.NationalTeamId > 0,
                    SeniorTeamId = seniorTeamId,
                    Specialty = player.Specialty,
                    Statement = player.Statement,
                    Wage = Convert.ToInt32(player.Salary)
                };

                this.seniorPlayerRepository.Insert(seniorPlayer);

                var seasonGoals = new SeniorPlayerSeasonGoals
                {
                    CupGoals = player.CupGoals,
                    FriendlyGoals = player.FriendliesGoals,
                    Season = Convert.ToByte(this.seasonNumber),
                    SeniorPlayerId = seniorPlayer.Id,
                    SeriesGoals = player.LeagueGoals
                };

                this.seniorPlayerSeasonGoalsRepository.Insert(seasonGoals);
            }
            else
            {
                seniorPlayer.Age = decimal.Parse(
                                               player.Age +
                                               CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator +
                                               player.AgeDays);
                seniorPlayer.BookingStatus = player.Cards;
                seniorPlayer.CareerGoals = player.CareerGoals;
                seniorPlayer.CareerHattricks = player.CareerHattricks;
                seniorPlayer.Category = player.PlayerCategoryId.HasValue && player.PlayerCategoryId.Value != 0
                                      ? player.PlayerCategoryId
                                      : null;
                seniorPlayer.FirstName = player.FirstName;
                seniorPlayer.HasHomegrownBonus = player.MotherClubBonus;
                seniorPlayer.InjuryStatus = player.InjuryLevel > -1
                                          ? (byte?)player.InjuryLevel
                                          : null;
                seniorPlayer.IsOnTransferMarket = player.TransferListed;
                seniorPlayer.LastName = player.LastName;
                seniorPlayer.MatchesOnJuniorNationalTeam = player.CapsU20;
                seniorPlayer.MatchesOnSeniorNationalTeam = player.Caps;
                seniorPlayer.NickName = player.NickName;
                seniorPlayer.PlaysOnNationalTeam = player.NationalTeamId > 0;
                seniorPlayer.Statement = player.Statement;
                seniorPlayer.Wage = Convert.ToInt32(player.Salary);

                this.seniorPlayerRepository.Update(seniorPlayer);
            }

            this.context.Save();

            if (player.DefenderSkill.HasValue)
            {
                this.ProcessSkills(
                         player.PlayerForm,
                         player.StaminaSkill,
                         player.Experience,
                         player.Loyalty,
                         player.KeeperSkill.Value,
                         player.DefenderSkill.Value,
                         player.PlaymakerSkill.Value,
                         player.WingerSkill.Value,
                         player.PassingSkill.Value,
                         player.ScorerSkill.Value,
                         player.SetPiecesSkill.Value,
                         Convert.ToInt32(player.TSI),
                         seniorPlayer.Id);
            }

            this.ProcessSeasonGoals(
                     player.LeagueGoals,
                     player.CupGoals,
                     player.FriendliesGoals,
                     Convert.ToByte(seniorPlayer.Country.League.CurrentSeason),
                     seniorPlayer.Id);
        }

        /// <summary>
        /// Processes Player season goals.
        /// </summary>
        /// <param name="seriesGoals">Season series goals.</param>
        /// <param name="cupGoals">Season cup goals.</param>
        /// <param name="friendlyGoals">Season friendly goals.</param>
        /// <param name="seasonNumber">Season number.</param>
        /// <param name="seniorPlayerId">Senior Player Id.</param>
        private void ProcessSeasonGoals(byte seriesGoals, byte cupGoals, byte friendlyGoals, byte seasonNumber, int seniorPlayerId)
        {
            var seasonGoals = this.seniorPlayerSeasonGoalsRepository.Get(spsg => spsg.SeniorPlayerId == seniorPlayerId
                                                                              && spsg.Season == seasonNumber)
                                                                    .SingleOrDefault();

            if (seasonGoals == null)
            {
                seasonGoals = new SeniorPlayerSeasonGoals
                {
                    CupGoals = cupGoals,
                    FriendlyGoals = friendlyGoals,
                    Season = seasonNumber,
                    SeniorPlayerId = seniorPlayerId,
                    SeriesGoals = seriesGoals
                };

                this.seniorPlayerSeasonGoalsRepository.Insert(seasonGoals);
            }
            else
            {
                seasonGoals.CupGoals = cupGoals;
                seasonGoals.FriendlyGoals = friendlyGoals;
                seasonGoals.SeriesGoals = seriesGoals;

                this.seniorPlayerSeasonGoalsRepository.Update(seasonGoals);
            }

            this.context.Save();
        }

        /// <summary>
        /// Processes Player skills.
        /// </summary>
        /// <param name="form">Form level.</param>
        /// <param name="stamina">Stamina level.</param>
        /// <param name="experience">Experience level.</param>
        /// <param name="loyalty">Loyalty level.</param>
        /// <param name="keeper">Keeper level.</param>
        /// <param name="defending">Defending level.</param>
        /// <param name="playmaking">Playmaking level.</param>
        /// <param name="winger">Winger level.</param>
        /// <param name="passing">Passing level.</param>
        /// <param name="scoring">Scoring level.</param>
        /// <param name="setPieces">Set Pieces level.</param>
        /// <param name="totalSkillIndex">Total Skill Index.</param>
        /// <param name="seniorPlayerId">Senior Player Id.</param>
        private void ProcessSkills(
                         byte form,
                         byte stamina,
                         byte experience,
                         byte loyalty,
                         byte keeper,
                         byte defending,
                         byte playmaking,
                         byte winger,
                         byte passing,
                         byte scoring,
                         byte setPieces,
                         int totalSkillIndex,
                         int seniorPlayerId)
        {
            var skills = this.seniorPlayerSkillsRepository.Get(sps => sps.Defending == defending
                                                                   && sps.Experience == experience
                                                                   && sps.Form == form
                                                                   && sps.Keeper == keeper
                                                                   && sps.Loyalty == loyalty
                                                                   && sps.Passing == passing
                                                                   && sps.Playmaking == playmaking
                                                                   && sps.Scoring == scoring
                                                                   && sps.SetPieces == setPieces
                                                                   && sps.Stamina == stamina
                                                                   && sps.Winger == winger
                                                                   && sps.TotalSkillIndex == totalSkillIndex
                                                                   && sps.SeniorPlayerId == seniorPlayerId)
                                                          .OrderBy(sps => sps.UpdatedOn)
                                                          .LastOrDefault();

            if (skills == null)
            {
                skills = new SeniorPlayerSkills
                {
                    Defending = defending,
                    Experience = experience,
                    Form = form,
                    Keeper = keeper,
                    Loyalty = loyalty,
                    Passing = passing,
                    Playmaking = playmaking,
                    Scoring = scoring,
                    SetPieces = setPieces,
                    Stamina = stamina,
                    Winger = winger,
                    TotalSkillIndex = totalSkillIndex,
                    UpdatedOn = DateTime.Now,
                    SeniorPlayerId = seniorPlayerId
                };

                this.seniorPlayerSkillsRepository.Insert(skills);

                this.context.Save();
            }
        }

        #endregion Private Methods
    }
}