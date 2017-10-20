// -----------------------------------------------------------------------
// <copyright file="IFileProcessFactory.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
// -----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessLogic.Chpp.Interface
{
    using BusinessObjects.Hattrick.Interface;

    /// <summary>
    /// File Process Factory definition.
    /// </summary>
    public interface IFileProcessFactory
    {
        #region Public Methods

        /// <summary>
        /// Gets the corresponding IFileProcessStrategy for the specified IXmlEntity object.
        /// </summary>
        /// <param name="entity">IXmlEntity object to process.</param>
        /// <returns>Correct IFileProcessStrategy object for the specified IXmlEntity.</returns>
        IFileProcessStrategy GetFor(IXmlEntity entity);

        #endregion Public Methods
    }
}