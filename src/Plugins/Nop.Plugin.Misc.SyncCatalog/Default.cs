namespace Nop.Plugin.Misc.SyncCatalog
{
    public static class Default
    {
        #region Locale String Resource

        public const string RESOURCE_PREFIX = "Plugin.Misc.SyncCatalog";

        #endregion

        #region Configure 

        /// <summary>
        /// Generic attribute name to hide general settings block on the plugin configuration page
        /// </summary>
        public static string HideGeneralBlock = "SyncCatalogPage.HideGeneralBlock";

        #endregion

        #region Permission Record

        /// <summary>
        /// Manager Name
        /// </summary>
        public static string PermissionManagerName = "Admin area. Manage Catalog Sync Access";

        /// <summary>
        /// Manager Name
        /// </summary>
        public static string PermissionManagerSystmeName = "CatalogSync";

        /// <summary>
        /// Manager Name
        /// </summary>
        public static string PermissionManagerCategoryName = "SettingSync";

        #endregion

        #region Menu site

        /// <summary>
        /// System Name
        /// </summary>
        public static string PluginSystemName = "SyncCatalog";

        /// <summary>
        /// Sync Settring
        /// </summary>

        public static string SystemNameMenuSetting = "SyncSettring";


        /// <summary>
        /// Sync Settring
        /// </summary>
        public static string SystemNameMenuCatalog = "SyncCatalog";

        /// <summary>
        /// Sync Settring
        /// </summary>
        public static string SystemNameMenuCatalogProduct = "SyncCatalogProduct";

        /// <summary>
        /// Menu Admin Name
        /// </summary>

        public static string PluginMenuTitle = "Plugin.Misc.SyncCatalog.Sync.Menu.Title";

        /// <summary>
        /// Menu Admin Name
        /// </summary>

        public static string PluginSettingTitle = "Plugin.Misc.SyncCatalog.Sync.Setting.SubMenu.Title";


        /// <summary>
        /// Menu Admin Name
        /// </summary>

        public static string PluginCatalogTitle = "Plugin.Misc.SyncCatalog.Sync.Catalog.SubMenu.Title";

        #endregion

        #region Resources List

        /// <summary>
        /// Url Services
        /// </summary>
        public const string RESOURCE_URL_SERVICES = "Plugin.Misc.SyncCatalog.Admin.Common.Sync.UrlService";

        /// <summary>
        /// User Name
        /// </summary>
        public const string RESOURCE_USER_NAME = "Plugin.Misc.SyncCatalog.Admin.Common.Sync.UserName";

        /// <summary>
        /// Password
        /// </summary>
        public const string RESOURCE_PASSWORD = "Plugin.Misc.SyncCatalog.Admin.Common.Sync.Password";

        /// <summary>
        /// Password
        /// </summary>
        public const string RESOURCE_STORE_ID = "Plugin.Misc.SyncCatalog.Admin.Common.Sync.StoreId";

        /// <summary>
        /// Query Authenticate
        /// </summary>
        public const string RESOURCE_QUERY_AUTHENTICATE = "Plugin.Misc.SyncCatalog.Admin.Common.Sync.QueryAuthenticate";

        /// <summary>
        /// Query Authenticate
        /// </summary>
        public const string RESOURCE_QUERY_REVENEW_CATALOG = "Plugin.Misc.SyncCatalog.Admin.Common.Sync.QueryRevenewCatalog";

        /// <summary>
        /// Query Revenew Catalog
        /// </summary>
        public const string RESOURCE_QUERY_CATEGORY_CATALOG = "Plugin.Misc.SyncCatalog.Admin.Common.Sync.QueryCategoryCatalog";

        /// <summary>
        /// Query Brand Catalog
        /// </summary>
        public const string RESOURCE_QUERY_BRAND_CATALOG = "Plugin.Misc.SyncCatalog.Admin.Common.Sync.QueryBrandCatalog";

        /// <summary>
        /// Query Revenew Store Catalog
        /// </summary>
        public const string RESOURCE_QUERY_REVENEW_STORE_CATALOG = "Plugin.Misc.SyncCatalog.Admin.Common.Sync.QueryRevenewStoreCatalog";

        /// <summary>
        /// Query Revenew Store Mapping Catalog
        /// </summary>
        public const string RESOURCE_QUERY_REVENEW_STORE_MAPPING_CATALOG = "Plugin.Misc.SyncCatalog.Admin.Common.Sync.QueryRevenewStoreMappingCatalog";

        /// <summary>
        /// Mutation Create Revenew Store Mapping Catalog
        /// </summary>
        public const string RESOURCE_MUTATION_CREATE_REVENEW_STORE_MAPPING_CATALOG = "Plugin.Misc.SyncCatalog.Admin.Common.Sync.MutationCreateRevenewStoreMappingCatalog";

        /// <summary>
        /// Query Product Store Mapping Catalog
        /// </summary>
        public const string RESOURCE_QUERY_PRODUCT_STORE_MAPPING_CATALOG = "Plugin.Misc.SyncCatalog.Admin.Common.Sync.QueryProductStoreMappingCatalog";

        /// <summary>
        /// Mutation Create Product Store Mapping Catalog
        /// </summary>
        public const string RESOURCE_MUTATION_CREATE_PRODUCT_STORE_MAPPING_CATALOG = "Plugin.Misc.SyncCatalog.Admin.Common.Sync.MutationCreateProductStoreMappingCatalog";

        /// <summary>
        /// Botton test name
        /// </summary>

        public const string RESOURCE_BOTTON_TEST = "Plugin.Misc.SyncCatalog.Admin.Common.Sync.Login.Test";

        /// <summary>
        /// Botton test name
        /// </summary>
        public const string URL_SERVICE_REQUIRED = "Plugin.Misc.SyncCatalog.Admin.Sync.Fields.UrlService.Required";

        /// <summary>
        /// Botton test name
        /// </summary>
        public const string USER_NAME_SERVICE_REQUIRED = "Plugin.Misc.SyncCatalog.Admin.Sync.Fields.UserName.Required";

        /// <summary>
        /// Botton test name
        /// </summary>
        public const string PASSWORD_SERVICE_REQUIRED = "Plugin.Misc.SyncCatalog.Admin.Sync.Fields.Password.Required";

        /// <summary>
        /// Botton test name
        /// </summary>
        public const string CATALOG_LIVE = "Plugin.Misc.SyncCatalog.Admin.Sync.Catalog";

        /// <summary>
        /// Botton test name
        /// </summary>
        public const string CATALOG_REVENEW = "Plugin.Misc.SyncCatalog.Admin.Sync.Catalog.Revenew";

        /// <summary>
        /// Identifier name column
        /// </summary>
        public const string REVENEW_IDENTIFIER = "Plugin.Misc.SyncCatalog.Admin.Sync.Catalog.Revenew.Filed.RevenewId";

        /// <summary>
        /// Name revenew column
        /// </summary>
        public const string REVENEW_NAME = "Plugin.Misc.SyncCatalog.Admin.Sync.Catalog.Revenew.Filed.Name";

        /// <summary>
        /// Priority name column
        /// </summary>
        public const string REVENEW_PRIORITY = "Plugin.Misc.SyncCatalog.Admin.Sync.Catalog.Revenew.Filed.Priority";

        /// <summary>
        /// NAme Property name column
        /// </summary>
        public const string NAME_PROPERTY_TYPE = "Plugin.Misc.SyncCatalog.Admin.Sync.Catalog.Revenew.Filed.NameType";

        /// <summary>
        /// Makeup Property name column
        /// </summary>
        public const string MAKEUP_NAME = "Plugin.Misc.SyncCatalog.Admin.Sync.Catalog.Revenew.Filed.Makeup";


        /// <summary>
        /// Identifier name column
        /// </summary>
        public const string IDENTIFIER_PRODUCT_MAPPING = "Plugin.Misc.SyncCatalog.Admin.Sync.Catalog.Product.Filed.IdMapping";

        /// <summary>
        /// Identifier name column
        /// </summary>
        public const string NAME_PRODUCT_MAPPING = "Plugin.Misc.SyncCatalog.Admin.Sync.Catalog.Product.Filed.Name";

        /// <summary>
        /// Identifier name column
        /// </summary>
        public const string EXTERNAL_PRODUCT_MAPPING = "Plugin.Misc.SyncCatalog.Admin.Sync.Catalog.Product.Filed.External";


        /// <summary>
        /// Menu Admin Name
        /// </summary>

        public static string PluginCatalogProductTitle = "Plugin.Misc.SyncCatalog.Sync.Catalog.Product.SubMenu.Title";

        /// <summary>
        /// Menu Admin Name
        /// </summary>
        public const string TITLE_ADD_NEW_PRODUCT_MAPPGIN = "Plugin.Misc.SyncCatalog.Admin.Catalog.Products.Sync.AddNew";

        /// <summary>
        /// Menu Admin Name
        /// </summary>
        public const string TITLE_ADD_NEW_REVENEW_MAPPGIN = "Plugin.Misc.SyncCatalog.Admin.Catalog.Revenew.Sync.AddNew";

        #endregion

        #region Generic Attribute

        /// <summary>
        /// Revenew catalog generic name
        /// </summary>
        public static string GenericRevenewCatalog = "RevenewSyncCatalog-";

        /// <summary>
        /// Catalog catalog generic name
        /// </summary>
        public static string GenericCategoryCatalog = "CategorySyncCatalog-";

        /// <summary>
        /// Catalog catalog generic name
        /// </summary>
        public static string GenericBrandCatalog = "BrandSyncCatalog-";

        #endregion

        #region Setting Default

        /// <summary>
        /// Query Login
        /// </summary>
        public static string DefaultSettingQueryAuthenticate = "mutation{login(loginInput: { email:" + '"' + "emailCode " + '"' + ", passowrd: " + '"' + "passowrdCode" + '"' + " }) { message, accessToken, refreshToken }}";

        /// <summary>
        /// Revenew Catalog
        /// </summary>
        public static string DefaultSettingQueryRevenewCatalog = "query{revenew{id,name}}";

        /// <summary>
        /// Category Catelog
        /// </summary>
        public static string DefaultSettingQueryCategoryCatalog = "query{category(token: " + '"' + "tokenCode" + '"' + "){externalId,name,distributorId}}";

        /// <summary>
        /// Brand Category
        /// </summary>
        public static string DefaultSettingQueryBrandCatalog = "query{brandsCatalog(token: " + '"' + "tokenCode" + '"' + "){name,externalId,distributorId}}";

        /// <summary>
        /// Revenew Store Catalog
        /// </summary>
        public static string DefaultSettingQueryRevenewStoreCatalog = "query{revenewStore(storeId: storeCode){storeId,revenewId,priority,type}}";

        /// <summary>
        /// Revenew Store Mapping
        /// </summary>
        public static string DefaultSettingQueryRevenewStoreMappingCatalog = "query{revenewStoreMapping(revenewStoreId:[revenewStoreCode]){revenewStoreId,externalId,makeup,active}}";

        /// <summary>
        /// Product Store Mapping
        /// </summary>
        public static string DefaultSettingQueryProductStoreMappingCatalog = "query{productStore(storeId: storeCode){id,storeId,productId}}";

        /// <summary>
        /// Create Revenew Store Mapping
        /// </summary>
        public static string DefaultSettingMutationCreateRevenewStoreMappingCatalog = "mutation{createRevenewStoreMapping(revenewCreate:{revenewStored:revenewStoredCode,storeId:storeIdCode,revenewTypeId:revenewTypeCode,priroty:priorityCode,revenewMappingCatalogs:[revenewMappingCatalogCode]})}";

        /// <summary>
        /// Create Product Store Mapping
        /// </summary>
        public static string DefaultSettingMutationCreateProductStoreMappingCatalog = "mutation{createProductMappingStore(productStores:[{id:1,storeId:1,productId:1}])}";

        #endregion
    }
}
