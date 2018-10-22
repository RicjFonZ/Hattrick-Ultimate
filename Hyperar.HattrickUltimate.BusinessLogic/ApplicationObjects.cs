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
#if DEBUG
            Container.Verify(VerificationOption.VerifyAndDiagnose);
#else
            Container.Verify(VerificationOption.VerifyOnly);
#endif
        }

        /// <summary>
        /// Registers dependency injection container objects.
        /// </summary>
        public static void RegisterContainer()
        {
            RegisterDatabaseContexts();
            RegisterQueryStrategies();
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
            // FileProcess Registrations.
            Container.Register<Chpp.Interface.IFileAnalysisFactory, Chpp.Factory.FileAnalysisFactory>(Lifestyle.Transient);
            Container.Register<Chpp.FileAnalyser>(Lifestyle.Transient);

            Container.Register<Chpp.Interface.IFileProcessFactory, Chpp.Factory.FileProcessFactory>(Lifestyle.Transient);
            Container.Register<Chpp.FileProcesser>(Lifestyle.Transient);
            Container.Register<Chpp.Strategy.FileProcess.ManagerCompendium>(Lifestyle.Transient);
            Container.Register<Chpp.Strategy.FileProcess.Players>(Lifestyle.Transient);
            Container.Register<Chpp.Strategy.FileProcess.TeamDetails>(Lifestyle.Transient);
            Container.Register<Chpp.Strategy.FileProcess.WorldDetails>(Lifestyle.Transient);
            Container.Register<Chpp.Strategy.FileProcess.YouthTeamDetails>(Lifestyle.Transient);

            Container.Register<Chpp.Interface.IFileValidationFactory, Chpp.Factory.FileValidationFactory>(Lifestyle.Transient);
            Container.Register<Chpp.FileValidator>(Lifestyle.Transient);
            Container.Register<Chpp.Strategy.FileValidation.Default>(Lifestyle.Transient);
            Container.Register<Chpp.Strategy.FileValidation.Players>(Lifestyle.Transient);

            // Business Object Mangers.
            Container.Register<ChppFileTaskManager>(Lifestyle.Transient);
            Container.Register<GridManager>(Lifestyle.Transient);
            Container.Register<SeniorPlayerManager>(Lifestyle.Transient);
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
        /// Registers entity query strategies.
        /// </summary>
        private static void RegisterQueryStrategies()
        {
            container.Register<IQueryStrategy<BusinessObjects.App.Continent>, DataAccess.Database.Strategy.QueryStrategy.Continent>();
            container.Register<IQueryStrategy<BusinessObjects.App.Country>, DataAccess.Database.Strategy.QueryStrategy.Country>();
            container.Register<IQueryStrategy<BusinessObjects.App.Currency>, DataAccess.Database.Strategy.QueryStrategy.Currency>();
            container.Register<IQueryStrategy<BusinessObjects.App.DateFormat>, DataAccess.Database.Strategy.QueryStrategy.DateFormat>();
            container.Register<IQueryStrategy<BusinessObjects.App.Grid>, DataAccess.Database.Strategy.QueryStrategy.Grid>();
            container.Register<IQueryStrategy<BusinessObjects.App.GridColumn>, DataAccess.Database.Strategy.QueryStrategy.GridColumn>();
            container.Register<IQueryStrategy<BusinessObjects.App.GridLayout>, DataAccess.Database.Strategy.QueryStrategy.GridLayout>();
            container.Register<IQueryStrategy<BusinessObjects.App.GridLayoutColumn>, DataAccess.Database.Strategy.QueryStrategy.GridLayoutColumn>();
            container.Register<IQueryStrategy<BusinessObjects.App.JuniorSeries>, DataAccess.Database.Strategy.QueryStrategy.JuniorSeries>();
            container.Register<IQueryStrategy<BusinessObjects.App.JuniorTeam>, DataAccess.Database.Strategy.QueryStrategy.JuniorTeam>();
            container.Register<IQueryStrategy<BusinessObjects.App.League>, DataAccess.Database.Strategy.QueryStrategy.League>();
            container.Register<IQueryStrategy<BusinessObjects.App.LeagueCup>, DataAccess.Database.Strategy.QueryStrategy.LeagueCup>();
            container.Register<IQueryStrategy<BusinessObjects.App.LeagueNationalTeam>, DataAccess.Database.Strategy.QueryStrategy.LeagueNationalTeam>();
            container.Register<IQueryStrategy<BusinessObjects.App.LeagueSchedule>, DataAccess.Database.Strategy.QueryStrategy.LeagueSchedule>();
            container.Register<IQueryStrategy<BusinessObjects.App.Manager>, DataAccess.Database.Strategy.QueryStrategy.Manager>();
            container.Register<IQueryStrategy<BusinessObjects.App.Region>, DataAccess.Database.Strategy.QueryStrategy.Region>();
            container.Register<IQueryStrategy<BusinessObjects.App.SeniorArena>, DataAccess.Database.Strategy.QueryStrategy.SeniorArena>();
            container.Register<IQueryStrategy<BusinessObjects.App.SeniorPlayer>, DataAccess.Database.Strategy.QueryStrategy.SeniorPlayer>();
            container.Register<IQueryStrategy<BusinessObjects.App.SeniorPlayerAvatar>, DataAccess.Database.Strategy.QueryStrategy.SeniorPlayerAvatar>();
            container.Register<IQueryStrategy<BusinessObjects.App.SeniorPlayerSeasonGoals>, DataAccess.Database.Strategy.QueryStrategy.SeniorPlayerSeasonGoals>();
            container.Register<IQueryStrategy<BusinessObjects.App.SeniorPlayerSkills>, DataAccess.Database.Strategy.QueryStrategy.SeniorPlayerSkills>();
            container.Register<IQueryStrategy<BusinessObjects.App.SeniorSeries>, DataAccess.Database.Strategy.QueryStrategy.SeniorSeries>();
            container.Register<IQueryStrategy<BusinessObjects.App.SeniorTeam>, DataAccess.Database.Strategy.QueryStrategy.SeniorTeam>();
            container.Register<IQueryStrategy<BusinessObjects.App.TimeFormat>, DataAccess.Database.Strategy.QueryStrategy.TimeFormat>();
            container.Register<IQueryStrategy<BusinessObjects.App.Token>, DataAccess.Database.Strategy.QueryStrategy.Token>();
            container.Register<IQueryStrategy<BusinessObjects.App.User>, DataAccess.Database.Strategy.QueryStrategy.User>();
            container.Register<IQueryStrategy<BusinessObjects.App.Zone>, DataAccess.Database.Strategy.QueryStrategy.Zone>();

            // Fallback Query Strategy.
            container.RegisterConditional(typeof(IQueryStrategy<>), typeof(DataAccess.Database.Strategy.QueryStrategy.Default<>), c => !c.Handled);
        }

        /// <summary>
        /// Registers entity repositories.
        /// </summary>
        private static void RegisterRepositories()
        {
            Container.Register(typeof(IRepository<>), typeof(Repository<>), Lifestyle.Scoped);
            Container.Register(typeof(IHattrickRepository<>), typeof(HattrickRepository<>), Lifestyle.Scoped);
            Container.Register(typeof(IReadOnlyRepository<>), typeof(ReadOnlyRepository<>), Lifestyle.Scoped);
        }

        #endregion Private Methods
    }
}