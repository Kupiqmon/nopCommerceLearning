using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Nop.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Web.Framework.Infrastructure.Extensions
{
    public static class ApplicationBuilderExtension
    {
        public static void InitializePlugins(this ApplicationPartManager applicationPartManager, PluginConfig pluginConfig)
        {
            ArgumentNullException.ThrowIfNull(applicationPartManager);
            ArgumentNullException.ThrowIfNull(pluginConfig);
        }
    }
}
