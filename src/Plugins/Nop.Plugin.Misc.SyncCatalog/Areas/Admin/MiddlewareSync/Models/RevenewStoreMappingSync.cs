namespace Nop.Plugin.Misc.SyncCatalog.Areas.Admin.MiddlewareSync.Models
{
    public class RevenewStoreMappingSync
    {
        public Revenewstoremapping[] revenewStoreMapping { get; set; }
    }

    public class Revenewstoremapping
    {
        public int revenewStoreId { get; set; }
        public int externalId { get; set; }
        public float makeup { get; set; }
    }
}
