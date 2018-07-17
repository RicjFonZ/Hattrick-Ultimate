//-----------------------------------------------------------------------
// <copyright file="GridColumn.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessObjects.App
{
    using System.Collections.Generic;
    using Interface;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class GridColumn : EntityBase, IEntity
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the Display Property.
        /// </summary>
        public string DisplayProperty { get; set; }

        /// <summary>
        /// Gets or sets the Grid.
        /// </summary>
        public virtual Grid Grid { get; set; }

        /// <summary>
        /// Gets or sets the Grid ID.
        /// </summary>
        public int GridId { get; set; }

        /// <summary>
        /// Gets or sets the Grid Layout Columns.
        /// </summary>
        public virtual ICollection<GridLayoutColumn> GridLayoutColumns { get; set; } = new HashSet<GridLayoutColumn>();

        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Value Property.
        /// </summary>
        public string ValueProperty { get; set; }

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