namespace Nop.Plugin.Misc.SyncCatalog.Areas.Admin.MiddlewareSync.Models
{
    public class RevenewStore
    {
        public Revenewstore[] revenewStore { get; set; }
    }

    public class Revenewstore
    {
        public int id { get; set; }
        public int revenewId { get; set; }
        public int storeId { get; set; }
        public int priority { get; set; }
        public int type { get; set; }
    }
}
