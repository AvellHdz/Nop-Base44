﻿namespace Nop.Plugin.Misc.SyncCatalog.Areas.Admin.MiddlewareSync.Models
{
    public class BrandSyncModel
    {
        public Brandscatalog[] brandsCatalog { get; set; }
    }

    public class Brandscatalog
    {
        public int id { get; set; }
        public string externalId { get; set; }
        public string name { get; set; }
    }

}
