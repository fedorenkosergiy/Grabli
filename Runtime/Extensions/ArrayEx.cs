using System.Collections.Generic;

public static class ArrayEx
{
	public static int FirstIndex<T>(this T[] array)
	{
		return 0;
	}

	public static int LastIndex<T>(this T[] array)
	{
		if (array.IsEmpty())
		{
			return -1;
		}
		return array.Length - 1;
	}
}
