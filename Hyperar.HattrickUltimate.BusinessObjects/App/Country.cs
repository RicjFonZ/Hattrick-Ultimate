// -----------------------------------------------------------------------
// <copyright file="Country.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
// -----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessObjects.App
{
    using System.Collections.Generic;
    using Interface;

    /// <summary>
    /// Represents a Country.
    /// </summary>
    public class Country : HattrickEntityBase, IEntity, IHattrickEntity
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the Currency.
        /// </summary>
        public virtual Currency Currency { get; set; }

        /// <summary>
        /// Gets or sets the Currency ID.
        /// </summary>
        public int CurrencyId { get; set; }

        /// <summary>
        /// Gets or sets the Date Format.
        /// </summary>
        public virtual DateFormat DateFormat { get; set; }

        /// <summary>
        /// Gets or sets the Date Format ID.
        /// </summary>
        public int DateFormatId { get; set; }

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
        /// Gets or sets the Managers.
        /// </summary>
        public virtual ICollection<Manager> Managers { get; set; } = new HashSet<Manager>();

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Country Regions.
        /// </summary>
        public virtual ICollection<Region> Regions { get; set; } = new HashSet<Region>();

        /// <summary>
        /// Gets or sets the Senior Players.
        /// </summary>
        public ICollection<SeniorPlayer> SeniorPlayers { get; set; } = new HashSet<SeniorPlayer>();

        /// <summary>
        /// Gets or sets the Time Format.
        /// </summary>
        public virtual TimeFormat TimeFormat { get; set; }

        /// <summary>
        /// Gets or sets the Time Format ID.
        /// </summary>
        public int TimeFormatId { get; set; }

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