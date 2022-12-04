﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nop.Core;
using Nop.Services.Common;
using Nop.Services.Localization;

namespace Nop.Plugin.Misc.SyncCatalog.Areas.Admin.Factories
{
    public class BasePluginAdminModelFactory : IBasePluginAdminModelFactory
    {
        #region Field

        private readonly ILocalizationService _localizationService;
        private readonly IGenericAttributeService _genericAttributeService;
        private readonly IStoreContext _storeContext;

        #endregion

        #region Ctor

        public BasePluginAdminModelFactory(ILocalizationService localizationService,
            IGenericAttributeService genericAttributeService,
            IStoreContext storeContext)
        {
            _localizationService = localizationService;
            _genericAttributeService = genericAttributeService;
            _storeContext = storeContext;
        }

        #endregion

        #region Utilities

        /// <summary>
        /// Prepare default item
        /// </summary>
        /// <param name="items">Available items</param>
        /// <param name="withSpecialDefaultItem">Whether to insert the first special item for the default value</param>
        /// <param name="defaultItemText">Default item text; pass null to use "All" text</param>
        /// <param name="defaultItemValue">Default item value; defaults 0</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        protected virtual async Task PrepareDefaultItemAsync(IList<SelectListItem> items, bool withSpecialDefaultItem, string defaultItemText = null, string defaultItemValue = "0")
        {
            if (items == null)
                throw new ArgumentNullException(nameof(items));

            //whether to insert the first special item for the default value
            if (!withSpecialDefaultItem)
                return;

            //prepare item text
            defaultItemText ??= await _localizationService.GetResourceAsync("Admin.Common.All");

            //insert this default item at first
            items.Insert(0, new SelectListItem { Text = defaultItemText, Value = defaultItemValue });
        }

        #endregion

        #region Methods

        /// <summary>
        /// Prepare revenew types
        /// </summary>
        /// <param name="items">Activity log type items</param>
        /// <param name="withSpecialDefaultItem">Whether to insert the first special item for the default value</param>
        /// <param name="defaultItemText">Default item text; pass null to use default value of the default item text</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public virtual async Task PrepareRevenewTypesAsync(IList<SelectListItem> items, bool withSpecialDefaultItem = true, string defaultItemText = null, List<string> filterValues = default)
        {
            if (items == null)
                throw new ArgumentNullException(nameof(items));

            filterValues ??= new List<string>();

            //prepare available types
            var store = await _storeContext.GetCurrentStoreAsync();
            var generics = await _genericAttributeService.GetAttributesForEntityAsync(store.Id, store.GetType().Name);

            var availableTypes = generics.Where(l => l.Key.Contains(Default.GenericRevenewCatalog));

            foreach (var revenewType in availableTypes)
            {
                var value = revenewType.Key.Replace(Default.GenericRevenewCatalog, string.Empty);

                if (!filterValues.Contains(revenewType.Value))
                    items.Add(new SelectListItem { Value = revenewType.Key.Replace(Default.GenericRevenewCatalog, string.Empty), Text = revenewType.Value });
            }

            //insert special item for the default value
            await PrepareDefaultItemAsync(items, withSpecialDefaultItem, defaultItemText);
        }

        /// <summary>
        /// Prepare categories types
        /// </summary>
        /// <param name="items">Activity log type items</param>
        /// <param name="withSpecialDefaultItem">Whether to insert the first special item for the default value</param>
        /// <param name="defaultItemText">Default item text; pass null to use default value of the default item text</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public virtual async Task PrepareCategoriesTypesAsync(IList<SelectListItem> items, bool withSpecialDefaultItem = true, string defaultItemText = null, List<string> filterValues = default)
        {
            if (items == null)
                throw new ArgumentNullException(nameof(items));

            filterValues ??= new List<string>();

            //prepare available types
            var store = await _storeContext.GetCurrentStoreAsync();
            var generics = await _genericAttributeService.GetAttributesForEntityAsync(store.Id, store.GetType().Name);

            var availableTypes = generics.Where(l => l.Key.Contains(Default.GenericCategoryCatalog));

            foreach (var category in availableTypes)
            {
                var value = category.Key.Replace(Default.GenericRevenewCatalog, string.Empty);

                if (!filterValues.Contains(category.Value))
                    items.Add(new SelectListItem { Value = value, Text = category.Value });
            }

            //insert special item for the default value
            await PrepareDefaultItemAsync(items, withSpecialDefaultItem, defaultItemText);
        }

        /// <summary>
        /// Prepare brand types
        /// </summary>
        /// <param name="items">Activity log type items</param>
        /// <param name="withSpecialDefaultItem">Whether to insert the first special item for the default value</param>
        /// <param name="defaultItemText">Default item text; pass null to use default value of the default item text</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public virtual async Task PrepareBrandTypesAsync(IList<SelectListItem> items, bool withSpecialDefaultItem = true, string defaultItemText = null, List<string> filterValues = default)
        {
            if (items == null)
                throw new ArgumentNullException(nameof(items));

            filterValues ??= new List<string>();

            //prepare available types
            var store = await _storeContext.GetCurrentStoreAsync();
            var generics = await _genericAttributeService.GetAttributesForEntityAsync(store.Id, store.GetType().Name);

            var availableTypes = generics.Where(l => l.Key.Contains(Default.GenericBrandCatalog));

            foreach (var brand in availableTypes)
            {
                var value = brand.Key.Replace(Default.GenericRevenewCatalog, string.Empty);

                if (!filterValues.Contains(brand.Value))
                    items.Add(new SelectListItem { Value = value, Text = brand.Value });
            }

            //insert special item for the default value
            await PrepareDefaultItemAsync(items, withSpecialDefaultItem, defaultItemText);
        }

        #endregion
    }
}
