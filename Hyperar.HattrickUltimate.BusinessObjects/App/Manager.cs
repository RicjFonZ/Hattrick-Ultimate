//-----------------------------------------------------------------------
// <copyright file="Manager.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessObjects.App
{
    using Interface;

    /// <summary>
    /// Team Manager.
    /// </summary>
    public class Manager : HattrickEntityBase, IHattrickEntity
    {
        #region Properties

        /// <summary>
        /// Gets or sets the UserName.
        /// </summary>
        public string UserName { get; set; }

        #endregion Properties

        #region Navigation properties

        /// <summary>
        /// Gets or sets the User.
        /// </summary>
        public virtual User User { get; set; }

        #endregion Navigation properties

        #region Methods

        /// <summary>
        /// Returns a System.String that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return $"{this.UserName} ({this.HattrickId})";
        }

        #endregion Methods
    }
}