//-----------------------------------------------------------------------
// <copyright file="SeniorPlayerAvatar.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.DataAccess.Database.Mapping
{
    using Constants;
    using Interface;

    /// <summary>
    /// SeniorPlayerAvatar entity mapping implementation.
    /// </summary>
    internal class SeniorPlayerAvatar : Entity<BusinessObjects.App.SeniorPlayerAvatar>, IMapping
    {
        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SeniorPlayerAvatar"/> class.
        /// </summary>
        internal SeniorPlayerAvatar()
        {
            this.RegisterTable();
            this.RegisterProperties();
            this.RegisterRelationships();
        }

        #endregion Internal Constructors

        #region Public Methods

        /// <summary>
        /// Registers property column mapping.
        /// </summary>
        public void RegisterProperties()
        {
            this.Property(p => p.AvatarBytes)
                .HasColumnName(ColumnName.AvatarBytes)
                .HasColumnOrder(1)
                .HasColumnType(ColumnType.VarBinaryMax)
                .IsRequired();
        }

        /// <summary>
        /// Register entity relationships.
        /// </summary>
        public void RegisterRelationships()
        {
            this.HasRequired(r => r.SeniorPlayer)
                .WithOptional(r => r.Avatar)
                .Map(m =>
                {
                    m.MapKey(ColumnName.SeniorPlayerId);
                    m.ToTable(TableName.SeniorPlayerAvatar, SchemaName.Default);
                });
        }

        /// <summary>
        /// Register entity table mapping.
        /// </summary>
        public void RegisterTable()
        {
            this.ToTable(TableName.SeniorPlayerAvatar, SchemaName.Default);
        }

        #endregion Public Methods
    }
}