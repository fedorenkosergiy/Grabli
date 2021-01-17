namespace Grabli.WrappedUnity.CodeGen
{
	public class DefaultDependencyResolver : DependenciesResolver
	{
		private Factory factory;

		public DefaultDependencyResolver(Factory factory)
		{
			this.factory = factory;
		}

		public void Resolve(string[] dependencyGuids, ReadonlyTypeConfigsSetter dependenciesSetter)
		{
			throw new System.NotImplementedException();
		}
	}
}
