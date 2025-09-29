using Nop.Core.Configuration;

namespace Nop.Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var learnBuilder = WebApplication.CreateBuilder(args);

            learnBuilder.Configuration.AddJsonFile(NopConfigurationDefaults.AppSettingsFilePath, true, true);
        }
    }
}