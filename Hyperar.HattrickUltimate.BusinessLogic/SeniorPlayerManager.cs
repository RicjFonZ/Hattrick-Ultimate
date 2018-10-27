//-----------------------------------------------------------------------
// <copyright file="SeniorPlayerManager.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessLogic
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using DataAccess.Database.Interface;

    /// <summary>
    /// Senior Player objects business processes.
    /// </summary>
    public class SeniorPlayerManager
    {
        #region Private Fields

        /// <summary>
        /// Database context.
        /// </summary>
        private readonly IDatabaseContext context;

        /// <summary>
        /// Senior Player Avatar Repository.
        /// </summary>
        private readonly IRepository<BusinessObjects.App.SeniorPlayerAvatar> seniorPlayerAvatarRepository;

        /// <summary>
        /// Senior Player Repository.
        /// </summary>
        private readonly IHattrickRepository<BusinessObjects.App.SeniorPlayer> seniorPlayerRepository;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SeniorPlayerManager"/> class.
        /// </summary>
        /// <param name="context">Database context.</param>
        /// <param name="seniorPlayerAvatarRepository">Senior Player Avatar Repository.</param>
        /// <param name="seniorPlayerRepository">Senior Player Repository.</param>
        public SeniorPlayerManager(
                   IDatabaseContext context,
                   IRepository<BusinessObjects.App.SeniorPlayerAvatar> seniorPlayerAvatarRepository,
                   IHattrickRepository<BusinessObjects.App.SeniorPlayer> seniorPlayerRepository)
        {
            this.context = context;
            this.seniorPlayerAvatarRepository = seniorPlayerAvatarRepository;
            this.seniorPlayerRepository = seniorPlayerRepository;
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// Gets the avatar for the Senior Player with the specified Hattrick ID.
        /// </summary>
        /// <param name="hattrickId">Senior Player Hattrick ID.</param>
        /// <returns>Senior Player Avatar Image.</returns>
        public Image GetSeniorPlayerAvatarByHattrickId(long hattrickId)
        {
            var seniorPlayerAvatar = this.seniorPlayerAvatarRepository.Query(a => a.SeniorPlayer.HattrickId == hattrickId)
                                                                      .SingleOrDefault();

            if (seniorPlayerAvatar != null)
            {
                using (var memoryStream = new MemoryStream(seniorPlayerAvatar.AvatarBytes))
                {
                    return Image.FromStream(memoryStream);
                }
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Gets the Senior Player Grid Rows for the specified Senior Team ID.
        /// </summary>
        /// <param name="selectedTeamId">Selected Senior Team ID.</param>
        /// <returns>Senior Player Grid Rows.</returns>
        public IQueryable<BusinessObjects.UI.SeniorPlayerGridRow> GetSeniorPlayerGridRows(int selectedTeamId)
        {
            var rows = new List<BusinessObjects.UI.SeniorPlayerGridRow>();

            var query = this.seniorPlayerRepository.Query(x => x.SeniorTeamId == selectedTeamId);

            query.ToList()
                 .ForEach(sp =>
                 {
                     (this.context as DbContext).Entry(sp).Reload();

                     var lastWeekLog = sp.WeekLogs.Last();
                     var previousWeekLog = sp.WeekLogs.Reverse()
                                                          .Skip(1)
                                                          .Take(1)
                                                          .SingleOrDefault();

                     var newRow = new BusinessObjects.UI.SeniorPlayerGridRow
                     {
                         Age = sp.WeekLogs.Last().Age,
                         Aggressiveness = sp.Aggressiveness,
                         Agreeability = sp.Agreeability,
                         Avatar = sp.Avatar.AvatarBytes,
                         BookingStatus = sp.BookingStatus,
                         CareerGoals = lastWeekLog.CareerGoals,
                         CareerGoalsDelta = previousWeekLog != null ? lastWeekLog.CareerGoals - previousWeekLog.CareerGoals : (int?)null,
                         CareerHattricks = lastWeekLog.CareerHattricks,
                         CareerHattricksDelta = previousWeekLog != null ? lastWeekLog.CareerHattricks - previousWeekLog.CareerHattricks : (int?)null,
                         Category = sp.Category,
                         CountryEnglishName = sp.Country.League.EnglishName,
                         CountryHattrickId = sp.Country.HattrickId,
                         CountryId = sp.CountryId,
                         CountryName = sp.Country.Name,
                         Defending = lastWeekLog.Defending,
                         DefendingDelta = previousWeekLog != null ? lastWeekLog.Defending - previousWeekLog.Defending : (int?)null,
                         Experience = lastWeekLog.Experience,
                         ExperienceDelta = previousWeekLog != null ? lastWeekLog.Experience - previousWeekLog.Experience : (int?)null,
                         FirstName = sp.FirstName,
                         Form = lastWeekLog.Form,
                         FormDelta = previousWeekLog != null ? lastWeekLog.Form - previousWeekLog.Form : (int?)null,
                         HasHomegrownBonus = sp.HasHomegrownBonus,
                         HattrickId = sp.HattrickId,
                         Honesty = sp.Honesty,
                         Id = sp.Id,
                         HealthStatus = lastWeekLog.HealthStatus,
                         HealthStatusDelta = previousWeekLog != null ? lastWeekLog.HealthStatus - previousWeekLog.HealthStatus : (int?)null,
                         IsOnTransferMarket = sp.IsOnTransferMarket,
                         Keeper = lastWeekLog.Keeper,
                         KeeperDelta = previousWeekLog != null ? lastWeekLog.Keeper - previousWeekLog.Keeper : (int?)null,
                         LastName = sp.LastName,
                         Leadership = sp.Leadership,
                         Loyalty = lastWeekLog.Loyalty,
                         LoyaltyDelta = previousWeekLog != null ? lastWeekLog.Loyalty - previousWeekLog.Loyalty : (int?)null,
                         MatchesOnJuniorNationalTeam = sp.MatchesOnJuniorNationalTeam,
                         MatchesOnSeniorNationalTeam = sp.MatchesOnSeniorNationalTeam,
                         NickName = sp.NickName,
                         Passing = lastWeekLog.Passing,
                         PassingDelta = previousWeekLog != null ? lastWeekLog.Passing - previousWeekLog.Passing : (int?)null,
                         Playmaking = lastWeekLog.Playmaking,
                         PlaymakingDelta = previousWeekLog != null ? lastWeekLog.Playmaking - previousWeekLog.Playmaking : (int?)null,
                         PlaysOnNationalTeam = sp.PlaysOnNationalTeam,
                         Scoring = lastWeekLog.Scoring,
                         ScoringDelta = previousWeekLog != null ? lastWeekLog.Scoring - previousWeekLog.Scoring : (int?)null,
                         SeniorTeamId = sp.SeniorTeamId,
                         SetPieces = lastWeekLog.SetPieces,
                         SetPiecesDelta = previousWeekLog != null ? lastWeekLog.SetPieces - previousWeekLog.SetPieces : (int?)null,
                         ShirtNumber = sp.ShirtNumber,
                         Specialty = sp.Specialty,
                         Stamina = lastWeekLog.Stamina,
                         StaminaDelta = previousWeekLog != null ? lastWeekLog.Stamina - previousWeekLog.Stamina : (int?)null,
                         TotalSkillIndex = lastWeekLog.TotalSkillIndex,
                         TotalSkillIndexDelta = previousWeekLog != null ? lastWeekLog.TotalSkillIndex - previousWeekLog.TotalSkillIndex : (int?)null,
                         Wage = lastWeekLog.Wage,
                         WageDelta = previousWeekLog != null ? lastWeekLog.Wage - previousWeekLog.Wage : (int?)null,
                         Winger = lastWeekLog.Winger,
                         WingerDelta = previousWeekLog != null ? lastWeekLog.Winger - previousWeekLog.Winger : (int?)null,
                     };

                     rows.Add(newRow);
                 });

            return rows.AsQueryable();
        }

        #endregion Public Methods
    }
}