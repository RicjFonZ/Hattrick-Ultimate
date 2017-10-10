// -----------------------------------------------------------------------
// <copyright file="LeagueCup.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
// -----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessObjects.App
{
    using Enums;
    using Interface;

    /// <summary>
    /// Represents a League Cup.
    /// </summary>
    public class LeagueCup : HattrickEntityBase, IEntity, IHattrickEntity
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the Current Round on this season.
        /// </summary>
        public byte CurrentRound { get; set; }

        /// <summary>
        /// Gets or sets the Division.
        /// </summary>
        public byte? Division { get; set; }

        /// <summary>
        /// Gets or sets the League.
        /// </summary>
        public virtual League League { get; set; }

        /// <summary>
        /// Gets or sets the League Id.
        /// </summary>
        public int LeagueId { get; set; }

        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Rounds left on this season.
        /// </summary>
        public byte RoundsLeft { get; set; }

        /// <summary>
        /// Gets or sets the Tier.
        /// </summary>
        public LeagueCupTier? Tier { get; set; }

        /// <summary>
        /// Gets or sets the Type.
        /// </summary>
        public LeagueCupType Type { get; set; }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// Returns a System.String that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return $"{this.Name} ({this.HattrickId})";
        }

        #endregion Public Methods
    }
}