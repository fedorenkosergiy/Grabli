using System;

namespace Grabli.WrappedUnity.CodeGen
{
	public interface ReadonlyTypeConfig : Initializable
	{
		string Guid { get; }
		Type Type { get; }
		string Namespace { get; }
		string InterfaceName { get; }
		string ClassName { get; }
		bool UnityVersionSpecific { get; }
		string PackageId { get; }
		Approach Approach { get; }
		ReadonlyTypeConfig[] Dependencies { get; }

		void ResolveDependencies(DependenciesResolver resolver);
	}
}
