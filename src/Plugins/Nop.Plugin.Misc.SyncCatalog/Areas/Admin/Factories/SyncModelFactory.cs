using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iTextSharp.text;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nop.Core;
using Nop.Core.Domain.Catalog;
using Nop.Plugin.Misc.SyncCatalog.Areas.Admin.MiddlewareSync.Models;
using Nop.Plugin.Misc.SyncCatalog.Areas.Admin.Models;
using Nop.Plugin.Misc.SyncCatalog.Areas.Admin.Services;
using Nop.Services.Common;
using Nop.Services.Configuration;
using Nop.Web.Framework.Models.Extensions;

namespace Nop.Plugin.Misc.SyncCatalog.Areas.Admin.Factories
{
    public class SyncModelFactory : ISyncModelFactory
    {
        #region Field

        private readonly IStoreContext _storeContext;
        private readonly ISettingService _settingService;
        private readonly ISyncService _syncService;
        private readonly IGenericAttributeService _genericAttributeService;
        private readonly IBasePluginAdminModelFactory _basePluginAdminModelFactory;

        #endregion

        #region Ctor

        public SyncModelFactory(IStoreContext storeContext,
            ISettingService settingService,
            ISyncService syncService,
            IGenericAttributeService genericAttributeService,
            IBasePluginAdminModelFactory basePluginAdminModelFactory)
        {
            _storeContext = storeContext;
            _settingService = settingService;
            _syncService = syncService;
            _genericAttributeService = genericAttributeService;
            _basePluginAdminModelFactory = basePluginAdminModelFactory;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Prepare catalog search model
        /// </summary>
        /// <param name="searchModel">Currency search model</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the currency search model
        /// </returns>
        public virtual async Task<CatalogSearchModel> PrepareCatalogSearchModelAsync(CatalogSearchModel searchModel)
        {
            if (searchModel == null)
                throw new ArgumentNullException(nameof(searchModel));

            //prepare page parameters
            searchModel.SetGridPageSize();

            return searchModel;
        }

        /// <summary>
        /// Prepare ConfigurationModel
        /// </summary>
        /// <param name="model">Model</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task<ConfigurationModel> PrepareModelAsync(ConfigurationModel model)
        {
            // Validae
            model ??= new();

            //load settings for active store scope
            var storeId = await _storeContext.GetActiveStoreScopeConfigurationAsync();
            var sendinblueSettings = await _settingService.LoadSettingAsync<SettingModel>(storeId);

            //prepare common properties
            model.UrlService = sendinblueSettings.UrlService;
            model.UserName = sendinblueSettings.UserName;
            model.Password = sendinblueSettings.Password;
            model.StoreId = sendinblueSettings.StoreId;
            model.QueryAuthenticate = sendinblueSettings.QueryAuthenticate;
            model.QueryRevenewCatalog = sendinblueSettings.QueryRevenewCatalog;
            model.QueryCategoryCatalog = sendinblueSettings.QueryCategoryCatalog;
            model.QueryBrandCatalog = sendinblueSettings.QueryBrandCatalog;
            model.QueryRevenewStoreCatalog = sendinblueSettings.QueryRevenewStoreCatalog;
            model.QueryRevenewStoreMappingCatalog = sendinblueSettings.QueryRevenewStoreMappingCatalog;

            return model;
        }

        /// <summary>
        /// Prepate catalog Model
        /// </summary>
        /// <param name="model"></param>
        /// <param name="excludeProperties"></param>
        /// <returns></returns>
        public virtual async Task<CatalogModel> PrepareCatalogModelAsync(CatalogModel model = null, bool excludeProperties = false,
            List<string> filterRevenews = default,
            List<string> filterCategories = default,
            List<string> filterBrands = default)
        {
            model ??= new();

            //prepare available revenews
            await _basePluginAdminModelFactory.PrepareRevenewTypesAsync(model.AvailableRevenews, withSpecialDefaultItem: false, filterValues: filterRevenews);

            //prepare available revenews
            await _basePluginAdminModelFactory.PrepareCategoriesTypesAsync(model.AvailableCategory, withSpecialDefaultItem: false, filterValues: filterCategories);

            //prepare available revenews
            await _basePluginAdminModelFactory.PrepareBrandTypesAsync(model.AvailableBrand, withSpecialDefaultItem: false, filterValues: filterBrands);

            return model;
        }

        /// <summary>
        /// Prepare paged catalog list model
        /// </summary>
        /// <param name="searchModel">Catalog sync search model</param>
        /// <param name="setting">Setting model</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the catalog sync list model
        /// </returns>
        public virtual async Task<CatalogListModel> PrepareCatalogSyncListModelAsync(CatalogSearchModel searchModel, SettingModel setting)
        {
            if (searchModel == null)
                throw new ArgumentNullException(nameof(searchModel));

            //get revenews services
            var revenews = (await _syncService.GetRevenewStoreCatalog(string.Empty, setting))
                .revenewStore.ToList();

            var revenewMapping = await _syncService.GetRevenewStoreMppingCatalog(revenews.Select(l => l.id).ToList(),
                setting,
                string.Empty);

            //prepare available types
            var store = await _storeContext.GetCurrentStoreAsync();
            var generics = await _genericAttributeService.GetAttributesForEntityAsync(store.Id, store.GetType().Name);

            //prepare grid model
            var model = await new CatalogListModel().PrepareToGridAsync(searchModel, revenews.ToPagedList(searchModel), () =>
            {
                /// Group catalog
                var revenewGruop = revenews.GroupJoin(revenewMapping.revenewStoreMapping,
                    str => str.id,
                    s => s.revenewStoreId,
                    (str, stuGroup) =>
                    new
                    {
                        id = str.id,
                        revenewName = str.revenewId,
                        priority = str.priority,
                        mapping = stuGroup
                    });

                var catalogModels = new List<CatalogModel>();

                /// Create Mapping
                foreach (var revenew in revenewGruop)
                {
                    foreach (var mapping in revenew.mapping)
                    {
                        #region Get additional data

                        var revenewsTypes = generics.Where(l => l.Key.Contains(Default.GenericRevenewCatalog));

                        var idRevenew = revenewsTypes.FirstOrDefault(x => x.Key.Replace(Default.GenericRevenewCatalog, string.Empty) == $"{revenew.id}")
                            .Key.Replace(Default.GenericRevenewCatalog, string.Empty);

                        var name = revenewsTypes.FirstOrDefault(x => x.Key.Replace(Default.GenericRevenewCatalog, string.Empty) == $"{revenew.id}")
                            .Value;

                        var categories = generics.Where(l => l.Key.Contains(Default.GenericCategoryCatalog));

                        var brands = generics.Where(l => l.Key.Contains(Default.GenericBrandCatalog));

                        var nameType = name switch
                        {
                            "Categoria" => categories.FirstOrDefault(x => x.Key.Replace(Default.GenericCategoryCatalog, string.Empty) == $"{mapping.externalId}").Value,
                            "Marca" => brands.FirstOrDefault(x => x.Key.Replace(Default.GenericBrandCatalog, string.Empty) == $"{mapping.externalId}").Value,
                            _ => string.Empty,
                        };

                        #endregion

                        catalogModels.Add(new()
                        {
                            IdRevenew = idRevenew ?? string.Empty,
                            RevenewName = name ?? string.Empty,
                            Priority = revenew.priority,
                            NameType = nameType,
                            Makeup = (decimal)mapping.makeup
                        });
                    }
                }

                return catalogModels.ToAsyncEnumerable();

                //return revenewGruop.SelectAwait(async revenew =>
                //{

                //    #region Revenew Store

                //    //prepare available types
                //    var store = await _storeContext.GetCurrentStoreAsync();

                //    var generics = await _genericAttributeService.GetAttributesForEntityAsync(store.Id, store.GetType().Name);

                //    var availableTypes = generics.Where(l => l.Key.Contains(Default.GenericRevenewCatalog));

                //    var idRevenew = availableTypes.FirstOrDefault(x => x.Key.Replace(Default.GenericRevenewCatalog, string.Empty) == $"{revenew.id}")
                //        .Key.Replace(Default.GenericRevenewCatalog, string.Empty);

                //    var name = availableTypes.FirstOrDefault(x => x.Key.Replace(Default.GenericRevenewCatalog, string.Empty) == $"{revenew.id}").Value;

                //    #endregion

                //    //fill in additional values (not existing in the entity)   
                //    var catalogModel = new CatalogModel()
                //    {
                //        IdRevenew = idRevenew ?? string.Empty,
                //        RevenewName = name ?? string.Empty,
                //        Priority = revenew.priority
                //    };

                //    return catalogModel;
                //});
            });

            return model;
        }

        /// <summary>
        /// Prepare paged catalog model - Sync Service
        /// </summary>
        /// <param name="setting">Setting model</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the catalog model
        /// </returns>
        public virtual async Task<IList<CatalogModel>> PrepareCatalogSyncModelAsync(SettingModel setting)
        {
            //get revenews services
            var revenews = (await _syncService.GetRevenewStoreCatalog(string.Empty, setting))
                .revenewStore.ToList();

            var revenewMapping = await _syncService.GetRevenewStoreMppingCatalog(revenews.Select(l => l.id).ToList(),
                setting,
                string.Empty);

            //prepare available types
            var store = await _storeContext.GetCurrentStoreAsync();
            var generics = await _genericAttributeService.GetAttributesForEntityAsync(store.Id, store.GetType().Name);


            /// Group catalog
            var revenewGruop = revenews.GroupJoin(revenewMapping.revenewStoreMapping,
                str => str.id,
                s => s.revenewStoreId,
                (str, stuGroup) =>
                new
                {
                    id = str.id,
                    revenewName = str.revenewId,
                    priority = str.priority,
                    mapping = stuGroup
                });

            var catalogModels = new List<CatalogModel>();

            /// Create Mapping
            foreach (var revenew in revenewGruop)
            {
                foreach (var mapping in revenew.mapping)
                {
                    #region Get additional data

                    var revenewsTypes = generics.Where(l => l.Key.Contains(Default.GenericRevenewCatalog));

                    var idRevenew = revenewsTypes.FirstOrDefault(x => x.Key.Replace(Default.GenericRevenewCatalog, string.Empty) == $"{revenew.id}")
                        .Key.Replace(Default.GenericRevenewCatalog, string.Empty);

                    var name = revenewsTypes.FirstOrDefault(x => x.Key.Replace(Default.GenericRevenewCatalog, string.Empty) == $"{revenew.id}")
                        .Value;

                    var categories = generics.Where(l => l.Key.Contains(Default.GenericCategoryCatalog));

                    var brands = generics.Where(l => l.Key.Contains(Default.GenericBrandCatalog));

                    var nameType = name switch
                    {
                        "Categoria" => categories.FirstOrDefault(x => x.Key.Replace(Default.GenericCategoryCatalog, string.Empty) == $"{mapping.externalId}").Value,
                        "Marca" => brands.FirstOrDefault(x => x.Key.Replace(Default.GenericBrandCatalog, string.Empty) == $"{mapping.externalId}").Value,
                        _ => string.Empty,
                    };

                    #endregion

                    catalogModels.Add(new()
                    {
                        IdRevenew = idRevenew ?? string.Empty,
                        RevenewName = name ?? string.Empty,
                        Priority = revenew.priority,
                        NameType = nameType,
                        Makeup = (decimal)mapping.makeup
                    });
                }
            }
            return catalogModels;
        }

        #endregion
    }
}
