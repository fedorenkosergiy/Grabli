using UnityEngine;

public static class IntEx
{
	public static bool ToBool(this int value)
	{
		return value > 0;
	}

	public static TextAnchor ToTextAnchor(this int value)
	{
		return (TextAnchor)value;
	}

	public static bool IsEven(this int value)
	{
		return value % 2 == 0;
	}

	public static bool IsOdd(this int value)
	{
		return !IsEven(value);
	}

	public static bool IsBetween(this int value, int a, int b, bool aIncluded, bool bIncluded)
	{
		if (a > b)
		{
			{
				int temp = a;
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

