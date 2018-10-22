//-----------------------------------------------------------------------
// <copyright file="Default.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessLogic.Chpp.Strategy.FileValidation
{
    using BusinessLogic.Chpp.Interface;
    using BusinessObjects.Hattrick.Interface;

    /// <summary>
    /// Default File Validation Strategy.
    /// </summary>
    public class Default : IFileValidationStrategy
    {
        /// <summary>
        /// Validates the specified entity.
        /// </summary>
        /// <param name="entity">Entity to validate.</param>
        public void Validate(IXmlEntity entity)
        {
        }
    }
}