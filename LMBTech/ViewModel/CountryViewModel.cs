using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LMBTech.ViewModel
{
    public class CountryViewModel
    {
        public List<Models.Country> CountryList = new List<Models.Country>();

        public int SelectedCountryID { get; set; }

        public IEnumerable<SelectListItem> CountryIEnum
        {
            get
            {
                return new SelectList(CountryList, "Id", "Name");
            }
        }
    }
}