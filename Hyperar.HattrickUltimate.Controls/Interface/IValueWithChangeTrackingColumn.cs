//-----------------------------------------------------------------------
// <copyright file="IValueWithChangeTrackingColumn.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.Controls.Interface
{
    using System.Drawing;

    /// <summary>
    /// ValueWithChangeTrackingColumn contract.
    /// </summary>
    public interface IValueWithChangeTrackingColumn
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the color to represent negative value changes.
        /// </summary>
        Color NegativeChangeBackColor { get; set; }

        /// <summary>
        /// Gets or sets the color to represent positive value changes.
        /// </summary>
        Color PositiveChangeBackColor { get; set; }

        /// <summary>
        /// Gets or sets the name of the value change bound property.
        /// </summary>
        string ValueChangeTrackingPropertyName { get; set; }

        #endregion Public Properties
    }
}