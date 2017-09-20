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
    using SimpleInjector.Lifestyles;

    internal static class Program
    {
        #region Private Methods

        private static void GetDatabaseInstance()
        {
            try
            {
                string localDbInstance = DatabaseUtils.GetLocalDbInstance();

                if (string.IsNullOrWhiteSpace(localDbInstance))
                {
                    throw new Exception(Localization.Strings.LocalDbInstanceNotFound);
                }

                AppDomain.CurrentDomain.SetData("LocalDbInstance", localDbInstance);
            }
            catch (Exception ex)
            {
                throw new Exception(Localization.Strings.CannotRetrieveLocalDbInstance, ex);
            }
        }

        private static void GetDataFolder()
        {
            try
            {
                string dataFolder = Properties.Settings.Default.DataFolder;

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
                            throw new Exception(Localization.Strings.DataFolderNotSet);
                        }
                    }
                }

                AppDomain.CurrentDomain.SetData("DataDirectory", dataFolder);
            }
            catch (Exception ex)
            {
                throw new Exception(Localization.Strings.CannotSetDataFolder, ex);
            }
        }

        private static void Initialize()
        {
            GetDatabaseInstance();
            GetDataFolder();
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ApplicationObjects.RegisterContainer();

            using (var scope = ThreadScopedLifestyle.BeginScope(ApplicationObjects.Container))
            {
                Initialize();
                Application.Run(ApplicationObjects.Container.GetInstance<FormMain>());
            }
        }

        #endregion Private Methods
    }
}