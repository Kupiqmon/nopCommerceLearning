using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.FileProviders;
using Nop.Core.Infrastructure;
using System.Security.AccessControl;
using System.Text;

namespace Nop.Core.Configuration
{
    public class NopFileProvider : PhysicalFileProvider, INopFileProvider
    {
        public string WebRootPath { get; }

        string INopFileProvider.WebRootPath => throw new NotImplementedException();

        // the purpose of the symbol "!" is to negate nullability of path.GetDirectoryName() instead of returning null
        public NopFileProvider(IWebHostEnvironment webHostEnvironment)
    : base(File.Exists(webHostEnvironment.ContentRootPath) ? Path.GetDirectoryName(webHostEnvironment.ContentRootPath)! : webHostEnvironment.ContentRootPath)
        {
            WebRootPath = File.Exists(webHostEnvironment.WebRootPath)
                ? Path.GetDirectoryName(webHostEnvironment.WebRootPath)
                : webHostEnvironment.WebRootPath;
        }
        #region Ulitility methods

        string INopFileProvider.Combine(params string[] paths)
        {
            throw new NotImplementedException();
        }

        void INopFileProvider.CreateDirectory(string path)
        {
            throw new NotImplementedException();
        }

        void INopFileProvider.CreateFile(string path)
        {
            throw new NotImplementedException();
        }

        void INopFileProvider.DeleteDirectory(string path)
        {
            throw new NotImplementedException();
        }

        void INopFileProvider.DeleteFile(string path)
        {
            throw new NotImplementedException();
        }

        bool INopFileProvider.DirectoryExists(string path)
        {
            throw new NotImplementedException();
        }

        void INopFileProvider.DirectoryMove(string sourceDirName, string destDirName)
        {
            throw new NotImplementedException();
        }

        IEnumerable<string> INopFileProvider.EnumerateFiles(string DirectoryPath, string searchPattern, bool topDirectoryOnly)
        {
            throw new NotImplementedException();
        }

        void INopFileProvider.FileCopy(string sourceFileName, string destFileName, bool overwrite)
        {
            throw new NotImplementedException();
        }

        bool INopFileProvider.FileExists(string filePath)
        {
            throw new NotImplementedException();
        }

        long INopFileProvider.FileLength(string path)
        {
            throw new NotImplementedException();
        }

        void INopFileProvider.FileMove(string sourceFileName, string destFileName)
        {
            throw new NotImplementedException();
        }

        string INopFileProvider.GetAbsolutePath(params string[] paths)
        {
            throw new NotImplementedException();
        }

        DirectorySecurity INopFileProvider.GetAccessControl(string path)
        {
            throw new NotImplementedException();
        }

        DateTime INopFileProvider.GetCreationTime(string path)
        {
            throw new NotImplementedException();
        }

        string[] INopFileProvider.GetDirectories(string path, string searchPattern, bool topDirectoryOnly)
        {
            throw new NotImplementedException();
        }

        string INopFileProvider.GetDirectoryName(string path)
        {
            throw new NotImplementedException();
        }

        string INopFileProvider.GetDirectoryNameOnly(string path)
        {
            throw new NotImplementedException();
        }

        string INopFileProvider.GetFileExtension(string filePath)
        {
            throw new NotImplementedException();
        }

        string INopFileProvider.GetFileName(string path)
        {
            throw new NotImplementedException();
        }

        string INopFileProvider.GetFileNameWithoutExtension(string filePath)
        {
            throw new NotImplementedException();
        }

        string[] INopFileProvider.GetFiles(string directoryPath, string searchPattern, bool topDirectoryOnly)
        {
            throw new NotImplementedException();
        }

        DateTime INopFileProvider.GetLastAccessTime(string path)
        {
            throw new NotImplementedException();
        }

        DateTime INopFileProvider.GetLastWriteTime(string path)
        {
            throw new NotImplementedException();
        }

        DateTime INopFileProvider.GetLastWriteTimeUtc(string path)
        {
            throw new NotImplementedException();
        }

        FileStream INopFileProvider.GetOrCreateFile(string path)
        {
            throw new NotImplementedException();
        }

        string INopFileProvider.GetParentDirectory(string directoryPath)
        {
            throw new NotImplementedException();
        }

        string INopFileProvider.GetVirtualPath(string path)
        {
            throw new NotImplementedException();
        }

        bool INopFileProvider.IsDirectory(string path)
        {
            throw new NotImplementedException();
        }

        string INopFileProvider.MapPath(string path)
        {
            throw new NotImplementedException();
        }

        Task<byte[]> INopFileProvider.ReadAllBytesAsync(string filePath)
        {
            throw new NotImplementedException();
        }

        Task<string> INopFileProvider.ReadAllTextAsync(string path, Encoding encoding)
        {
            throw new NotImplementedException();
        }

        string INopFileProvider.ReadAllText(string path, Encoding encoding)
        {
            throw new NotImplementedException();
        }

        Task INopFileProvider.WriteAllBytesAsync(string filePath, byte[] bytes)
        {
            throw new NotImplementedException();
        }

        Task INopFileProvider.WriteAllTextAsync(string path, string contents, Encoding encoding)
        {
            throw new NotImplementedException();
        }

        void INopFileProvider.WriteAllText(string path, string contents, Encoding encoding)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
