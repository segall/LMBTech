// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RegionControllerTest.cs" company="LBM Tech">
//   LBM Tech
// </copyright>
// <summary>
//   The RegionControllerTest.cs.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace LMBTech.Tests.API
{
    #region includes

    using System;
    using System.Collections.Generic;

    using LMBTech.Contexts;
    using LMBTech.Controllers.API;
    using LMBTech.Models;
    using LMBTech.Tests.Helpers;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    #endregion

    /// <summary>The region controller test.</summary>
    [TestClass]
    public class RegionControllerTest
    {
        #region Public Methods and Operators

        /// <summary>The get regions by country id.</summary>
        [TestMethod]
        public void GetRegionsByCountryId()
        {
            // Arrange
            Mock<IDatabaseContext> contextMock = TestHelper.CreateMockContext();
            RegionsController controller = new RegionsController(contextMock.Object);

            // Act
            IEnumerable<Region> result = controller.GetRegionsByCountryId(1);

            // Assert
            throw new NotImplementedException("Please complete proper assert statements for this test");
        }

        #endregion
    }
}