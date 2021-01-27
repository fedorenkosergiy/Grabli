namespace Grabli.WrappedUnity.CodeGen
{
	public interface DependenciesResolver
	{
        TypeConfig [] Resolve(string[] dependencyGuids);
	}
}
