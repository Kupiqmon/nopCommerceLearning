using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection; // DependencyInjection.Abstractions
using Nop.Core;
using Nop.Core.Configuration;
using Nop.Core.Helper;
using Nop.Core.Infrastructure;
using System.Net;

namespace Nop.Web.Framework.Infrastructure.Extensions
{
    // Convention when using Extensions method
    public static class ServiceCollectionExtensions
    {
        // DependencyInjection.Abstractions (9.0.8) is required for IServiceCollection interface
        public static void ConfigureApplicationSettings(this IServiceCollection services, WebApplicationBuilder builder)
        {
            // let the OS decide what TLS protocol version to use
            // Check the Server framework default supported versions
            // TLS is binded to the connection depending on the client and server supported versions
            // Refer to the OneNote - DevOps - TLS Documentation for Windows Server
            ServicePointManager.SecurityProtocol = SecurityProtocolType.SystemDefault;

            // *** Explanation ***
            // Since Application Settings is stored in the file system, we need to init the file provider
            // Init IO class for on-disk file system usage
            CommonHelper.DefaultFileProvider = new NopFileProvider(builder.Environment);

            // --- Technique ---
            // Reflection to find all IConfig implementations
            // find all IConfig classes
            /// Init Application Configuration Instances
            var typeFinder = new WebAppTypeFinder();
            Singleton<ITypeFinder>.Instance = typeFinder;
            services.AddSingleton<ITypeFinder>(typeFinder);

            var configurations = typeFinder
                .FindClassesOfType<IConfig>()
                .Select(configType => (IConfig)Activator.CreateInstance(configType))
                .ToList();

            /// Binding the each configuration into the corresponding section
            foreach (var config in configurations)
            {
                builder.Configuration.GetSection(config.Name).Bind(config, options => options.BindNonPublicProperties = true);
            }

            /// Save Application settings into both file system and application (service, database, cloud,...)
            var appSettings = AppSettingHelper.SaveAppSettings(configurations, CommonHelper.DefaultFileProvider);
            services.AddSingleton(appSettings);
        }

        public static void ConfigureApplicationServices(this IServiceCollection services, WebApplicationBuilder builder)
        {
            // HttpContextAccessor Service is a service that provides access to the current HttpContext outside of a controller or middleware.
            // It lets non-HTTP-aware components (like services, repositories, or helpers) access information about the current HTTP request.
            // add accessor to HttpContext
            services.AddHttpContextAccessor();

            // initialize plugins
            var mvcCoreBuilder = services.AddMvcCore();
            var pluginConfig = new PluginConfig();
            builder.Configuration.GetSection(nameof(PluginConfig)).Bind(pluginConfig, options => options.BindNonPublicProperties = true);
            mvcCoreBuilder.PartManager.InitializePlugins(pluginConfig);

            // Create engine and configure service provider
            var engine = EngineContext.Create();

            
        }

        /// <summary>
        /// Register HttpContextAccessor
        /// </summary>
        /// <param name="services">Collection of service descriptors</param>
        public static void AddHttpContextAccessor(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }
    }
}
