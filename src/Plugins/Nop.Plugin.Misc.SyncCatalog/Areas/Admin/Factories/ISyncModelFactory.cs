using System.Collections.Generic;
using System.Threading.Tasks;
using Nop.Plugin.Misc.SyncCatalog.Areas.Admin.Models;

namespace Nop.Plugin.Misc.SyncCatalog.Areas.Admin.Factories
{
    public interface ISyncModelFactory
    {
        #region Methods


        /// <summary>
        /// Prepare catalog search model
        /// </summary>
        /// <param name="searchModel">Currency search model</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the currency search model
        /// </returns>
        Task<CatalogSearchModel> PrepareCatalogSearchModelAsync(CatalogSearchModel searchModel);

        /// <summary>
        /// Prepare ConfigurationModel
        /// </summary>
        /// <param name="model">Model</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task<ConfigurationModel> PrepareModelAsync(ConfigurationModel model);

        /// <summary>
        /// Prepare catalog search model
        /// </summary>
        /// <param name="searchModel">Currency search model</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the currency search model
        /// </returns>
        Task<CatalogProductSearchModel> PrepareCatalogProductSearchModelAsync(CatalogProductSearchModel searchModel);

        /// <summary>
        /// Prepate catalog Model
        /// </summary>
        /// <param name="model"></param>
        /// <param name="excludeProperties"></param>
        /// <returns></returns>
        Task<CatalogModel> PrepareCatalogModelAsync(CatalogModel model = null, bool excludeProperties = false,
            List<string> filterRevenews = default,
            List<string> filterCategories = default,
            List<string> filterBrands = default);


        /// <summary>
        /// Prepare paged catalog list model
        /// </summary>
        /// <param name="searchModel">Catalog sync search model</param>
        /// <param name="setting">Setting model</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the ier price list model
        /// </returns>
        Task<CatalogListModel> PrepareCatalogSyncListModelAsync(CatalogSearchModel searchModel, SettingModel setting);

        /// <summary>
        /// Prepare paged catalog model - Sync Service
        /// </summary>
        /// <param name="setting">Setting model</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the catalog model
        /// </returns>
        Task<IList<CatalogModel>> PrepareCatalogSyncModelAsync(SettingModel setting);

        /// <summary>
        /// Prepare paged catalog product list model
        /// </summary>
        /// <param name="searchModel">Catalog sync search model</param>
        /// <param name="setting">Setting model</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the catalog sync list model
        /// </returns>
        Task<CatalogProductListModel> PrepareCatalogProductSyncListModelAsync(CatalogProductSearchModel searchModel, SettingModel setting);

        /// <summary>
        /// Prepare paged catalog model - Sync Service
        /// </summary>
        /// <param name="setting">Setting model</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the catalog model
        /// </returns>
        Task<CatalogProductModel> PrepareCatalogProductSyncModelAsync(SettingModel setting);

        #endregion
    }
}
