using System;

namespace Grabli.WrappedUnity.CodeGen
{
	public interface TypeHandlingConfig : ReadonlyTypeHandlingConfig
	{
		void SetType(Type type);
		void SetInterfaceName(string interfaceName);
		void SetClassName(string className);
		void SetUnityVersionSpecific();
		void ResetUnityVersionSpecific();

		void SetPackage(string packageId);
		void ResetPackage();
		void SetApproach(Approach approach);

		void AddDependency(ReadonlyTypeHandlingConfig config);
		void RemoveDependency(Type type);

		void ResolveDependencies(DependenciesResolver resolver);
	}
}
