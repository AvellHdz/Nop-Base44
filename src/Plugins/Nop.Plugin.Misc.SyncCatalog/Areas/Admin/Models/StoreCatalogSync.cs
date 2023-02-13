using System.Collections.Generic;
using Nop.Plugin.Misc.SyncCatalog.Areas.Admin.Models.Sync;

namespace Nop.Plugin.Misc.SyncCatalog.Areas.Admin.Models
{
    public class StoreCatalogSync
    {
        public StoreCatalogSync()
        {
            Category = new();
            Product = new();
        }
        public List<Category> Category { get; set; }
        public List<ProductSync> Product { get; set; }
    }
}
