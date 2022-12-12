﻿using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Core.Domain.Configuration;
using Nop.Core.Domain.Customers;
using Nop.Plugin.Misc.SyncCatalog.Areas.Admin.Factories;
using Nop.Plugin.Misc.SyncCatalog.Areas.Admin.MiddlewareSync.Models;
using Nop.Plugin.Misc.SyncCatalog.Areas.Admin.Models;
using Nop.Plugin.Misc.SyncCatalog.Areas.Admin.Services;
using Nop.Services.Common;
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
    public class CatalogSyncController : BasePluginController
    {

        #region Field

        private readonly IPermissionService _permissionService;
        private readonly ISettingService _settingService;
        private readonly INotificationService _notificationService;
        private readonly ILocalizationService _localizationService;
        private readonly IStoreContext _storeContext;
        private readonly ISyncService _syncService;
        private readonly IGenericAttributeService _genericAttributeService;
        private readonly ISyncModelFactory _syncModelFactory;

        #endregion

        #region Ctor

        public CatalogSyncController(IPermissionService permissionService,
            ISettingService settingService,
            INotificationService notificationService,
            ILocalizationService localizationService,
            IStoreContext storeContext,
            ISyncService syncService,
            IGenericAttributeService genericAttributeService,
            ISyncModelFactory syncModelFactory)
        {
            _permissionService = permissionService;
            _settingService = settingService;
            _notificationService = notificationService;
            _localizationService = localizationService;
            _storeContext = storeContext;
            _syncService = syncService;
            _genericAttributeService = genericAttributeService;
            _syncModelFactory = syncModelFactory;
        }

        #endregion

        #region Methods

        /// <returns>A task that represents the asynchronous operation</returns>
        public virtual async Task<IActionResult> List()
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageWidgets))
                return AccessDeniedView();

            var model = await _syncModelFactory.PrepareCatalogSearchModelAsync(new());

            return View(model);

        }

        [HttpPost]
        /// <returns>A task that represents the asynchronous operation</returns>
        public virtual async Task<IActionResult> CatalogSyncList(CatalogSearchModel searchModel)
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageProducts))
                return await AccessDeniedDataTablesJson();

            //load settings for a chosen store scope
            var storeScope = await _storeContext.GetActiveStoreScopeConfigurationAsync();
            var syncSetting = await _settingService.LoadSettingAsync<SettingModel>(storeScope);

            //prepare model
            var model = await _syncModelFactory.PrepareCatalogSyncListModelAsync(searchModel, syncSetting);

            return Json(model);
        }

        /// <returns>A task that represents the asynchronous operation</returns>
        public virtual async Task<IActionResult> RevenewCreatePopup()
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageWidgets))
                return AccessDeniedView();

            //load settings for a chosen store scope
            var storeScope = await _storeContext.GetActiveStoreScopeConfigurationAsync();
            var syncSetting = await _settingService.LoadSettingAsync<SettingModel>(storeScope);

            //get filters services

            var syncs = await _syncModelFactory.PrepareCatalogSyncModelAsync(syncSetting);

            var categories = syncs.Where(l => l.RevenewName == "Categoria")
                .Select(x => x.NameType)
                .ToList();

            var bransd = syncs.Where(l => l.RevenewName == "Marca")
                .Select(x => x.NameType)
                .ToList();

            var model = await _syncModelFactory.PrepareCatalogModelAsync(filterCategories: categories, filterBrands: bransd);

            return View(model);
        }

        [HttpPost]
        [FormValueRequired("save")]
        /// <returns>A task that represents the asynchronous operation</returns>
        public virtual async Task<IActionResult> RevenewCreatePopup(CatalogModel model)
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageProducts))
                return AccessDeniedView();

            if (ModelState.IsValid)
            {
                //load settings for a chosen store scope
                var storeScope = await _storeContext.GetActiveStoreScopeConfigurationAsync();
                var syncSetting = await _settingService.LoadSettingAsync<SettingModel>(storeScope);


                //prepare available types
                var store = await _storeContext.GetCurrentStoreAsync();
                var generics = await _genericAttributeService.GetAttributesForEntityAsync(store.Id, store.GetType().Name);

                var genericsFilter = model.SelectedCategoriesIds.Any()
                    ? generics.Where(l => model.SelectedCategoriesIds.Contains(l.Id))
                        .Select(l => l.Key.Replace(Default.GenericCategoryCatalog, string.Empty))
                    : generics.Where(l => model.SelectedBrandsIds.Contains(l.Id))
                        .Select(l => l.Key.Replace(Default.GenericBrandCatalog, string.Empty));

                var mappings = genericsFilter.Select(c =>
                    new RevenewMappingCatalog() { ExternalID = c , MakeUp = model.Makeup });

                var catalog = new RevenewStoreCatalog()
                {
                    StoreId = syncSetting.StoreId,
                    RevenewTypeId = model.SelectedRevenew,
                    Priroty = model.Priority,
                    RevenewMappingCatalogs = mappings.ToList()
                };

                await _syncService.CreateStoreMappingAsync(catalog, syncSetting);

                ViewBag.RefreshPage = true;

                return View(model);
            }

            //prepare model
            model = await _syncModelFactory.PrepareCatalogModelAsync();

            //if we got this far, something failed, redisplay form
            return View(model);
        }

        /// <returns>A task that represents the asynchronous operation</returns>
        public virtual async Task<IActionResult> LiveCatalog()
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageWidgets))
                return AccessDeniedView();

            //load settings for a chosen store scope
            var storeScope = await _storeContext.GetActiveStoreScopeConfigurationAsync();
            var syncSetting = await _settingService.LoadSettingAsync<SettingModel>(storeScope);

            #region Authenticate service

            var loginModel = new LoginModel() { Email = syncSetting.UserName, Password = syncSetting.Password };

            var authenticate = await _syncService.AuthenticateAsync(loginModel, syncSetting);

            #endregion

            #region Sync Revenew Catalog

            var revenews = await _syncService.GetRevenewCatalog(authenticate.login.accessToken, syncSetting);

            if (!revenews.revenew.Any())
                _notificationService.WarningNotification(LiteralSync.NOT_SUCCESS_CATALOG);

            foreach (var revenew in revenews.revenew)
                await _genericAttributeService.SaveAttributeAsync(_storeContext.GetCurrentStore(), $"{Default.GenericRevenewCatalog}{revenew.id}", revenew.name);


            #endregion

            #region Sync Category Catalog

            var categories = await _syncService.GetCategoryCatalog(authenticate.login.accessToken, syncSetting);

            if (!categories.category.Any())
                _notificationService.WarningNotification(LiteralSync.NOT_SUCCESS_CATALOG);

            foreach (var category in categories.category)
                await _genericAttributeService.SaveAttributeAsync(_storeContext.GetCurrentStore(), $"{Default.GenericCategoryCatalog}{category.externalId}", category.name);

            #endregion


            #region Sync Brand Catalog

            var brands = await _syncService.GetBransCatalog(authenticate.login.accessToken, syncSetting);

            if (!brands.brandsCatalog.Any())
                _notificationService.WarningNotification(LiteralSync.NOT_SUCCESS_CATALOG);

            foreach (var brand in brands.brandsCatalog)
                await _genericAttributeService.SaveAttributeAsync(_storeContext.GetCurrentStore(), $"{Default.GenericBrandCatalog}{brand.externalId}", brand.name);

            #endregion

            _notificationService.SuccessNotification("Sincronización Exitosa");

            return await List();
        }

        #endregion
    }
}