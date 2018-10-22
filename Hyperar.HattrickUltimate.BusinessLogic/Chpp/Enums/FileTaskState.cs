//-----------------------------------------------------------------------
// <copyright file="FileTaskState.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessLogic.Chpp.Enums
{
    /// <summary>
    /// File Task State.
    /// </summary>
    public enum FileTaskState : int
    {
        /// <summary>
        /// Downloading file task state.
        /// </summary>
        Downloading = 0,

        /// <summary>
        /// Validating file task state.
        /// </summary>
        Validating = 1,

        /// <summary>
        /// Analyzing file task state.
        /// </summary>
        Analyzing = 2,

        /// <summary>
        /// Processing file task state.
        /// </summary>
        Processing = 3,

        /// <summary>
        /// Finished file task state.
        /// </summary>
        Finished = 4
    }
}