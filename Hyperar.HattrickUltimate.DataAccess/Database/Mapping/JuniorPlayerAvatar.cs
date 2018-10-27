//-----------------------------------------------------------------------
// <copyright file="JuniorPlayerAvatar.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.DataAccess.Database.Mapping
{
    using Constants;
    using Interface;

    /// <summary>
    /// JuniorPlayerAvatar entity mapping implementation.
    /// </summary>
    internal class JuniorPlayerAvatar : Entity<BusinessObjects.App.JuniorPlayerAvatar>, IMapping
    {
        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="JuniorPlayerAvatar"/> class.
        /// </summary>
        internal JuniorPlayerAvatar()
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
            this.HasRequired(r => r.JuniorPlayer)
                .WithOptional(r => r.Avatar)
                .Map(m =>
                {
                    m.MapKey(ColumnName.JuniorPlayerId);
                    m.ToTable(TableName.JuniorPlayerAvatar, SchemaName.Default);
                });
        }

        /// <summary>
        /// Register entity table mapping.
        /// </summary>
        public void RegisterTable()
        {
            this.ToTable(TableName.JuniorPlayerAvatar, SchemaName.Default);
        }

        #endregion Public Methods
    }
}