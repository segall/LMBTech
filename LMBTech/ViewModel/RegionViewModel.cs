using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LMBTech.ViewModel
{
    public class RegionViewModel
    {
        public List<Models.Region> RegionList = new List<Models.Region>();

        public int SelectedRegionId { get; set; }

        public IEnumerable<SelectListItem> RegionIEnum
        {
            get
            {
                return new SelectList(RegionList, "Id", "Name");
            }
        }
    }
}