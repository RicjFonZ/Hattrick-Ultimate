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
        #region Private Fields

        /// <summary>
        /// Strategy Dictionary.
        /// </summary>
        private readonly Dictionary<string, IFileValidationStrategy> strategies;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="FileValidationFactory"/> class.
        /// </summary>
        public FileValidationFactory()
        {
            this.strategies = new Dictionary<string, IFileValidationStrategy>();
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// Gets the corresponding Strategy to Validation the specified file.
        /// </summary>
        /// <param name="entity">Entity to validate.</param>
        /// <returns>The corresponding IFileValidation strategy.</returns>
        public IFileValidationStrategy GetFor(IXmlEntity entity)
        {
            IFileValidationStrategy result = null;

            string key = entity.FileName.ToLower();

            if (!this.strategies.ContainsKey(key))
            {
                switch (key)
                {
                    case XmlFileName.Avatars:
                    case XmlFileName.ManagerCompendium:
                    case XmlFileName.TeamDetails:
                    case XmlFileName.WorldDetails:
                    case XmlFileName.YouthAvatars:
                    case XmlFileName.YouthPlayerList:
                    case XmlFileName.YouthTeamDetails:
                        this.strategies.Add(key, new Default());
                        break;

                    case XmlFileName.Players:
                        this.strategies.Add(key, new Players());
                        break;

                    default:
                        throw new NotImplementedException();
                }
            }

            result = this.strategies[key];

            return result;
        }

        #endregion Public Methods
    }
}