// -----------------------------------------------------------------------
// <copyright file="LeagueNationalTeam.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
// -----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessObjects.App
{
    using Interface;

    /// <summary>
    /// Represents a League National Team.
    /// </summary>
    public class LeagueNationalTeam : EntityBase, IEntity
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the Junior National Team Id.
        /// </summary>
        public long JuniorNationalTeamId { get; set; }

        /// <summary>
        /// Gets or sets the League.
        /// </summary>
        public virtual League League { get; set; }

        /// <summary>
        /// Gets the League Id.
        /// </summary>
        public int? LeagueId
        {
            get
            {
                return this.League?.Id;
            }
        }

        /// <summary>
        /// Gets or sets the Senior National Team Id.
        /// </summary>
        public long SeniorNationalTeamId { get; set; }

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