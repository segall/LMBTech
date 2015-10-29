// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CountryController.cs" company="">
//   
// </copyright>
// <summary>
//   The country controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace LMBTech.Controllers.API
{
    #region includes

    using System;
    using System.Collections.Generic;
    using System.Web.Http;

    using LMBTech.Contexts;
    using LMBTech.Models;

    #endregion

    /// <summary>The country controller.</summary>
    public class CountryController : ApiController
    {
        #region Constants and Fields

        /// <summary>The db.</summary>
        private readonly IDatabaseContext db;

        #endregion

        #region Public Methods and Operators

        /// <summary>The get.</summary>
        /// <returns>The <see cref="List{Country}" />.</returns>
        public IEnumerable<Country> GetAllCountries()
        {
            return db.Countries;
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

        #region Constructors and Destructors

        /// <summary>Initializes a new instance of the <see cref="CountryController" /> class.</summary>
        public CountryController()
            : this(new DatabaseContext())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="CountryController"/> class.</summary>
        /// <param name="db">The db.</param>
        public CountryController(IDatabaseContext db)
        {
            this.db = db;
        }

        #endregion
    }
}