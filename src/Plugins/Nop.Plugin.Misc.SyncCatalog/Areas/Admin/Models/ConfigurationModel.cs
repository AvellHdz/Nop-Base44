namespace Nop.Plugin.Misc.SyncCatalog.Areas.Admin.Models
{
    public class ConfigurationModel
    {

        /// <summary>
        /// Url Service
        /// </summary>
        public string UrlService { get; set; }

        /// <summary>
        /// User Name
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Password
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Store Id
        /// </summary>
        public int StoreId { get; set; }

        /// <summary>
        /// Query autjenticate Sync Services
        /// </summary>
        public string QueryAuthenticate { get; set; }

        /// <summary>
        /// Query Revenew Catalog - Sync Services
        /// </summary>
        public string QueryRevenewCatalog { get; set; }

        /// <summary>
        /// Query Category Catalog - Sync Services
        /// </summary>
        public string QueryCategoryCatalog { get; set; }


        /// <summary>
        /// Query Brand Catalog - Sync Services
        /// </summary>
        public string QueryBrandCatalog { get; set; }

        /// <summary>
        /// Query Revenew Store Catalog - Sync Services
        /// </summary>
        public string QueryRevenewStoreCatalog { get; set; }

        /// <summary>
        /// Query Revenew Store Mapping Catalog - Sync Services
        /// </summary>
        public string QueryRevenewStoreMappingCatalog { get; set; }

        /// <summary>
        /// Mutation Revenew Store Mapping Catalog - Sync Services
        /// </summary>
        public string MutationCreateRevenewStoreMappingCatalog { get; set; }

        /// <summary>
        /// Query Product Store Mapping Catalog - Sync Services
        /// </summary>
        public string QueryProductStoreMappingCatalog { get; set; }

        /// <summary>
        /// Mutation Product Store Mapping Catalog - Sync Services
        /// </summary>
        public string MutationCreateProductStoreMappingCatalog { get; set; }

        /// <summary>
        /// Hide General Block
        /// </summary>
        public bool HideGeneralBlock { get; set; }
    }
}
