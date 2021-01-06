namespace Grabli.WrappedUnity
{
	public interface WrappersFactory
	{
		Ping NewPing(string address);
		T New<T>();
	}
}
