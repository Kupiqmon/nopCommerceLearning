using System.Reflection;


namespace Nop.Core.Infrastructure
{
    /// <summary>
    /// Providesa information about types in the current web application.
    /// Optionally this calss can look at all assemblies in the bin folder
    /// </summary>
    public partial class WebAppTypeFinder: AppDomainTypeFinder
    {
        #region Fields

        protected bool _binFolderAssembliesLoaded;

        #endregion

        #region Ctor
        
        public WebAppTypeFinder(INopFileProvider fileProvider = null) : base(fileProvider)
        {
        }

        #endregion

        #region Methods
        // Gets a physical disk path of \Bin directory
        public virtual string GetBinDirectory()
        {
            return AppContext.BaseDirectory;
        }

        // Gets assemblies
        public override IList<Assembly> GetAssemblies()
        {
            return new List<Assembly>();
        }
        #endregion

        #region Properties

        /// Gets or sets whether assemblies in the bin folder of the web application should be specifically checked for being loaded on application load.
        /// This is need in situations where plugins need to be loaded in the AppDomain after the application has been reloaded
        public bool EnsureBinFolderAssembliesLoaded { get; set; }

        #endregion
    }
}
