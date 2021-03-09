namespace SystemInterface.IO
{
    using System.IO;

    /// <summary>
    ///     Factory that creates a new <see cref="IFileStreamFactory"/> instance.
    /// </summary>
    public interface IFileStreamFactory
    {
        #region Public Methods and Operators

        /// <summary>
        ///     Creates a new instance of the <see cref='IFileStream'/> class.
        /// </summary>
        /// <returns>
        ///     The <see cref="IFileStream"/>.
        /// </returns>
        IFileStream Create(string path,
                           FileMode fileMode);

        /// <summary>
        ///     Creates a new instance of the <see cref='IFileStream'/> class.
        /// </summary>
        /// <param name="stream">
        ///     The file stream.
        /// </param>
        /// <returns>
        ///     The <see cref="IFileStream"/>.
        /// </returns>
        IFileStream Create(Stream stream);

        /// <summary>
        ///     Creates a new instance of the <see cref='IFileStream'/> class passing the memory stream.
        /// </summary>
        /// <param name="fileStream">
        ///     The file stream.
        /// </param>
        /// <returns>
        ///     The <see cref="IFileStream"/>.
        /// </returns>
        IFileStream Create(FileStream fileStream);

        /// <summary>
        /// Initializes a new instance of the <see cref="T:SystemWrapper.IO.FileStreamWrap"/> class with the specified path and creation mode. 
        /// </summary>
        /// <param name="path">A relative or absolute path for the file that the current FileStream object will encapsulate.</param>
        /// <param name="mode">A FileMode constant that determines how to open or create the file.</param>
        /// <param name="access">A FileAccess constant that determines how the file can be accessed by the FileStream object. This gets the CanRead and CanWrite properties of the FileStream object. CanSeek is true if path specifies a disk file.</param>
        IFileStream Create(string path,
                           FileMode mode,
                           FileAccess access);

        /// <summary>
        /// Initializes a new instance of the <see cref="T:SystemWrapper.IO.FileStreamWrap"/> class with the specified path, creation mode, read/write permission, and sharing permission.
        /// </summary>
        /// <param name="path">A relative or absolute path for the file that the current FileStream object will encapsulate.</param>
        /// <param name="mode">A FileMode constant that determines how to open or create the file.</param>
        /// <param name="access">A FileAccess constant that determines how the file can be accessed by the FileStream object. This gets the CanRead and CanWrite properties of the FileStream object. CanSeek is true if path specifies a disk file.</param>
        /// <param name="share">A FileShare constant that determines how the file will be shared by processes. </param>
        IFileStream Create(string path,
                           FileMode mode,
                           FileAccess access,
                           FileShare share);

        /// <summary>
        /// Initializes a new instance of the <see cref="T:SystemWrapper.IO.FileStreamWrap"/> class with the specified path, creation mode, read/write permission, and sharing permission, and buffer size.
        /// </summary>
        /// <param name="path">A relative or absolute path for the file that the current FileStream object will encapsulate.</param>
        /// <param name="mode">A FileMode constant that determines how to open or create the file.</param>
        /// <param name="access">A FileAccess constant that determines how the file can be accessed by the FileStream object. This gets the CanRead and CanWrite properties of the FileStream object. CanSeek is true if path specifies a disk file.</param>
        /// <param name="share">A FileShare constant that determines how the file will be shared by processes. </param>
        /// <param name="bufferSize">A positive Int32 value greater than 0 indicating the buffer size. For bufferSize values between one and eight, the actual buffer size is set to eight bytes. </param>
        IFileStream Create(string path,
                           FileMode mode,
                           FileAccess access,
                           FileShare share,
                           int bufferSize);

        /// <summary>
        /// Initializes a new instance of the <see cref="T:SystemWrapper.IO.FileStreamWrap"/> class with the specified path, creation mode, read/write permission, and sharing permission, and buffer size.
        /// </summary>
        /// <param name="path">A relative or absolute path for the file that the current FileStream object will encapsulate.</param>
        /// <param name="mode">A FileMode constant that determines how to open or create the file.</param>
        /// <param name="access">A FileAccess constant that determines how the file can be accessed by the FileStream object. This gets the CanRead and CanWrite properties of the FileStream object. CanSeek is true if path specifies a disk file.</param>
        /// <param name="share">A FileShare constant that determines how the file will be shared by processes. </param>
        /// <param name="bufferSize">A positive Int32 value greater than 0 indicating the buffer size. For bufferSize values between one and eight, the actual buffer size is set to eight bytes.</param>
        /// <param name="useAsync">A positive Int32 value greater than 0 indicating the buffer size. For bufferSize values between one and eight, the actual buffer size is set to eight bytes.</param>
        IFileStream Create(string path,
                           FileMode mode,
                           FileAccess access,
                           FileShare share,
                           int bufferSize,
                           bool useAsync);

        /// <summary>
        /// Initializes a new instance of the <see cref="T:SystemWrapper.IO.FileStreamWrap"/> class with the specified path, creation mode, read/write and sharing permission, the access other FileStreams can have to the same file, the buffer size, and additional file options.
        /// </summary>
        /// <param name="path">A relative or absolute path for the file that the current FileStream object will encapsulate.</param>
        /// <param name="mode">A FileMode constant that determines how to open or create the file.</param>
        /// <param name="access">A FileAccess constant that determines how the file can be accessed by the FileStream object. This gets the CanRead and CanWrite properties of the FileStream object. CanSeek is true if path specifies a disk file.</param>
        /// <param name="share">A FileShare constant that determines how the file will be shared by processes. </param>
        /// <param name="bufferSize">A positive Int32 value greater than 0 indicating the buffer size. For bufferSize values between one and eight, the actual buffer size is set to eight bytes.</param>
        /// <param name="options">A FileOptions value that specifies additional file options.</param>
        IFileStream Create(string path,
                           FileMode mode,
                           FileAccess access,
                           FileShare share,
                           int bufferSize,
                           FileOptions options);

        #endregion
    }
}