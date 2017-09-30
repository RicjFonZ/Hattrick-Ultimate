// -----------------------------------------------------------------------
// <copyright file="DownloadCompletedEventArgs.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
// -----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessLogic
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using BusinessObjects.Hattrick.Interface;

    /// <summary>
    /// Download completed event arguments.
    /// </summary>
    public class DownloadCompletedEventArgs : AsyncCompletedEventArgs
    {
        #region Private Fields

        /// <summary>
        /// List of downloaded files.
        /// </summary>
        private readonly List<IXmlEntity> downloadedFiles;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DownloadCompletedEventArgs" /> class.
        /// </summary>
        /// <param name="downloadedFiles">Downloaded files.</param>
        /// <param name="error">Any error that occurred during the asynchronous operation.</param>
        /// <param name="cancelled">A value indicating whether the asynchronous operation was canceled.</param>
        /// <param name="userState">The optional user-supplied state object passed to the System.ComponentModel.BackgroundWorker.RunWorkerAsync(System.Object) method.</param>
        public DownloadCompletedEventArgs(List<IXmlEntity> downloadedFiles, Exception error, bool cancelled, object userState) : base(error, cancelled, userState)
        {
            this.downloadedFiles = downloadedFiles;
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>
        /// Gets the list of downloaded files.
        /// </summary>
        public List<IXmlEntity> DownloadedFiles
        {
            get
            {
                this.RaiseExceptionIfNecessary();

                return this.downloadedFiles;
            }
        }

        #endregion Public Properties
    }
}