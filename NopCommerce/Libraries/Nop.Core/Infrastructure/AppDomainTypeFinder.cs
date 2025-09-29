using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Core.Infrastructure
{
    /// <summary>
    /// A class that finds types needed by Nop by looping assemblies in the
    /// currently executing AppDomain. Only assemblies whose names matches
    /// certain patterns are investigated and an optional list of assemblies
    /// referenced by <see cref="AssemblyNames"/> are always investigated
    /// </summary>
    public partial class AppDomainTypeFinder : ITypeFinder
    {
        #region Fields

        protected readonly bool _ignoreReflectionErrors = true;
        protected readonly INopFileProvider _fileProvider;

        #endregion

        public AppDomainTypeFinder(INopFileProvider fileProvider = null)
        {
            _fileProvider = fileProvider ?? CommonHelper.DefaultFileProvider;
            //_fileProvider = fileProvider ??
        }

        #region Utilities
        protected virtual IEnumerable<Type> FindClassesOfType(Type assignTypeFrom, IEnumerable<Assembly> assemblies, bool onlyConcreteClasses = true)
        {
            var result = new List<Type>();
            return result;
        }
        #endregion

        #region Methods

        /// <summary>
        /// Find classes of type
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="onlyConcreteClasses">A value indicating whether to find only concrete classes</param>
        /// <returns>Result</returns>
        public IEnumerable<Type> FindClassesOfType<T>(bool onlyConcreteClasses = true)
        {
            return FindClassesOfType(typeof(T), onlyConcreteClasses);
        }

        /// <summary>
        /// Find classes of type
        /// </summary>
        /// <param name="assignTypeFrom">Assign type from</param>
        /// <param name="onlyConcreteClasses">A value indicating whether to find only concrete classes</param>
        /// <returns>Result</returns>
        /// <returns></returns>
        public IEnumerable<Type> FindClassesOfType(Type assignTypeFrom, bool onlyConcreteClasses = true)
        {
            return FindClassesOfType(assignTypeFrom, GetAssemblies(), onlyConcreteClasses);
        }

        /// <summary>
        /// Gets the assemblies related to the current implementation.
        /// </summary>
        /// <returns>A list of assemblies</returns>
        public virtual IList<Assembly> GetAssemblies()
        {
            var addedAssemblyNames = new List<string>();
            var assemblies = new List<Assembly>();

            /*if (LoadAppDomainAssemblies)
                AddAssembliesInAppDomain(addedAssemblyNames, assemblies);
            AddConfiguredAssemblies(addedAssemblyNames, assemblies);*/

            return assemblies;
        }

        #endregion
    }
}
