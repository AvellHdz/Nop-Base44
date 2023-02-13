using System.Collections.Generic;
using Nop.Plugin.Misc.SyncCatalog.Areas.Admin.Models.Sync;

namespace Nop.Plugin.Misc.SyncCatalog.Areas.Admin.Models
{
    public record StoreCatalog
    {
        public StoreCatalog()
        {
            Categories = new();
            Products = new();
        }
        public List<CategorySync> Categories { get; set; }
        public List<ProductSync> Products { get; set; }

    }
}
