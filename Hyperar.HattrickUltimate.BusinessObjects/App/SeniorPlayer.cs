// -----------------------------------------------------------------------
// <copyright file="SeniorPlayer.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
// -----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessObjects.App
{
    using System.Collections.Generic;
    using Interface;

    /// <summary>
    /// Represents a Senior Player.
    /// </summary>
    public class SeniorPlayer : HattrickEntityBase, IEntity, IHattrickEntity
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the Age.
        /// </summary>
        public decimal Age { get; set; }

        /// <summary>
        /// Gets or sets the Aggressiveness.
        /// </summary>
        public byte Aggressiveness { get; set; }

        /// <summary>
        /// Gets or sets the Agreeability.
        /// </summary>
        public byte Agreeability { get; set; }

        /// <summary>
        /// Gets or sets the Booking Status.
        /// </summary>
        public byte BookingStatus { get; set; }

        /// <summary>
        /// Gets or sets the Career Goals.
        /// </summary>
        public short CareerGoals { get; set; }

        /// <summary>
        /// Gets or sets the Career Hattricks.
        /// </summary>
        public short CareerHattricks { get; set; }

        /// <summary>
        /// Gets or sets the Category.
        /// </summary>
        public byte? Category { get; set; }

        /// <summary>
        /// Gets or sets the Country.
        /// </summary>
        public virtual Country Country { get; set; }

        /// <summary>
        /// Gets or sets the Country Id.
        /// </summary>
        public int CountryId { get; set; }

        /// <summary>
        /// Gets or sets the FirstName.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the player has the Homegrown Bonus or not.
        /// </summary>
        public bool HasHomegrownBonus { get; set; }

        /// <summary>
        /// Gets or sets the Honesty.
        /// </summary>
        public byte Honesty { get; set; }

        /// <summary>
        /// Gets or sets the Injury Status.
        /// </summary>
        public byte? InjuryStatus { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the player is on the Transfer Market or not.
        /// </summary>
        public bool IsOnTransferMarket { get; set; }

        /// <summary>
        /// Gets or sets the LastName.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the Leadership.
        /// </summary>
        public byte Leadership { get; set; }

        /// <summary>
        /// Gets or sets the Matches played on the Junior National Team.
        /// </summary>
        public short MatchesOnJuniorNationalTeam { get; set; }

        /// <summary>
        /// Gets or sets the Matches played on the Senior National Team.
        /// </summary>
        public short MatchesOnSeniorNationalTeam { get; set; }

        /// <summary>
        /// Gets or sets the NickName.
        /// </summary>
        public string NickName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the player is enrolled on the National Team or not.
        /// </summary>
        public bool PlaysOnNationalTeam { get; set; }

        /// <summary>
        /// Gets or sets the Senior Player SeasonGoals.
        /// </summary>
        public virtual ICollection<SeniorPlayerSeasonGoals> SeasonGoals { get; set; } = new HashSet<SeniorPlayerSeasonGoals>();

        /// <summary>
        /// Gets or sets the Senior Team.
        /// </summary>
        public virtual SeniorTeam SeniorTeam { get; set; }

        /// <summary>
        /// Gets or sets the Senior Team Id.
        /// </summary>
        public int SeniorTeamId { get; set; }

        /// <summary>
        /// Gets or sets the Senior Player Skills.
        /// </summary>
        public virtual ICollection<SeniorPlayerSkills> Skills { get; set; } = new HashSet<SeniorPlayerSkills>();

        /// <summary>
        /// Gets or sets the Specialty.
        /// </summary>
        public byte Specialty { get; set; }

        /// <summary>
        /// Gets or sets the Statement.
        /// </summary>
        public string Statement { get; set; }

        /// <summary>
        /// Gets or sets the Wage.
        /// </summary>
        public int Wage { get; set; }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// Returns a System.String that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            if (!string.IsNullOrWhiteSpace(this.NickName))
            {
                return $"{this.FirstName} \"{this.NickName}\" {this.LastName} ({this.HattrickId})";
            }
            else
            {
                return $"{this.FirstName} {this.LastName} ({this.HattrickId})";
            }
        }

        #endregion Public Methods
    }
}