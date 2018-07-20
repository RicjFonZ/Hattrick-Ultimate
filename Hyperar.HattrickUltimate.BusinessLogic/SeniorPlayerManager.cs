//-----------------------------------------------------------------------
// <copyright file="SeniorPlayerManager.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.BusinessLogic
{
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
        private IDatabaseContext context;

        /// <summary>
        /// Senior Player With Skill Delta repository.
        /// </summary>
        private IReadOnlyRepository<BusinessObjects.App.SeniorPlayerWithSkillDelta> seniorPlayerWithSkillDelta;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SeniorPlayerManager" /> class.
        /// </summary>
        /// <param name="context">Database context.</param>
        /// <param name="seniorPlayerWithSkillDelta">Senior Player With Skill Delta repository.</param>
        public SeniorPlayerManager(
                   IDatabaseContext context,
                   IReadOnlyRepository<BusinessObjects.App.SeniorPlayerWithSkillDelta> seniorPlayerWithSkillDelta)
        {
            this.context = context;
            this.seniorPlayerWithSkillDelta = seniorPlayerWithSkillDelta;
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// Gets the Senior Players with Skills and Skills Deltas for the specified Senior Team ID.
        /// </summary>
        /// <param name="seniorTeamId">Owning Senior Team ID.</param>
        /// <returns>Senior Players with Skills and Skills Delta on a Queryable object.</returns>
        public IQueryable<BusinessObjects.App.SeniorPlayerWithSkillDelta> GetSeniorPlayerWithSkillDelta(int seniorTeamId)
        {
            return this.seniorPlayerWithSkillDelta.Query(x => x.SeniorTeamId == seniorTeamId);
        }

        #endregion Public Methods
    }
}