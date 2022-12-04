using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Web.Framework.Models;

namespace Nop.Plugin.Misc.SyncCatalog.Areas.Admin.Models
{
    /// <summary>
    /// Represents a tier price list model
    /// </summary>
    public partial record CatalogListModel : BasePagedListModel<CatalogModel>
    {

    }

}
