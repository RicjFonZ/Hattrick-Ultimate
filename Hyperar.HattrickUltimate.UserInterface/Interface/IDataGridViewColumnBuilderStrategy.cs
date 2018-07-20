//-----------------------------------------------------------------------
// <copyright file="IDataGridViewColumnBuilderStrategy.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.UserInterface.Interface
{
    using System.Windows.Forms;

    /// <summary>
    /// DataGridViewColumnBuilderStrategy contract.
    /// </summary>
    public interface IDataGridViewColumnBuilderStrategy
    {
        #region Public Methods

        /// <summary>
        /// Builds a DataGridViewColumn using the specified GridLayoutColumn as a templates.
        /// </summary>
        /// <param name="gridLayoutColumn">Grid Layout Column to use as a template.</param>
        /// <returns>DataGridViewColumn generated with the specified template.</returns>
        DataGridViewColumn Build(BusinessObjects.App.GridLayoutColumn gridLayoutColumn);

        #endregion Public Methods
    }
}