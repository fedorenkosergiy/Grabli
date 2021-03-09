using System.IO;

namespace SystemInterface.IO
{
    /// <summary>
    /// Wrapper for <see cref="T:System.IO.FileStream"/> class.
    /// </summary>
    public interface IFileStream : IStream
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:SystemInterface.IO.FileStreamWrap"/> class on the specified path.
        /// </summary>
        /// <param name="stream">A <see cref="T:System.IO.Stream"/> object.</param>
        void Initialize(Stream stream);

        /// <summary>
        /// Initializes a new instance of the <see cref="T:SystemInterface.IO.FileStreamWrap"/> class on the specified path.
        /// </summary>
        /// <param name="fileStream">A <see cref="T:System.IO.FileStream"/> object.</param>
        void Initialize(FileStream fileStream);

        /// <summary>
        /// Initializes a new instance of the <see cref="T:SystemInterface.IO.FileStreamWrap"/> class with the specified path and creation mode.
        /// </summary>
        /// <param name="path">A relative or absolute path for the file that the current FileStream object will encapsulate.</param>
        /// <param name="mode">A FileMode constant that determines how to open or create the file.</param>
        void Initialize(string path, FileMode mode);

        /// <summary>
        /// Initializes a new instance of the <see cref="T:SystemInterface.IO.FileStreamWrap"/> class with the specified path and creation mode.
        /// </summary>
        /// <param name="path">A relative or absolute path for the file that the current FileStream object will encapsulate.</param>
        /// <param name="mode">A FileMode constant that determines how to open or create the file.</param>
        /// <param name="access">A FileAccess constant that determines how the file can be accessed by the FileStream object. This gets the CanRead and CanWrite properties of the FileStream object. CanSeek is <c>true</c> if path specifies a disk file.</param>
        void Initialize(string path, FileMode mode, FileAccess access);

        /// <summary>
        /// Initializes a new instance of the <see cref="T:SystemInterface.IO.FileStreamWrap"/> class with the specified path, creation mode, read/write permission, and sharing permission.
        /// </summary>
        /// <param name="path">A relative or absolute path for the file that the current FileStream object will encapsulate.</param>
        /// <param name="mode">A FileMode constant that determines how to open or create the file.</param>
        /// <param name="access">A FileAccess constant that determines how the file can be accessed by the FileStream object. This gets the CanRead and CanWrite properties of the FileStream object. CanSeek is true if path specifies a disk file.</param>
        /// <param name="share">A FileShare constant that determines how the file will be shared by processes. </param>
        void Initialize(string path, FileMode mode, FileAccess access, FileShare share);

        /// <summary>
        /// Initializes a new instance of the <see cref="T:SystemInterface.IO.FileStreamWrap"/> class with the specified path, creation mode, read/write permission, and sharing permission, and buffer size.
        /// </summary>
        /// <param name="path">A relative or absolute path for the file that the current FileStream object will encapsulate.</param>
        /// <param name="mode">A FileMode constant that determines how to open or create the file.</param>
        /// <param name="access">A FileAccess constant that determines how the file can be accessed by the FileStream object. This gets the CanRead and CanWrite properties of the FileStream object. CanSeek is true if path specifies a disk file.</param>
        /// <param name="share">A FileShare constant that determines how the file will be shared by processes. </param>
        /// <param name="bufferSize">A positive Int32 value greater than 0 indicating the buffer size. For bufferSize values between one and eight, the actual buffer size is set to eight bytes. </param>
        void Initialize(string path, FileMode mode, FileAccess access, FileShare share, int bufferSize);

        /// <summary>
        /// Initializes a new instance of the <see cref="T:SystemInterface.IO.FileStreamWrap"/> class with the specified path, creation mode, read/write permission, and sharing permission, and buffer size.
        /// </summary>
        /// <param name="path">A relative or absolute path for the file that the current FileStream object will encapsulate.</param>
        /// <param name="mode">A FileMode constant that determines how to open or create the file.</param>
        /// <param name="access">A FileAccess constant that determines how the file can be accessed by the FileStream object. This gets the CanRead and CanWrite properties of the FileStream object. CanSeek is true if path specifies a disk file.</param>
        /// <param name="share">A FileShare constant that determines how the file will be shared by processes. </param>
        /// <param name="bufferSize">A positive Int32 value greater than 0 indicating the buffer size. For bufferSize values between one and eight, the actual buffer size is set to eight bytes.</param>
        /// <param name="useAsync">A positive Int32 value greater than 0 indicating the buffer size. For bufferSize values between one and eight, the actual buffer size is set to eight bytes.</param>
        void Initialize(string path, FileMode mode, FileAccess access, FileShare share, int bufferSize, bool useAsync);

        /// <summary>
        /// Initializes a new instance of the <see cref="T:SystemInterface.IO.FileStreamWrap"/> class with the specified path, creation mode, read/write and sharing permission, the access other FileStreams can have to the same file, the buffer size, and additional file options.
        /// </summary>
        /// <param name="path">A relative or absolute path for the file that the current FileStream object will encapsulate.</param>
        /// <param name="mode">A FileMode constant that determines how to open or create the file.</param>
        /// <param name="access">A FileAccess constant that determines how the file can be accessed by the FileStream object. This gets the CanRead and CanWrite properties of the FileStream object. CanSeek is true if path specifies a disk file.</param>
        /// <param name="share">A FileShare constant that determines how the file will be shared by processes. </param>
        /// <param name="bufferSize">A positive Int32 value greater than 0 indicating the buffer size. For bufferSize values between one and eight, the actual buffer size is set to eight bytes.</param>
        /// <param name="options">A FileOptions value that specifies additional file options.</param>
        void Initialize(string path, FileMode mode, FileAccess access, FileShare share, int bufferSize, FileOptions options);
        // Properties

        /// <summary>
        /// Gets <see cref="T:System.IO.FileStream"/> object.
        /// </summary>
        FileStream FileStreamInstance { get; }

        /// <summary>
        /// Gets a value indicating whether the FileStream was opened asynchronously or synchronously.
        /// </summary>
        bool IsAsync { get; }

        /// <summary>
        /// Gets the name of the IFileStreamWrap that was passed to the constructor.
        /// </summary>
        string Name { get; }

        // Methods

        /// <summary>
        /// Prevents other processes from changing the FileStream while permitting read access.
        /// </summary>
        /// <param name="position">The beginning of the range to lock. The value of this parameter must be equal to or greater than zero (0). </param>
        /// <param name="length">The range to be locked. </param>
        void Lock(long position, long length);

        /// <summary>
        /// Returns a String that represents the current Object.
        /// </summary>
        /// <returns>A String that represents the current Object. </returns>
        string ToString();

        /// <summary>
        /// Allows access by other processes to all or part of a file that was previously locked.
        /// </summary>
        /// <param name="position">The beginning of the range to unlock.</param>
        /// <param name="length">The range to be unlocked.</param>
        void Unlock(long position, long length);
    }
}
