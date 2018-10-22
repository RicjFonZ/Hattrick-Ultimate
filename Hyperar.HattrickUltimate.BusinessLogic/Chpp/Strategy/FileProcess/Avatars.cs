// -----------------------------------------------------------------------
// <copyright file="Avatars.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
// -----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessLogic.Chpp.Strategy.FileProcess
{
    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Linq;
    using BusinessObjects.App;
    using BusinessObjects.Hattrick.Interface;
    using DataAccess.Database.Interface;
    using Interface;

    /// <summary>
    /// Provides functionality to process Avatars file.
    /// </summary>
    public class Avatars : IFileProcessStrategy
    {
        #region Private Fields

        /// <summary>
        /// CHPP Manager.
        /// </summary>
        private readonly DataAccess.Chpp.ChppManager chppManager;

        /// <summary>
        /// Database context.
        /// </summary>
        private readonly IDatabaseContext context;

        /// <summary>
        /// SeniorPlayerAvatar repository.
        /// </summary>
        private readonly IRepository<SeniorPlayerAvatar> seniorPlayerAvatarRepository;

        /// <summary>
        /// SeniorPlayer repository.
        /// </summary>
        private readonly IHattrickRepository<SeniorPlayer> seniorPlayerRepository;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Avatars"/> class.
        /// </summary>
        /// <param name="chppManager">CHPP Manager.</param>
        /// <param name="context">Database context.</param>
        /// <param name="seniorPlayerRepository">SeniorPlayer repository.</param>
        /// <param name="seniorPlayerAvatarRepository">SeniorPlayerAvatar repository.</param>
        public Avatars(
                   DataAccess.Chpp.ChppManager chppManager,
                   IDatabaseContext context,
                   IHattrickRepository<SeniorPlayer> seniorPlayerRepository,
                   IRepository<SeniorPlayerAvatar> seniorPlayerAvatarRepository)
        {
            this.chppManager = chppManager;
            this.context = context;
            this.seniorPlayerRepository = seniorPlayerRepository;
            this.seniorPlayerAvatarRepository = seniorPlayerAvatarRepository;
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// Process SeniorPlayerAvatar Compendium file.
        /// </summary>
        /// <param name="fileToProcess">File to process.</param>
        public void ProcessFile(IXmlEntity fileToProcess)
        {
            if (fileToProcess == null)
            {
                throw new ArgumentNullException(nameof(fileToProcess));
            }

            var file = fileToProcess as BusinessObjects.Hattrick.Avatars.Root;

            if (file == null)
            {
                throw new ArgumentException(Localization.Messages.UnexpectedObjectType, nameof(fileToProcess));
            }

            this.ProcessTeam(file.Team);
        }

        #endregion Public Methods

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
        /// Gets the specified image's bytes.
        /// </summary>
        /// <param name="image">Image to read.</param>
        /// <returns>Image's content bytes.</returns>
        private byte[] GetBytesFromImage(Image image)
        {
            using (var memoryStream = new MemoryStream())
            {
                image.Save(memoryStream, ImageFormat.Png);

                return memoryStream.ToArray();
            }
        }

        /// <summary>
        /// Builds an image from the specified bytes.
        /// </summary>
        /// <param name="imageBytes">Image's content bytes.</param>
        /// <returns>Built image.</returns>
        private Bitmap GetImageFromBytes(byte[] imageBytes)
        {
            using (var memoryStream = new MemoryStream(imageBytes))
            {
                var bitmap = new Bitmap(Image.FromStream(memoryStream));

                bitmap.SetResolution(120, 120);

                return bitmap;
            }
        }

        /// <summary>
        /// Process Avatar object in Avatars XML file.
        /// </summary>
        /// <param name="avatar">Avatar to process.</param>
        /// <returns>Avatar image content bytes.</returns>
        private byte[] ProcessAvatar(BusinessObjects.Hattrick.Avatars.Avatar avatar)
        {
            if (avatar == null)
            {
                throw new ArgumentNullException(nameof(avatar));
            }

            Bitmap avatarImage = new Bitmap(110, 155, PixelFormat.Format32bppArgb);

            avatarImage.SetResolution(120, 120);

            Graphics graphics = Graphics.FromImage(avatarImage);

            graphics.DrawImageUnscaled(
                         this.GetImageFromBytes(
                                  this.chppManager.DownloadResourceFile(
                                                       this.BuildUrl(avatar.BackgroundImage))),
                         0,
                         0,
                         110,
                         155);

            foreach (var curLayer in avatar.Layers)
            {
                Bitmap layerImage = this.GetImageFromBytes(
                                            this.chppManager.DownloadResourceFile(
                                                                 this.BuildUrl(curLayer.Image)));

                graphics.DrawImageUnscaled(layerImage, curLayer.X, curLayer.Y, layerImage.Width, layerImage.Height);
            }

            return this.GetBytesFromImage(avatarImage);
        }

        /// <summary>
        /// Process Player object in Avatars XML file.
        /// </summary>
        /// <param name="player">Player to process.</param>
        private void ProcessPlayer(BusinessObjects.Hattrick.Avatars.Player player)
        {
            if (player == null)
            {
                throw new ArgumentNullException(nameof(player));
            }

            var seniorPlayerAvatar = this.seniorPlayerAvatarRepository.Query(a => a.SeniorPlayer.HattrickId == player.PlayerId)
                                                                      .SingleOrDefault();

            if (seniorPlayerAvatar == null)
            {
                seniorPlayerAvatar = new SeniorPlayerAvatar
                {
                    AvatarBytes = this.ProcessAvatar(player.Avatar),
                    SeniorPlayer = this.seniorPlayerRepository.GetByHattrickId(player.PlayerId)
                };

                this.seniorPlayerAvatarRepository.Insert(seniorPlayerAvatar);
            }
            else
            {
                seniorPlayerAvatar.AvatarBytes = this.ProcessAvatar(player.Avatar);

                this.seniorPlayerAvatarRepository.Update(seniorPlayerAvatar);
            }

            this.context.Save();
        }

        /// <summary>
        /// Process the Team object of the Avatars XML file.
        /// </summary>
        /// <param name="team">SeniorPlayerAvatar object.</param>
        private void ProcessTeam(BusinessObjects.Hattrick.Avatars.Team team)
        {
            if (team == null)
            {
                throw new ArgumentNullException(nameof(team));
            }

            foreach (var curPlayer in team.Players)
            {
                this.ProcessPlayer(curPlayer);
            }

            this.context.Save();
        }

        #endregion Private Methods
    }
}