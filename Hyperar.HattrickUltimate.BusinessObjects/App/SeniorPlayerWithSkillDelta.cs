//-----------------------------------------------------------------------
// <copyright file="SeniorPlayerWithSkillDelta.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessObjects.App
{
    using Interface;

    /// <summary>
    /// Represents a SeniorPlayerWithSkillDelta view record.
    /// </summary>
    public class SeniorPlayerWithSkillDelta : HattrickEntityBase, IHattrickEntity
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the Age.
        /// </summary>
        public decimal Age { get; set; }

        /// <summary>
        /// Gets or sets the Aggressiveness.
        /// </summary>
        public int Aggressiveness { get; set; }

        /// <summary>
        /// Gets or sets the Agreeability.
        /// </summary>
        public int Agreeability { get; set; }

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
        /// Gets or sets the Country English Name.
        /// </summary>
        public string CountryEnglishName { get; set; }

        /// <summary>
        /// Gets or sets the Country Hattrick ID.
        /// </summary>
        public long CountryHattrickId { get; set; }

        /// <summary>
        /// Gets or sets the Country ID.
        /// </summary>
        public int CountryId { get; set; }

        /// <summary>
        /// Gets or sets the Country Name.
        /// </summary>
        public string CountryName { get; set; }

        /// <summary>
        /// Gets or sets the Defending.
        /// </summary>
        public int Defending { get; set; }

        /// <summary>
        /// Gets or sets the Defending Delta.
        /// </summary>
        public int? DefendingDelta { get; set; }

        /// <summary>
        /// Gets or sets the Experience.
        /// </summary>
        public int Experience { get; set; }

        /// <summary>
        /// Gets or sets the Experience Delta.
        /// </summary>
        public int? ExperienceDelta { get; set; }

        /// <summary>
        /// Gets or sets the First Name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the Form.
        /// </summary>
        public int Form { get; set; }

        /// <summary>
        /// Gets or sets the Form Delta.
        /// </summary>
        public int? FormDelta { get; set; }

        /// <summary>
        /// Gets the Full Name.
        /// </summary>
        public string FullName
        {
            get
            {
                if (string.IsNullOrWhiteSpace(this.NickName))
                {
                    return $"{this.FirstName} {this.LastName}";
                }
                else
                {
                    return $"{this.FirstName} \" {this.NickName}\" {this.LastName}";
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the player Has Homegrown Bonus or not.
        /// </summary>
        public bool HasHomegrownBonus { get; set; }

        /// <summary>
        /// Gets or sets the Honesty.
        /// </summary>
        public int Honesty { get; set; }

        /// <summary>
        /// Gets or sets the Injury Status.
        /// </summary>
        public byte? InjuryStatus { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the player Is On Transfer Market or not.
        /// </summary>
        public bool IsOnTransferMarket { get; set; }

        /// <summary>
        /// Gets or sets the Keeper.
        /// </summary>
        public int Keeper { get; set; }

        /// <summary>
        /// Gets or sets the Keeper Delta.
        /// </summary>
        public int? KeeperDelta { get; set; }

        /// <summary>
        /// Gets or sets the Age.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the Leadership.
        /// </summary>
        public int Leadership { get; set; }

        /// <summary>
        /// Gets or sets the Loyalty.
        /// </summary>
        public int Loyalty { get; set; }

        /// <summary>
        /// Gets or sets the Loyalty Delta.
        /// </summary>
        public int? LoyaltyDelta { get; set; }

        /// <summary>
        /// Gets or sets the Matches On Junior National Team.
        /// </summary>
        public short MatchesOnJuniorNationalTeam { get; set; }

        /// <summary>
        /// Gets or sets the Matches On Senior National Team.
        /// </summary>
        public short MatchesOnSeniorNationalTeam { get; set; }

        /// <summary>
        /// Gets or sets the Nick Name.
        /// </summary>
        public string NickName { get; set; }

        /// <summary>
        /// Gets or sets the Passing.
        /// </summary>
        public int Passing { get; set; }

        /// <summary>
        /// Gets or sets the Passing Delta.
        /// </summary>
        public int? PassingDelta { get; set; }

        /// <summary>
        /// Gets or sets the Playmaking.
        /// </summary>
        public int Playmaking { get; set; }

        /// <summary>
        /// Gets or sets the Playmaking Delta.
        /// </summary>
        public int? PlaymakingDelta { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the player Plays On National Team or not.
        /// </summary>
        public bool PlaysOnNationalTeam { get; set; }

        /// <summary>
        /// Gets or sets the Scoring.
        /// </summary>
        public int Scoring { get; set; }

        /// <summary>
        /// Gets or sets the Scoring Delta.
        /// </summary>
        public int? ScoringDelta { get; set; }

        /// <summary>
        /// Gets or sets the Senior Team ID.
        /// </summary>
        public int SeniorTeamId { get; set; }

        /// <summary>
        /// Gets or sets the Set Pieces.
        /// </summary>
        public int SetPieces { get; set; }

        /// <summary>
        /// Gets or sets the Set Pieces Delta.
        /// </summary>
        public int? SetPiecesDelta { get; set; }

        /// <summary>
        /// Gets or sets the Specialty.
        /// </summary>
        public int Specialty { get; set; }

        /// <summary>
        /// Gets or sets the Stamina.
        /// </summary>
        public int Stamina { get; set; }

        /// <summary>
        /// Gets or sets the Stamina Delta.
        /// </summary>
        public int? StaminaDelta { get; set; }

        /// <summary>
        /// Gets or sets the Total Skill Index.
        /// </summary>
        public int TotalSkillIndex { get; set; }

        /// <summary>
        /// Gets or sets the Total Skill Index Delta.
        /// </summary>
        public int? TotalSkillIndexDelta { get; set; }

        /// <summary>
        /// Gets or sets the Wage.
        /// </summary>
        public int Wage { get; set; }

        /// <summary>
        /// Gets or sets the Winger.
        /// </summary>
        public int Winger { get; set; }

        /// <summary>
        /// Gets or sets the Winger Delta.
        /// </summary>
        public int? WingerDelta { get; set; }

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