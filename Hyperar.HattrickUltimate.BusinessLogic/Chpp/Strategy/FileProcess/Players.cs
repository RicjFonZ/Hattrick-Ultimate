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
        private readonly IDatabaseContext context;

        /// <summary>
        /// Country repository.
        /// </summary>
        private readonly IHattrickRepository<Country> countryRepository;

        /// <summary>
        /// Current culture number decimal separator.
        /// </summary>
        private readonly string decimalSeparator;

        /// <summary>
        /// League repository.
        /// </summary>
        private readonly IHattrickRepository<League> leagueRepository;

        /// <summary>
        /// SeniorPlayerAvatar repository.
        /// </summary>
        private readonly IRepository<SeniorPlayerAvatar> seniorPlayerAvatarRepository;

        /// <summary>
        /// Senior Player repository.
        /// </summary>
        private readonly IHattrickRepository<SeniorPlayer> seniorPlayerRepository;

        /// <summary>
        /// Senior Player Week Log repository.
        /// </summary>
        private readonly IRepository<SeniorPlayerWeekLog> seniorPlayerWeekLogRepository;

        /// <summary>
        /// Senior Team repository.
        /// </summary>
        private readonly IHattrickRepository<SeniorTeam> seniorTeamRepository;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Players"/> class.
        /// </summary>
        /// <param name="context">Database context.</param>
        /// <param name="countryRepository">Country repository.</param>
        /// <param name="leagueRepository">League repository.</param>
        /// <param name="seniorPlayerAvatarRepository">Senior Player Avatar repository.</param>
        /// <param name="seniorPlayerRepository">Senior Player repository.</param>
        /// <param name="seniorPlayerWeekLogRepository">Senior Player Week Log repository.</param>
        /// <param name="seniorTeamRepository">Senior Team repository.</param>
        public Players(
                   IDatabaseContext context,
                   IHattrickRepository<Country> countryRepository,
                   IHattrickRepository<League> leagueRepository,
                   IRepository<SeniorPlayerAvatar> seniorPlayerAvatarRepository,
                   IHattrickRepository<SeniorPlayer> seniorPlayerRepository,
                   IRepository<SeniorPlayerWeekLog> seniorPlayerWeekLogRepository,
                   IHattrickRepository<SeniorTeam> seniorTeamRepository)
        {
            this.context = context;
            this.countryRepository = countryRepository;
            this.leagueRepository = leagueRepository;
            this.seniorPlayerAvatarRepository = seniorPlayerAvatarRepository;
            this.seniorPlayerRepository = seniorPlayerRepository;
            this.seniorPlayerWeekLogRepository = seniorPlayerWeekLogRepository;
            this.seniorTeamRepository = seniorTeamRepository;
            this.decimalSeparator = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
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

            if (!(fileToProcess is BusinessObjects.Hattrick.Players.Root file))
            {
                throw new ArgumentException(Localization.Messages.UnexpectedObjectType, nameof(fileToProcess));
            }

            if (file.IsPlayingMatch)
            {
                throw new InvalidOperationException(
                          string.Format(
                                     Localization.Messages.TeamIsPlayingMatchCannotProcessPlayers,
                                     file.Team.TeamName));
            }

            var seniorTeam = this.seniorTeamRepository.GetByHattrickId(file.Team.TeamId);

            var processingDate = DateTime.Now;

            var sampleLeague = this.leagueRepository.GetByHattrickId(1);

            short season = sampleLeague.CurrentSeason;
            byte week = sampleLeague.CurrentRound;

            foreach (var curPlayer in file.Team.PlayerList)
            {
                this.ProcessPlayer(curPlayer, season, week, seniorTeam.Id);
            }

            // Gets the current Team's Players Hattrick ID.
            var fileSeniorPlayerIds = file.Team.PlayerList.Select(sp => sp.PlayerId);

            // Gets the stored Team's Players ID.
            var seniorPlayerIdsToDelete = this.seniorPlayerRepository.Query(sp => !fileSeniorPlayerIds.Contains(sp.HattrickId)
                                                                             && sp.SeniorTeam.HattrickId == file.Team.TeamId)
                                                                     .Select(sp => sp.Id)
                                                                     .ToList();

            // If there are players to delete.
            if (seniorPlayerIdsToDelete.Any())
            {
                foreach (int curPlayerId in seniorPlayerIdsToDelete)
                {
                    var seniorPlayerToDelete = this.seniorPlayerRepository.GetById(curPlayerId);

                    this.seniorPlayerAvatarRepository.Delete(seniorPlayerToDelete.Avatar.Id);

                    int[] weekLogsToDelete = seniorPlayerToDelete.WeekLogs.Select(wl => wl.Id)
                                                                                .ToArray();
                    foreach (int curId in weekLogsToDelete)
                    {
                        this.seniorPlayerWeekLogRepository.Delete(curId);
                    }

                    this.seniorPlayerRepository.Delete(curPlayerId);
                }

                this.context.Save();
            }
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        /// Process Player.
        /// </summary>
        /// <param name="player">Player to process.</param>
        /// <param name="season">Current season.</param>
        /// <param name="week">Current week.</param>
        /// <param name="seniorTeamId">Senior Team Id.</param>
        private void ProcessPlayer(BusinessObjects.Hattrick.Players.Player player, short season, byte week, int seniorTeamId)
        {
            if (player == null)
            {
                throw new ArgumentNullException(nameof(player));
            }

            var seniorPlayer = this.seniorPlayerRepository.GetByHattrickId(player.PlayerId);

            if (seniorPlayer == null)
            {
                seniorPlayer = new SeniorPlayer();
            }

            seniorPlayer.AgeDays = player.AgeDays;
            seniorPlayer.Aggressiveness = player.Aggressiveness;
            seniorPlayer.Agreeability = player.Agreeability;
            seniorPlayer.BookingStatus = player.Cards;
            seniorPlayer.Category = player.PlayerCategoryId.HasValue && player.PlayerCategoryId.Value != 0 ? player.PlayerCategoryId : null;
            seniorPlayer.CountryId = this.countryRepository.GetByHattrickId(player.CountryId).Id;
            seniorPlayer.FirstName = player.FirstName;
            seniorPlayer.HasHomegrownBonus = player.MotherClubBonus;
            seniorPlayer.HattrickId = player.PlayerId;
            seniorPlayer.Honesty = player.Honesty;
            seniorPlayer.IsOnTransferMarket = player.TransferListed;
            seniorPlayer.LastName = player.LastName;
            seniorPlayer.Leadership = player.Leadership;
            seniorPlayer.MatchesOnJuniorNationalTeam = player.CapsU20;
            seniorPlayer.MatchesOnSeniorNationalTeam = player.Caps;
            seniorPlayer.NickName = string.IsNullOrWhiteSpace(player.NickName) ? null : player.NickName;
            seniorPlayer.PlaysOnNationalTeam = player.NationalTeamId > 0;
            seniorPlayer.SeniorTeamId = seniorTeamId;
            seniorPlayer.ShirtNumber = player.PlayerNumber == 100 ? (byte?)null : player.PlayerNumber;
            seniorPlayer.Specialty = player.Specialty;
            seniorPlayer.Statement = player.Statement;

            if (seniorPlayer.Id == 0)
            {
                this.seniorPlayerRepository.Insert(seniorPlayer);
            }
            else
            {
                this.seniorPlayerRepository.Update(seniorPlayer);
            }

            this.context.Save();

            this.ProcessWeekLog(
                     season,
                     week,
                     player.Age,
                     player.InjuryLevel,
                     player.CareerGoals,
                     player.CareerHattricks,
                     player.LeagueGoals,
                     player.CupGoals,
                     player.FriendliesGoals,
                     player.PlayerForm,
                     player.StaminaSkill,
                     player.KeeperSkill.Value,
                     player.DefenderSkill.Value,
                     player.PlaymakerSkill.Value,
                     player.WingerSkill.Value,
                     player.PassingSkill.Value,
                     player.ScorerSkill.Value,
                     player.SetPiecesSkill.Value,
                     player.Loyalty,
                     player.Experience,
                     Convert.ToInt32(player.TSI),
                     Convert.ToInt32(player.Salary),
                     seniorPlayer.Id);
        }

        /// <summary>
        /// Process Senior Player Week Log.
        /// </summary>
        /// <param name="season">Current Season.</param>
        /// <param name="week">Current Week.</param>
        /// <param name="age">Age in Years.</param>
        /// <param name="healthStatus">Health Status.</param>
        /// <param name="careerGoals">Career Goals.</param>
        /// <param name="careerHattricks">Career Hattricks.</param>
        /// <param name="seriesGoals">Series Goals.</param>
        /// <param name="cupGoals">Cup Goals.</param>
        /// <param name="friendlyGoals">Friendly Goals.</param>
        /// <param name="form">Form Level.</param>
        /// <param name="stamina">Stamina Level.</param>
        /// <param name="keeper">Keeper Level.</param>
        /// <param name="defending">Defending Level.</param>
        /// <param name="playmaking">Playmaking Level.</param>
        /// <param name="winger">Winger Level.</param>
        /// <param name="passing">Passing Level.</param>
        /// <param name="scoring">Scoring Level.</param>
        /// <param name="setPieces">Set Pieces Level.</param>
        /// <param name="loyalty">Loyalty Level.</param>
        /// <param name="experience">Experience Level.</param>
        /// <param name="totalSkillIndex">Total Skill Index.</param>
        /// <param name="wage">Player's Wage.</param>
        /// <param name="seniorPlayerId">Senior Player ID.</param>
        private void ProcessWeekLog(
            short season,
            byte week,
            byte age,
            int healthStatus,
            short careerGoals,
            short careerHattricks,
            byte seriesGoals,
            byte cupGoals,
            byte friendlyGoals,
            byte form,
            byte stamina,
            byte keeper,
            byte defending,
            byte playmaking,
            byte winger,
            byte passing,
            byte scoring,
            byte setPieces,
            byte loyalty,
            byte experience,
            int totalSkillIndex,
            int wage,
            int seniorPlayerId)
        {
            var weekLog = this.seniorPlayerWeekLogRepository.Query()
                                                            .SingleOrDefault(wl => wl.Season == season
                                                                                && wl.Week == week
                                                                                && wl.SeniorPlayerId == seniorPlayerId);

            bool shouldInsert = false;

            if (weekLog == null)
            {
                weekLog = new SeniorPlayerWeekLog
                {
                    Age = age,
                    CareerGoals = careerGoals,
                    CareerHattricks = careerHattricks,
                    CupGoals = cupGoals,
                    Defending = defending,
                    Experience = experience,
                    Form = form,
                    FriendlyGoals = friendlyGoals,
                    HealthStatus = healthStatus,
                    Keeper = keeper,
                    Loyalty = loyalty,
                    Passing = passing,
                    Playmaking = playmaking,
                    Scoring = scoring,
                    Season = season,
                    SeniorPlayerId = seniorPlayerId,
                    SeriesGoals = seriesGoals,
                    SetPieces = setPieces,
                    Stamina = stamina,
                    TotalSkillIndex = totalSkillIndex,
                    Wage = wage,
                    Week = week,
                    Winger = winger
                };

                shouldInsert = true;
            }
            else
            {
                weekLog.Age = age;
                weekLog.CareerGoals = careerGoals;
                weekLog.CareerHattricks = careerHattricks;
                weekLog.CupGoals = cupGoals;
                weekLog.Defending = defending;
                weekLog.Experience = experience;
                weekLog.Form = form;
                weekLog.FriendlyGoals = friendlyGoals;
                weekLog.HealthStatus = healthStatus;
                weekLog.Keeper = keeper;
                weekLog.Loyalty = loyalty;
                weekLog.Passing = passing;
                weekLog.Playmaking = playmaking;
                weekLog.Scoring = scoring;
                weekLog.SeriesGoals = seriesGoals;
                weekLog.SetPieces = setPieces;
                weekLog.Stamina = stamina;
                weekLog.TotalSkillIndex = totalSkillIndex;
                weekLog.Wage = wage;
                weekLog.Winger = winger;
            }

            if (shouldInsert)
            {
                this.seniorPlayerWeekLogRepository.Insert(weekLog);
            }
            else
            {
                this.seniorPlayerWeekLogRepository.Update(weekLog);
            }

            this.context.Save();
        }

        #endregion Private Methods
    }
}