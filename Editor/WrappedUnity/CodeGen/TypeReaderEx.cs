namespace Grabli.WrappedUnity.CodeGen
{
	public static class TypeReaderEx
	{
		public static bool TryRead(this TypeReader reader, string guid, out TypeConfigRaw config)
		{
			try
			{
				config = reader.Read(guid);
				return true;
			}
			catch
			{
				config = default;
				return false;
			}
		}
	}
}
