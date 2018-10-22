//-----------------------------------------------------------------------
// <copyright file="FileValidationFactory.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessLogic.Chpp.Factory
{
    using System;
    using System.Collections.Generic;
    using BusinessLogic.Chpp.Interface;
    using BusinessLogic.Chpp.Strategy.FileValidation;
    using BusinessObjects.Hattrick.Interface;
    using DataAccess.Chpp.Constants;

    /// <summary>
    /// File Validation Strategy Factory.
    /// </summary>
    public class FileValidationFactory : IFileValidationFactory
    {
        /// <summary>
        /// Strategy Dictionary.
        /// </summary>
        private readonly Dictionary<string, IFileValidationStrategy> strategies;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileValidationFactory"/> class.
        /// </summary>
        public FileValidationFactory()
        {
            this.strategies = new Dictionary<string, IFileValidationStrategy>();
        }

        /// <summary>
        /// Gets the corresponding Strategy to Validation the specified file.
        /// </summary>
        /// <param name="entity">Entity to validate.</param>
        /// <returns>The corresponding IFileValidation strategy.</returns>
        public IFileValidationStrategy GetFor(IXmlEntity entity)
        {
            IFileValidationStrategy result = null;

            if (!this.strategies.ContainsKey(entity.FileName.ToLower()))
            {
                switch (entity.FileName.ToLower())
                {
                    case XmlFileName.Avatars:
                    case XmlFileName.ManagerCompendium:
                    case XmlFileName.TeamDetails:
                    case XmlFileName.WorldDetails:
                    case XmlFileName.YouthTeamDetails:
                        this.strategies.Add(entity.FileName, new Default());
                        break;

                    case XmlFileName.Players:
                        this.strategies.Add(entity.FileName, new Players());
                        break;

                    default:
                        throw new NotImplementedException();
                }
            }

            result = this.strategies[entity.FileName];

            return result;
        }
    }
}