using Nop.Plugin.Misc.SyncCatalog.Areas.Admin.MiddlewareSync.Models;
using Nop.Plugin.Misc.SyncCatalog.Areas.Admin.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nop.Plugin.Misc.SyncCatalog.Areas.Admin.Services
{
    public interface ISyncService
    {

        /// <summary>
        /// Authenticate with API - Sync Catalog
        /// </summary>
        /// <param name="login"></param>
        /// <param name="setting"></param>
        /// <returns></returns>
        Task<AuthenticateModel> AuthenticateAsync(LoginModel login, SettingModel setting);

        /// <summary>
        /// Revenew Catalog - Sync Catalog
        /// </summary>
        /// <param name="login"></param>
        /// <param name="setting"></param>
        /// <returns></returns>
        Task<RevenewSyncModel> GetRevenewCatalog(string token, SettingModel setting);

        /// <summary>
        /// Category Catalog - Sync Catalog
        /// </summary>
        /// <param name="login"></param>
        /// <param name="setting"></param>
        /// <returns></returns>
        Task<CategorySynModel> GetCategoryCatalog(string token, SettingModel setting);

        /// <summary>
        /// Brand Catalog - Sync Catalog
        /// </summary>
        /// <param name="login"></param>
        /// <param name="setting"></param>
        /// <returns></returns>
        Task<BrandSyncModel> GetBransCatalog(string token, SettingModel setting);

        /// <summary>
        /// Revenew Catalog - Sync Catalog
        /// </summary>
        /// <param name="login"></param>
        /// <param name="setting"></param>
        /// <returns></returns>
        Task<RevenewStore> GetRevenewStoreCatalog(string token, SettingModel setting);

        /// <summary>
        /// Revenew Catalog - Sync Catalog
        /// </summary>
        /// <param name="login"></param>
        /// <param name="setting"></param>
        /// <returns></returns>
        Task<RevenewStoreMappingSync> GetRevenewStoreMppingCatalog(List<int> revenewStore, SettingModel setting, string token);
    }
}
