//-----------------------------------------------------------------------
// <copyright file="GridManager.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessLogic
{
    using System.Linq;
    using DataAccess.Database.Interface;
    using Hyperar.HattrickUltimate.BusinessObjects.App.Enums;

    /// <summary>
    /// Grid objects business processes.
    /// </summary>
    public class GridManager
    {
        #region Private Fields

        /// <summary>
        /// Database context.
        /// </summary>
        private IDatabaseContext context;

        /// <summary>
        /// Grid Layout Column Repository.
        /// </summary>
        private IRepository<BusinessObjects.App.GridLayoutColumn> gridLayoutColumnRepository;

        /// <summary>
        /// Grid Layout Repository.
        /// </summary>
        private IRepository<BusinessObjects.App.GridLayout> gridLayoutRepository;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="GridManager" /> class.
        /// </summary>
        /// <param name="context">Database context.</param>
        /// <param name="gridLayoutRepository">Grid Layout Repository.</param>
        /// <param name="gridLayoutColumnRepository">Grid Layout Column Repository.</param>
        public GridManager(
                   IDatabaseContext context,
                   IRepository<BusinessObjects.App.GridLayout> gridLayoutRepository,
                   IRepository<BusinessObjects.App.GridLayoutColumn> gridLayoutColumnRepository)
        {
            this.context = context;
            this.gridLayoutRepository = gridLayoutRepository;
            this.gridLayoutColumnRepository = gridLayoutColumnRepository;
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// Gets the Grid Layout.
        /// </summary>
        /// <param name="gridType">Grid Type.</param>
        /// <returns>Default Grid Layout.</returns>
        public BusinessObjects.App.GridLayout GetGridLayout(GridType gridType)
        {
            var gridLayout = this.gridLayoutRepository.Query(x => x.Grid.GridType == gridType
                                                               && x.IsSelected)
                                                      .SingleOrDefault();

            if (gridLayout == null)
            {
                gridLayout = this.gridLayoutRepository.Query(x => x.Grid.GridType == gridType
                                                               && x.IsDefault)
                                                      .Single();
            }

            return gridLayout;
        }

        /// <summary>
        /// Saves the specified Grid Layout.
        /// </summary>
        /// <param name="gridLayout">Grid Layout to save.</param>
        public void SaveLayout(BusinessObjects.App.GridLayout gridLayout)
        {
            this.gridLayoutRepository.Update(gridLayout);

            this.context.Save();
        }

        #endregion Public Methods
    }
}