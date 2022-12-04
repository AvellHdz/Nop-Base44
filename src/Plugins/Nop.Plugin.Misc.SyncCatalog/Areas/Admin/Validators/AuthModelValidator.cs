using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Nop.Plugin.Misc.SyncCatalog.Areas.Admin.Models;
using Nop.Services.Localization;
using Nop.Web.Framework.Validators;

namespace Nop.Plugin.Misc.SyncCatalog.Areas.Admin.Validators
{
    /// <summary>
    /// Represents an <see cref="AuthModel"/> validator.
    /// </summary>
    public class AuthModelValidator : BaseNopValidator<ConfigurationModel>
    {
        public AuthModelValidator(ILocalizationService localizationService)
        {
            RuleFor(model => model.UrlService).NotEmpty()
                .WithMessageAwait(localizationService.GetResourceAsync(Default.URL_SERVICE_REQUIRED));
            RuleFor(model => model.UserName).NotEmpty()
                .WithMessageAwait(localizationService.GetResourceAsync(Default.URL_SERVICE_REQUIRED));
            RuleFor(model => model.Password).NotEmpty()
                .WithMessageAwait(localizationService.GetResourceAsync(Default.URL_SERVICE_REQUIRED));

        }
    }
}
