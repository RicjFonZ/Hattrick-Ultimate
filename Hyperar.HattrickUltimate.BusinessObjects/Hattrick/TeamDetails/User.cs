// -----------------------------------------------------------------------
// <copyright file="User.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
// -----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessObjects.Hattrick.TeamDetails
{
    using System;

    /// <summary>
    /// User node within TeamDetails XML file.
    /// </summary>
    public class User
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the Activation Date.
        /// </summary>
        public DateTime ActivationDate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether if the manager has license or not.
        /// </summary>
        public bool HasManagerLicense { get; set; }

        /// <summary>
        /// Gets or sets the Icq.
        /// </summary>
        public string Icq { get; set; }

        /// <summary>
        /// Gets or sets the Language.
        /// </summary>
        public Language Language { get; set; }

        /// <summary>
        /// Gets or sets the Last Login Date.
        /// </summary>
        public DateTime LastLoginDate { get; set; }

        /// <summary>
        /// Gets or sets the Loginname.
        /// </summary>
        public string Loginname { get; set; }

        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the National Team Coach.
        /// </summary>
        public NationalTeamCoach NationalTeamCoach { get; set; }

        /// <summary>
        /// Gets or sets the Signup Date.
        /// </summary>
        public DateTime SignupDate { get; set; }

        /// <summary>
        /// Gets or sets the Supporter Tier.
        /// </summary>
        public string SupporterTier { get; set; }

        /// <summary>
        /// Gets or sets the User Id.
        /// </summary>
        public long UserId { get; set; }

        #endregion Public Properties
    }
}