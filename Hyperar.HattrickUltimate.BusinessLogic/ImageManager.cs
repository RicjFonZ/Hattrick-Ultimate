//-----------------------------------------------------------------------
// <copyright file="ImageManager.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessLogic
{
    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;

    /// <summary>
    /// Provides functionality to download and process Hattrick Images.
    /// </summary>
    public class ImageManager
    {
        #region Private Fields

        /// <summary>
        /// CHPP Manager.
        /// </summary>
        private readonly DataAccess.Chpp.ChppManager chppManager;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageManager"/> class.
        /// </summary>
        /// <param name="chppManager">CHPP Manager.</param>
        public ImageManager(DataAccess.Chpp.ChppManager chppManager)
        {
            this.chppManager = chppManager;
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// Builds an image from the specified bytes.
        /// </summary>
        /// <param name="imageBytes">Image's content bytes.</param>
        /// <returns>Built image.</returns>
        public Bitmap GetImageFromBytes(byte[] imageBytes)
        {
            using (var memoryStream = new MemoryStream(imageBytes))
            {
                var bitmap = new Bitmap(Image.FromStream(memoryStream));

                bitmap.SetResolution(120, 120);

                return bitmap;
            }
        }

        #endregion Public Methods

        #region Internal Methods

        /// <summary>
        /// Gets the specified image's bytes.
        /// </summary>
        /// <param name="image">Image to read.</param>
        /// <returns>Image's content bytes.</returns>
        internal byte[] GetBytesFromImage(Image image)
        {
            using (var memoryStream = new MemoryStream())
            {
                image.Save(memoryStream, ImageFormat.Png);

                return memoryStream.ToArray();
            }
        }

        /// <summary>
        /// Gets the Image from the specified relative URL.
        /// </summary>
        /// <param name="relativeUrl">Image's relative URL.</param>
        /// <returns>Specified Image URL.</returns>
        internal Bitmap GetImage(string relativeUrl)
        {
            return this.GetImageFromBytes(
                           this.GetImageBytes(relativeUrl));
        }

        /// <summary>
        /// Gets image bytes by Url.
        /// </summary>
        /// <param name="relativeUrl">Image relative Url.</param>
        /// <returns>Image bytes.</returns>
        internal byte[] GetImageBytes(string relativeUrl)
        {
            string fileNameAndPath = this.GetLocalFileNameAndPath(relativeUrl);

            if (File.Exists(fileNameAndPath))
            {
                return this.GetImageBytesFromLocalDrive(fileNameAndPath);
            }
            else
            {
                byte[] imageBytes = this.chppManager.DownloadResourceFile(
                                                         this.BuildUrl(relativeUrl));

                string folder = Path.GetDirectoryName(fileNameAndPath);

                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }

                File.WriteAllBytes(fileNameAndPath, imageBytes);

                return imageBytes;
            }
        }

        #endregion Internal Methods

        #region Private Methods

        /// <summary>
        /// Builds the Resource URL.
        /// </summary>
        /// <param name="relativePath">Resource relative path.</param>
        /// <returns>Hattrick Resource absolute URL.</returns>
        private string BuildUrl(string relativePath)
        {
            return $"https://www.hattrick.org{relativePath}";
        }

        /// <summary>
        /// Gets image bytes from local drive.
        /// </summary>
        /// <param name="fileNameAndPath">File Name and Path.</param>
        /// <returns>Image bytes.</returns>
        private byte[] GetImageBytesFromLocalDrive(string fileNameAndPath)
        {
            byte[] imageBytes = null;

            imageBytes = File.ReadAllBytes(fileNameAndPath);

            return imageBytes;
        }

        /// <summary>
        /// Gets the local file name and path for the given relative Url.
        /// </summary>
        /// <param name="relativeUrl">Image relative Url.</param>
        /// <returns>File name and path.</returns>
        private string GetLocalFileNameAndPath(string relativeUrl)
        {
            string fileName = relativeUrl.Substring(relativeUrl.LastIndexOf('/') + 1);
            string[] relativePath = relativeUrl.Substring(0, relativeUrl.LastIndexOf('/'))
                                               .Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

            string absolutePath = Path.Combine(
                                          Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                                          "Hyperar",
                                          "Hattrick Ultimate");

            foreach (string folder in relativePath)
            {
                absolutePath = Path.Combine(absolutePath, folder);
            }

            return Path.Combine(absolutePath, fileName);
        }

        #endregion Private Methods
    }
}