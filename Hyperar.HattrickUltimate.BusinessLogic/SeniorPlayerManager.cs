//-----------------------------------------------------------------------
// <copyright file="SeniorPlayerManager.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessLogic
{
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using DataAccess.Database.Interface;

    /// <summary>
    /// Senior Player objects business processes.
    /// </summary>
    public class SeniorPlayerManager
    {
        #region Private Fields

        /// <summary>
        /// Database context.
        /// </summary>
        private readonly IDatabaseContext context;

        /// <summary>
        /// Senior Player Avatar Repository.
        /// </summary>
        private readonly IRepository<BusinessObjects.App.SeniorPlayerAvatar> seniorPlayerAvatarRepository;

        /// <summary>
        /// Senior Player Repository.
        /// </summary>
        private readonly IHattrickRepository<BusinessObjects.App.SeniorPlayer> seniorPlayerRepository;

        /// <summary>
        /// Senior Player With Skill Delta Repository.
        /// </summary>
        private readonly IReadOnlyRepository<BusinessObjects.App.SeniorPlayerWithSkillDelta> seniorPlayerWithSkillDeltaRepository;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SeniorPlayerManager"/> class.
        /// </summary>
        /// <param name="context">Database context.</param>
        /// <param name="seniorPlayerAvatarRepository">Senior Player Avatar Repository.</param>
        /// <param name="seniorPlayerRepository">Senior Player Repository.</param>
        /// <param name="seniorPlayerWithSkillDeltaRepository">Senior Player With Skill Delta Repository.</param>
        public SeniorPlayerManager(
                   IDatabaseContext context,
                   IRepository<BusinessObjects.App.SeniorPlayerAvatar> seniorPlayerAvatarRepository,
                   IHattrickRepository<BusinessObjects.App.SeniorPlayer> seniorPlayerRepository,
                   IReadOnlyRepository<BusinessObjects.App.SeniorPlayerWithSkillDelta> seniorPlayerWithSkillDeltaRepository)
        {
            this.context = context;
            this.seniorPlayerAvatarRepository = seniorPlayerAvatarRepository;
            this.seniorPlayerRepository = seniorPlayerRepository;
            this.seniorPlayerWithSkillDeltaRepository = seniorPlayerWithSkillDeltaRepository;
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// Gets the avatar for the Senior Player with the specified Hattrick ID.
        /// </summary>
        /// <param name="hattrickId">Senior Player Hattrick ID.</param>
        /// <returns>Senior Player Avatar Image.</returns>
        public Image GetSeniorPlayerAvatarByHattrickId(long hattrickId)
        {
            var seniorPlayerAvatar = this.seniorPlayerAvatarRepository.Query(a => a.SeniorPlayer.HattrickId == hattrickId)
                                                                      .SingleOrDefault();

            if (seniorPlayerAvatar != null)
            {
                using (var memoryStream = new MemoryStream(seniorPlayerAvatar.AvatarBytes))
                {
                    return Image.FromStream(memoryStream);
                }
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Gets the Senior Players with Skills and Skills Deltas for the specified Senior Team ID.
        /// </summary>
        /// <param name="seniorTeamId">Owning Senior Team ID.</param>
        /// <returns>Senior Players with Skills and Skills Delta on a Queryable object.</returns>
        public IQueryable<BusinessObjects.App.SeniorPlayerWithSkillDelta> GetSeniorPlayerWithSkillDelta(int seniorTeamId)
        {
            return this.seniorPlayerWithSkillDeltaRepository.Query(x => x.SeniorTeamId == seniorTeamId);
        }

        #endregion Public Methods
    }
}