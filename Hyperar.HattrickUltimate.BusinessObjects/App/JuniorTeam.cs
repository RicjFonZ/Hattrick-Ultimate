// -----------------------------------------------------------------------
// <copyright file="JuniorTeam.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
// -----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessObjects.App
{
    using System.Collections.Generic;
    using Interface;

    /// <summary>
    /// Represents a Junior Team.
    /// </summary>
    public class JuniorTeam : HattrickEntityBase, IEntity, IHattrickEntity
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the FullName.
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Gets or sets the Junior Players.
        /// </summary>
        public virtual ICollection<JuniorPlayer> JuniorPlayers { get; set; } = new HashSet<JuniorPlayer>();

        /// <summary>
        /// Gets or sets the Junior Series.
        /// </summary>
        public virtual JuniorSeries JuniorSeries { get; set; }

        /// <summary>
        /// Gets or sets the Junior Series Id.
        /// </summary>
        public int? JuniorSeriesId { get; set; }

        /// <summary>
        /// Gets or sets the Senior Team.
        /// </summary>
        public virtual SeniorTeam SeniorTeam { get; set; }

        /// <summary>
        /// Gets the Senior Team Id.
        /// </summary>
        public int? SeniorTeamId
        {
            get
            {
                return this.SeniorTeam?.Id;
            }
        }

        /// <summary>
        /// Gets or sets the ShortName.
        /// </summary>
        public string ShortName { get; set; }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// Returns a System.String that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return $"{this.FullName} ({this.HattrickId})";
        }

        #endregion Public Methods
    }
}