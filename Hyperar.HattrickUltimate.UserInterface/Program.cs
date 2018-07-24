//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.UserInterface
{
    using System;
    using System.IO;
    using System.Windows.Forms;
    using BusinessLogic;
    using SimpleInjector;
    using SimpleInjector.Lifestyles;

    /// <summary>
    /// Application entry point.
    /// </summary>
    internal static class Program
    {
        #region Private Methods

        /// <summary>
        /// Gets the App Name.
        /// </summary>
        private static void GetAppName()
        {
            string appName = $"{Application.ProductName} v{Application.ProductVersion}";

#if DEBUG
            appName += " [DEBUG]";
#endif

            AppDomain.CurrentDomain.SetData(Constants.Settings.AppName, appName);
        }

        /// <summary>
        /// Gets the best LocalDb instance.
        /// </summary>
        private static void GetDatabaseInstance()
        {
            try
            {
                string localDbInstance = DatabaseUtils.GetLocalDbInstance();

                if (string.IsNullOrWhiteSpace(localDbInstance))
                {
                    throw new Exception(Localization.Messages.LocalDbInstanceNotFound);
                }

                AppDomain.CurrentDomain.SetData(Constants.Settings.LocalDbInstance, localDbInstance);
            }
            catch (Exception ex)
            {
                throw new Exception(Localization.Messages.CannotRetrieveLocalDbInstance, ex);
            }
        }

        /// <summary>
        /// Gets the user selected database folder.
        /// </summary>
        private static void GetDataFolder()
        {
            try
            {
                string dataFolder = Properties.Settings.Default[Constants.Settings.DataDirectory].ToString();

                if (string.IsNullOrWhiteSpace(dataFolder))
                {
                    using (var form = ApplicationObjects.Container.GetInstance<FormDataFolder>())
                    {
                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            dataFolder = form.DataFolder;

                            if (!Directory.Exists(dataFolder))
                            {
                                Directory.CreateDirectory(dataFolder);
                            }
                        }
                        else
                        {
                            throw new Exception(Localization.Messages.DataFolderNotSet);
                        }
                    }
                }

                AppDomain.CurrentDomain.SetData(Constants.Settings.DataDirectory, dataFolder);

                Properties.Settings.Default[Constants.Settings.DataDirectory] = dataFolder;

                Properties.Settings.Default.Save();
            }
            catch (Exception ex)
            {
                throw new Exception(Localization.Messages.CannotSetDataFolder, ex);
            }
        }

        /// <summary>
        /// Initializes the database prerequisites.
        /// </summary>
        private static void Initialize()
        {
            GetAppName();
            GetDatabaseInstance();
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Initialize();
            RegisterDependencies();

            using (var scope = ThreadScopedLifestyle.BeginScope(ApplicationObjects.Container))
            {
                GetDataFolder();
                Application.Run(ApplicationObjects.Container.GetInstance<FormMain>());
            }
        }

        /// <summary>
        /// Registers dependencies.
        /// </summary>
        private static void RegisterDependencies()
        {
            ApplicationObjects.RegisterContainer();
            RegisterForms();
            RegisterFactoriesAndStrategies();
            ApplicationObjects.Finish();
        }

        /// <summary>
        /// Registers application forms.
        /// </summary>
        private static void RegisterForms()
        {
            ApplicationObjects.RegisterForm<FormDataFolder>();
            ApplicationObjects.RegisterForm<FormDownload>();
            ApplicationObjects.RegisterForm<FormGenericProgress>();
            ApplicationObjects.RegisterForm<FormMain>();
            ApplicationObjects.RegisterForm<FormToken>();
            ApplicationObjects.RegisterForm<FormUser>();
        }

        /// <summary>
        /// Registers factories and strategies.
        /// </summary>
        private static void RegisterFactoriesAndStrategies()
        {
            ApplicationObjects.Container.Register<Interface.IDataGridViewColumnBuilderFactory, Factory.DataGridViewColumnBuilderFactory>(Lifestyle.Transient);
            ApplicationObjects.Container.Register<Interface.IDenominationDictionaryBuilderFactory, Factory.DenominationDictionaryFactory>(Lifestyle.Transient);

            ApplicationObjects.Container.Register<Strategy.DataGridViewColumnBuilder.DenominatedValue>(Lifestyle.Transient);
            ApplicationObjects.Container.Register<Strategy.DataGridViewColumnBuilder.DenominatedValueWithChangeTracking>(Lifestyle.Transient);
            ApplicationObjects.Container.Register<Strategy.DataGridViewColumnBuilder.Image>(Lifestyle.Transient);
            ApplicationObjects.Container.Register<Strategy.DataGridViewColumnBuilder.Text>(Lifestyle.Transient);
            ApplicationObjects.Container.Register<Strategy.DataGridViewColumnBuilder.ValueWithChangeTracking>(Lifestyle.Transient);

            ApplicationObjects.Container.Register<Strategy.DenominationDictionaryBuilder.Aggressiveness>(Lifestyle.Transient);
            ApplicationObjects.Container.Register<Strategy.DenominationDictionaryBuilder.Agreeability>(Lifestyle.Transient);
            ApplicationObjects.Container.Register<Strategy.DenominationDictionaryBuilder.Honesty>(Lifestyle.Transient);
            ApplicationObjects.Container.Register<Strategy.DenominationDictionaryBuilder.PlayerSkill>(Lifestyle.Transient);
            ApplicationObjects.Container.Register<Strategy.DenominationDictionaryBuilder.PlayerSpecialty>(Lifestyle.Transient);
        }

        #endregion Private Methods
    }
}