//-----------------------------------------------------------------------
// <copyright file="PlayerSkills.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessObjects.Hattrick.YouthPlayerList
{
    /// <summary>
    /// Player Skills node within Youth Player List XML file.
    /// </summary>
    public class PlayerSkills
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the Defender Skill.
        /// </summary>
        public Skill DefenderSkill { get; set; }

        /// <summary>
        /// Gets or sets the Defender Skill Max.
        /// </summary>
        public SkillMax DefenderSkillMax { get; set; }

        /// <summary>
        /// Gets or sets the Keeper Skill.
        /// </summary>
        public Skill KeeperSkill { get; set; }

        /// <summary>
        /// Gets or sets the Keeper Skill Max.
        /// </summary>
        public SkillMax KeeperSkillMax { get; set; }

        /// <summary>
        /// Gets or sets the Passing Skill.
        /// </summary>
        public Skill PassingSkill { get; set; }

        /// <summary>
        /// Gets or sets the Passing Skill Max.
        /// </summary>
        public SkillMax PassingSkillMax { get; set; }

        /// <summary>
        /// Gets or sets the Playmaker Skill.
        /// </summary>
        public Skill PlaymakerSkill { get; set; }

        /// <summary>
        /// Gets or sets the Playmaker Skill Max.
        /// </summary>
        public SkillMax PlaymakerSkillMax { get; set; }

        /// <summary>
        /// Gets or sets the Scorer Skill.
        /// </summary>
        public Skill ScorerSkill { get; set; }

        /// <summary>
        /// Gets or sets the Scorer Skill Max.
        /// </summary>
        public SkillMax ScorerSkillMax { get; set; }

        /// <summary>
        /// Gets or sets the SetPieces Skill.
        /// </summary>
        public Skill SetPiecesSkill { get; set; }

        /// <summary>
        /// Gets or sets the SetPieces Skill Max.
        /// </summary>
        public SkillMax SetPiecesSkillMax { get; set; }

        /// <summary>
        /// Gets or sets the Winger Skill.
        /// </summary>
        public Skill WingerSkill { get; set; }

        /// <summary>
        /// Gets or sets the Winger Skill Max.
        /// </summary>
        public SkillMax WingerSkillMax { get; set; }

        #endregion Public Properties
    }
}