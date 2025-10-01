namespace Nop.Core.Infrastructure
{
    /// <summary>
    /// Provide access to all "singletons" stored by <see cref="Singleton{T}"/>
    /// </summary>
    public partial class BaseSingleton
    {
        /// <summary>
        /// Dictionary of type to singleton instances
        /// </summary>
        public static IDictionary<Type, Object> AllSingletons { get;}
        static BaseSingleton()
        {
            AllSingletons = new Dictionary<Type, Object>();
        }

    }
}
