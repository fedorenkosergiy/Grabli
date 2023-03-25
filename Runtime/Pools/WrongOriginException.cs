using System;

namespace Grabli.Pools
{
	internal class WrongOriginException<T> : Exception where T : class, new()
	{
		private const string FORMAT = "Object {0} was created outside of the pool";

		public WrongOriginException(T value) : base(string.Format(FORMAT, value)) { }
	}
}
