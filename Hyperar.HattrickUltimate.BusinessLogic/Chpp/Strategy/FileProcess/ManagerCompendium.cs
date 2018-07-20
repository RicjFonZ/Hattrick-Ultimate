// -----------------------------------------------------------------------
// <copyright file="ManagerCompendium.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
// -----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessLogic.Chpp.Strategy.FileProcess
{
    using System;
    using System.Linq;
    using BusinessObjects.App;
    using BusinessObjects.Hattrick.Interface;
    using DataAccess.Database.Interface;
    using ExtensionMethods;
    using Interface;

    /// <summary>
    /// Provides functionality to process ManagerCompendium file.
    /// </summary>
    public class ManagerCompendium : IFileProcessStrategy
    {
        #region Private Fields

        /// <summary>
        /// Database context.
        /// </summary>
        private IDatabaseContext context;

        /// <summary>
        /// Country repository.
        /// </summary>
        private IHattrickRepository<Country> countryRepository;

        /// <summary>
        /// Manager repository.
        /// </summary>
        private IHattrickRepository<Manager> managerRepository;

        /// <summary>
        /// User repository.
        /// </summary>
        private IRepository<User> userRepository;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ManagerCompendium" /> class.
        /// </summary>
        /// <param name="context">Database context.</param>
        /// <param name="countryRepository">Country repository.</param>
        /// <param name="managerRepository">Manager repository.</param>
        /// <param name="userRepository">User repository.</param>
        public ManagerCompendium(
                   IDatabaseContext context,
                   IHattrickRepository<Country> countryRepository,
                   IHattrickRepository<Manager> managerRepository,
                   IRepository<User> userRepository)
        {
            this.context = context;
            this.countryRepository = countryRepository;
            this.managerRepository = managerRepository;
            this.userRepository = userRepository;
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// Process Manager Compendium file.
        /// </summary>
        /// <param name="fileToProcess">File to process.</param>
        public void ProcessFile(IXmlEntity fileToProcess)
        {
            if (fileToProcess == null)
            {
                throw new ArgumentNullException(nameof(fileToProcess));
            }

            var file = fileToProcess as BusinessObjects.Hattrick.ManagerCompendium.Root;

            if (file == null)
            {
                throw new ArgumentException(Localization.Messages.UnexpectedObjectType, nameof(fileToProcess));
            }

            var isUser = file.UserID == file.Manager.UserId;

            this.ProcessManager(file.Manager, isUser);
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        /// Process the Manager object of the ManagerCompendium file.
        /// </summary>
        /// <param name="manager">Manager object.</param>
        /// <param name="isUser">A value indicating whether the Manager is User.</param>
        private void ProcessManager(BusinessObjects.Hattrick.ManagerCompendium.Manager manager, bool isUser)
        {
            if (manager == null)
            {
                throw new ArgumentNullException(nameof(manager));
            }

            var storedManager = this.managerRepository.GetByHattrickId(manager.UserId);

            if (storedManager == null)
            {
                storedManager = new Manager
                {
                    CountryId = this.countryRepository.GetByHattrickId(manager.Country.CountryId).Id,
                    HattrickId = manager.UserId,
                    SupporterTier = manager.SupporterTier.GetEnum(),
                    User = isUser
                         ? this.userRepository.Query().Single()
                         : null,
                    UserName = manager.LoginName,
                };

                this.managerRepository.Insert(storedManager);
            }
            else
            {
                storedManager.SupporterTier = manager.SupporterTier.GetEnum();
                storedManager.UserName = manager.LoginName;

                this.managerRepository.Update(storedManager);
            }

            this.context.Save();
        }

        #endregion Private Methods
    }
}