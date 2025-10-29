namespace Nop.Core.Configuration
{
    public static class NopConfigurationDefaults
    {
        /// Get the path to file that contains app settings for
        public static string AppSettingsFilePath => "App_Data/appsettings.json";

        /// Get the path to file that contains app settings for specific hosting environment
        public static string AppSettingsEnvironmentFilePath => "App_Data/appsettings.{0}.json";
    }
}

