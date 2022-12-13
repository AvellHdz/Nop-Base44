namespace Nop.Plugin.Misc.SyncCatalog.Areas.Admin.MiddlewareSync.Models
{
    public class ProductSyncStore
    {
        public Productstore[] productStore { get; set; }
    }

    public class Productstore
    {
        public int productId { get; set; }
        public int storeId { get; set; }
        public int Id { get; set; }
    }

}
