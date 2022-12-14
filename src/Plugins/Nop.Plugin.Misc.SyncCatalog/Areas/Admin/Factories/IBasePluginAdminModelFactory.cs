using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Nop.Plugin.Misc.SyncCatalog.Areas.Admin.Factories
{
    public interface IBasePluginAdminModelFactory
    {

        /// <summary>
        /// Prepare revenew types
        /// </summary>
        /// <param name="items">Activity log type items</param>
        /// <param name="withSpecialDefaultItem">Whether to insert the first special item for the default value</param>
        /// <param name="defaultItemText">Default item text; pass null to use default value of the default item text</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task PrepareRevenewTypesAsync(IList<SelectListItem> items, bool withSpecialDefaultItem = true, string defaultItemText = null, List<string> filterValues = default);


        /// <summary>
        /// Prepare categories types
        /// </summary>
        /// <param name="items">Activity log type items</param>
        /// <param name="withSpecialDefaultItem">Whether to insert the first special item for the default value</param>
        /// <param name="defaultItemText">Default item text; pass null to use default value of the default item text</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task PrepareCategoriesTypesAsync(IList<SelectListItem> items, bool withSpecialDefaultItem = true, string defaultItemText = null, List<string> filterValues = default);

        /// <summary>
        /// Prepare brand types
        /// </summary>
        /// <param name="items">Activity log type items</param>
        /// <param name="withSpecialDefaultItem">Whether to insert the first special item for the default value</param>
        /// <param name="defaultItemText">Default item text; pass null to use default value of the default item text</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task PrepareBrandTypesAsync(IList<SelectListItem> items, bool withSpecialDefaultItem = true, string defaultItemText = null, List<string> filterValues = default);

        /// <summary>
        /// Prepare product types
        /// </summary>
        /// <param name="items">Activity log type items</param>
        /// <param name="withSpecialDefaultItem">Whether to insert the first special item for the default value</param>
        /// <param name="defaultItemText">Default item text; pass null to use default value of the default item text</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        Task PrepareProductsAsync(IList<SelectListItem> items, bool withSpecialDefaultItem = true, string defaultItemText = null, List<int> filterValues = default);
    }
}
