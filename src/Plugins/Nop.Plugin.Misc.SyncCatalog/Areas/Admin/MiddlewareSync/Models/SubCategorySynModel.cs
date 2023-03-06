namespace Nop.Plugin.Misc.SyncCatalog.Areas.Admin.MiddlewareSync.Models
{
    public class SubCategorySynModel
    {
        public SubCategory[] subCategory { get; set; }
    }

    public class SubCategory
    {
        public int Id { get; set; }
        public string externalId { get; set; }
        public string name { get; set; }
        public string parentId { get; set; }
        public string parent { get; set; }
        public int distributorId { get; set; }
    }

}
