// -----------------------------------------------------------------------
// <copyright file="LeagueCupType.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
// -----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessObjects.App.Enums
{
    /// <summary>
    /// League Cup Types.
    /// </summary>
    public enum LeagueCupType : byte
    {
        /// <summary>
        /// National and Divisional League Cup Type.
        /// </summary>
        Official = 1,

        /// <summary>
        /// Challenger League Cup Type.
        /// </summary>
        Challenger = 2,

        /// <summary>
        /// Consolation League Cup Type.
        /// </summary>
        Consolation = 3
    }
}