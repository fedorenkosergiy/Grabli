using System;

namespace Grabli.WrappedUnity.CodeGen
{
	public class DefaultReadonlyTypeConfig : ReadonlyTypeConfig
	{
		public string Guid { get; }
		public Type Type { get; }
		public string Namespace { get; }
		public string InterfaceName { get; }
		public string ClassName { get; }
		public bool UnityVersionSpecific { get; }
		public string PackageId { get; }
		public Approach Approach { get; }
		public ReadonlyTypeConfig[] Dependencies { get; }

		public DefaultReadonlyTypeConfig(string guid)
		{
			Guid = guid;
		}

		public void ResolveDependencies(DependenciesResolver resolver)
		{

		}
	}
}
