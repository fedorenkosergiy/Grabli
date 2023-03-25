using System;

namespace Grabli.Pools
{
	internal class ThereIsBetterPoolException : Exception
	{
		private const string FORMAT = "{0} pool fits better to {1}";

		public ThereIsBetterPoolException(string poolName, Type target) :
			base(string.Format(FORMAT, poolName, target))
		{ }
	}
}
