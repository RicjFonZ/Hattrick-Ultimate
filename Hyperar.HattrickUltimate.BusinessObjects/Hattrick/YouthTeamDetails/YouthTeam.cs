//-----------------------------------------------------------------------
// <copyright file="YouthTeam.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessObjects.Hattrick.YouthTeamDetails
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// YouthTeam node within YouthTeamDetails XML file.
    /// </summary>
    public class YouthTeam
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the Country.
        /// </summary>
        public Country Country { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the Youth Team was created.
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the next training match can be booked.
        /// </summary>
        public DateTime NextTrainingMatchDate { get; set; }

        /// <summary>
        /// Gets or sets the Owning Team.
        /// </summary>
        public OwningTeam OwningTeam { get; set; }

        /// <summary>
        /// Gets or sets the Region.
        /// </summary>
        public Region Region { get; set; }

        /// <summary>
        /// Gets or sets the Scout list.
        /// </summary>
        public List<Scout> ScoutList { get; set; }

        /// <summary>
        /// Gets or sets the Youth Team Short Name.
        /// </summary>
        public string ShortTeamName { get; set; }

        /// <summary>
        /// Gets or sets the Youth Arena.
        /// </summary>
        public YouthArena YouthArena { get; set; }

        /// <summary>
        /// Gets or sets the Youth League.
        /// </summary>
        public YouthLeague YouthLeague { get; set; }

        /// <summary>
        /// Gets or sets the Youth Team ID.
        /// </summary>
        public long YouthTeamId { get; set; }

        /// <summary>
        /// Gets or sets the Youth Team Name.
        /// </summary>
        public string YouthTeamName { get; set; }

        /// <summary>
        /// Gets or sets the Youth Trainer.
        /// </summary>
        public YouthTrainer YouthTrainer { get; set; }

        #endregion Public Properties
    }
}