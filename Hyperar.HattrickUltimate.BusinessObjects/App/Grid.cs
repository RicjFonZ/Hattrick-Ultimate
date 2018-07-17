//-----------------------------------------------------------------------
// <copyright file="Grid.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessObjects.App
{
    using System.Collections.Generic;
    using Interface;

    /// <summary>
    /// Represents a Grid.
    /// </summary>
    public class Grid : EntityBase, IEntity
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the Grid Columns.
        /// </summary>
        public virtual ICollection<GridColumn> GridColumns { get; set; } = new HashSet<GridColumn>();

        /// <summary>
        /// Gets or sets the Grid Layouts.
        /// </summary>
        public virtual ICollection<GridLayout> GridLayouts { get; set; } = new HashSet<GridLayout>();

        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        public string Name { get; set; }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// Returns a System.String that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return this.GetType().FullName;
        }

        #endregion Public Methods
    }
}