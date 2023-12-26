using System.Linq;
using System.Threading.Tasks;
using Nop.Core;
using Nop.Core.Domain.Catalog;
using Nop.Plugin.Misc.SyncCatalog.Areas.Admin.MiddlewareSync.Models;
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
        private readonly IManufacturerService _manufacturerService;

        #endregion

        #region Ctor

        public SynchronizationManager(ISyncService syncService,
            IStoreContext storeContext,
            ISettingService settingService,
            ICategoryService categoryService,
            IProductService productService,
            IManufacturerService manufacturerService)
        {
            _syncService = syncService;
            _storeContext = storeContext;
            _settingService = settingService;
            _categoryService = categoryService;
            _productService = productService;
            _manufacturerService = manufacturerService;
        }

        #endregion

        #region Utilities

        /// <summary>
        /// Save product relationship by category record
        /// </summary>
        /// <param name="product"></param>
        /// <param name="external"></param>
        /// <returns></returns>
        private async Task CategoryMappingAsync(Product product, ProductStore external)
        {
            #region Save category relationship 

            var categories = await _categoryService.GetAllCategoriesAsync(showHidden: true);

            var category = categories.FirstOrDefault(l => l.Name == external.user_agreement_text);

            var mappping = await _categoryService.GetProductCategoryIdsAsync(new[] { product.Id });

            if (mappping is null)
                await _categoryService.InsertProductCategoryAsync(new()
                {
                    CategoryId = category.Id,
                    ProductId = product.Id,
                });

            #endregion
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

            #region Authenticate service

            var loginModel = new LoginModel() { Email = syncSetting.UserName, Password = syncSetting.Password };

            var authenticate = await _syncService.AuthenticateAsync(loginModel, syncSetting);

            #endregion 

            var model = await _syncService.GetStoreCatalog(setting: syncSetting, token: authenticate.login.accessToken) ?? new();

            foreach (var category in model.storeCatalog.categories)
            {
                var record = await _categoryService.GetAllCategoriesAsync(showHidden: true);

                if (!record.Any(x => x.Name == category.name))
                {
                    var catalog = new Core.Domain.Catalog.Category()
                    {
                        Name = category.name,
                        Description = category.description
                    };

                    await _categoryService.InsertCategoryAsync(catalog);
                }
            }

            foreach (var subcategory in model.storeCatalog.subcategories)
            {
                var record = await _categoryService.GetAllCategoriesAsync(showHidden: true);

                if (!record.Any(x => x.Name == subcategory.name))
                {
                    var parent = record.FirstOrDefault(l => l.Name == subcategory.description);

                    var catalog = new Core.Domain.Catalog.Category()
                    {
                        Name = subcategory.name,
                        ParentCategoryId = parent.Id
                    };

                    await _categoryService.InsertCategoryAsync(catalog);
                }
            }

            foreach (var manufacture in model.storeCatalog.brands)
            {
                var record = await _manufacturerService.GetAllManufacturersAsync(showHidden: true);

                if (!record.Any(x => x.Name == manufacture.name))
                {

                    var catalog = new Manufacturer()
                    {
                        Name = manufacture.name,
                    };

                    await _manufacturerService.InsertManufacturerAsync(catalog);
                }
            }

            foreach (var product in model.storeCatalog.products)
            {
                var record = await _productService.SearchProductsAsync(showHidden: true, storeId: storeScope);

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

                    await CategoryMappingAsync(catalog, product);

                }
                else
                {
                    var sync = record.FirstOrDefault(c => c.Name == product.name);

                    sync.Price = product.price;
                    sync.ProductCost = product.product_cost;

                    await _productService.UpdateProductAsync(sync);

                    await CategoryMappingAsync(sync,product);
                }

            }

        }

        #endregion
    }
}
