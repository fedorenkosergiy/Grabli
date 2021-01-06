using System;

namespace Grabli.WrappedUnity
{
	public class DefaultWrappersFactory : WrappersFactory
	{
		public virtual T New<T>()
		{
			throw new NotImplementedException();
		}

		public virtual Ping NewPing(string address) => new DefaultPing(address);
	}
}
