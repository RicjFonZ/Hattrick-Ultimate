//-----------------------------------------------------------------------
// <copyright file="DatabaseContext.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.DataAccess.Database
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Core.Objects;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using BusinessObjects.App.Interface;
    using Interface;

    /// <summary>
    /// Application Database Context definition.
    /// </summary>
    public class DatabaseContext : DbContext, IDatabaseContext
    {
        #region Private Fields

        /// <summary>
        /// Indicates whether the current operation has been cancelled.
        /// </summary>
        private bool cancelled;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseContext"/> class.
        /// </summary>
        public DatabaseContext()
            : base($"Data Source=(localdb)\\{AppDomain.CurrentDomain.GetData("LocalDbInstance")};AttachDbFilename={AppDomain.CurrentDomain.GetData("DataDirectory")}\\HattrickUltimateDB.mdf;Initial Catalog=HattrickUltimateDB;Integrated Security=True;")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DatabaseContext, Migrations.Configuration>());

            this.cancelled = false;
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// Initializes a new transaction.
        /// </summary>
        public void BeginTransaction()
        {
            if (this.Database.CurrentTransaction != null)
            {
                throw new InvalidOperationException(Localization.Messages.OverlappingTransaction);
            }

            this.Database.BeginTransaction();
        }

        /// <summary>
        /// Sets the current transaction as cancelled so when the EndTransaction method is called
        /// changes undone.
        /// </summary>
        public void Cancel()
        {
            this.cancelled = true;
        }

        /// <summary>
        /// Returns a IQueryable instance for access to entities of the given type in the context and
        /// the underlying store.
        /// </summary>
        /// <typeparam name="TEntity">The type entity for which a set should be returned.</typeparam>
        /// <returns>A set for the given entity type.</returns>
        public virtual IDbSet<TEntity> CreateSet<TEntity>() where TEntity : class, IEntity
        {
            return this.Set<TEntity>();
        }

        /// <summary>
        /// Commits or rollbacks the pending changes depending on the transaction state.
        /// </summary>
        public void EndTransaction()
        {
            if (this.cancelled)
            {
                this.Rollback();
            }
            else
            {
                this.Commit();
            }
        }

        /// <summary>
        /// Saves changes to the database.
        /// </summary>
        /// <remarks>In case there's an active transaction changes will be saved within its scope.</remarks>
        public void Save()
        {
            this.SaveChanges();
        }

        #endregion Public Methods

        #region Protected Methods

        /// <summary>
        /// Disposes the context. The underlying System.Data.Entity.Core.Objects.ObjectContext is
        /// also disposed if it was created is by this context or ownership was passed to this
        /// context when this context was created. The connection to the database
        /// (System.Data.Common.DbConnection object) is also disposed if it was created is by this
        /// context or ownership was passed to this context when this context was created.
        /// </summary>
        /// <param name="disposing">
        /// True to release both managed and unmanaged resources; false to release only unmanaged resources.
        /// </param>
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        /// <summary>
        /// Model definition.
        /// </summary>
        /// <param name="modelBuilder">
        /// The builder that defines the model for the context being created.
        /// </param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new Mapping.Continent());
            modelBuilder.Configurations.Add(new Mapping.Country());
            modelBuilder.Configurations.Add(new Mapping.Currency());
            modelBuilder.Configurations.Add(new Mapping.DateFormat());
            modelBuilder.Configurations.Add(new Mapping.Grid());
            modelBuilder.Configurations.Add(new Mapping.GridColumn());
            modelBuilder.Configurations.Add(new Mapping.GridLayout());
            modelBuilder.Configurations.Add(new Mapping.GridLayoutColumn());
            modelBuilder.Configurations.Add(new Mapping.JuniorSeries());
            modelBuilder.Configurations.Add(new Mapping.JuniorTeam());
            modelBuilder.Configurations.Add(new Mapping.League());
            modelBuilder.Configurations.Add(new Mapping.LeagueCup());
            modelBuilder.Configurations.Add(new Mapping.LeagueNationalTeam());
            modelBuilder.Configurations.Add(new Mapping.LeagueSchedule());
            modelBuilder.Configurations.Add(new Mapping.Manager());
            modelBuilder.Configurations.Add(new Mapping.Region());
            modelBuilder.Configurations.Add(new Mapping.SeniorArena());
            modelBuilder.Configurations.Add(new Mapping.SeniorPlayer());
            modelBuilder.Configurations.Add(new Mapping.SeniorPlayerAvatar());
            modelBuilder.Configurations.Add(new Mapping.SeniorPlayerSeasonGoals());
            modelBuilder.Configurations.Add(new Mapping.SeniorPlayerSkills());
            modelBuilder.Configurations.Add(new Mapping.SeniorPlayerWithSkillDelta());
            modelBuilder.Configurations.Add(new Mapping.SeniorSeries());
            modelBuilder.Configurations.Add(new Mapping.SeniorTeam());
            modelBuilder.Configurations.Add(new Mapping.TimeFormat());
            modelBuilder.Configurations.Add(new Mapping.Token());
            modelBuilder.Configurations.Add(new Mapping.User());
            modelBuilder.Configurations.Add(new Mapping.Zone());
        }

        #endregion Protected Methods

        #region Private Methods

        /// <summary>
        /// Save changes and commits the transaction, if any.
        /// </summary>
        private void Commit()
        {
            this.SaveChanges();

            if (this.Database.CurrentTransaction != null)
            {
                this.Database.CurrentTransaction.Commit();
            }
        }

        /// <summary>
        /// Revert changes and rollbacks the transaction, if any.
        /// </summary>
        private void Rollback()
        {
            this.UndoChanges();

            if (this.Database.CurrentTransaction != null)
            {
                this.Database.CurrentTransaction.Rollback();
            }

            this.cancelled = false;
        }

        /// <summary>
        /// Revert changes made to context entities.
        /// </summary>
        private void UndoChanges()
        {
            var objectContext = ((IObjectContextAdapter)this).ObjectContext;

            var rollbackStrategyFactory = new Factory.RollbackStrategyFactory();

            var entriesToRevert = objectContext.ObjectStateManager.GetObjectStateEntries(EntityState.Added |
                                                                                         EntityState.Deleted |
                                                                                         EntityState.Modified)
                                                                  .Where(e => e.Entity != null)
                                                                  .ToList();

            entriesToRevert.ForEach(e =>
            {
                rollbackStrategyFactory.GetFor(e.State)
                                       .Undo(e, objectContext);
            });

            objectContext.Refresh(RefreshMode.StoreWins, entriesToRevert.Select(etr => etr.Entity));
        }

        #endregion Private Methods
    }
}