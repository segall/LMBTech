// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HomeController.cs" company="LBM Tech">
//   
// </copyright>
// <summary>
//   The HomeController.cs.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace LMBTech.Controllers.MVC
{
    #region includes

    using System.Web.Mvc;

    #endregion

    /// <summary>The home controller.</summary>
    public class HomeController : Controller
    {
        #region Public Methods and Operators

        /// <summary>The index.</summary>
        /// <returns>The <see cref="ActionResult" />.</returns>
        public ActionResult Index()
        {
            return this.View();
        }

        #endregion
    }
}