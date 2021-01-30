using System;

namespace Grabli.WrappedUnity.CodeGen
{
	public interface WritableTypeConfig : TypeConfig
	{
		void SetType(Type type);
		void SetInterfaceName(string interfaceName);
        void SetClassName(string className);
        void SetSpaceName(string spaceName);
		void SetUnityVersionSpecific();
		void ResetUnityVersionSpecific();

		void SetPackage(string packageId);
		void ResetPackage();
		void SetApproach(Approach approach);

		void AddDependency(TypeConfig dependency);
		void RemoveDependency(TypeConfig dependency);

        void SetSource(TypeConfig source, DependenciesResolver resolver);
    }
}
