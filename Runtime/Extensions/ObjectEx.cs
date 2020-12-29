using UnityEngine;

public static class ObjectEx
{
	public static bool IsNull<T>(this T value) where T : class
	{
		return value == null;
	}

	public static bool Is<T>(this T value) where T : class
	{
		return value != null;
	}

	public static T Log<T>(this T value)
	{
		Debug.Log(GetValidLog(value));
		return value;
	}

	private static object GetValidLog(object value)
	{
		return value ?? "NULL";
	}

	public static T LogFormat<T>(this T value, string template)
	{
		string log = string.Format(template, GetValidLog(value));
		Debug.Log(log);
		return value;
	}
}
