// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RegionsController.cs" company="LBM Tech">
//   LBM Tech
// </copyright>
// <summary>
//   The RegionsController.cs.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace LMBTech.Controllers.API
{
    #region includes

    using System;
    using System.Collections.Generic;
    using System.Web.Http;
    using System.Web.Http.Description;

    using LMBTech.Contexts;
    using LMBTech.Models;

    #endregion

    /// <summary>The regions controller.</summary>
    public class RegionsController : ApiController
    {
        #region Constants and Fields

        /// <summary>The db.</summary>
        private readonly IDatabaseContext db;

        #endregion

        #region Constructors and Destructors

        /// <summary>Initializes a new instance of the <see cref="RegionsController"/> class.</summary>
        /// <param name="db">The db.</param>
        public RegionsController(IDatabaseContext db)
        {
            this.db = db;
        }

        /// <summary>Initializes a new instance of the <see cref="RegionsController" /> class.</summary>
        public RegionsController()
            : this(new DatabaseContext())
        {
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>The get regions.</summary>
        /// <param name="countryId">The country Id.</param>
        /// <returns>The <see cref="IEnumerable{Region}"/>.</returns>
        [ResponseType(typeof(IEnumerable<Region>))]
        public IEnumerable<Region> GetRegionsByCountryId(int countryId)
        {
            return db.Regions;
        }

        #endregion

        #region Methods

        /// <summary>The dispose.</summary>
        /// <param name="disposing">The disposing.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.db.Dispose();
            }

            base.Dispose(disposing);
        }

        #endregion
    }
}