using System.Collections.Generic;

namespace Nop.Plugin.Misc.SyncCatalog.Areas.Admin.MiddlewareSync.Models
{
    public class RevenewStoreCatalog
    {
        public RevenewStoreCatalog()
        {
            RevenewMappingCatalogs = new List<RevenewMappingCatalog>();
        }

        public int RevenewStored { get; set; }
        public int StoreId { get; set; }
        public int RevenewTypeId { get; set; }
        public int Priroty { get; set; }
        public List<RevenewMappingCatalog> RevenewMappingCatalogs { get; set; }
    }

    public class RevenewMappingCatalog
    {
        public string ExternalID { get; set; }
        public decimal MakeUp { get; set; }
    }
}
