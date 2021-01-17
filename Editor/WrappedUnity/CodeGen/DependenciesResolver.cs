namespace Grabli.WrappedUnity.CodeGen
{
	public interface DependenciesResolver
	{
		ReadonlyTypeConfig [] Resolve(string[] dependencyGuids);
	}
}
