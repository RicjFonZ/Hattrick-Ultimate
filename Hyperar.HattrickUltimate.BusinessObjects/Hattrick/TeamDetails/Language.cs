// -----------------------------------------------------------------------
// <copyright file="Language.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
// -----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessObjects.Hattrick.TeamDetails
{
    /// <summary>
    /// Language node within TeamDetails XML file.
    /// </summary>
    public class Language
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the Language ID.
        /// </summary>
        public long LanguageId { get; set; }

        /// <summary>
        /// Gets or sets the name of the Language.
        /// </summary>
        public string LanguageName { get; set; }

        #endregion Public Properties
    }
}