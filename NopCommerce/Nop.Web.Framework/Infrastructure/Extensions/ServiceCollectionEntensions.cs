using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection; // DependencyInjection.Abstractions
using Nop.Core.Configuration;
using Nop.Core.Infrastructure;
using System.Net;

namespace Nop.Web.Framework.Infrastructure.Extensions
{
    // Convention when using Extensions method
    public static class ServiceCollectionEntensions
    {
        // DependencyInjection.Abstractions (9.0.8) is required for IServiceCollection interface
        public static void ConfigureApplicationSettings(this IServiceCollection services, WebApplicationBuilder builder)
        {
            // let the OS decide what TLS protocol version to use
            // Check the Server framework default supported versions
            // TLS is binded to the connection depending on the client and server supported versions
            // Refer to the OneNote - DevOps - TLS Documentation for Windows Server
            ServicePointManager.SecurityProtocol = SecurityProtocolType.SystemDefault;

            // Init IO class for on-disk file system usage
            /// TBD

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
                continue;
            }

            /// Save Application settings into both file system and application (service, database, cloud,...) 
        }

        public static void ConfigureApplicationServices(this IServiceCollection services, WebApplicationBuilder builder)
        {
            // add accessor to HttpContext
            services.AddHttpContextAccessor();

            // initialize plugins
            var mvcCoreBuilder = services.AddMvcCore();
            var pluginConfig = new PluginConfig();

            
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
