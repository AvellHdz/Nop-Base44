using System.Collections.Generic;
using System.Threading.Tasks;
using Nop.Plugin.Misc.SyncCatalog.Areas.Admin.MiddlewareSync;
using Nop.Plugin.Misc.SyncCatalog.Areas.Admin.MiddlewareSync.Models;
using Nop.Plugin.Misc.SyncCatalog.Areas.Admin.Models;

namespace Nop.Plugin.Misc.SyncCatalog.Areas.Admin.Services
{
    public class SyncService : ISyncService
    {

        #region Methods

        /// <summary>
        /// Authenticate with API - Sync Catalog
        /// </summary>
        /// <param name="login"></param>
        /// <param name="setting"></param>
        /// <returns></returns>
        public async Task<AuthenticateModel> AuthenticateAsync(LoginModel login, SettingModel setting)
        {
            #region Data Sync

            if (!string.IsNullOrEmpty(setting.UrlService)
                && !string.IsNullOrEmpty(setting.QueryAuthenticate))
            {
                var mutarionAuthRequest = setting.QueryAuthenticate
                    .Replace(LiteralSync.REQUEST_EMAIL_AUTH, login.Email)
                    .Replace(LiteralSync.REQUEST_PASSWORD_AUTH, login.Password);

                return await MutationLicenseService.ExceuteMutationAsyn<AuthenticateModel>(mutarionAuthRequest) ?? new();
            }

            #endregion

            return new();
        }


        /// <summary>
        /// Revenew Catalog - Sync Catalog
        /// </summary>
        /// <param name="login"></param>
        /// <param name="setting"></param>
        /// <returns></returns>
        public async Task<RevenewSyncModel> GetRevenewCatalog(string token, SettingModel setting)
        {
            #region Data Sync

            if (!string.IsNullOrEmpty(setting.UrlService)
                && !string.IsNullOrEmpty(setting.QueryAuthenticate))
            {
                return await Query.ExceuteQueryAsync<RevenewSyncModel>(setting.QueryRevenewCatalog, auth: false, bearer: token) ?? new();
            }

            #endregion

            return new();
        }


        /// <summary>
        /// Category Catalog - Sync Catalog
        /// </summary>
        /// <param name="login"></param>
        /// <param name="setting"></param>
        /// <returns></returns>
        public async Task<CategorySynModel> GetCategoryCatalog(string token, SettingModel setting)
        {
            #region Data Sync

            if (!string.IsNullOrEmpty(setting.UrlService)
                && !string.IsNullOrEmpty(setting.QueryAuthenticate))
            {
                var queryRequest = setting.QueryCategoryCatalog
                    .Replace(LiteralSync.TOKEN_NAME, token);

                return await Query.ExceuteQueryAsync<CategorySynModel>(queryRequest, auth: false, bearer: token) ?? new();
            }

            #endregion

            return new();
        }

        /// <summary>
        /// Brand Catalog - Sync Catalog
        /// </summary>
        /// <param name="login"></param>
        /// <param name="setting"></param>
        /// <returns></returns>
        public async Task<BrandSyncModel> GetBransCatalog(string token, SettingModel setting)
        {
            #region Data Sync

            if (!string.IsNullOrEmpty(setting.UrlService)
                && !string.IsNullOrEmpty(setting.QueryAuthenticate))
            {
                var queryRequest = setting.QueryBrandCatalog
                    .Replace(LiteralSync.TOKEN_NAME, token);

                return await Query.ExceuteQueryAsync<BrandSyncModel>(queryRequest, auth: false, bearer: token) ?? new();
            }

            #endregion

            return new();
        }

        /// <summary>
        /// Revenew Catalog - Sync Catalog
        /// </summary>
        /// <param name="login"></param>
        /// <param name="setting"></param>
        /// <returns></returns>
        public async Task<RevenewStore> GetRevenewStoreCatalog(string token, SettingModel setting)
        {
            #region Data Sync

            if (!string.IsNullOrEmpty(setting.UrlService)
                && !string.IsNullOrEmpty(setting.QueryAuthenticate)
                && setting.StoreId > 0)
            {

                var queryRequest = setting.QueryRevenewStoreCatalog
                    .Replace(LiteralSync.STORE_ID_CODE, $"{setting.StoreId}");

                return await Query.ExceuteQueryAsync<RevenewStore>(queryRequest, auth: false, bearer: token) ?? new();
            }

            #endregion

            return new();
        }

        /// <summary>
        /// Revenew Catalog - Sync Catalog
        /// </summary>
        /// <param name="login"></param>
        /// <param name="setting"></param>
        /// <returns></returns>
        public async Task<RevenewStoreMappingSync> GetRevenewStoreMppingCatalog(List<int> revenewStore, SettingModel setting, string token)
        {
            #region Data Sync

            if (!string.IsNullOrEmpty(setting.UrlService)
                && !string.IsNullOrEmpty(setting.QueryAuthenticate)
                && setting.StoreId > 0)
            {
                var mapping = string.Join(",", revenewStore);

                var queryRequest = setting.QueryRevenewStoreMappingCatalog
                    .Replace(LiteralSync.MAPPING_REVENEW_ID, mapping);

                return await Query.ExceuteQueryAsync<RevenewStoreMappingSync>(queryRequest, auth: false, bearer: token) ?? new();
            }

            #endregion

            return new();
        }
        #endregion
    }
}
