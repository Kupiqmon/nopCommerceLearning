using Nop.Core.Interfaces;
using System.Runtime.CompilerServices;


namespace Nop.Core.Infrastructure
{
    public class EngineContext
    {
        #region Methods
        /// <summary>
        /// Create a static instance of the Nop engine
        /// </summary>
        [MethodImpl(MethodImplOptions.Synchronized)] // used for thread safety, preventing multiple threads from creating multiple instances simultaneously
        public static IEngine Create()
        {
            return Singleton<IEngine>.Instance ?? (Singleton<IEngine>.Instance = new NopEngine());
        }
        #endregion
    }
}
