// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CountryControllerTest.cs" company="LBM Tech">
//   LBM Tech
// </copyright>
// <summary>
//   The CountryControllerTest.cs.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace LMBTech.Tests.Controllers
{
    #region includes

    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    using LMBTech.Contexts;
    using LMBTech.Controllers;
    using LMBTech.Controllers.API;
    using LMBTech.Models;
    using LMBTech.Tests.Helpers;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    #endregion

    /// <summary>The country controller test.</summary>
    [TestClass]
    public class CountryControllerTest
    {
        #region Public Methods and Operators

        /// <summary>The get countries.</summary>
        [TestMethod]
        public void GetCountries()
        {
            // Arrange
            Mock<IDatabaseContext> contextMock = TestHelper.CreateMockContext();
            CountryController controller = new CountryController(contextMock.Object);

            // Act
            List<Country> result = controller.GetAllCountries().ToList();
            Debug.WriteLine(string.Join("\r\n", result));

            // Assert
            Assert.IsTrue(result.Any());
        }

        #endregion
    }
}