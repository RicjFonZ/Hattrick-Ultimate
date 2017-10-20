// -----------------------------------------------------------------------
// <copyright file="FileTaskProgressChangedEventArgs.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
// -----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessLogic
{
    using System.ComponentModel;

    /// <summary>
    /// Download progress changed event arguments.
    /// </summary>
    public class FileTaskProgressChangedEventArgs : ProgressChangedEventArgs
    {
        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="FileTaskProgressChangedEventArgs" /> class.
        /// </summary>
        /// <param name="fileTask">The name of the task's file.</param>
        /// <param name="progressPercentage">The percentage of an asynchronous task that has been completed.</param>
        /// <param name="userState">A unique user state.</param>
        public FileTaskProgressChangedEventArgs(string fileTask, int progressPercentage, object userState) : base(progressPercentage, userState)
        {
            this.FileTask = fileTask;
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>
        /// Gets the name of the task's file.
        /// </summary>
        public string FileTask { get; private set; }

        #endregion Public Properties
    }
}