//-----------------------------------------------------------------------
// <copyright file="ScoutComment.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessObjects.Hattrick.YouthPlayerList
{
    /// <summary>
    /// ScoutComment node within Youth Player List XML file.
    /// </summary>
    public class ScoutComment
    {
        /// <summary>
        /// Gets or sets the Comment Skill Level.
        /// </summary>
        public byte CommentSkillLevel { get; set; }

        /// <summary>
        /// Gets or sets the Comment Skill Type.
        /// </summary>
        public long CommentSkillType { get; set; }

        /// <summary>
        /// Gets or sets the Comment Text.
        /// </summary>
        public string CommentText { get; set; }

        /// <summary>
        /// Gets or sets the Comment Type.
        /// </summary>
        public byte CommentType { get; set; }

        /// <summary>
        /// Gets or sets the Comment Variation.
        /// </summary>
        public long CommentVariation { get; set; }
    }
}