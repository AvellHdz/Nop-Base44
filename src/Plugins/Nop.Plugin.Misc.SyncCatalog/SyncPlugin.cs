using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Routing;
using Nop.Core;
using Nop.Services.Common;
using Nop.Services.Localization;
using Nop.Services.Plugins;
using Nop.Web.Framework;
using Nop.Web.Framework.Menu;

namespace Nop.Plugin.Misc.SyncCatalog
{
    public class SyncPlugin : BasePlugin, IMiscPlugin, IAdminMenuPlugin
    {
        #region Field

        private readonly IWebHelper _webHelper;
        private readonly ILocalizationService _localizationService;

        #endregion

        #region Ctor

        public SyncPlugin(IWebHelper webHelper, 
            ILocalizationService localizationService)
        {
            _webHelper = webHelper;
            _localizationService = localizationService;
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
                [$"{Default.RESOURCE_PREFIX}.Admin.Sync.Catalog.Revenew"] = "Cifra",
                [$"{Default.RESOURCE_PREFIX}.Admin.Sync.Catalog.Revenew.Filed.RevenewId"] = "Id",
                [$"{Default.RESOURCE_PREFIX}.Admin.Sync.Catalog.Revenew.Filed.Name"] = "Nombre",
                [$"{Default.RESOURCE_PREFIX}.Admin.Sync.Catalog.Revenew.Filed.Priority"] = "Prioridad",
                [$"{Default.RESOURCE_PREFIX}.Admin.Sync.Catalog.Revenew.Filed.NameType"] = "Tipo",
                [$"{Default.RESOURCE_PREFIX}.Admin.Sync.Catalog.Revenew.Filed.Makeup"] = "Ganancia"
            });

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

            menuItem.ChildNodes.Add(subMenuSetting);
            menuItem.ChildNodes.Add(subMenuCatalog);

            rootNode.ChildNodes.Add(menuItem);

        }

        #endregion
    }
}
