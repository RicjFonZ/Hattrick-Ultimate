//-----------------------------------------------------------------------
// <copyright file="FileValidator.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessLogic.Chpp
{
    using BusinessLogic.Chpp.Interface;
    using BusinessObjects.Hattrick.Interface;

    /// <summary>
    /// Provides functionality to validate CHPP files.
    /// </summary>
    public class FileValidator : IFileValidationStrategy
    {
        #region Private Fields

        /// <summary>
        /// File Validation Strategy Factory.
        /// </summary>
        private readonly IFileValidationFactory factory;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="FileValidator"/> class.
        /// </summary>
        /// <param name="factory">File Validation Strategy Factory.</param>
        public FileValidator(IFileValidationFactory factory)
        {
            this.factory = factory;
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// Validates the specified File.
        /// </summary>
        /// <param name="entity">Entity to validate.</param>
        public void Validate(IXmlEntity entity)
        {
            this.factory.GetFor(entity)
                        .Validate(entity);
        }

        #endregion Public Methods
    }
}