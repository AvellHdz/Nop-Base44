namespace Nop.Plugin.Misc.SyncCatalog.Areas.Admin.MiddlewareSync.Models
{
    public class GroupsModel
    {
        public Group[] groups { get; set; }
    }

    public class Group
    {
        public int id { get; set; }
        public string externalId { get; set; }
        public string name { get; set; }
        public int distributorId { get; set; }
    }

}
