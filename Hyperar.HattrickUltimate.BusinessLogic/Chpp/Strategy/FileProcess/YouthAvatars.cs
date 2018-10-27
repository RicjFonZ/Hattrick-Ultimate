// -----------------------------------------------------------------------
// <copyright file="YouthAvatars.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
// -----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessLogic.Chpp.Strategy.FileProcess
{
    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Linq;
    using BusinessObjects.App;
    using BusinessObjects.Hattrick.Interface;
    using DataAccess.Database.Interface;
    using Interface;

    /// <summary>
    /// Provides functionality to process YouthAvatars file.
    /// </summary>
    public class YouthAvatars : IFileProcessStrategy
    {
        #region Private Fields

        /// <summary>
        /// Database context.
        /// </summary>
        private readonly IDatabaseContext context;

        /// <summary>
        /// Image Manager.
        /// </summary>
        private readonly ImageManager imageManager;

        /// <summary>
        /// JuniorPlayerAvatar repository.
        /// </summary>
        private readonly IRepository<JuniorPlayerAvatar> juniorPlayerAvatarRepository;

        /// <summary>
        /// JuniorPlayer repository.
        /// </summary>
        private readonly IHattrickRepository<JuniorPlayer> juniorPlayerRepository;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="YouthAvatars"/> class.
        /// </summary>
        /// <param name="imageManager">CHPP Manager.</param>
        /// <param name="context">Database context.</param>
        /// <param name="juniorPlayerRepository">JuniorPlayer repository.</param>
        /// <param name="juniorPlayerAvatarRepository">JuniorPlayerAvatar repository.</param>
        public YouthAvatars(
                   ImageManager imageManager,
                   IDatabaseContext context,
                   IHattrickRepository<JuniorPlayer> juniorPlayerRepository,
                   IRepository<JuniorPlayerAvatar> juniorPlayerAvatarRepository)
        {
            this.imageManager = imageManager;
            this.context = context;
            this.juniorPlayerRepository = juniorPlayerRepository;
            this.juniorPlayerAvatarRepository = juniorPlayerAvatarRepository;
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// Process JuniorPlayerAvatar Compendium file.
        /// </summary>
        /// <param name="fileToProcess">File to process.</param>
        public void ProcessFile(IXmlEntity fileToProcess)
        {
            if (fileToProcess == null)
            {
                throw new ArgumentNullException(nameof(fileToProcess));
            }

            if (!(fileToProcess is BusinessObjects.Hattrick.YouthAvatars.Root file))
            {
                throw new ArgumentException(Localization.Messages.UnexpectedObjectType, nameof(fileToProcess));
            }

            this.ProcessYouthTeam(file.YouthTeam);
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        /// Process Avatar object in YouthAvatars XML file.
        /// </summary>
        /// <param name="avatar">Avatar to process.</param>
        /// <returns>Avatar image content bytes.</returns>
        private byte[] ProcessAvatar(BusinessObjects.Hattrick.YouthAvatars.Avatar avatar)
        {
            if (avatar == null)
            {
                throw new ArgumentNullException(nameof(avatar));
            }

            var avatarImage = new Bitmap(110, 155, PixelFormat.Format32bppArgb);

            avatarImage.SetResolution(120, 120);

            var graphics = Graphics.FromImage(avatarImage);

            graphics.DrawImageUnscaled(
                         this.imageManager.GetImage(avatar.BackgroundImage),
                         0,
                         0,
                         110,
                         155);

            foreach (var curLayer in avatar.Layers)
            {
                var layerImage = this.imageManager.GetImage(curLayer.Image);

                graphics.DrawImageUnscaled(layerImage, curLayer.X, curLayer.Y, layerImage.Width, layerImage.Height);
            }

            return this.imageManager.GetBytesFromImage(avatarImage);
        }

        /// <summary>
        /// Process YouthPlayer object in YouthAvatars XML file.
        /// </summary>
        /// <param name="player">YouthPlayer to process.</param>
        private void ProcessYouthPlayer(BusinessObjects.Hattrick.YouthAvatars.YouthPlayer player)
        {
            if (player == null)
            {
                throw new ArgumentNullException(nameof(player));
            }

            var juniorPlayerAvatar = this.juniorPlayerAvatarRepository.Query(a => a.JuniorPlayer.HattrickId == player.YouthPlayerId)
                                                                      .SingleOrDefault();

            if (juniorPlayerAvatar == null)
            {
                juniorPlayerAvatar = new JuniorPlayerAvatar
                {
                    AvatarBytes = this.ProcessAvatar(player.Avatar),
                    JuniorPlayer = this.juniorPlayerRepository.GetByHattrickId(player.YouthPlayerId)
                };

                this.juniorPlayerAvatarRepository.Insert(juniorPlayerAvatar);
            }
            else
            {
                juniorPlayerAvatar.AvatarBytes = this.ProcessAvatar(player.Avatar);

                this.juniorPlayerAvatarRepository.Update(juniorPlayerAvatar);
            }

            this.context.Save();
        }

        /// <summary>
        /// Process the YouthTeam object of the YouthAvatars XML file.
        /// </summary>
        /// <param name="youthTeam">JuniorPlayerAvatar object.</param>
        private void ProcessYouthTeam(BusinessObjects.Hattrick.YouthAvatars.YouthTeam youthTeam)
        {
            if (youthTeam == null)
            {
                throw new ArgumentNullException(nameof(youthTeam));
            }

            foreach (var curYouthPlayer in youthTeam.YouthPlayers)
            {
                this.ProcessYouthPlayer(curYouthPlayer);
            }

            this.context.Save();
        }

        #endregion Private Methods
    }
}