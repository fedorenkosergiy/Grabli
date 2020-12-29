using NUnit.Framework;

public class CharExTest
{
	[TestCase('1', true)]
	[TestCase('2', true)]
	[TestCase('3', true)]
	[TestCase('4', true)]
	[TestCase('5', true)]
	[TestCase('6', true)]
	[TestCase('7', true)]
	[TestCase('8', true)]
	[TestCase('9', true)]
	[TestCase('0', true)]
	[TestCase('a', false)]
	[TestCase('A', false)]
	[TestCase('z', false)]
	[TestCase('\0', false)]
	[TestCase('\t', false)]
	[TestCase('\r', false)]
	[TestCase('o', false)]
	public void CheckIsDecimalDigit(char symbol, bool expected)
	{
		bool actual = symbol.IsDecimalDigit();
		Assert.AreEqual(expected, actual);
	}
}

