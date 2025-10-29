namespace Nop.Core.Configuration
{
    public partial class CommonConfig : IConfig
    {
        /// <summary>
        /// Gets or sets a value indicating whether to display the full error in production environment. It's ignored (always enabled) in development environment.
        /// </summary>
        public bool DisplayFullErrorStack { get; protected set; } = false;

        /// <summary>
        /// Gets or sets path to database with user agent strings
        /// </summary>
        public string UserAgentStringsPath { get; protected set; } = "~/App_Data/browscap.xml";

        /// <summary>
        /// Get or set a value indicating whether to use Autofac IoC container.
        /// If false then the default .Net IoC Container will be used
        /// </summary>
        public bool UseAutofac { get; set; } = true;
    }
}
