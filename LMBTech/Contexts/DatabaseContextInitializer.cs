// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DatabaseContextInitializer.cs" company="LBM Tech">
//   LBM Tech
// </copyright>
// <summary>
//   The DatabaseContextInitializer.cs.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace LMBTech.Contexts
{
    #region includes

    using System.Collections.ObjectModel;
    using System.Data.Entity;

    using LMBTech.Models;

    #endregion

    /// <summary>The database context initializer.</summary>
    public class DatabaseContextInitializer : DropCreateDatabaseIfModelChanges<DatabaseContext>
    {
        #region Methods

        /// <summary>The seed.</summary>
        /// <param name="context">The context.</param>
        protected override void Seed(DatabaseContext context)
        {
            base.Seed(context);

            this.CreateCountries(context);

            context.SaveChanges();
        }

        /// <summary>The create countries.</summary>
        /// <param name="context">The context.</param>
        private void CreateCountries(DatabaseContext context)
        {
            Country country = context.Countries.Create();
            country.Name = "United Kingdom";
            country.Regions = new Collection<Region>
            {
                new Region { Name = "England" }, 
                new Region { Name = "Scotland" }, 
                new Region { Name = "Wales" }, 
                new Region { Name = "Northen Ireland" }
            };
            context.Countries.Add(country);

            country = context.Countries.Create();
            country.Name = "Australia";
            country.Regions = new Collection<Region>
            {
                new Region { Name = "Queensland" }, 
                new Region { Name = "Victoria" }, 
                new Region { Name = "Tasmania" }, 
                new Region { Name = "New South Wales" }
            };
            context.Countries.Add(country);
        }

        #endregion
    }
}