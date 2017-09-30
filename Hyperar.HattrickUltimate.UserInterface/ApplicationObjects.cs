//-----------------------------------------------------------------------
// <copyright file="ApplicationObjects.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.UserInterface
{
    using DataAccess.Database;
    using DataAccess.Database.Interface;
    using SimpleInjector;

    /// <summary>
    /// Provides application objects across the layer.
    /// </summary>
    internal static class ApplicationObjects
    {
        #region Private Fields

        /// <summary>
        /// Dependency injection container.
        /// </summary>
        private static Container container;

        #endregion Private Fields

        #region Internal Properties

        /// <summary>
        /// Gets the Dependency injection container.
        /// </summary>
        internal static Container Container
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

        #endregion Internal Properties

        #region Internal Methods

        /// <summary>
        /// Registers dependency injection container objects.
        /// </summary>
        internal static void RegisterContainer()
        {
            RegisterDatabaseContexts();
            RegisterRepositories();
            RegisterForms();
            RegisterBusinessObjectsManagers();
        }

        #endregion Internal Methods

        #region Private Methods

        /// <summary>
        /// Registers business objects managers.
        /// </summary>
        private static void RegisterBusinessObjectsManagers()
        {
            Container.Register(typeof(BusinessLogic.DownloadManager));
            Container.Register(typeof(BusinessLogic.UserManager));
        }

        /// <summary>
        /// Registers database contexts.
        /// </summary>
        private static void RegisterDatabaseContexts()
        {
            Container.Register<IDatabaseContext, DatabaseContext>(Lifestyle.Scoped);
        }

        /// <summary>
        /// Registers application forms.
        /// </summary>
        private static void RegisterForms()
        {
            Container.Register<FormDataFolder>(Lifestyle.Transient);
            Container.Register<FormMain>(Lifestyle.Transient);
            Container.Register<FormToken>(Lifestyle.Transient);
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