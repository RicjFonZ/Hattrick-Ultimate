// -----------------------------------------------------------------------
// <copyright file="Junior.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
// -----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessLogic.Actions
{
    using System.Linq;
    using DataAccess.Database.Interface;

    /// <summary>
    /// Junior business objects related actions
    /// </summary>
    public class Junior
    {
        #region Private Fields

        /// <summary>
        /// Database context.
        /// </summary>
        private IDatabaseContext context;

        /// <summary>
        /// Junior Series repository.
        /// </summary>
        private IRepository<BusinessObjects.App.JuniorSeries> juniorSeriesRepository;

        /// <summary>
        /// Junior Team repository.
        /// </summary>
        private IRepository<BusinessObjects.App.JuniorTeam> juniorTeamRepository;

        /// <summary>
        /// Senior Team repository.
        /// </summary>
        private IRepository<BusinessObjects.App.SeniorTeam> seniorTeamRepository;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Junior" /> class.
        /// </summary>
        /// <param name="context">Database context.</param>
        /// <param name="juniorSeriesRepository">Junior Series repository.</param>
        /// <param name="juniorTeamRepository">Junior Team repository.</param>
        /// <param name="seniorTeamRepository">Senior Team repository.</param>
        public Junior(
                   IDatabaseContext context,
                   IRepository<BusinessObjects.App.JuniorSeries> juniorSeriesRepository,
                   IRepository<BusinessObjects.App.JuniorTeam> juniorTeamRepository,
                   IRepository<BusinessObjects.App.SeniorTeam> seniorTeamRepository)
        {
            this.context = context;
            this.juniorSeriesRepository = juniorSeriesRepository;
            this.juniorTeamRepository = juniorTeamRepository;
            this.seniorTeamRepository = seniorTeamRepository;
        }

        #endregion Public Constructors

        #region Internal Methods

        /// <summary>
        /// Process Youth Team.
        /// </summary>
        /// <param name="youthTeamId">Youth Team Id.</param>
        /// <param name="youthTeamName">Youth Team Name.</param>
        /// <param name="seniorTeamId">Senior Team Id.</param>
        internal void ProcessYouthTeam(uint? youthTeamId, string youthTeamName, int seniorTeamId)
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

        #endregion Internal Methods

        #region Private Methods

        /// <summary>
        /// Create Junior Team.
        /// </summary>
        /// <param name="juniorTeamId">Junior Team Id.</param>
        /// <param name="juniorTeamName">Junior Team Name</param>
        /// <param name="seniorTeamId">Senior Team Id.</param>
        private void CreateJuniorTeam(uint juniorTeamId, string juniorTeamName, int seniorTeamId)
        {
            var juniorTeam = new BusinessObjects.App.JuniorTeam
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