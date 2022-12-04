namespace Nop.Plugin.Misc.SyncCatalog.Areas.Admin.MiddlewareSync.Models
{
    public class RevenewSyncModel
    {
        public Revenew[] revenew { get; set; }
    }

    public class Revenew
    {
        public int id { get; set; }
        public string name { get; set; }
    }
}
