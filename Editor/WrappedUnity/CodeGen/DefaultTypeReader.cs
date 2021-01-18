using System.IO;
using UnityEngine;

namespace Grabli.WrappedUnity.CodeGen
{
	public class DefaultTypeReader : DummyTypeReader
	{
		private Factory factory;

		public DefaultTypeReader(Factory factory)
		{
			this.factory = factory;
		}

		protected override ReadonlyTypeConfig DoRead(string guid)
		{
			string content = ReadFile(guid);
			TypeConfigRaw type = JsonUtility.FromJson<TypeConfigRaw>(content);
			return factory.CreateTypeConfig<ReadonlyTypeConfig>(type, guid);
		}

		private static string ReadFile(string guid)
		{
			string path = AssetDatabaseContext.Instance.GUIDToAssetPath(guid);
			if (path.IsNull() || !FileContext.Instance.Exists(path))
			{
				throw new FileNotFoundException("File not found", path);
			}

			return FileContext.Instance.ReadAllText(path);
		}
	}
}
