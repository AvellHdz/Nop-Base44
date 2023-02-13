using System;

namespace Nop.Plugin.Misc.SyncCatalog.Areas.Admin.Models.Sync
{
    public class CategorySync
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public int CategoryTemplateId { get; set; } = default;

        public string MetaKeywords { get; set; } = string.Empty;

        public string MetaDescription { get; set; } = string.Empty;

        public string MetaTitle { get; set; } = string.Empty;

        public int ParentCategoryId { get; set; } = default;

        public int PictureId { get; set; } = default;

        public int PageSize { get; set; } = default;

        public bool AllowCustomersToSelectPageSize { get; set; }

        public string PageSizeOptions { get; set; } = string.Empty;

        public bool ShowOnHomepage { get; set; }

        public bool IncludeInTopMenu { get; set; }

        public bool SubjectToAcl { get; set; }

        public bool LimitedToStores { get; set; }

        public bool Published { get; set; }

        public bool Deleted { get; set; }


        public int DisplayOrder { get; set; } = default;

        public DateTime CreatedOnUtc { get; set; }

        public DateTime UpdatedOnUtc { get; set; }

        public bool PriceRangeFiltering { get; set; }

        public int PriceFrom { get; set; } = default;

        public int PriceTo { get; set; } = default;

        public bool ManuallyPriceRange { get; set; }

        public int Id { get; set; } = default;
    }
}
