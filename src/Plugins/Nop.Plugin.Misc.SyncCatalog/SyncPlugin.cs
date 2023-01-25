using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Routing;
using Nop.Core;
using Nop.Core.Domain.Security;
using Nop.Data;
using Nop.Plugin.Misc.SyncCatalog.Areas.Admin.Models;
using Nop.Services.Common;
using Nop.Services.Configuration;
using Nop.Services.Customers;
using Nop.Services.Localization;
using Nop.Services.Plugins;
using Nop.Services.Security;
using Nop.Web.Framework.Menu;

namespace Nop.Plugin.Misc.SyncCatalog
{
    public class SyncPlugin : BasePlugin, IMiscPlugin, IAdminMenuPlugin
    {
        #region Field

        private readonly IWebHelper _webHelper;
        private readonly ILocalizationService _localizationService;
        private readonly IPermissionService _permissionService;
        private readonly ICustomerService _customerService;
        private readonly ISettingService _settingService;
        private readonly IStoreContext _storeContext;
        private readonly IRepository<PermissionRecord> _permissionRecordRepository;

        #endregion

        #region Ctor

        public SyncPlugin(IWebHelper webHelper,
            ILocalizationService localizationService,
            IPermissionService permissionService,
            ICustomerService customerService,
            ISettingService settingService,
            IStoreContext storeContext,
            IRepository<PermissionRecord> permissionRecordRepository)
        {
            _webHelper = webHelper;
            _localizationService = localizationService;
            _permissionService = permissionService;
            _customerService = customerService;
            _settingService = settingService;
            _storeContext = storeContext;
            _permissionRecordRepository = permissionRecordRepository;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets a configuration page URL
        /// </summary>
        public override string GetConfigurationPageUrl()
        {
            return $"{_webHelper.GetStoreLocation()}Admin/Sendinblue/Configure";
        }

        /// <summary>
        /// Install the plugin
        /// </summary>
        /// <returns>A task that represents the asynchronous operation</returns>
        public override async Task InstallAsync()
        {

            //locales
            await _localizationService.AddLocaleResourceAsync(new Dictionary<string, string>
            {
                [$"{Default.RESOURCE_PREFIX}.TitleInfo"] = "Sync Catalog",
                [$"{Default.RESOURCE_PREFIX}.Sync.Menu.Title"] = "Configuración",
                [$"{Default.RESOURCE_PREFIX}.Sync.Setting.SubMenu.Title"] = "Configuración",
                [$"{Default.RESOURCE_PREFIX}.Admin.Common.Sync.Login.Test"] = "Prueba de login",
                [$"{Default.RESOURCE_PREFIX}.Admin.Sync.Fields.UrlService.Required"] = "URL requerida",
                [$"{Default.RESOURCE_PREFIX}.Admin.Sync.Fields.UserName.Required"] = "El usuario es requerido",
                [$"{Default.RESOURCE_PREFIX}.Admin.Sync.Fields.Password.Required"] = "La contraseña es requerida",
                [$"{Default.RESOURCE_PREFIX}.Admin.Sync.Catalog"] = "Catálogo",
                [$"{Default.RESOURCE_PREFIX}.Admin.Sync.Catalog.Revenew"] = "Detalle catálogo de ganancias",
                [$"{Default.RESOURCE_PREFIX}.Admin.Sync.Catalog.Revenew.Filed.RevenewId"] = "Id",
                [$"{Default.RESOURCE_PREFIX}.Admin.Sync.Catalog.Revenew.Filed.Name"] = "Nombre",
                [$"{Default.RESOURCE_PREFIX}.Admin.Sync.Catalog.Revenew.Filed.Priority"] = "Prioridad",
                [$"{Default.RESOURCE_PREFIX}.Admin.Sync.Catalog.Revenew.Filed.NameType"] = "Tipo",
                [$"{Default.RESOURCE_PREFIX}.Admin.Sync.Catalog.Revenew.Filed.Makeup"] = "Ganancia",
                [$"{Default.RESOURCE_PREFIX}.Sync.Catalog.SubMenu.Title"] = "Catálogo de ganancias",
                [$"{Default.RESOURCE_PREFIX}.Admin.Sync.Catalog.Revenew.AddNew"] = "Agregar nuevo revenew",
                [$"{Default.RESOURCE_PREFIX}.Sync.Catalog.Product.SubMenu.Title"] = "Productos de Ordenes a Sync",
                [$"{Default.RESOURCE_PREFIX}.Admin.Sync.Catalog.Product.AddNew"] = "Agregar nueva relación",
                [$"{Default.RESOURCE_PREFIX}.Admin.Sync.Catalog.Product.Edit"] = "Editar relación",
                [Default.IDENTIFIER_PRODUCT_MAPPING] = "Producto en Ordenes a Sincronizar",
                [Default.NAME_PRODUCT_MAPPING] = "Producto",
                [Default.EXTERNAL_PRODUCT_MAPPING] = "Product Code",
                [Default.TITLE_ADD_NEW_PRODUCT_MAPPGIN] = "Agregar relacion de productos",
                [Default.TITLE_ADD_NEW_REVENEW_MAPPGIN] = "Agregar relacion de ganancia por tipo",
                [Default.RESOURCE_URL_SERVICES] = "API Services - URL",
                [Default.RESOURCE_USER_NAME] = "Usuario",
                [Default.RESOURCE_PASSWORD] = "Contraseña",
                [Default.RESOURCE_STORE_ID] = "Identificador Tienda",
                [Default.RESOURCE_QUERY_AUTHENTICATE] = "Query - Obtener Autentificador",
                [Default.RESOURCE_QUERY_REVENEW_CATALOG] = "Query - Catálogo Revenew",
                [Default.RESOURCE_QUERY_CATEGORY_CATALOG] = "Query - Catálogo de Categorías",
                [Default.RESOURCE_QUERY_BRAND_CATALOG] = "Query - Catálogo de Marcas",
                [Default.RESOURCE_QUERY_REVENEW_STORE_CATALOG] = "Query - Catálogo de Ganancia de Tienda",
                [Default.RESOURCE_QUERY_REVENEW_STORE_MAPPING_CATALOG] = "Query - Mapeo Catálogos",
                [Default.RESOURCE_MUTATION_CREATE_REVENEW_STORE_MAPPING_CATALOG] = "Mutation - Creación Mapeo de Tienda",
                [Default.RESOURCE_QUERY_PRODUCT_STORE_MAPPING_CATALOG] = "Query - Mapeo de Productos",
                [Default.RESOURCE_MUTATION_CREATE_PRODUCT_STORE_MAPPING_CATALOG] = "Mutation - Creación Mapeo de Productos"
            });

            // Settings Default
            var storeScope = await _storeContext.GetActiveStoreScopeConfigurationAsync();
            var syncSetting = await _settingService.LoadSettingAsync<SettingModel>(storeScope);

            syncSetting.QueryAuthenticate = Default.DefaultSettingQueryAuthenticate;
            syncSetting.QueryRevenewCatalog = Default.DefaultSettingQueryRevenewCatalog;
            syncSetting.QueryCategoryCatalog = Default.DefaultSettingQueryCategoryCatalog;
            syncSetting.QueryBrandCatalog = Default.DefaultSettingQueryBrandCatalog;
            syncSetting.QueryRevenewStoreCatalog = Default.DefaultSettingQueryRevenewStoreCatalog;
            syncSetting.QueryRevenewStoreMappingCatalog = Default.DefaultSettingQueryRevenewStoreMappingCatalog;
            syncSetting.QueryProductStoreMappingCatalog = Default.DefaultSettingQueryProductStoreMappingCatalog;
            syncSetting.MutationCreateRevenewStoreMappingCatalog = Default.DefaultSettingMutationCreateRevenewStoreMappingCatalog;
            syncSetting.MutationCreateProductStoreMappingCatalog = Default.DefaultSettingMutationCreateProductStoreMappingCatalog;

            await _settingService.SaveSettingAsync(syncSetting, settings => settings.QueryAuthenticate, clearCache: false);
            await _settingService.SaveSettingAsync(syncSetting, settings => settings.QueryRevenewCatalog, clearCache: false);
            await _settingService.SaveSettingAsync(syncSetting, settings => settings.QueryCategoryCatalog, clearCache: false);
            await _settingService.SaveSettingAsync(syncSetting, settings => settings.QueryBrandCatalog, clearCache: false);
            await _settingService.SaveSettingAsync(syncSetting, settings => settings.QueryRevenewStoreCatalog, clearCache: false);
            await _settingService.SaveSettingAsync(syncSetting, settings => settings.QueryRevenewStoreMappingCatalog, clearCache: false);
            await _settingService.SaveSettingAsync(syncSetting, settings => settings.MutationCreateRevenewStoreMappingCatalog, clearCache: false);
            await _settingService.SaveSettingAsync(syncSetting, settings => settings.QueryProductStoreMappingCatalog, clearCache: false);
            await _settingService.SaveSettingAsync(syncSetting, settings => settings.MutationCreateProductStoreMappingCatalog, clearCache: false);

            // Add new permission record
            var catalogManageSystem = new PermissionRecord
            {
                Name = Default.PermissionManagerName,
                SystemName = Default.PermissionManagerSystmeName,
                Category = Default.PermissionManagerCategoryName
            };

            var permissionRecord = (await _permissionService.GetAllPermissionRecordsAsync()).Where(x => x.Name == Default.PermissionManagerName);

            if (permissionRecord == null || !permissionRecord.Any())
                await _permissionRecordRepository.InsertAsync(catalogManageSystem);

            var customerRole = (await _customerService.GetAllCustomerRolesAsync()).Where(cr => cr.Name == "Administrators").FirstOrDefault();

            if (customerRole != null)
            {
                var mapping = await _permissionService.GetMappingByPermissionRecordIdAsync(catalogManageSystem.Id);
                if (mapping != null && mapping.Count == 0)
                {
                    var prcrm = new PermissionRecordCustomerRoleMapping { CustomerRoleId = customerRole.Id, PermissionRecordId = catalogManageSystem.Id };

                    await _permissionService.InsertPermissionRecordCustomerRoleMappingAsync(prcrm);
                }
            }

            await base.InstallAsync();
        }

        #endregion

        #region AdminMenu

        public async Task ManageSiteMapAsync(SiteMapNode rootNode)
        {
            var menuItem = new SiteMapNode()
            {
                SystemName = Default.PluginSystemName,
                Title = await _localizationService.GetResourceAsync(Default.PluginMenuTitle),
                ControllerName = null,
                ActionName = null,
                Visible = true,
                IconClass = "fas fa-solid fa-code",
                Url = string.Empty,
                RouteValues = new RouteValueDictionary() { { "area", null } }
            };

            var subMenuSetting = new SiteMapNode()
            {
                SystemName = Default.SystemNameMenuSetting,
                Title = await _localizationService.GetResourceAsync(Default.PluginSettingTitle),
                ControllerName = "Sync",
                ActionName = "Configure",
                Visible = true,
                IconClass = "fas fa-solid fa-file-code",
                Url = string.Empty,
                RouteValues = new RouteValueDictionary() { { "area", "admin" } },
            };

            var subMenuCatalog = new SiteMapNode()
            {
                SystemName = Default.SystemNameMenuCatalog,
                Title = await _localizationService.GetResourceAsync(Default.PluginCatalogTitle),
                ControllerName = "CatalogSync",
                ActionName = "List",
                Visible = true,
                IconClass = "fas fa-solid fa-file-code",
                Url = string.Empty,
                RouteValues = new RouteValueDictionary() { { "area", "admin" } },
            };

            var subMenuCatalogProduct = new SiteMapNode()
            {
                SystemName = Default.SystemNameMenuCatalogProduct,
                Title = await _localizationService.GetResourceAsync(Default.PluginCatalogProductTitle),
                ControllerName = "CatalogSync",
                ActionName = "ListProducts",
                Visible = true,
                IconClass = "fas fa-solid fa-file-code",
                Url = string.Empty,
                RouteValues = new RouteValueDictionary() { { "area", "admin" } },
            };

            menuItem.ChildNodes.Add(subMenuSetting);
            menuItem.ChildNodes.Add(subMenuCatalog);
            menuItem.ChildNodes.Add(subMenuCatalogProduct);

            rootNode.ChildNodes.Add(menuItem);

        }

        #endregion
    }
}
