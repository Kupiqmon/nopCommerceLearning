using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Core
{
    internal class Constants
    {
        // Nop Configuration Defaults - NopConfigurationDefault.cs
        public static string AppSettingsFilePath => "App_Data/appsettings.json";
        public static string AppSettingsEnvironmentFilePath => "App_Data/appsettings.{0}.json";
    }
}
