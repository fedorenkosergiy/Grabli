using System;
using System.IO;
using System.Runtime.InteropServices;
using SystemInterface;
using SystemInterface.IO;

namespace SystemWrapper.IO
{
    /// <summary>
    /// Wrapper for <see cref="T:System.IO.Directory"/> class.
    /// </summary>
    [Serializable, ComVisible(true)]
    public partial class DirectoryWrap : IDirectory
    {
        /// <inheritdoc />
        public IDirectoryInfo CreateDirectory(string path)
        {
            DirectoryInfo di = Directory.CreateDirectory(path);
            return new DirectoryInfoWrap(di);
        }

        /// <inheritdoc />
        public void Delete(string path)
        {
            Directory.Delete(path);
        }

        /// <inheritdoc />
        public void Delete(string path, bool recursive)
        {
            Directory.Delete(path, recursive);
        }

        /// <inheritdoc />
        public bool Exists(string path)
        {
            return Directory.Exists(path);
        }

        /// <inheritdoc />
        public IDateTime GetCreationTime(string path)
        {
            return new DateTimeWrap(Directory.GetCreationTime(path));
        }

        /// <inheritdoc />
        public IDateTime GetCreationTimeUtc(string path)
        {
            return new DateTimeWrap(Directory.GetCreationTimeUtc(path));
        }

        /// <inheritdoc />
        public string GetCurrentDirectory()
        {
            return Directory.GetCurrentDirectory();
        }

        /// <inheritdoc />
        public string[] GetDirectories(string path)
        {
            return Directory.GetDirectories(path);
        }

        /// <inheritdoc />
        public string[] GetDirectories(string path, string searchPattern)
        {
            return Directory.GetDirectories(path, searchPattern);
        }

        /// <inheritdoc />
        public string[] GetDirectories(string path, string searchPattern, SearchOption searchOption)
        {
            return Directory.GetDirectories(path, searchPattern, searchOption);
        }

        /// <inheritdoc />
        public string GetDirectoryRoot(string path)
        {
            return Directory.GetDirectoryRoot(path);
        }

        /// <inheritdoc />
        public string[] GetFiles(string path)
        {
            return Directory.GetFiles(path);
        }

        /// <inheritdoc />
        public string[] GetFiles(string path, string searchPattern)
        {
            return Directory.GetFiles(path, searchPattern);
        }

        /// <inheritdoc />
        public string[] GetFiles(string path, string searchPattern, SearchOption searchOption)
        {
            return Directory.GetFiles(path, searchPattern, searchOption);
        }

        /// <inheritdoc />
        public string[] GetFileSystemEntries(string path)
        {
            return Directory.GetFileSystemEntries(path);
        }

        /// <inheritdoc />
        public string[] GetFileSystemEntries(string path, string searchPattern)
        {
            return Directory.GetFileSystemEntries(path, searchPattern);
        }

        /// <inheritdoc />
        public IDateTime GetLastAccessTime(string path)
        {
            return new DateTimeWrap(Directory.GetLastAccessTime(path));
        }

        /// <inheritdoc />
        public IDateTime GetLastAccessTimeUtc(string path)
        {
            return new DateTimeWrap(Directory.GetLastAccessTimeUtc(path));
        }

        /// <inheritdoc />
        public IDateTime GetLastWriteTime(string path)
        {
            return new DateTimeWrap(Directory.GetLastWriteTime(path));
        }

        /// <inheritdoc />
        public IDateTime GetLastWriteTimeUtc(string path)
        {
            return new DateTimeWrap(Directory.GetLastWriteTimeUtc(path));
        }

        /// <inheritdoc />
        public string[] GetLogicalDrives()
        {
            return Directory.GetLogicalDrives();
        }

        /// <inheritdoc />
        public IDirectoryInfo GetParent(string path)
        {
            DirectoryInfo di = Directory.GetParent(path);
            return new DirectoryInfoWrap(di);
        }

        /// <inheritdoc />
        public void Move(string sourceDirName, string destDirName)
        {
            Directory.Move(sourceDirName, destDirName);
        }

        /// <inheritdoc />
        public void SetCreationTime(string path, IDateTime creationTime)
        {
            Directory.SetCreationTime(path, creationTime.DateTimeInstance);
        }

        /// <inheritdoc />
        public void SetCreationTimeUtc(string path, IDateTime creationTimeUtc)
        {
            Directory.SetCreationTimeUtc(path, creationTimeUtc.DateTimeInstance);
        }

        /// <inheritdoc />
        public void SetCurrentDirectory(string path)
        {
            Directory.SetCurrentDirectory(path);
        }

        /// <inheritdoc />
        public void SetLastAccessTime(string path, IDateTime lastAccessTime)
        {
            Directory.SetLastAccessTime(path, lastAccessTime.DateTimeInstance);
        }

        /// <inheritdoc />
        public void SetLastAccessTimeUtc(string path, IDateTime lastAccessTimeUtc)
        {
            Directory.SetLastAccessTimeUtc(path, lastAccessTimeUtc.DateTimeInstance);
        }

        /// <inheritdoc />
        public void SetLastWriteTime(string path, IDateTime lastWriteTime)
        {
            Directory.SetLastWriteTime(path, lastWriteTime.DateTimeInstance);
        }

        /// <inheritdoc />
        public void SetLastWriteTimeUtc(string path, IDateTime lastWriteTimeUtc)
        {
            Directory.SetLastWriteTimeUtc(path, lastWriteTimeUtc.DateTimeInstance);
        }
    }
}