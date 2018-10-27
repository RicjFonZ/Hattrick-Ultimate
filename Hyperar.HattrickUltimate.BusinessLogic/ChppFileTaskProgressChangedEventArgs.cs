//-----------------------------------------------------------------------
// <copyright file="ChppFileTaskProgressChangedEventArgs.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessLogic
{
    using System.ComponentModel;
    using Hyperar.HattrickUltimate.BusinessLogic.Chpp.Enums;

    /// <summary>
    /// Provides data for the <see cref="ChppFileTaskManager.ChppFileTaskProgressChanged"/> event.
    /// </summary>
    public class ChppFileTaskProgressChangedEventArgs : ProgressChangedEventArgs
    {
        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ChppFileTaskProgressChangedEventArgs"/> class.
        /// </summary>
        /// <param name="fileName">File name.</param>
        /// <param name="state">Task state.</param>
        /// <param name="progressPercentage">Progress percentage.</param>
        /// <param name="userState">User state.</param>
        public ChppFileTaskProgressChangedEventArgs(
                   string fileName,
                   FileTaskState state,
                   int progressPercentage,
                   object userState) : base(progressPercentage, userState)
        {
            this.FileName = fileName;
            this.State = state;
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>
        /// Gets the file name.
        /// </summary>
        public string FileName { get; }

        /// <summary>
        /// Gets the task state.
        /// </summary>
        public FileTaskState State { get; }

        #endregion Public Properties
    }
}