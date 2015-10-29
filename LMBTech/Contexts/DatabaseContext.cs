// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DatabaseContext.cs" company="LBM Tech">
//   LBM Tech
// </copyright>
// <summary>
//   The DatabaseContext.cs.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace LMBTech.Contexts
{
    #region includes

    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;

    using LMBTech.Models;

    #endregion

    /// <summary>The database context.</summary>
    // ReSharper disable once ClassWithVirtualMembersNeverInherited.Global
    public class DatabaseContext : DbContext, IDatabaseContext
    {
        #region Constructors and Destructors

        /// <summary>Initializes a new instance of the <see cref="DatabaseContext" /> class.</summary>
        public DatabaseContext()
            : base("Database")
        {
            Database.SetInitializer(new DatabaseContextInitializer());
        }

        #endregion

        #region Public Properties

        /// <summary>Gets or sets the countries.</summary>
        public virtual IDbSet<Country> Countries { get; set; }

        /// <summary>Gets or sets the people.</summary>
        public virtual IDbSet<Person> People { get; set; }

        /// <summary>Gets or sets the regions.</summary>
        public virtual IDbSet<Region> Regions { get; set; }

        #endregion

        #region Methods

        /// <summary>The on model creating.</summary>
        /// <param name="modelBuilder">The model builder.</param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        #endregion
    }
}