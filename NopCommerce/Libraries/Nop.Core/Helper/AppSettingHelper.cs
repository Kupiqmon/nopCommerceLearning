using Nop.Core.Configuration;
using Nop.Core.Infrastructure;

namespace Nop.Core.Helper
{
    public partial class AppSettingHelper
    {
        public static AppSettings SaveAppSettings(IList<IConfig> configurations, INopFileProvider fileProvider, bool overwrite = true)
        {
            var appSettings = Singleton<AppSettings>.Instance ?? new AppSettings();
            // sample only since testing new code
            Singleton<AppSettings>.Instance = appSettings;
            return appSettings;
        }

    }
}
