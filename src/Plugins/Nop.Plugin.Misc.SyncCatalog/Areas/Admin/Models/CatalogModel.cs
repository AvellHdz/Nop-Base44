using Microsoft.AspNetCore.Mvc.Rendering;
using Nop.Web.Framework.Models;
using System.Collections.Generic;

namespace Nop.Plugin.Misc.SyncCatalog.Areas.Admin.Models
{
    public partial record CatalogModel : BaseNopEntityModel
    {
        public CatalogModel()
        {
            AvailableRevenews = new List<SelectListItem>();
            AvailableCategory = new List<SelectListItem>();
            AvailableBrand = new List<SelectListItem>();
        }

        public string IdRevenew { get; set; }
        public string RevenewName { get; set; }
        public int Priority { get; set; }
        public int SelectedRevenew { get; set; }
        public string NameType { get; set; }
        public decimal Makeup { get; set; }
        public IList<SelectListItem> AvailableRevenews { get; set; }
        public IList<int> SelectedCategoriesIds { get; set; }
        public IList<SelectListItem> AvailableCategory { get; set; }
        public IList<int> SelectedBrandsIds { get; set; }
        public IList<SelectListItem> AvailableBrand { get; set; }
    }
}
