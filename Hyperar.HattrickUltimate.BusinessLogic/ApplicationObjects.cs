//-----------------------------------------------------------------------
// <copyright file="ApplicationObjects.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessLogic
{
    using DataAccess.Database;
    using DataAccess.Database.Interface;
    using SimpleInjector;

    /// <summary>
    /// Provides application objects across the layer.
    /// </summary>
    public static class ApplicationObjects
    {
        #region Private Fields

        /// <summary>
        /// Dependency injection container.
        /// </summary>
        private static Container container;

        #endregion Private Fields

        #region Public Properties

        /// <summary>
        /// Gets the Dependency injection container.
        /// </summary>
        public static Container Container
        {
            get
            {
                if (container == null)
                {
                    container = new Container();

                    container.Options.DefaultLifestyle = Lifestyle.Scoped;
                    container.Options.DefaultScopedLifestyle = new SimpleInjector.Lifestyles.ThreadScopedLifestyle();
                }

                return container;
            }
        }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// Registers dependency injection container objects.
        /// </summary>
        public static void RegisterContainer()
        {
            RegisterDatabaseContexts();
            RegisterRepositories();
            RegisterBusinessObjectsManagers();
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        /// Registers business objects managers.
        /// </summary>
        private static void RegisterBusinessObjectsManagers()
        {
            Container.Register(typeof(DownloadManager));
            Container.Register(typeof(TokenManager));
            Container.Register(typeof(UserManager));
        }

        /// <summary>
        /// Registers database contexts.
        /// </summary>
        private static void RegisterDatabaseContexts()
        {
            Container.Register<IDatabaseContext, DatabaseContext>(Lifestyle.Scoped);
        }

        /// <summary>
        /// Registers entity repositories.
        /// </summary>
        private static void RegisterRepositories()
        {
            Container.Register(typeof(IRepository<>), typeof(Repository<>), Lifestyle.Scoped);
        }

        #endregion Private Methods
    }
}