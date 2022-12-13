using Nop.Web.Framework.Models;

namespace Nop.Plugin.Misc.SyncCatalog.Areas.Admin.Models
{
    public record CatalogProductModel : BaseNopEntityModel
    {
        public int IdMapping { get; set; }
        public string GTIN { get; set; }
        public string Name { get; set; } 
    }
}
