//-----------------------------------------------------------------------
// <copyright file="IDataGridViewColumnBuilderFactory.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.UserInterface.Interface
{
    using BusinessObjects.App.Enums;

    /// <summary>
    /// DataGridViewColumnBuilderFactory contract.
    /// </summary>
    public interface IDataGridViewColumnBuilderFactory
    {
        #region Public Methods

        /// <summary>
        /// Gets the correct strategy for the specified column type.
        /// </summary>
        /// <param name="columnType">Column type to build.</param>
        /// <returns>The corresponding IDataGridViewColumnBuilderStrategy object.</returns>
        IDataGridViewColumnBuilderStrategy GetFor(GridColumnType columnType);

        #endregion Public Methods
    }
}