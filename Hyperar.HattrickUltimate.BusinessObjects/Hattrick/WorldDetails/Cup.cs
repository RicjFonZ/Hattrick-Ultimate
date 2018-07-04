// -----------------------------------------------------------------------
// <copyright file="Cup.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
// -----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessObjects.Hattrick.WorldDetails
{
    /// <summary>
    /// Cup node within WorldDetails XML file.
    /// </summary>
    public class Cup
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the Cup ID.
        /// </summary>
        public long CupId { get; set; }

        /// <summary>
        /// Gets or sets the Cup League Level.
        /// </summary>
        /// <remarks>
        /// For National cups (Levels 1 through 6) DO NOT have a League Level, and Hattrick
        /// represents this with a 0 instead of a NULL.
        /// </remarks>
        public byte CupLeagueLevel { get; set; }

        /// <summary>
        /// Gets or sets the Cup Level.
        /// </summary>
        /// <remarks>
        /// DO NOT mistake with CupLeagueLevel. National/Divisional Cups: 1. Challenger Cups: 2.
        /// Consolation Cups: 3.
        /// </remarks>
        public byte CupLevel { get; set; }

        /// <summary>
        /// Gets or sets the CupLevelIndex
        /// </summary>
        /// <remarks>
        /// Only Consolation Cups have a Level Index, for the rest the value is always 1.
        /// Emerald: 1.
        /// Ruby: 2.
        /// Sapphire: 3.
        /// </remarks>
        public byte CupLevelIndex { get; set; }

        /// <summary>
        /// Gets or sets the name of the Cup.
        /// </summary>
        public string CupName { get; set; }

        /// <summary>
        /// Gets or sets the current match round of the Cup.
        /// </summary>
        public byte MatchRound { get; set; }

        /// <summary>
        /// Gets or sets the number of match rounds of the Cup left to be played.
        /// </summary>
        public byte MatchRoundsLeft { get; set; }

        #endregion Public Properties
    }
}