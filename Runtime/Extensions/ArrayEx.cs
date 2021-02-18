public static class ArrayEx
{
	public static int FirstIndex<T>(this T[] array)
	{
		return 0;
	}

	public static int LastIndex<T>(this T[] array)
	{
		if (array.IsEmptyArray())
		{
			return -1;
		}
		return array.Length - 1;
	}

    public static bool IsEmptyArray<T>(this T[] array)
    {
        return array.Length == 0;
    }
}
