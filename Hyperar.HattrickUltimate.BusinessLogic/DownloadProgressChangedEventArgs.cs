// -----------------------------------------------------------------------
// <copyright file="DownloadProgressChangedEventArgs.cs" company="Hyperar">
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
    public class DownloadProgressChangedEventArgs : ProgressChangedEventArgs
    {
        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DownloadProgressChangedEventArgs" /> class.
        /// </summary>
        /// <param name="lastDownloadedFile">The name of the last downloaded file.</param>
        /// <param name="progressPercentage">The percentage of an asynchronous task that has been completed.</param>
        /// <param name="userState">A unique user state.</param>
        public DownloadProgressChangedEventArgs(string lastDownloadedFile, int progressPercentage, object userState) : base(progressPercentage, userState)
        {
            this.LastDownloadedFile = lastDownloadedFile;
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>
        /// Gets the name of the latest downloaded file.
        /// </summary>
        public string LastDownloadedFile { get; private set; }

        #endregion Public Properties
    }
}