namespace Nop.Core.Configuration
{
    /// <summary>
    /// Represents cache configuration parameters
    /// </summary>
    public class CacheConfig
    {
        /// <summary>
        /// Get or set the default cache time in minutes
        /// </summary>
        public int DefaultCacheTime { get; protected set; } = 60;
    }
}
