using System;

namespace Grabli.WrappedUnity.CodeGen
{
	public interface WritableTypeConfig : TypeConfig
	{
		void SetType(Type type);
		void SetInterfaceName(string interfaceName);
		void SetClassName(string className);
		void SetUnityVersionSpecific();
		void ResetUnityVersionSpecific();

		void SetPackage(string packageId);
		void ResetPackage();
		void SetApproach(Approach approach);

		void AddDependency(ReadonlyTypeConfig config);
		void RemoveDependency(Type type);
    }
}
