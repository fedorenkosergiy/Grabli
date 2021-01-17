using System.IO;

namespace Grabli.WrappedUnity.CodeGen
{
	public static class TypeReaderEx
	{
		public static bool TryRead(this TypeReader reader, string guid, out ReadonlyTypeConfig config)
		{
			try
			{
				config = reader.Read(guid);
				return true;
			}
			catch
			{
				config = null;
				return false;
			}
		}
	}
}
