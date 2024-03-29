﻿using Nop.Core.Configuration;

namespace Nop.Plugin.Misc.SyncCatalog.Areas.Admin.Models
{
    public class SettingModel : ISettings
    {
        public string UrlService { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int StoreId { get; set; }

        #region Services Query
        
        /// <summary>
        /// Query authenticate - Sync Services
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
        /// Query Category Catalog - Sync Services
        /// </summary>
        public string QuerySubCategoryCatalog { get; set; }
        
        /// <summary>
        /// Query Groups Catalog - Sync Services
        /// </summary>
        public string QueryGroupsCatalog { get; set; }


        /// <summary>
        /// Query Brand Catalog - Sync Services
        /// </summary>
        public string QueryBrandCatalog { get; set; }

        /// <summary>
        /// Query Revenew Store Catalog - Sync Services
        /// </summary>
        public string QueryRevenewStoreCatalog { get; set; } 
        
        /// <summary>
        /// Query Catalog Store Sync Services
        /// </summary>
        public string QueryCatalogStore { get; set; }

        /// <summary>
        /// Query Revenew Store Mapping Catalog - Sync Services
        /// </summary>
        public string QueryRevenewStoreMappingCatalog { get; set; }

        /// <summary>
        /// Mutation Revenew Store Mapping Catalog - Sync Services
        /// </summary>
        public string MutationCreateRevenewStoreMappingCatalog { get; set; }
        
        /// <summary>
        /// Mutation Revenew Store Mapping Catalog - Sync Services
        /// </summary>
        public string MutationUpdateRevenewStoreMappingCatalog { get; set; }

        /// <summary>
        /// Mutation Revenew Store Mapping Catalog - Sync Services
        /// </summary>
        public string MutationDeleteRevenewStoreMappingCatalog { get; set; }

        /// <summary>
        /// Query Product Store Mapping Catalog - Sync Services
        /// </summary>
        public string QueryProductStoreMappingCatalog { get; set; }

        /// <summary>
        /// Mutation Product Store Mapping Catalog - Sync Services
        /// </summary>
        public string MutationCreateProductStoreMappingCatalog { get; set; }

        #endregion
    }
}
