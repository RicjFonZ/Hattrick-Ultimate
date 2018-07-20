//-----------------------------------------------------------------------
// <copyright file="GridLayoutColumn.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessObjects.App
{
    using Interface;

    /// <summary>
    /// Represents a GridLayoutColumn.
    /// </summary>
    public class GridLayoutColumn : EntityBase, IEntity
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the Width.
        /// </summary>
        public int Alignment { get; set; }

        /// <summary>
        /// Gets or sets the Custom Header Text.
        /// </summary>
        public string CustomHeaderText { get; set; }

        /// <summary>
        /// Gets or sets the Display Index.
        /// </summary>
        public int DisplayIndex { get; set; }

        /// <summary>
        /// Gets or sets the Display Mode.
        /// </summary>
        public byte DisplayMode { get; set; }

        /// <summary>
        /// Gets or sets the Grid Column.
        /// </summary>
        public virtual GridColumn GridColumn { get; set; }

        /// <summary>
        /// Gets or sets the Grid Column ID.
        /// </summary>
        public int GridColumnId { get; set; }

        /// <summary>
        /// Gets or sets the Grid Layout.
        /// </summary>
        public virtual GridLayout GridLayout { get; set; }

        /// <summary>
        /// Gets or sets the Grid Layout ID.
        /// </summary>
        public int GridLayoutId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether it's fixed or not.
        /// </summary>
        public bool IsFixed { get; set; }

        /// <summary>
        /// Gets or sets the Width.
        /// </summary>
        public int Width { get; set; }

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