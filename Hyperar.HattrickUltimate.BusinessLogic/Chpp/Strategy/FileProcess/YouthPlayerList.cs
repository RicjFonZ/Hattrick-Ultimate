// -----------------------------------------------------------------------
// <copyright file="YouthPlayerList.cs" company="Hyperar">
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
    /// Provides functionality to process YouthPlayerList file.
    /// </summary>
    public class YouthPlayerList : IFileProcessStrategy
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
        /// JuniorPlayerAvatar repository.
        /// </summary>
        private readonly IRepository<JuniorPlayerAvatar> juniorPlayerAvatarRepository;

        /// <summary>
        /// Junior Player repository.
        /// </summary>
        private readonly IHattrickRepository<JuniorPlayer> juniorPlayerRepository;

        /// <summary>
        /// Junior Player Week Log repository.
        /// </summary>
        private readonly IRepository<JuniorPlayerWeekLog> juniorPlayerWeekLogRepository;

        /// <summary>
        /// Junior Team repository.
        /// </summary>
        private readonly IHattrickRepository<JuniorTeam> juniorTeamRepository;

        /// <summary>
        /// League repository.
        /// </summary>
        private readonly IHattrickRepository<League> leagueRepository;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="YouthPlayerList"/> class.
        /// </summary>
        /// <param name="context">Database context.</param>
        /// <param name="countryRepository">Country repository.</param>
        /// <param name="leagueRepository">League repository.</param>
        /// <param name="juniorPlayerAvatarRepository">Junior Player Avatar repository.</param>
        /// <param name="juniorPlayerRepository">Junior Player repository.</param>
        /// <param name="juniorPlayerWeekLogRepository">Junior Player Week Log repository.</param>
        /// <param name="juniorTeamRepository">Junior Team repository.</param>
        public YouthPlayerList(
                   IDatabaseContext context,
                   IHattrickRepository<Country> countryRepository,
                   IHattrickRepository<League> leagueRepository,
                   IRepository<JuniorPlayerAvatar> juniorPlayerAvatarRepository,
                   IHattrickRepository<JuniorPlayer> juniorPlayerRepository,
                   IRepository<JuniorPlayerWeekLog> juniorPlayerWeekLogRepository,
                   IHattrickRepository<JuniorTeam> juniorTeamRepository)
        {
            this.context = context;
            this.countryRepository = countryRepository;
            this.leagueRepository = leagueRepository;
            this.juniorPlayerAvatarRepository = juniorPlayerAvatarRepository;
            this.juniorPlayerRepository = juniorPlayerRepository;
            this.juniorPlayerWeekLogRepository = juniorPlayerWeekLogRepository;
            this.juniorTeamRepository = juniorTeamRepository;
            this.decimalSeparator = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// Process YouthPlayerList file.
        /// </summary>
        /// <param name="fileToProcess">File to process.</param>
        public void ProcessFile(IXmlEntity fileToProcess)
        {
            if (fileToProcess == null)
            {
                throw new ArgumentNullException(nameof(fileToProcess));
            }

            if (!(fileToProcess is BusinessObjects.Hattrick.YouthPlayerList.Root file))
            {
                throw new ArgumentException(Localization.Messages.UnexpectedObjectType, nameof(fileToProcess));
            }

            if (!file.PlayerList.Any())
            {
                return;
            }

            var juniorTeam = this.juniorTeamRepository.GetByHattrickId(file.PlayerList.First().OwningYouthTeam.YouthTeamId);

            var processingDate = DateTime.Now;

            var sampleLeague = this.leagueRepository.GetByHattrickId(1);

            short season = sampleLeague.CurrentSeason;
            byte week = sampleLeague.CurrentRound;

            foreach (var curPlayer in file.PlayerList)
            {
                this.ProcessPlayer(curPlayer, season, week, juniorTeam.Id);
            }

            // Gets the current Team's YouthPlayerList Hattrick ID.
            var fileJuniorPlayerIds = file.PlayerList.Select(sp => sp.YouthPlayerId);

            // Gets the stored Team's YouthPlayerList ID.
            var juniorPlayerIdsToDelete = this.juniorPlayerRepository.Query(sp => !fileJuniorPlayerIds.Contains(sp.HattrickId)
                                                                               && sp.JuniorTeam.HattrickId == juniorTeam.HattrickId)
                                                                     .Select(sp => sp.Id)
                                                                     .ToList();

            // If there are players to delete.
            if (juniorPlayerIdsToDelete.Any())
            {
                foreach (int curPlayerId in juniorPlayerIdsToDelete)
                {
                    var juniorPlayerToDelete = this.juniorPlayerRepository.GetById(curPlayerId);

                    this.juniorPlayerAvatarRepository.Delete(juniorPlayerToDelete.Avatar.Id);

                    int[] weekLogsToDelete = juniorPlayerToDelete.WeekLogs.Select(wl => wl.Id)
                                                                          .ToArray();
                    foreach (int curId in weekLogsToDelete)
                    {
                        this.juniorPlayerWeekLogRepository.Delete(curId);
                    }

                    this.juniorPlayerRepository.Delete(curPlayerId);
                }

                this.context.Save();
            }
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        /// Process Player.
        /// </summary>
        /// <param name="youthPlayer">Player to process.</param>
        /// <param name="season">Current season.</param>
        /// <param name="week">Current week.</param>
        /// <param name="juniorTeamId">Junior Team Id.</param>
        private void ProcessPlayer(
            BusinessObjects.Hattrick.YouthPlayerList.YouthPlayer youthPlayer,
            short season,
            byte week,
            int juniorTeamId)
        {
            if (youthPlayer == null)
            {
                throw new ArgumentNullException(nameof(youthPlayer));
            }

            var juniorPlayer = this.juniorPlayerRepository.GetByHattrickId(youthPlayer.YouthPlayerId);

            if (juniorPlayer == null)
            {
                juniorPlayer = new JuniorPlayer
                {
                    AgeDays = youthPlayer.AgeDays,
                    ArrivedOn = youthPlayer.ArrivalDate,
                    BookingStatus = youthPlayer.Cards,
                    Category = youthPlayer.PlayerCategoryId.HasValue && youthPlayer.PlayerCategoryId.Value != 0 ? youthPlayer.PlayerCategoryId : null,
                    DaysToPromote = youthPlayer.CanBePromotedIn,
                    FirstName = youthPlayer.FirstName,
                    HattrickId = youthPlayer.YouthPlayerId,
                    JuniorTeamId = juniorTeamId,
                    LastName = youthPlayer.LastName,
                    NickName = !string.IsNullOrWhiteSpace(youthPlayer.NickName) ? youthPlayer.NickName : null,
                    OwnerNotes = !string.IsNullOrWhiteSpace(youthPlayer.OwnerNotes) ? youthPlayer.OwnerNotes : null,
                    ShirtNumber = youthPlayer.PlayerNumber == 100 ? (byte?)null : youthPlayer.PlayerNumber,
                    Specialty = youthPlayer.Specialty,
                    Statement = !string.IsNullOrWhiteSpace(youthPlayer.Statement) ? youthPlayer.Statement : null,
                    LastMatchRating = youthPlayer.LastMatch?.Rating
                };

                this.juniorPlayerRepository.Insert(juniorPlayer);
            }
            else
            {
                juniorPlayer.BookingStatus = youthPlayer.Cards;
                juniorPlayer.Category = youthPlayer.PlayerCategoryId.HasValue && youthPlayer.PlayerCategoryId.Value != 0 ? youthPlayer.PlayerCategoryId : null;
                juniorPlayer.DaysToPromote = youthPlayer.CanBePromotedIn;
                juniorPlayer.FirstName = youthPlayer.FirstName;
                juniorPlayer.LastName = youthPlayer.LastName;
                juniorPlayer.NickName = !string.IsNullOrWhiteSpace(youthPlayer.NickName) ? youthPlayer.NickName : null;
                juniorPlayer.OwnerNotes = !string.IsNullOrWhiteSpace(youthPlayer.OwnerNotes) ? youthPlayer.OwnerNotes : null;
                juniorPlayer.ShirtNumber = youthPlayer.PlayerNumber == 100 ? (byte?)null : youthPlayer.PlayerNumber;
                juniorPlayer.Specialty = youthPlayer.Specialty;
                juniorPlayer.Statement = !string.IsNullOrWhiteSpace(youthPlayer.Statement) ? youthPlayer.Statement : null;

                this.juniorPlayerRepository.Update(juniorPlayer);
            }

            this.context.Save();

            this.ProcessWeekLog(
                     season,
                     week,
                     youthPlayer.Age,
                     youthPlayer.InjuryLevel,
                     youthPlayer.CareerGoals,
                     youthPlayer.CareerHattricks,
                     youthPlayer.LeagueGoals,
                     youthPlayer.FriendlyGoals,
                     youthPlayer.PlayerSkills,
                     juniorPlayer.Id);
        }

        /// <summary>
        /// Process Junior Player Week Log.
        /// </summary>
        /// <param name="season">Current Season.</param>
        /// <param name="week">Current Week.</param>
        /// <param name="age">Age in Years.</param>
        /// <param name="healthStatus">Health Status.</param>
        /// <param name="careerGoals">Career Goals.</param>
        /// <param name="careerHattricks">Career Hattricks.</param>
        /// <param name="seriesGoals">Series Goals.</param>
        /// <param name="friendlyGoals">Friendly Goals.</param>
        /// <param name="skills">Junior Player Skills.</param>
        /// <param name="juniorPlayerId">Junior Player ID.</param>
        private void ProcessWeekLog(
            short season,
            byte week,
            byte age,
            int healthStatus,
            short careerGoals,
            short careerHattricks,
            byte seriesGoals,
            byte friendlyGoals,
            BusinessObjects.Hattrick.YouthPlayerList.PlayerSkills skills,
            int juniorPlayerId)
        {
            var weekLog = this.juniorPlayerWeekLogRepository.Query()
                                                            .SingleOrDefault(wl => wl.Season == season
                                                                                && wl.Week == week
                                                                                && wl.JuniorPlayerId == juniorPlayerId);

            bool shouldInsert = false;

            if (weekLog == null)
            {
                weekLog = new JuniorPlayerWeekLog
                {
                    Age = age,
                    CareerGoals = careerGoals,
                    CareerHattricks = careerHattricks,
                    Defending = skills.DefenderSkill.Value,
                    DefendingMax = skills.DefenderSkillMax.Value,
                    DefendingMaxReached = skills.DefenderSkill.IsMaxReached,
                    FriendlyGoals = friendlyGoals,
                    HealthStatus = healthStatus,
                    Keeper = skills.KeeperSkill.Value,
                    KeeperMax = skills.KeeperSkillMax.Value,
                    KeeperMaxReached = skills.KeeperSkill.IsMaxReached,
                    Passing = skills.PassingSkill.Value,
                    PassingMax = skills.PassingSkillMax.Value,
                    PassingMaxReached = skills.PassingSkill.IsMaxReached,
                    Playmaking = skills.PlaymakerSkill.Value,
                    PlaymakingMax = skills.PlaymakerSkillMax.Value,
                    PlaymakingMaxReached = skills.PlaymakerSkill.IsMaxReached,
                    Scoring = skills.ScorerSkill.Value,
                    ScoringMax = skills.ScorerSkillMax.Value,
                    ScoringMaxReached = skills.ScorerSkill.IsMaxReached,
                    Season = season,
                    JuniorPlayerId = juniorPlayerId,
                    SeriesGoals = seriesGoals,
                    SetPieces = skills.SetPiecesSkill.Value,
                    SetPiecesMax = skills.SetPiecesSkillMax.Value,
                    SetPiecesMaxReached = skills.SetPiecesSkill.IsMaxReached,
                    Week = week,
                    Winger = skills.WingerSkill.Value,
                    WingerMax = skills.WingerSkillMax.Value,
                    WingerMaxReached = skills.WingerSkill.IsMaxReached
                };

                shouldInsert = true;
            }
            else
            {
                weekLog.Age = age;
                weekLog.CareerGoals = careerGoals;
                weekLog.CareerHattricks = careerHattricks;
                weekLog.Defending = skills.DefenderSkill.Value;
                weekLog.DefendingMax = skills.DefenderSkillMax.Value;
                weekLog.DefendingMaxReached = skills.DefenderSkill.IsMaxReached;
                weekLog.FriendlyGoals = friendlyGoals;
                weekLog.HealthStatus = healthStatus;
                weekLog.Keeper = skills.KeeperSkill.Value;
                weekLog.KeeperMax = skills.KeeperSkillMax.Value;
                weekLog.KeeperMaxReached = skills.KeeperSkill.IsMaxReached;
                weekLog.Passing = skills.PassingSkill.Value;
                weekLog.PassingMax = skills.PassingSkillMax.Value;
                weekLog.PassingMaxReached = skills.PassingSkill.IsMaxReached;
                weekLog.Playmaking = skills.PlaymakerSkill.Value;
                weekLog.PlaymakingMax = skills.PlaymakerSkillMax.Value;
                weekLog.PlaymakingMaxReached = skills.PlaymakerSkill.IsMaxReached;
                weekLog.Scoring = skills.ScorerSkill.Value;
                weekLog.ScoringMax = skills.ScorerSkillMax.Value;
                weekLog.ScoringMaxReached = skills.ScorerSkill.IsMaxReached;
                weekLog.Season = season;
                weekLog.JuniorPlayerId = juniorPlayerId;
                weekLog.SeriesGoals = seriesGoals;
                weekLog.SetPieces = skills.SetPiecesSkill.Value;
                weekLog.SetPiecesMax = skills.SetPiecesSkillMax.Value;
                weekLog.SetPiecesMaxReached = skills.SetPiecesSkill.IsMaxReached;
                weekLog.Week = week;
                weekLog.Winger = skills.WingerSkill.Value;
                weekLog.WingerMax = skills.WingerSkillMax.Value;
                weekLog.WingerMaxReached = skills.WingerSkill.IsMaxReached;
            }

            if (shouldInsert)
            {
                this.juniorPlayerWeekLogRepository.Insert(weekLog);
            }
            else
            {
                this.juniorPlayerWeekLogRepository.Update(weekLog);
            }

            this.context.Save();
        }

        #endregion Private Methods
    }
}