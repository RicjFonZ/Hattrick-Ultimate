// -----------------------------------------------------------------------
// <copyright file="FileProcessFactory.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
// -----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessLogic.Chpp.Factory
{
    using System;
    using BusinessObjects.Hattrick.Interface;
    using DataAccess.Chpp.Constants;
    using Interface;

    /// <summary>
    /// File Process Factory.
    /// </summary>
    public class FileProcessFactory : IFileProcessFactory
    {
        #region Private Fields

        /// <summary>
        /// Avatars File Processing Strategy.
        /// </summary>
        private readonly Strategy.FileProcess.Avatars avatarsStrategy;

        /// <summary>
        /// ManagerCompendium File Processing Strategy.
        /// </summary>
        private readonly Strategy.FileProcess.ManagerCompendium managerCompendiumStrategy;

        /// <summary>
        /// Players File Processing Strategy.
        /// </summary>
        private readonly Strategy.FileProcess.Players playersStrategy;

        /// <summary>
        /// TeamDetails File Processing Strategy.
        /// </summary>
        private readonly Strategy.FileProcess.TeamDetails teamDetailsStrategy;

        /// <summary>
        /// WorldDetails File Processing Strategy.
        /// </summary>
        private readonly Strategy.FileProcess.WorldDetails worldDetailsStrategy;

        /// <summary>
        /// YouthAvatars File Processing Strategy.
        /// </summary>
        private readonly Strategy.FileProcess.YouthAvatars youthAvatarsStrategy;

        /// <summary>
        /// YouthPlayerList File Processing Strategy.
        /// </summary>
        private readonly Strategy.FileProcess.YouthPlayerList youthPlayerListStrategy;

        /// <summary>
        /// YouthTeamDetails File Processing Strategy.
        /// </summary>
        private readonly Strategy.FileProcess.YouthTeamDetails youthTeamDetailsStrategy;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="FileProcessFactory"/> class.
        /// </summary>
        /// <param name="avatarsStrategy">Avatars File Processing Strategy.</param>
        /// <param name="managerCompendiumStrategy">ManagerCompendium File Processing Strategy.</param>
        /// <param name="playersStrategy">Players File Processing Strategy.</param>
        /// <param name="teamDetailsStrategy">TeamDetails File Processing Strategy.</param>
        /// <param name="worldDetailsStrategy">WorldDetails File Processing Strategy.</param>
        /// <param name="youthAvatarsStrategy">YouthAvatars File Processing Strategy.</param>
        /// <param name="youthPlayerListStrategy">YouthPlayerList File Processing Strategy.</param>
        /// <param name="youthTeamDetailsStrategy">YouthTeamDetails File Processing Strategy.</param>
        public FileProcessFactory(
                   Strategy.FileProcess.Avatars avatarsStrategy,
                   Strategy.FileProcess.ManagerCompendium managerCompendiumStrategy,
                   Strategy.FileProcess.Players playersStrategy,
                   Strategy.FileProcess.TeamDetails teamDetailsStrategy,
                   Strategy.FileProcess.WorldDetails worldDetailsStrategy,
                   Strategy.FileProcess.YouthAvatars youthAvatarsStrategy,
                   Strategy.FileProcess.YouthPlayerList youthPlayerListStrategy,
                   Strategy.FileProcess.YouthTeamDetails youthTeamDetailsStrategy)
        {
            this.avatarsStrategy = avatarsStrategy;
            this.managerCompendiumStrategy = managerCompendiumStrategy;
            this.playersStrategy = playersStrategy;
            this.teamDetailsStrategy = teamDetailsStrategy;
            this.worldDetailsStrategy = worldDetailsStrategy;
            this.youthAvatarsStrategy = youthAvatarsStrategy;
            this.youthPlayerListStrategy = youthPlayerListStrategy;
            this.youthTeamDetailsStrategy = youthTeamDetailsStrategy;
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// Gets the corresponding IFileProcessStrategy for the specified IXmlEntity object.
        /// </summary>
        /// <param name="entity">IXmlEntity object to process.</param>
        /// <returns>Correct IFileProcessStrategy object for the specified IXmlEntity.</returns>
        public IFileProcessStrategy GetFor(IXmlEntity entity)
        {
            switch (entity.FileName.ToLower())
            {
                case XmlFileName.Avatars:
                    return this.avatarsStrategy;

                case XmlFileName.ManagerCompendium:
                    return this.managerCompendiumStrategy;

                case XmlFileName.Players:
                    return this.playersStrategy;

                case XmlFileName.TeamDetails:
                    return this.teamDetailsStrategy;

                case XmlFileName.WorldDetails:
                    return this.worldDetailsStrategy;

                case XmlFileName.YouthAvatars:
                    return this.youthAvatarsStrategy;

                case XmlFileName.YouthPlayerList:
                    return this.youthPlayerListStrategy;

                case XmlFileName.YouthTeamDetails:
                    return this.youthTeamDetailsStrategy;

                default:
                    throw new NotImplementedException(
                                  string.Format(
                                             Localization.Messages.NotImplemented,
                                             typeof(IFileProcessStrategy).Name,
                                             entity.FileName));
            }
        }

        #endregion Public Methods
    }
}