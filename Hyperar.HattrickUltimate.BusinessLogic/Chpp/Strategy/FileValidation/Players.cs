//-----------------------------------------------------------------------
// <copyright file="Players.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessLogic.Chpp.Strategy.FileValidation
{
    using System;
    using BusinessObjects.Hattrick.Interface;
    using Chpp.Interface;

    /// <summary>
    /// Players File Validation Strategy.
    /// </summary>
    public class Players : IFileValidationStrategy
    {
        /// <summary>
        /// Validates the specified entity.
        /// </summary>
        /// <param name="entity">Entity to validate.</param>
        public void Validate(IXmlEntity entity)
        {
            var players = entity as BusinessObjects.Hattrick.Players.Root;

            if (players.IsPlayingMatch)
            {
                throw new InvalidOperationException(Localization.Messages.TeamIsPlayingMatch);
            }
        }
    }
}