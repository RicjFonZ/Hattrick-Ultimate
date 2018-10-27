// -----------------------------------------------------------------------
// <copyright file="JuniorPlayer.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
// -----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessObjects.App
{
    using System;
    using System.Collections.Generic;
    using Interface;

    /// <summary>
    /// Represents a Junior Player.
    /// </summary>
    public class JuniorPlayer : HattrickEntityBase, IEntity, IHattrickEntity
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the Age Days.
        /// </summary>
        public byte AgeDays { get; set; }

        /// <summary>
        /// Gets or sets the date when the Player arrived to the Team.
        /// </summary>
        public DateTime ArrivedOn { get; set; }

        /// <summary>
        /// Gets or sets the Junior Player.
        /// </summary>
        public virtual JuniorPlayerAvatar Avatar { get; set; }

        /// <summary>
        /// Gets or sets the Booking Status.
        /// </summary>
        public byte BookingStatus { get; set; }

        /// <summary>
        /// Gets or sets the Category.
        /// </summary>
        public byte? Category { get; set; }

        /// <summary>
        /// Gets or sets the Days To Promote.
        /// </summary>
        public int DaysToPromote { get; set; }

        /// <summary>
        /// Gets or sets the FirstName.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the Junior Team.
        /// </summary>
        public virtual JuniorTeam JuniorTeam { get; set; }

        /// <summary>
        /// Gets or sets the Junior Team Id.
        /// </summary>
        public int JuniorTeamId { get; set; }

        /// <summary>
        /// Gets or sets the LastName.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the NickName.
        /// </summary>
        public string NickName { get; set; }

        /// <summary>
        /// Gets or sets the Owner Notes.
        /// </summary>
        public string OwnerNotes { get; set; }

        /// <summary>
        /// Gets or sets the Shirt Number.
        /// </summary>
        public byte? ShirtNumber { get; set; }

        /// <summary>
        /// Gets or sets the Specialty.
        /// </summary>
        public byte? Specialty { get; set; }

        /// <summary>
        /// Gets or sets the Statement.
        /// </summary>
        public string Statement { get; set; }

        /// <summary>
        /// Gets or sets the Junior Player Week Logs.
        /// </summary>
        public virtual ICollection<JuniorPlayerWeekLog> WeekLogs { get; set; } = new HashSet<JuniorPlayerWeekLog>();

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