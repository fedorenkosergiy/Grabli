public static class BoolEx
{
	public static int ToInt(this bool value)
	{
		return value ? 1 : 0;
	}

	public static uint ToUint(this bool value)
	{
		return value ? 1 : uint.MinValue;
	}
}

