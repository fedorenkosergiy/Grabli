using UnityEngine;

namespace Grabli.WrappedUnity.CodeGen
{
	public class DefaultTypesReader : TypesReader
	{
		private Factory factory;

		public DefaultTypesReader(Factory factory)
		{
			this.factory = factory;
		}

		public ReadonlyTypeConfig Read(string guid)
		{
			string path = AssetDatabaseContext.Instance.GUIDToAssetPath(guid);
			string content = FileContext.Instance.ReadAllText(path);
			TypeConfigRaw type = JsonUtility.FromJson<TypeConfigRaw>(content);
			return factory.CreateTypeConfig<ReadonlyTypeConfig>(type);
		}
	}
}
