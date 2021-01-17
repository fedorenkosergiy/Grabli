namespace Grabli.WrappedUnity.CodeGen
{
	public interface DependenciesResolver
	{
		void Resolve(string[] dependencyGuids, ReadonlyTypeConfigsSetter dependenciesSetter);
	}
}
