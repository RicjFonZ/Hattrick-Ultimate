// -----------------------------------------------------------------------
// <copyright file="YouthTeamDetails.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
// -----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessLogic.Chpp.Strategy.FileProcess
{
    using System;
    using BusinessObjects.App;
    using BusinessObjects.Hattrick.Interface;
    using DataAccess.Database.Interface;
    using Interface;

    /// <summary>
    /// Provides functionality to process YouthTeamDetails file.
    /// </summary>
    public class YouthTeamDetails : IFileProcessStrategy
    {
        #region Private Fields

        /// <summary>
        /// Database context.
        /// </summary>
        private IDatabaseContext context;

        /// <summary>
        /// Junior Series repository.
        /// </summary>
        private IHattrickRepository<JuniorSeries> juniorSeriesRepository;

        /// <summary>
        /// Junior Team repository.
        /// </summary>
        private IHattrickRepository<JuniorTeam> juniorTeamRepository;

        /// <summary>
        /// Senior Team repository.
        /// </summary>
        private IHattrickRepository<SeniorTeam> seniorTeamRepository;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="YouthTeamDetails" /> class.
        /// </summary>
        /// <param name="context">Database context.</param>
        /// <param name="juniorSeriesRepository">Junior Series repository.</param>
        /// <param name="juniorTeamRepository">Junior Team repository.</param>
        /// <param name="seniorTeamRepository">Senior Team repository.</param>
        public YouthTeamDetails(
                   IDatabaseContext context,
                   IHattrickRepository<JuniorSeries> juniorSeriesRepository,
                   IHattrickRepository<JuniorTeam> juniorTeamRepository,
                   IHattrickRepository<SeniorTeam> seniorTeamRepository)
        {
            this.context = context;
            this.juniorSeriesRepository = juniorSeriesRepository;
            this.juniorTeamRepository = juniorTeamRepository;
            this.seniorTeamRepository = seniorTeamRepository;
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// Process Team Details file.
        /// </summary>
        /// <param name="fileToProcess">File to process.</param>
        public void ProcessFile(IXmlEntity fileToProcess)
        {
            if (fileToProcess == null)
            {
                throw new ArgumentNullException(nameof(fileToProcess));
            }

            var file = fileToProcess as BusinessObjects.Hattrick.YouthTeamDetails.Root;

            if (file == null)
            {
                throw new ArgumentException(Localization.Strings.Message_UnexpectedObjectType, nameof(fileToProcess));
            }

            // No Youth Team to process.
            if (file.YouthTeam == null || file.YouthTeam.YouthTeamId == 0)
            {
                return;
            }

            this.ProcessJuniorTeam(file.YouthTeam);
        }

        #endregion Public Methods

        #region Private Methods
        /// <summary>
        /// Process Youth League.
        /// </summary>
        /// <param name="youthLeague">Youth League.</param>
        /// <returns>BusinessObjects.App.JuniorSeries object.</returns>
        private JuniorSeries ProcessJuniorSeries(BusinessObjects.Hattrick.YouthTeamDetails.YouthLeague youthLeague)
        {
            var juniorSeries = this.juniorSeriesRepository.GetByHattrickId(youthLeague.YouthLeagueId);

            if (juniorSeries == null)
            {
                juniorSeries = new JuniorSeries
                {
                    HattrickId = youthLeague.YouthLeagueId,
                    Name = youthLeague.YouthLeagueName
                };

                this.juniorSeriesRepository.Insert(juniorSeries);
            }
            else
            {
                juniorSeries.Name = youthLeague.YouthLeagueName;

                this.juniorSeriesRepository.Update(juniorSeries);
            }

            this.context.Save();

            return juniorSeries;
        }

        /// <summary>
        /// Process Youth Team.
        /// </summary>
        /// <param name="youthTeam">Youth Team.</param>
        private void ProcessJuniorTeam(BusinessObjects.Hattrick.YouthTeamDetails.YouthTeam youthTeam)
        {
            var juniorTeam = this.juniorTeamRepository.GetByHattrickId(youthTeam.YouthTeamId);

            if (juniorTeam == null)
            {
                juniorTeam = new JuniorTeam
                {
                    HattrickId = youthTeam.YouthTeamId,
                    FullName = youthTeam.YouthTeamName,
                    ShortName = youthTeam.ShortTeamName,
                    JuniorSeries = this.ProcessJuniorSeries(youthTeam.YouthLeague),
                    SeniorTeam = this.seniorTeamRepository.GetByHattrickId(youthTeam.OwningTeam.MotherTeamId)
                };

                this.juniorTeamRepository.Insert(juniorTeam);
            }
            else
            {
                juniorTeam.FullName = youthTeam.YouthTeamName;
                juniorTeam.ShortName = youthTeam.ShortTeamName;
                juniorTeam.JuniorSeries = this.ProcessJuniorSeries(youthTeam.YouthLeague);

                this.juniorTeamRepository.Update(juniorTeam);
            }

            this.context.Save();
        }

        #endregion Private Methods
    }
}