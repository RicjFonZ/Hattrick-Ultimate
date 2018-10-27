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
        /// Database context.
        /// </summary>
        private readonly IDatabaseContext context;

        /// <summary>
        /// Image Manager.
        /// </summary>
        private readonly ImageManager imageManager;

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
        /// <param name="imageManager">CHPP Manager.</param>
        /// <param name="context">Database context.</param>
        /// <param name="seniorPlayerRepository">SeniorPlayer repository.</param>
        /// <param name="seniorPlayerAvatarRepository">SeniorPlayerAvatar repository.</param>
        public Avatars(
                   ImageManager imageManager,
                   IDatabaseContext context,
                   IHattrickRepository<SeniorPlayer> seniorPlayerRepository,
                   IRepository<SeniorPlayerAvatar> seniorPlayerAvatarRepository)
        {
            this.imageManager = imageManager;
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

            if (!(fileToProcess is BusinessObjects.Hattrick.Avatars.Root file))
            {
                throw new ArgumentException(Localization.Messages.UnexpectedObjectType, nameof(fileToProcess));
            }

            this.ProcessTeam(file.Team);
        }

        #endregion Public Methods

        #region Private Methods

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