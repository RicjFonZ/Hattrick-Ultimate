// -----------------------------------------------------------------------
// <copyright file="Player.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
// -----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessObjects.Hattrick.Players
{
    /// <summary>
    /// Player node within WorldDetails XML file.
    /// </summary>
    public class Player
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the player age in years.
        /// </summary>
        public byte Age { get; set; }

        /// <summary>
        /// Gets or sets the days since the last birthday.
        /// </summary>
        public byte AgeDays { get; set; }

        /// <summary>
        /// Gets or sets the Aggressiveness.
        /// </summary>
        public byte Aggressiveness { get; set; }

        /// <summary>
        /// Gets or sets the Agreeability.
        /// </summary>
        public byte Agreeability { get; set; }

        /// <summary>
        /// Gets or sets the number of caps for the Senior National Team.
        /// </summary>
        public ushort Caps { get; set; }

        /// <summary>
        /// Gets or sets the number of caps for the Junior National Team.
        /// </summary>
        public ushort CapsU20 { get; set; }

        /// <summary>
        /// Gets or sets the number of bookings.
        /// </summary>
        /// <remarks>
        /// One yellow card: 1.
        /// Two yellow cards: 2.
        /// Suspended: 3. Two bookings on the same game or by accumulation of 3 yellow cards.
        /// </remarks>
        public byte Cards { get; set; }

        /// <summary>
        /// Gets or sets the number of goals on his career.
        /// </summary>
        public ushort CareerGoals { get; set; }

        /// <summary>
        /// Gets or sets the number of hattricks on his career.
        /// </summary>
        public ushort CareerHattricks { get; set; }

        /// <summary>
        /// Gets or sets the Country Id.
        /// </summary>
        public uint CountryId { get; set; }

        /// <summary>
        /// Gets or sets the league cup goals within the current season.
        /// </summary>
        public byte CupGoals { get; set; }

        /// <summary>
        /// Gets or sets the Defender skill level.
        /// </summary>
        /// <remarks>
        /// Only available for owned or transferlisted players.
        /// </remarks>
        public byte? DefenderSkill { get; set; }

        /// <summary>
        /// Gets or sets the Experience.
        /// </summary>
        public byte Experience { get; set; }

        /// <summary>
        /// Gets or sets the First Name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the friendlies goals within the current season.
        /// </summary>
        public byte FriendliesGoals { get; set; }

        /// <summary>
        /// Gets or sets the Honesty.
        /// </summary>
        public byte Honesty { get; set; }

        /// <summary>
        /// Gets or sets the Injury level.
        /// </summary>
        /// <remarks>
        /// Healthy: -1.
        /// Bruised: 0.
        /// Injured: > 0.
        /// </remarks>
        public sbyte InjuryLevel { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the player is foreign or not.s
        /// </summary>
        /// <remarks>
        /// The value is a binary in the Xml file.
        /// </remarks>
        public bool IsAbroad { get; set; }

        /// <summary>
        /// Gets or sets the Keeper skill level.
        /// </summary>
        /// <remarks>
        /// Only available for owned or transferlisted players.
        /// </remarks>
        public byte? KeeperSkill { get; set; }

        /// <summary>
        /// Gets or sets the Last match.
        /// </summary>
        public LastMatch LastMatch { get; set; }

        /// <summary>
        /// Gets or sets the LastName.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the Leadership.
        /// </summary>
        public byte Leadership { get; set; }

        /// <summary>
        /// Gets or sets the league goals within the current season.
        /// </summary>
        public byte LeagueGoals { get; set; }

        /// <summary>
        /// Gets or sets the Loyalty.
        /// </summary>
        public byte Loyalty { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the player has the Mother Club Bonus or not.
        /// </summary>
        public bool MotherClubBonus { get; set; }

        /// <summary>
        /// Gets or sets the National Team Id if he's selected.
        /// </summary>
        public uint NationalTeamId { get; set; }

        /// <summary>
        /// Gets or sets the NickName.
        /// </summary>
        public string NickName { get; set; }

        /// <summary>
        /// Gets or sets the Passing skill level.
        /// </summary>
        /// <remarks>
        /// Only available for owned or transferlisted players.
        /// </remarks>
        public byte? PassingSkill { get; set; }

        /// <summary>
        /// Gets or sets the Player category.
        /// </summary>
        /// <remarks>
        /// Only available for owned players.
        /// </remarks>
        public byte? PlayerCategoryId { get; set; }

        /// <summary>
        /// Gets or sets the Player Form.
        /// </summary>
        public byte PlayerForm { get; set; }

        /// <summary>
        /// Gets or sets the Player Id.
        /// </summary>
        public uint PlayerId { get; set; }

        /// <summary>
        /// Gets or sets the Player Number.
        /// </summary>
        /// <remarks>
        /// A value of 100 means no number for the player.
        /// </remarks>
        public byte PlayerNumber { get; set; }

        /// <summary>
        /// Gets or sets the Playmaker skill level.
        /// </summary>
        /// <remarks>
        /// Only available for owned or transferlisted players.
        /// </remarks>
        public byte? PlaymakerSkill { get; set; }

        /// <summary>
        /// Gets or sets the Salary.
        /// </summary>
        /// <remarks>
        /// The value is given in Swedish Kroner (kr).
        /// </remarks>
        public uint Salary { get; set; }

        /// <summary>
        /// Gets or sets the Scorer skill level.
        /// </summary>
        /// <remarks>
        /// Only available for owned or transferlisted players.
        /// </remarks>
        public byte? ScorerSkill { get; set; }

        /// <summary>
        /// Gets or sets the Set Pieces skill level.
        /// </summary>
        /// <remarks>
        /// Only available for owned or transferlisted players.
        /// </remarks>
        public byte? SetPiecesSkill { get; set; }

        /// <summary>
        /// Gets or sets the specialty.
        /// </summary>
        public byte Specialty { get; set; }

        /// <summary>
        /// Gets or sets the Stamina skill level.
        /// </summary>
        public byte StaminaSkill { get; set; }

        /// <summary>
        /// Gets or sets the Statement.s
        /// </summary>
        public string Statement { get; set; }

        /// <summary>
        /// Gets or sets the Trainer data.
        /// </summary>
        public TrainerData TrainerData { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the player is on the transfer market or not.
        /// </summary>
        public bool TransferListed { get; set; }

        /// <summary>
        /// Gets or sets the TSI.
        /// </summary>
        public uint TSI { get; set; }

        /// <summary>
        /// Gets or sets the Winger skill level.
        /// </summary>
        /// <remarks>
        /// Only available for owned or transferlisted players.
        /// </remarks>
        public byte? WingerSkill { get; set; }

        #endregion Public Properties
    }
}