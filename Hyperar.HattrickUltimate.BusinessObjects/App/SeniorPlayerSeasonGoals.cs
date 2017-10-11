// -----------------------------------------------------------------------
// <copyright file="SeniorPlayerSeasonGoals.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
// -----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessObjects.App
{
    using Interface;

    /// <summary>
    /// Represents the Senior Player Goals on a Season.
    /// </summary>
    public class SeniorPlayerSeasonGoals : EntityBase, IEntity
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the Cup Goals.
        /// </summary>
        public short CupGoals { get; set; }

        /// <summary>
        /// Gets or sets the Friendly Goals.
        /// </summary>
        public short FriendlyGoals { get; set; }

        /// <summary>
        /// Gets or sets the Season.
        /// </summary>
        public short Season { get; set; }

        /// <summary>
        /// Gets or sets the Senior Player.
        /// </summary>
        public virtual SeniorPlayer SeniorPlayer { get; set; }

        /// <summary>
        /// Gets or sets the Senior Player Id.
        /// </summary>
        public int SeniorPlayerId { get; set; }

        /// <summary>
        /// Gets or sets the Series Goals.
        /// </summary>
        public short SeriesGoals { get; set; }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// Returns a System.String that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return this.GetType().FullName;
        }

        #endregion Public Methods
    }
}