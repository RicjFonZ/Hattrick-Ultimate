// -----------------------------------------------------------------------
// <copyright file="SeniorArena.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
// -----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessObjects.App
{
    using Interface;

    /// <summary>
    /// Represents a Senior Arena.
    /// </summary>
    public class SeniorArena : HattrickEntityBase, IEntity, IHattrickEntity
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Senior Team.
        /// </summary>
        public virtual SeniorTeam SeniorTeam { get; set; }

        /// <summary>
        /// Gets the Senior Team Id.
        /// </summary>
        public int? SeniorTeamId
        {
            get
            {
                return this.SeniorTeam?.Id;
            }
        }

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