namespace Nop.Core.Configuration
{
    public class PluginConfig : IConfig
    {
        /// <summary>
        /// Gets or sets a value indicating whether to load an assembly into the load-from context, bypassing some security checks
        /// </summary>
        public bool UseUnsafeLoadAssembly { get; set; } = true;
    }
}
