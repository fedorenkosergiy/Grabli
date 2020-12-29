using NUnit.Framework;
namespace System.Collections.Generic
{
	public partial class IListIntExTest
	{
		[TestCase(2, true, 1, 2, 3)]
		[TestCase(2, true, 3, 1, 2)]
		[TestCase(5, true, 5)]
		[TestCase(6, true, 5, 6)]
		[TestCase(6, true, 6, 5)]
		[TestCase(0, false)]
		[TestCase(6, true, 6, 5)]
		[TestCase(13, true, 3, 4, 6, 87, 32, 4, 123, 54, 32, 13, 4)]
		[TestCase(14, true, 3, 4, 6, 87, 32, 4, 123, 54, 32, 13, 4, 14)]
		[TestCase(14, true, 3, 4, 6, 87, 32, 4, 123, 54, 32, 15, 4, 14)]
		[TestCase(-14, true, -123, -87, -54, -32, -32, -15, -14, -6, -4, -4, -4, -3)]
		[TestCase(-14, true, -123, -87, -54, -32, -32, -13, -14, -6, -4, -4, -4, -3)]
		[TestCase(-13, true, -123, -87, -54, -32, -32, -13, -6, -4, -4, -4, -3)]
		[TestCase(-4, true, -2, -3, -4, -5)]
		[TestCase(0, true, int.MinValue, int.MaxValue)]
		[TestCase(int.MaxValue, true, int.MaxValue, int.MaxValue)]
		[TestCase(int.MinValue, true, int.MinValue, int.MinValue)]
		[TestCase(int.MaxValue - 1, true, int.MaxValue - 1, int.MaxValue)]
		[TestCase(int.MinValue, true, int.MinValue + 1, int.MinValue)]
		public void CheckTryGetMedian(int expectedMedian, bool expectedResult, params int[] values)
		{
			List<int> list = new List<int>(values);
			bool actualResult = list.TryGetMedian(out int actualMedian);
			Assert.AreEqual(expectedResult, actualResult);
			Assert.AreEqual(expectedMedian, actualMedian);
		}
	}
}
