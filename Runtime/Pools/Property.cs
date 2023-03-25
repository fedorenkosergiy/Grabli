namespace Grabli.Pools
{
	internal interface Property
	{
		bool SetOwner(object owner);
		bool ResetOwner(object owner);
	}
}
