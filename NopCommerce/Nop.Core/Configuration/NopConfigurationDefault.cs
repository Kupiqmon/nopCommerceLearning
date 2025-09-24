namespace Nop.Core.Configuration
{
    /// <summary>
    /// Represents default values related to configuration services (optional)
    /// </summary>
    public static class NopConfigurationDefault
    {
        /// <summary>
        /// Get the DEFAULT path to file that contains the app s
        /// </summary>
        public static string AppSettingsFilePath => "App_Data/appsettings.json";

        /// <summary>
        /// Get the path to file that contains the app settings for specific environment if NOT 'AppSettingsFilePath'
        /// </summary>
        public static string AppSettingsEnvironmentFilePath => "App_Data/appsettings.{0}.json";

    }
}
