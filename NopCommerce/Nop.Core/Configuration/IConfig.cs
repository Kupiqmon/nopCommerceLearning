using Newtonsoft.Json;

namespace Nop.Core.Configuration
{
    public partial interface IConfig
    {
        /// <summary>
        /// Get a section name to load configuration
        /// </summary>
        [JsonIgnore]
        string Name => GetType().Name;

        /// <summary>
        /// Gets an order of configuration
        /// </summary>
        /// <returns>Order</returns>
        public int GetOrder() => 1;
    }
}
