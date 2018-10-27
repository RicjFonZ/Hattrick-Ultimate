//-----------------------------------------------------------------------
// <copyright file="IFileValidationStrategy.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessLogic.Chpp.Interface
{
    using BusinessObjects.Hattrick.Interface;

    /// <summary>
    /// File Validation Strategy Contract.
    /// </summary>
    public interface IFileValidationStrategy
    {
        #region Public Methods

        /// <summary>
        /// Validates the specified entity.
        /// </summary>
        /// <param name="entity">Entity to validate.</param>
        void Validate(IXmlEntity entity);

        #endregion Public Methods
    }
}