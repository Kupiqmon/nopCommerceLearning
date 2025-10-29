namespace Nop.Core.Configuration
{
    public partial class AppSettings
    {
        #region Fields

        protected readonly Dictionary<Type, IConfig> _configurations;

        #endregion

        #region Ctor
        public AppSettings(IList<IConfig> configurations = null)
        {
            // sample code
            _configurations = new Dictionary<Type, IConfig>();
            
        }
        #endregion

        #region Methods

        /// <summary>
        /// Get configuration parameters by type
        /// </summary>
        /// <typeparam name="TConfig">Configuration type</typeparam>
        /// <returns>Configuration parameters</returns>
        public TConfig Get<TConfig>() where TConfig : class, IConfig
        {
            // sample code
            _configurations.Add(typeof(CommonConfig), new CommonConfig());
            if (_configurations[typeof(TConfig)] is not TConfig config)
            {
                throw new Exception($"No configuration with type '{typeof(TConfig)}' found");
            }

            return config;
        }

        #endregion
    }
}
