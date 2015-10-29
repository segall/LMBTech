// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDatabaseContext.cs" company="LBM Tech">
//   LBM Tech
// </copyright>
// <summary>
//   The IDatabaseContext.cs.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace LMBTech.Contexts
{
    #region includes

    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Threading.Tasks;

    using LMBTech.Models;

    #endregion

    /// <summary>The DatabaseContext interface.</summary>
    public interface IDatabaseContext : IDisposable
    {
        #region Public Properties

        /// <summary>Gets or sets the countries.</summary>
        IDbSet<Country> Countries { get; set; }

        /// <summary>Gets or sets the people.</summary>
        IDbSet<Person> People { get; set; }

        /// <summary>Gets or sets the regions.</summary>
        IDbSet<Region> Regions { get; set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>The entry.</summary>
        /// <param name="entity">The entity.</param>
        /// <returns>The <see cref="DbEntityEntry"/>.</returns>
        DbEntityEntry Entry(object entity);

        /// <summary>The entry.</summary>
        /// <param name="entity">The entity.</param>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns>The <see cref="DbEntityEntry"/>.</returns>
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        /// <summary>The save changes.</summary>
        /// <returns>The <see cref="int" />.</returns>
        int SaveChanges();

        /// <summary>The save changes async.</summary>
        /// <returns>The <see cref="Task" />.</returns>
        Task<int> SaveChangesAsync();

        #endregion
    }
}