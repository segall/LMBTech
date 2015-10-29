// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestHelper.cs" company="LBM Tech">
//   LBM Tech
// </copyright>
// <summary>
//   The TestHelper.cs.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace LMBTech.Tests.Helpers
{
    #region includes

    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    using LMBTech.Contexts;
    using LMBTech.Models;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    #endregion

    /// <summary>The test helper.</summary>
    public class TestHelper
    {
        #region Public Methods and Operators

        /// <summary>The create mock context.</summary>
        /// <returns>The <see cref="Mock" />.</returns>
        public static Mock<IDatabaseContext> CreateMockContext()
        {
            Mock<IDatabaseContext> contextMock = new Mock<IDatabaseContext>();
            IQueryable<Region> regions = new List<Region>
            {
                new Region { Id = 1, CountryId = 1, Name = "England" }, 
                new Region { Id = 2, CountryId = 1, Name = "Scotland" }, 
                new Region { Id = 3, CountryId = 1, Name = "Wales" }, 
                new Region { Id = 4, CountryId = 1, Name = "Northen Ireland" }, 
                new Region { Id = 5, CountryId = 2, Name = "Queensland" }, 
                new Region { Id = 6, CountryId = 2, Name = "Victoria" }, 
                new Region { Id = 7, CountryId = 2, Name = "Tasmania" }, 
                new Region { Id = 8, CountryId = 2, Name = "New South Wales" }
            }.AsQueryable();

            IQueryable<Country> coutries = new List<Country>
            {
                new Country
                {
                    Id = 1, Name = "United Kingdom", Regions = regions.Where(a => a.CountryId == 1).ToList()
                }, 
                new Country
                {
                    Id = 2, Name = "Australia", Regions = regions.Where(a => a.CountryId == 2).ToList()
                }
            }.AsQueryable();

            foreach (Region region in regions)
            {
                region.Country = coutries.First(a => a.Id == region.CountryId);
            }

            Mock<IDbSet<Country>> countryMock = new Mock<IDbSet<Country>>();
            countryMock.As<IQueryable<Country>>().Setup(m => m.Provider).Returns(coutries.Provider);
            countryMock.As<IQueryable<Country>>().Setup(m => m.Expression).Returns(coutries.Expression);
            countryMock.As<IQueryable<Country>>().Setup(m => m.ElementType).Returns(coutries.ElementType);
            countryMock.As<IQueryable<Country>>().Setup(m => m.GetEnumerator()).Returns(coutries.GetEnumerator());

            Mock<IDbSet<Region>> regionMock = new Mock<IDbSet<Region>>();
            regionMock.As<IQueryable<Region>>().Setup(m => m.Provider).Returns(regions.Provider);
            regionMock.As<IQueryable<Region>>().Setup(m => m.Expression).Returns(regions.Expression);
            regionMock.As<IQueryable<Region>>().Setup(m => m.ElementType).Returns(regions.ElementType);
            regionMock.As<IQueryable<Region>>().Setup(m => m.GetEnumerator()).Returns(regions.GetEnumerator());

            contextMock.Setup(a => a.Countries).Returns(countryMock.Object);
            contextMock.Setup(a => a.Regions).Returns(regionMock.Object);

            // verify that the mocking is setup correctly
            List<Region> result = contextMock.Object.Countries.Include(a => a.Regions).SelectMany(a => a.Regions).ToList();
            Assert.AreEqual(regions.Count(), result.Count);

            return contextMock;
        }

        #endregion
    }
}