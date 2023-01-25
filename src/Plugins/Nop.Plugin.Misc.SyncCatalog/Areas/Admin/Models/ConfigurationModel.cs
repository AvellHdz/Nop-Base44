using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Plugin.Misc.SyncCatalog.Areas.Admin.Models
{
    public class ConfigurationModel
    {

        /// <summary>
        /// Url Service
        /// </summary>
        [NopResourceDisplayName(Default.RESOURCE_URL_SERVICES)]
        public string UrlService { get; set; }

        /// <summary>
        /// User Name
        /// </summary>
        [NopResourceDisplayName(Default.RESOURCE_USER_NAME)]
        public string UserName { get; set; }

        /// <summary>
        /// Password
        /// </summary>
        
        [NopResourceDisplayName(Default.RESOURCE_PASSWORD)]
        public string Password { get; set; }

        /// <summary>
        /// Store Id
        /// </summary>
        [NopResourceDisplayName(Default.RESOURCE_STORE_ID)]
        public int StoreId { get; set; }

        /// <summary>
        /// Query autjenticate Sync Services
        /// </summary>
        [NopResourceDisplayName(Default.RESOURCE_QUERY_AUTHENTICATE)]
        public string QueryAuthenticate { get; set; }

        /// <summary>
        /// Query Revenew Catalog - Sync Services
        /// </summary>
        [NopResourceDisplayName(Default.RESOURCE_QUERY_REVENEW_CATALOG)]
        public string QueryRevenewCatalog { get; set; }

        /// <summary>
        /// Query Category Catalog - Sync Services
        /// </summary>
        [NopResourceDisplayName(Default.RESOURCE_QUERY_CATEGORY_CATALOG)]
        public string QueryCategoryCatalog { get; set; }


        /// <summary>
        /// Query Brand Catalog - Sync Services
        /// </summary>
        [NopResourceDisplayName(Default.RESOURCE_QUERY_BRAND_CATALOG)]
        public string QueryBrandCatalog { get; set; }

        /// <summary>
        /// Query Revenew Store Catalog - Sync Services
        /// </summary>
        [NopResourceDisplayName(Default.RESOURCE_QUERY_REVENEW_STORE_CATALOG)]
        public string QueryRevenewStoreCatalog { get; set; }

        /// <summary>
        /// Query Revenew Store Mapping Catalog - Sync Services
        /// </summary>
        [NopResourceDisplayName(Default.RESOURCE_QUERY_REVENEW_STORE_MAPPING_CATALOG)]
        public string QueryRevenewStoreMappingCatalog { get; set; }

        /// <summary>
        /// Mutation Revenew Store Mapping Catalog - Sync Services
        /// </summary>
        [NopResourceDisplayName(Default.RESOURCE_MUTATION_CREATE_REVENEW_STORE_MAPPING_CATALOG)]
        public string MutationCreateRevenewStoreMappingCatalog { get; set; }
        
        /// <summary>
        /// Mutation Revenew Store Mapping Catalog - Sync Services
        /// </summary>
        [NopResourceDisplayName(Default.RESOURCE_MUTATION_UPDATE_REVENEW_STORE_MAPPING_CATALOG)]
        public string MutationUpdateRevenewStoreMappingCatalog { get; set; }
        
        /// <summary>
        /// Mutation Revenew Store Mapping Catalog - Sync Services
        /// </summary>
        [NopResourceDisplayName(Default.RESOURCE_MUTATION_DELETE_REVENEW_STORE_MAPPING_CATALOG)]
        public string MutationDeleteRevenewStoreMappingCatalog { get; set; }

        /// <summary>
        /// Query Product Store Mapping Catalog - Sync Services
        /// </summary>
        [NopResourceDisplayName(Default.RESOURCE_QUERY_PRODUCT_STORE_MAPPING_CATALOG)]
        public string QueryProductStoreMappingCatalog { get; set; }

        /// <summary>
        /// Mutation Product Store Mapping Catalog - Sync Services
        /// </summary>
        [NopResourceDisplayName(Default.RESOURCE_MUTATION_CREATE_PRODUCT_STORE_MAPPING_CATALOG)]
        public string MutationCreateProductStoreMappingCatalog { get; set; }

        /// <summary>
        /// Hide General Block
        /// </summary>
        public bool HideGeneralBlock { get; set; }
    }
}
