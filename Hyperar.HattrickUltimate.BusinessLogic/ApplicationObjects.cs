//-----------------------------------------------------------------------
// <copyright file="ApplicationObjects.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessLogic
{
    using System;
    using DataAccess.Database;
    using DataAccess.Database.Interface;
    using SimpleInjector;
    using SimpleInjector.Diagnostics;

    /// <summary>
    /// Provides application objects across the layer.
    /// </summary>
    public static class ApplicationObjects
    {
        #region Private Fields

        /// <summary>
        /// Ignore parameter constant.
        /// </summary>
        private const string Ignore = "ignore";

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
        /// Finished and verifies the container.
        /// </summary>
        public static void Finish()
        {
            Container.Verify(VerificationOption.VerifyAndDiagnose);
        }

        /// <summary>
        /// Registers dependency injection container objects.
        /// </summary>
        public static void RegisterContainer()
        {
            RegisterDatabaseContexts();
            RegisterRepositories();
            RegisterBusinessObjectsManagers();
        }

        /// <summary>
        /// Registers forms in the container.
        /// </summary>
        /// <typeparam name="T">Form type.</typeparam>
        public static void RegisterForm<T>() where T : class, IDisposable
        {
            Container.Register<T>(Lifestyle.Transient);

            var registration = Lifestyle.Transient.CreateRegistration<T>(Container);

            registration.SuppressDiagnosticWarning(DiagnosticType.DisposableTransientComponent, Ignore);

            Container.RegisterInitializer<T>(o => Lifestyle.Scoped.RegisterForDisposal(Container, o));
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        /// Registers business objects managers.
        /// </summary>
        private static void RegisterBusinessObjectsManagers()
        {
            Container.Register<Chpp.Interface.IFileProcessFactory, Chpp.Factory.FileProcessFactory>(Lifestyle.Transient);
            Container.Register<Chpp.Strategy.FileProcess.ManagerCompendium>(Lifestyle.Transient);
            Container.Register<Chpp.Strategy.FileProcess.Players>(Lifestyle.Transient);
            Container.Register<Chpp.Strategy.FileProcess.TeamDetails>(Lifestyle.Transient);
            Container.Register<Chpp.Strategy.FileProcess.WorldDetails>(Lifestyle.Transient);
            Container.Register<Chpp.ChppFileProcesser>(Lifestyle.Transient);
            Container.Register<DownloadManager>(Lifestyle.Transient);
            Container.Register<FileProcessManager>(Lifestyle.Transient);
            Container.Register<TokenManager>(Lifestyle.Transient);
            Container.Register<UserManager>(Lifestyle.Transient);
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