using System.Linq;
using System.Threading.Tasks;
using Nop.Core;
using Nop.Core.Domain.Catalog;
using Nop.Plugin.Misc.SyncCatalog.Areas.Admin.Models;
using Nop.Services.Catalog;
using Nop.Services.Configuration;

namespace Nop.Plugin.Misc.SyncCatalog.Areas.Admin.Services
{
    public class SynchronizationManager
    {
        #region Field

        private readonly ISyncService _syncService;
        private readonly IStoreContext _storeContext;
        private readonly ISettingService _settingService;
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;

        #endregion

        #region Ctor

        public SynchronizationManager(ISyncService syncService,
            IStoreContext storeContext,
            ISettingService settingService, 
            ICategoryService categoryService,
            IProductService productService)
        {
            _syncService = syncService;
            _storeContext = storeContext;
            _settingService = settingService;
            _categoryService = categoryService;
            _productService = productService;
        }

        #endregion

        #region Synchronization

        /// <summary>
        /// Task Sync
        /// </summary>
        /// <returns></returns>
        public async Task SynchronizeAsync()
        {
            //load settings for a chosen store scope
            var storeScope = await _storeContext.GetActiveStoreScopeConfigurationAsync();
            var syncSetting = await _settingService.LoadSettingAsync<SettingModel>(storeScope);

            var model = await _syncService.GetStoreCatalog(syncSetting);

            foreach(var category in model.Categories)
            {
                var record = await _categoryService.GetAllCategoriesAsync();

                if(!record.Any(x=> x.Name == category.Name))
                {
                    var catalog = new Category()
                    {
                        Name = category.Name,
                        Description = category.Description
                    };

                    await _categoryService.InsertCategoryAsync(catalog);
                }
            }

            foreach (var product in model.Products)
            {
                var record = (await _productService.SearchProductsAsync())
                    .Select(c=> c);

                if (!record.Any(x => x.Name == product.name))
                {
                    var catalog = new Product()
                    {
                        Name = product.name,
                        ShortDescription = product.short_description,
                        FullDescription = product.full_description,
                        Gtin = product.gtin,
                        Price = product.price,
                        ProductCost = product.product_cost
                    };

                    await _productService.InsertProductAsync(catalog);
                }
                else
                {
                    var sync = record.FirstOrDefault(c=> c.Name == product.name);

                    sync.Price = product.price;
                    sync.ProductCost = product.product_cost;

                    await _productService.UpdateProductAsync(sync);

                }
            }
        }

        #endregion
    }
}
