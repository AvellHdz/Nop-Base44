using System.Collections.Generic;
using Nop.Plugin.Misc.SyncCatalog.Areas.Admin.Models.Sync;

namespace Nop.Plugin.Misc.SyncCatalog.Areas.Admin.Models
{

    public class StoreCatalogSync
    {
        public Storecatalog storeCatalog { get; set; }
    }

    public class Storecatalog
    {
        public CategoryStore[] categories { get; set; }
        public SubCategoryStore[] subcategories { get; set; }      
        
        public Brands[] brands { get; set; }

        public ProductStore[] products { get; set; }
    }

    public class CategoryStore
    {
        public string name { get; set; }
        public string description { get; set; }
    }

    public class SubCategoryStore
    {
        public string name { get; set; }
        public string description { get; set; }
    }

    public class ProductStore
    {
        public string name { get; set; }
        public string short_description { get; set; }
        public string full_description { get; set; }
        public string gtin { get; set; }
        public decimal price { get; set; }
        public decimal product_cost { get; set; }
        public int vendor_id { get; set; } = default;
        public string user_agreement_text { get; set; }
    }   
    
    public class Brands
    {
        public string name { get; set; }

    }
}
