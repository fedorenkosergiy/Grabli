namespace System.Collections.Generic
{
	public static class IListUintEx
	{
		public static bool TryGetMedian(this IList<uint> list, out uint result)
		{
			return list.TryGetMedian(GetAvg, out result);
		}

		private static uint GetAvg(uint a, uint b)
		{
			if (a == b)
			{
				return a;
			}

			bool sumIsOdd = a.IsOdd() && b.IsEven() || a.IsEven() && b.IsOdd();
			bool avgWillBeLess = a.IsOdd() && b.IsOdd();

			uint result = (a >> 1) + (b >> 1);
			if (sumIsOdd && result.IsOdd() || avgWillBeLess)
			{
				++result;
			}
			return result;
		}
	}
}
