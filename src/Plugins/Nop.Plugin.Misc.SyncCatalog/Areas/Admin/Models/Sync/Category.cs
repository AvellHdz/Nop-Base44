using System;
using Newtonsoft.Json;

namespace Nop.Plugin.Misc.SyncCatalog.Areas.Admin.Models.Sync
{
    public class Category
    {
        public string Name { get; set; }
        public string Description { get; set; }

        [JsonProperty("category_template_id")]
        public int CategoryTemplateId { get; set; } = 0;

        [JsonProperty("meta_keywords")]
        public string MetaKeywords { get; set; }

        [JsonProperty("meta_description")]
        public string MetaDescription { get; set; }

        [JsonProperty("meta_title")]
        public string MetaTitle { get; set; }

        [JsonProperty("parent_category_id")]
        public int ParentCategoryId { get; set; } = 0;

        [JsonProperty("picture_id")]
        public int PictureId { get; set; } = 0;

        [JsonProperty("page_size")]
        public int PageSize { get; set; } = 0;

        [JsonProperty("allow_customers_to_select_page_size")]
        public bool AllowCustomersToSelectPageSize { get; set; }

        [JsonProperty("page_size_options")]
        public string PageSizeOptions { get; set; }

        [JsonProperty("show_on_homepage")]
        public bool ShowOnHomepage { get; set; } = false;

        [JsonProperty("include_in_top_menu")]
        public bool IncludeInTopMenu { get; set; } = false;

        [JsonProperty("subject_to_acl")]
        public bool SubjectToAcl { get; set; } = true;

        [JsonProperty("limited_to_stores")]
        public bool LimitedToStores { get; set; } = false;

        public bool Published { get; set; } = true;

        public bool Deleted { get; set; } = false;

        [JsonProperty("display_order")]
        public int DisplayOrder { get; set; } = 0;

        [JsonProperty("created_on_utc")]
        public DateTime CreatedOnUtc { get; set; } = DateTime.UtcNow;

        [JsonProperty("updated_on_utc")]
        public DateTime UpdatedOnUtc { get; set; } = DateTime.UtcNow;

        [JsonProperty("price_range_filtering")]
        public bool PriceRangeFiltering { get; set; } = true;

        [JsonProperty("price_from")]
        public int PriceFrom { get; set; } = 0;

        [JsonProperty("price_to")]
        public int PriceTo { get; set; } = 0;

        [JsonProperty("manually_price_range")]
        public bool ManuallyPriceRange { get; set; }

        public int Id { get; set; } = 0;
    }
}
