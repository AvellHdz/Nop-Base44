﻿using Microsoft.Extensions.DependencyInjection;
using Nop.Core.Configuration;
using Nop.Core.Infrastructure.DependencyManagement;
using Nop.Core.Infrastructure;
using Nop.Plugin.Misc.SyncCatalog.Areas.Admin.Services;
using Nop.Plugin.Misc.SyncCatalog.Areas.Admin.Factories;

namespace Nop.Plugin.Misc.SyncCatalog.Areas.Admin.Infrastructure
{
    /// <summary>
    /// Represents a plugin dependency registrar
    /// </summary>
    public class DependencyRegistrar : IDependencyRegistrar
    {
        /// <summary>
        /// Register services and interfaces
        /// </summary>
        /// <param name="services">Collection of service descriptors</param>
        /// <param name="typeFinder">Type finder</param>
        /// <param name="appSettings">App settings</param>
        public virtual void Register(IServiceCollection services, ITypeFinder typeFinder, AppSettings appSettings)
        {
            #region Services

            services.AddScoped<ISyncService, SyncService>();

            #endregion

            #region Factory 

            services.AddScoped<ISyncModelFactory, SyncModelFactory>();
            services.AddScoped<IBasePluginAdminModelFactory, BasePluginAdminModelFactory>();

            #endregion
        }

        /// <summary>
        /// Order of this dependency registrar implementation
        /// </summary>
        public int Order => 1;
    }
}
