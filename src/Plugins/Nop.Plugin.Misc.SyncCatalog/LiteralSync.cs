namespace Nop.Plugin.Misc.SyncCatalog
{
    public class LiteralSync
    {

        #region Static

        /// <summary>
        /// Request email name
        /// </summary>
        public const string SUCCESS = "Success";

        /// <summary>
        /// Request email name
        /// </summary>
        public const string SUCCESS_MESSAGE = "Prueba exitosa, configuración válida";

        /// <summary>
        /// Request Error
        /// </summary>
        public const string NOT_SUCCESS_MESSAGE = "Prueba fallida, configuración erronea";

        /// <summary>
        /// Request error catalog
        /// </summary>
        public const string NOT_SUCCESS_BRAND_CATALOG = "No se encontro catálogo de marcar para sincronizar.";
        
        /// <summary>
        /// Request error catalog
        /// </summary>
        public const string NOT_SUCCESS_REVENEW_CATALOG = "No se encontro catálogo de ganancias para sincronizar.";
        
        /// <summary>
        /// Request error catalog
        /// </summary>
        public const string NOT_SUCCESS_CATEGORY_CATALOG = "No se encontro catálogo de categoría para sincronizar.";
        
        /// <summary>
        /// Request error catalog
        /// </summary>
        public const string NOT_SUCCESS_SUB_CATEGORY_CATALOG = "No se encontro catálogo de sub categoría para sincronizar.";
        
        /// <summary>
        /// Request error catalog
        /// </summary>
        public const string NOT_SUCCESS_GROUPS_CATALOG = "No se encontro catálogo de familias para sincronizar.";

        /// <summary>
        /// Request email name
        /// </summary>
        public const string REQUEST_EMAIL_AUTH = "emailCode";

        /// <summary>
        /// Request password name
        /// </summary>
        public const string REQUEST_PASSWORD_AUTH = "passowrdCode";

        /// <summary>
        /// Request store id name
        /// </summary>
        public const string STORE_ID_CODE = "storeCode";

        /// <summary>
        /// Request revenew store mapping name
        /// </summary>
        public const string MAPPING_REVENEW_ID = "revenewStoreCode";

        /// <summary>
        /// Token store name
        /// </summary>
        public const string TOKEN_NAME = "tokenCode";

        /// <summary>
        /// Revenew Store Name
        /// </summary>
        public const string REVENEW_STORED_CODE_NAME = "revenewStoredCode";

        /// <summary>
        /// Store Id Code Name
        /// </summary>
        public const string STORE_ID_CODE_NAME = "storeIdCode";

        /// <summary>
        /// Priority Code Name
        /// </summary>
        public const string PRIORITY_CODE_NAME = "priorityCode";

        /// <summary>
        /// Revenew Type Code Name
        /// </summary>
        public const string REVENEW_TYPE_CODE_NAME = "revenewTypeCode";

        /// <summary>
        /// Revenew Mapping Catalog Code Name
        /// </summary>
        public const string REVENEW_MAPPING_CATALOG_CODE_NAME = "revenewMappingCatalogCode";

        /// <summary>
        /// Revenew Mapping Catalog Code Detail Name
        /// </summary>
        public const string REVENEW_MAPPING_CATALOG_CODE_DETAIL_NAME = "externalID: {0}, makeUp:{1}";

        /// <summary>
        /// Revenew Mapping Catalog Code Name
        /// </summary>
        public const string PRODUCT_STORES_CODE = "productStoresCode";

        #endregion

        #region Task - Get Invoices

        /// <summary>
        /// Gets a type of the synchronization schedule task
        /// </summary>
        public static string SynchronizationTask => "Nop.Plugin.Misc.SyncCatalog.Areas.Admin.Services.SynchronizationTask";

        /// <summary>
        /// Gets a default synchronization period in hours
        /// </summary>
        public static int DefaultSynchronizationPeriod => 1;

        /// <summary>
        /// Gets a name of the synchronization schedule task
        /// </summary>
        public static string SynchronizationTaskName => "Synchronization Store";

        #endregion
    }
}
