public static class CharEx
{
	private const char MinDigit = '0';
	private const char MaxDigit = '9';

	public static bool IsDecimalDigit(this char symbol)
	{
		return symbol >= MinDigit && symbol <= MaxDigit;
	}
}
