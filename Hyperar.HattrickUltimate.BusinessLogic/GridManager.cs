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
        public GridManager(
                   IDatabaseContext context,
                   IRepository<BusinessObjects.App.GridLayout> gridLayoutRepository)
        {
            this.context = context;
            this.gridLayoutRepository = gridLayoutRepository;
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// Gets the Grid Layout.
        /// </summary>
        /// <returns>Default Grid Layout.</returns>
        public BusinessObjects.App.GridLayout GetGridLayout()
        {
            return this.gridLayoutRepository.Query()
                                            .Single();
        }

        #endregion Public Methods
    }
}