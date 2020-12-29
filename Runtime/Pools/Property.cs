namespace Grabli.Pools
{
	public interface Property
	{
		bool SetOwner(object owner);
		bool ResetOwner(object owner);
	}
}
