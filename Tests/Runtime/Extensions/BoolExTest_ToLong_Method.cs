using NUnit.Framework;

public partial class BoolExTest
{
	[TestCase(true, 1L)]
	[TestCase(false, 0L)]
	public void CheckToLongConvertion(bool value, long expected)
	{
		long actual = value.ToLong();
		Assert.AreEqual(expected, actual);
	}
}
