using SystemInterface.IO;
using SystemWrapper.IO;

namespace Grabli.WrappedUnity
{
	public class FileContext : Context<FileContext, FileWrap, IFile>
	{
		public FileContext(IFile file) : base(file)
		{
		}

		public FileContext()
		{
		}
	}
}
