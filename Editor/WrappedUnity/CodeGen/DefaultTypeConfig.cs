using System;

namespace Grabli.WrappedUnity.CodeGen
{
	public class DefaultTypeConfig : DefaultReadonlyTypeConfig, TypeConfig
	{
		public DefaultTypeConfig(string guid) : base(guid)
		{
		}

		public void SetType(Type type)
		{
			throw new NotImplementedException();
		}

		public void SetInterfaceName(string interfaceName)
		{
			throw new NotImplementedException();
		}

		public void SetClassName(string className)
		{
			throw new NotImplementedException();
		}

		public void SetUnityVersionSpecific()
		{
			throw new NotImplementedException();
		}

		public void ResetUnityVersionSpecific()
		{
			throw new NotImplementedException();
		}

		public void SetPackage(string packageId)
		{
			throw new NotImplementedException();
		}

		public void ResetPackage()
		{
			throw new NotImplementedException();
		}

		public void SetApproach(Approach approach)
		{
			throw new NotImplementedException();
		}

		public void AddDependency(ReadonlyTypeConfig config)
		{
			throw new NotImplementedException();
		}

		public void RemoveDependency(Type type)
		{
			throw new NotImplementedException();
		}

		public void ResolveDependencies(DependenciesResolver resolver)
		{
			throw new NotImplementedException();
		}
	}
}
