// -----------------------------------------------------------------------
// <copyright file="Manager.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
// -----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessObjects.App
{
    using System.Collections.Generic;
    using Enums;
    using Interface;

    /// <summary>
    /// Represents a Manager.
    /// </summary>
    public class Manager : HattrickEntityBase, IEntity, IHattrickEntity
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the Country.
        /// </summary>
        public virtual Country Country { get; set; }

        /// <summary>
        /// Gets or sets the Country Id.
        /// </summary>
        public int CountryId { get; set; }

        /// <summary>
        /// Gets or sets the Senior Teams.
        /// </summary>
        public virtual ICollection<SeniorTeam> SeniorTeams { get; set; } = new HashSet<SeniorTeam>();

        /// <summary>
        /// Gets or sets the Supporter Tier.
        /// </summary>
        public SupporterTier SupporterTier { get; set; }

        /// <summary>
        /// Gets or sets the User.
        /// </summary>
        public virtual User User { get; set; }

        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        public string UserName { get; set; }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// Returns a System.String that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return $"{this.UserName} ({this.HattrickId})";
        }

        #endregion Public Methods
    }
}