//-----------------------------------------------------------------------
// <copyright file="IMapping.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.DataAccess.Database.Interface
{
    /// <summary>
    /// Entity mapping definition.
    /// </summary>
    internal interface IMapping
    {
        #region Public Methods

        /// <summary>
        /// Registers property column mapping.
        /// </summary>
        void RegisterProperties();

        /// <summary>
        /// Register entity relationships.
        /// </summary>
        void RegisterRelationships();

        /// <summary>
        /// Register entity table mapping.
        /// </summary>
        void RegisterTable();

        #endregion Public Methods
    }
}