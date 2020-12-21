using NUnit.Framework;

public partial class BoolExTest
{
	[TestCase(true, 1)]
	[TestCase(false, 0)]
	public void CheckToIntConvertion(bool value, int expected)
	{
		int actual = value.ToInt();
		Assert.AreEqual(expected, actual);
	}
}
