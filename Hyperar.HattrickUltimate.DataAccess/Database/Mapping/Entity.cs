//-----------------------------------------------------------------------
// <copyright file="Entity.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.DataAccess.Database.Mapping
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;
    using BusinessObjects.App;
    using BusinessObjects.App.Interface;
    using Constants;

    /// <summary>
    /// IEntity base mapping.
    /// </summary>
    /// <typeparam name="TEntity">IEntity entity.</typeparam>
    internal class Entity<TEntity> : EntityTypeConfiguration<TEntity> where TEntity : EntityBase, IEntity
    {
        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Entity{TEntity}"/> class.
        /// </summary>
        internal Entity()
        {
            this.Property(p => p.Id)
                .HasColumnOrder(0)
                .HasColumnType(ColumnType.Integer)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();
        }

        #endregion Internal Constructors
    }
}