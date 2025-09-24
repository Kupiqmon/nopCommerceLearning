namespace Nop.Core.Configuration
{
    public static class NopConfigurationDefaults
    {
        /// <summary>
        /// Represents default values related to configuration services
        /// </summary>
        public NopConfigurationDefaults()
        {
            /// Get the path to file that contains app settings for
            public static string AppSettingsFilePath => "App_Data/appsettings.json";

            /// Get the path to file that contains app settings for specific hosting environment
            public static string AppSettingsEnvironmentFilePath => "App_Data/appsettings.{0}.json"
        }
    }
}

