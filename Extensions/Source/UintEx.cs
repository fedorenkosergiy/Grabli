public static class UintEx
{
	public static bool ToBool(this uint value)
	{
		return value > uint.MinValue;
	}

	public static bool IsEven(this uint value)
	{
		return value % 2 == uint.MinValue;
	}

	public static bool IsOdd(this uint value)
	{
		return !IsEven(value);
	}

	public static bool IsBetween(this uint value, uint a, uint b, bool aIncluded, bool bIncluded)
	{
		if (a > b)
		{
			{
				uint temp = a;
				a = b;
				b = temp;
			}
			{
				bool temp = aIncluded;
				aIncluded = bIncluded;
				bIncluded = temp;
			}
		}

		if (value < a)
		{
			return false;
		}

		if (value == a && value == b && (aIncluded || bIncluded))
		{
			return true;
		}

		if (value == a && !aIncluded)
		{
			return false;
		}
		if (value > b)
		{
			return false;
		}
		if (value == b && !bIncluded)
		{
			return false;
		}
		return true;
	}
}

