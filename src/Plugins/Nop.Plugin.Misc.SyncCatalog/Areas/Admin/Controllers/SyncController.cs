using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Plugin.Misc.SyncCatalog.Areas.Admin.Factories;
using Nop.Plugin.Misc.SyncCatalog.Areas.Admin.MiddlewareSync.Models;
using Nop.Plugin.Misc.SyncCatalog.Areas.Admin.Models;
using Nop.Plugin.Misc.SyncCatalog.Areas.Admin.Services;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using Nop.Services.Messages;
using Nop.Services.Security;
using Nop.Web.Framework;
using Nop.Web.Framework.Controllers;
using Nop.Web.Framework.Mvc.Filters;

namespace Nop.Plugin.Misc.SyncCatalog.Areas.Admin.Controllers
{

    [Area(AreaNames.Admin)]
    [AuthorizeAdmin]
    [AutoValidateAntiforgeryToken]
    public class SyncController : BasePluginController
    {

        #region Field

        private readonly ISyncModelFactory _syncModelFactory;
        private readonly IPermissionService _permissionService;
        private readonly ISettingService _settingService;
        private readonly INotificationService _notificationService;
        private readonly ILocalizationService _localizationService;
        private readonly IStoreContext _storeContext;
        private readonly ISyncService _syncService;

        #endregion

        #region Ctor

        public SyncController(ISyncModelFactory syncModelFactory,
            IPermissionService permissionService,
            ISettingService settingService,
            INotificationService notificationService,
            ILocalizationService localizationService,
            IStoreContext storeContext,
            ISyncService syncService)
        {
            _syncModelFactory = syncModelFactory;
            _permissionService = permissionService;
            _settingService = settingService;
            _notificationService = notificationService;
            _localizationService = localizationService;
            _storeContext = storeContext;
            _syncService = syncService;
        }

        #endregion

        #region Methods

        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task<IActionResult> Configure(bool lives = false)
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageWidgets))
                return AccessDeniedView();

            var model = await _syncModelFactory.PrepareModelAsync(new());

            if (lives)
            {
                await LoginTest(model);
                return await Configure();
            }

            return View(model);
        }

        [HttpPost]
        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task<IActionResult> Configure(ConfigurationModel model)
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageWidgets))
                return AccessDeniedView();

            //load settings for a chosen store scope
            var storeScope = await _storeContext.GetActiveStoreScopeConfigurationAsync();
            var syncSetting = await _settingService.LoadSettingAsync<SettingModel>(storeScope);

            syncSetting.StoreId = model.StoreId;
            syncSetting.UrlService = model.UrlService;
            syncSetting.UserName = model.UserName;
            syncSetting.Password = model.Password;
            syncSetting.QueryAuthenticate = model.QueryAuthenticate;
            syncSetting.QueryRevenewCatalog = model.QueryRevenewCatalog;
            syncSetting.QueryCategoryCatalog = model.QueryCategoryCatalog;
            syncSetting.QuerySubCategoryCatalog = model.QuerySubCategoryCatalog;
            syncSetting.QueryGroupsCatalog = model.QueryGroupsCatalog;
            syncSetting.QueryBrandCatalog = model.QueryBrandCatalog;
            syncSetting.QueryRevenewStoreCatalog = model.QueryRevenewStoreCatalog;
            syncSetting.QueryRevenewStoreMappingCatalog = model.QueryRevenewStoreMappingCatalog;
            syncSetting.QueryProductStoreMappingCatalog = model.QueryProductStoreMappingCatalog;
            syncSetting.MutationCreateRevenewStoreMappingCatalog = model.MutationCreateRevenewStoreMappingCatalog;
            syncSetting.MutationUpdateRevenewStoreMappingCatalog = model.MutationUpdateRevenewStoreMappingCatalog;
            syncSetting.MutationDeleteRevenewStoreMappingCatalog = model.MutationDeleteRevenewStoreMappingCatalog;
            syncSetting.MutationCreateProductStoreMappingCatalog = model.MutationCreateProductStoreMappingCatalog;
            syncSetting.QueryCatalogStore = model.QueryCatalogStore;

            /* We do not clear cache after each setting update.
             * This behavior can increase performance because cached settings will not be cleared 
             * and loaded from database after each update */
            await _settingService.SaveSettingAsync(syncSetting, settings => settings.StoreId, clearCache: false);
            await _settingService.SaveSettingAsync(syncSetting, settings => settings.UrlService, clearCache: false);
            await _settingService.SaveSettingAsync(syncSetting, settings => settings.UserName, clearCache: false);
            await _settingService.SaveSettingAsync(syncSetting, settings => settings.Password, clearCache: false);
            await _settingService.SaveSettingAsync(syncSetting, settings => settings.QueryAuthenticate, clearCache: false);
            await _settingService.SaveSettingAsync(syncSetting, settings => settings.QueryRevenewCatalog, clearCache: false);
            await _settingService.SaveSettingAsync(syncSetting, settings => settings.QueryCategoryCatalog, clearCache: false);
            await _settingService.SaveSettingAsync(syncSetting, settings => settings.QuerySubCategoryCatalog, clearCache: false);
            await _settingService.SaveSettingAsync(syncSetting, settings => settings.QueryGroupsCatalog, clearCache: false);
            await _settingService.SaveSettingAsync(syncSetting, settings => settings.QueryBrandCatalog, clearCache: false);
            await _settingService.SaveSettingAsync(syncSetting, settings => settings.QueryRevenewStoreCatalog, clearCache: false);
            await _settingService.SaveSettingAsync(syncSetting, settings => settings.QueryRevenewStoreMappingCatalog, clearCache: false);
            await _settingService.SaveSettingAsync(syncSetting, settings => settings.MutationCreateRevenewStoreMappingCatalog, clearCache: false);
            await _settingService.SaveSettingAsync(syncSetting, settings => settings.MutationUpdateRevenewStoreMappingCatalog, clearCache: false);
            await _settingService.SaveSettingAsync(syncSetting, settings => settings.MutationDeleteRevenewStoreMappingCatalog, clearCache: false);
            await _settingService.SaveSettingAsync(syncSetting, settings => settings.QueryProductStoreMappingCatalog, clearCache: false);
            await _settingService.SaveSettingAsync(syncSetting, settings => settings.MutationCreateProductStoreMappingCatalog, clearCache: false);
            await _settingService.SaveSettingAsync(syncSetting, settings => settings.QueryCatalogStore, clearCache: false);

            //now clear settings cache
            await _settingService.ClearCacheAsync();

            _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Plugins.Saved"));

            return await Configure();
        }

        [HttpPost]
        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task<IActionResult> LoginTest(ConfigurationModel model)
        {
            if (ModelState.IsValid)
            {
                /// Setting Test
                var settingTest = new SettingModel() { UrlService = model.UrlService, QueryAuthenticate = model.QueryAuthenticate };

                var loginModel = new LoginModel() { Email = model.UserName, Password = model.Password };

                var authenticate = await _syncService.AuthenticateAsync(loginModel, settingTest);

                if (authenticate?.login != null
                    && authenticate.login.message == LiteralSync.SUCCESS)
                    _notificationService.SuccessNotification(LiteralSync.SUCCESS_MESSAGE);
                else
                    _notificationService.WarningNotification(LiteralSync.NOT_SUCCESS_MESSAGE);

            }
            return await Configure();
        }

        #endregion
    }
}
