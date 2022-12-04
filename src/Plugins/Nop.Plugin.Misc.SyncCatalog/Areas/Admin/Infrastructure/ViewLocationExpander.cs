using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Razor;
using Nop.Core.Infrastructure;
using Nop.Web.Framework.Themes;
using Nop.Web.Framework;

namespace Nop.Plugin.Misc.SyncCatalog.Areas.Admin.Infrastructure
{
    public class ViewLocationExpander : IViewLocationExpander
    {
        private const string THEME_KEY = "nop.themename";

        /// <summary>
        /// Invoked by a Microsoft.AspNetCore.Mvc.Razor.RazorViewEngine to determine the
        /// values that would be consumed by this instance of Microsoft.AspNetCore.Mvc.Razor.IViewLocationExpander.
        /// The calculated values are used to determine if the view location has changed since the last time it was located.
        /// </summary>
        /// <param name="context">Context</param>
        public void PopulateValues(ViewLocationExpanderContext context)
        {
            //no need to add the themeable view locations at all as the administration should not be themeable anyway
            if (context.AreaName?.Equals(AreaNames.Admin) ?? false)
                return;

            context.Values[THEME_KEY] = EngineContext.Current.Resolve<IThemeContext>().GetWorkingThemeNameAsync().Result;
        }

        /// <summary>
        /// Invoked by a Microsoft.AspNetCore.Mvc.Razor.RazorViewEngine to determine potential locations for a view.
        /// </summary>
        /// <param name="context">Context</param>
        /// <param name="viewLocations">View locations</param>
        /// <returns>iew locations</returns>
        public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
        {
            viewLocations = new[] {
                    $"/Plugins/Misc.SyncCatalog/Areas/Admin/Views/{context.ControllerName}/{context.ViewName}.cshtml"
                }.Concat(viewLocations);

            return viewLocations;
        }
    }
}
