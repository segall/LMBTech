// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PeopleController.cs" company="LBM Tech">
//   LBM Tech
// </copyright>
// <summary>
//   The PeopleController.cs.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace LMBTech.Controllers.MVC
{
    #region includes

    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;
    using System.Linq;
    using System.Data.Entity;
    using LMBTech.Contexts;
    using LMBTech.Models;
    using LMBTech.Controllers.API;

    #endregion

    /// <summary>The people controller.</summary>
    public class PeopleController : Controller
    {
        #region Constants and Fields

        /// <summary>The db.</summary>
        private readonly IDatabaseContext db;
        #endregion

        #region Constructors and Destructors

        /// <summary>Initializes a new instance of the <see cref="PeopleController"/> class.</summary>
        /// <param name="db">The db.</param>
        public PeopleController(IDatabaseContext db)
        {
            this.db = db;
        }

        /// <summary>Initializes a new instance of the <see cref="PeopleController" /> class.</summary>
        public PeopleController()
            : this(new DatabaseContext())
        {
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>The create.</summary>
        /// <returns>The <see cref="ActionResult" />.</returns>
        public ActionResult Create()
        {
            return this.View();
        }

        /// <summary>The create.</summary>
        /// <param name="person">The person.</param>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Person person, FormCollection objFrm)
        {
            if (person != null && ModelState.IsValid)
            {
                person.RegionId = int.Parse(objFrm["SelectedRegionId"]);
                db.People.Add(person);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        /// <summary>The index.</summary>
        /// <returns>The <see cref="ActionResult" />.</returns>
        public ActionResult Index(string name, string surname)
        {
            var people = db.People 
                    .Include(p => p.Region) 
                    .Include(p => p.Country);
            List<Person> model = new List<Person>();

            if (String.IsNullOrEmpty(name) && String.IsNullOrEmpty(surname))
                return View(db.People.ToList());
            else if (String.IsNullOrEmpty(name))
                return View(db.People.ToList().Where(p => p.Surname.Contains(surname)));
            else if (String.IsNullOrEmpty(surname))
                return View(db.People.ToList().Where(p => p.Name.Contains(name)));
            else
                return View(db.People.ToList().Where(p => p.Name.Contains(name) && p.Surname.Contains(surname)));
        }

        public static ViewModel.CountryViewModel cvm = new ViewModel.CountryViewModel();
        public ActionResult CountryView()
        {
            cvm.CountryList.Clear();
            foreach (Country cd in db.Countries)
            {
                cvm.CountryList.Add(cd);
            }
            return View(cvm);
        }

        public static ViewModel.RegionViewModel rvm = new ViewModel.RegionViewModel();
        public ActionResult RegionView(int? countryID)
        {
            rvm.RegionList.Clear();
            if (countryID != null)
            {
                foreach (Region rd in db.Regions.Where(r => r.CountryId == countryID))
                {
                    rvm.RegionList.Add(rd);
                }
            }
            return View(rvm);
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