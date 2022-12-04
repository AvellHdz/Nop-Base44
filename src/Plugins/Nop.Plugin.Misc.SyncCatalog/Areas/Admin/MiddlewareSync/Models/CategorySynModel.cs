namespace Nop.Plugin.Misc.SyncCatalog.Areas.Admin.MiddlewareSync.Models
{
    public class CategorySynModel
    {
        public Category[] category { get; set; }
    }

    public class Category
    {
        public string externalId { get; set; }
        public string name { get; set; }
        public int distributorId { get; set; }
    }

}
