using UnityEngine;

public static class ObjectEx
{
	public static bool IsNull<T>(this T value) where T : class
	{
		return value == null;
	}

	public static bool Is<T>(this T value) where T: class
	{
		return value != null;
	}

	public static T Log<T>(this T value)
	{
		if (value == null)
		{
			Debug.Log("NULL");
		}
		else
		{
			Debug.Log(value);
		}
		return value;
	}
}
