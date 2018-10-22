//-----------------------------------------------------------------------
// <copyright file="IFileAnalysisFactory.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessLogic.Chpp.Interface
{
    using BusinessObjects.Hattrick.Interface;

    /// <summary>
    /// File Analysis Factory Contact.
    /// </summary>
    public interface IFileAnalysisFactory
    {
        /// <summary>
        /// Gets the corresponding strategy for the specified entity.
        /// </summary>
        /// <param name="entity">Entity to validate.</param>
        /// <returns>The corresponding IFileAnalysisStrategy for the specified entity.</returns>
        IFileAnalysisStrategy GetFor(IXmlEntity entity);
    }
}