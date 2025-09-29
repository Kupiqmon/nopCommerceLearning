using Autofac.Core;
using Autofac.Extensions.DependencyInjection; // useAutofac
using Microsoft.Extensions.DependencyInjection;
using Nop.Core.Configuration;
using Nop.Web.Framework.Infrastructure.Extensions;


namespace Nop.Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var learningBuilder = WebApplication.CreateBuilder(args);

            learningBuilder.Configuration.AddJsonFile(NopConfigurationDefault.AppSettingsFilePath, true, true);
            // AntiforgeryApplicationBuilderExtensions.Environment?.EnvironmentName does not contain a definition for 'Environment' field
            if (!string.IsNullOrEmpty(learningBuilder.Environment?.EnvironmentName))
            {
                // Read the description in the Core Configuration
                var path = string.Format(NopConfigurationDefault.AppSettingsEnvironmentFilePath, learningBuilder.Environment.EnvironmentName);
                // Add the default app settings to WebApp
                learningBuilder.Configuration.AddJsonFile(path, true, true);
            }
            learningBuilder.Configuration.AddEnvironmentVariables();

            learningBuilder.Services.ConfigureApplicationSettings(learningBuilder);

            var appSettings = Singleton<appSettings>.Instance;

            var useAutofac = appSettings.Get<CommonConfig>().UseAutofac;

            // useAutofac
            if (useAutofac)
                learningBuilder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
            else
                learningBuilder.Host.UseDefaultServiceProvider(options =>
                {
                    // Default for NopCommerce is false since the initial configuration we need to resolve some services through the root container
                    //In this example, if ValidateScopes were set to true, the container would throw an exception because IMyService is registered as scoped, but it's being resolved through the root container
                    //(which is essentially a singleton scope). By setting ValidateScopes to false, you can resolve the service without the container complaining about the scope mismatch.
                    // Scoped service resolved within a singleton service must be handled properly
                    ///*** WRONG Code ***
                    // Register a scoped service
                    //services.AddScoped<IMyService, MyService>();

                    // During application startup, resolve the service through the root container
                    //var myService = serviceProvider.GetService<IMyService>();
                    ///***
                    options.ValidateScopes = false;
                    options.ValidateOnBuild = true;
                });

            learningBuilder.Services.ConfigureApplicationServices(learningBuilder);


        }
    }
}