//-----------------------------------------------------------------------
// <copyright file="Configuration.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.IO;

    /// <summary>
    /// Hattrick Ultimate Database Configurations.
    /// </summary>
    internal sealed class Configuration : DbMigrationsConfiguration<Database.DatabaseContext>
    {
        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Configuration" /> class.
        /// </summary>
        public Configuration()
        {
            this.AutomaticMigrationsEnabled =
            this.AutomaticMigrationDataLossAllowed = true;
        }

        #endregion Public Constructors

        #region Protected Methods

        /// <summary>
        /// Runs after upgrading to the latest migration to allow seed data to be updated.
        /// </summary>
        /// <param name="context">Database context.</param>
        protected override void Seed(Database.DatabaseContext context)
        {
            var sqlFiles = Directory.GetFiles(
                                        Path.Combine(
                                                AppDomain.CurrentDomain.BaseDirectory,
                                                "Database",
                                                "Scripts"),
                                        "*.sql");

            foreach (var curSqlFile in sqlFiles)
            {
                context.Database.ExecuteSqlCommand(
                                     File.ReadAllText(curSqlFile));
            }

            base.Seed(context);
        }

        #endregion Protected Methods
    }
}