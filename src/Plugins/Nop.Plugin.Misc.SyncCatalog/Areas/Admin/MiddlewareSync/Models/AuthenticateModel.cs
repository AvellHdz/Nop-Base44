
namespace Nop.Plugin.Misc.SyncCatalog.Areas.Admin.MiddlewareSync.Models
{
    public class AuthenticateModel
    {
        public Login login { get; set; }
    }
    public class Login
    {
        public string message { get; set; }
        public string accessToken { get; set; }
        public string refreshToken { get; set; }
    }
}
