// -----------------------------------------------------------------------
// <copyright file="Language.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
// -----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessObjects.Hattrick.ManagerCompendium
{
    /// <summary>
    /// Language node within ManagerCompendium XML file.
    /// </summary>
    public class Language
    {
        #region Properties

        /// <summary>
        /// Gets or sets the ID.
        /// </summary>
        public uint LanguageId { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string LanguageName { get; set; }

        #endregion Properties
    }
}