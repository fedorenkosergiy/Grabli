using NUnit.Framework;

public partial class IntExTest
{
	[TestCase(2, 1, 3, false, false, true)]
	[TestCase(2, 3, 1, false, false, true)]
	[TestCase(2, 1, 3, true, true, true)]
	[TestCase(2, 3, 1, true, true, true)]
	[TestCase(2, 2, 2, true, true, true)]
	[TestCase(2, 2, 2, true, false, true)]
	[TestCase(2, 2, 2, false, true, true)]
	[TestCase(2, 2, 2, false, false, false)]
	[TestCase(20, 1, 3, false, false, false)]
	[TestCase(-20, 1, 3, false, false, false)]
	[TestCase(0, int.MinValue, int.MaxValue, true, true, true)]
	[TestCase(0, int.MaxValue, int.MinValue, true, true, true)]
	public void CheckIsBetween(int value, int a, int b, bool aIncluded, bool bIncluded, bool expected)
	{
		bool actual = value.IsBetween(a, b, aIncluded, bIncluded);
		Assert.AreEqual(expected, actual);
	}
}

