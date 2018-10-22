//-----------------------------------------------------------------------
// <copyright file="IFileValidationFactory.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessLogic.Chpp.Interface
{
    using BusinessObjects.Hattrick.Interface;

    /// <summary>
    /// File Validation Factory Contact.
    /// </summary>
    public interface IFileValidationFactory
    {
        /// <summary>
        /// Gets the corresponding strategy for the specified entity.
        /// </summary>
        /// <param name="entity">Entity to validate.</param>
        /// <returns>The corresponding IFileValidationStrategy for the specified entity.</returns>
        IFileValidationStrategy GetFor(IXmlEntity entity);
    }
}