using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using Nop.Web.Framework.Models;

namespace Nop.Plugin.Misc.SyncCatalog.Areas.Admin.Models
{
    public record CatalogProductModel : BaseNopEntityModel
    {
        public CatalogProductModel()
        {
            SelectedProductsId = new List<int>();
            AvailableProducts = new List<SelectListItem>();
        }

        public int IdMapping { get; set; }
        public string GTIN { get; set; }
        public string Name { get; set; }
        public IList<int> SelectedProductsId { get; set; }
        public IList<SelectListItem> AvailableProducts { get; set; }
    }
}
