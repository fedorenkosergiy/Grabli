using UnityEngine;
using System;
using Object = UnityEngine.Object;

public static class ObjectEx
{
    public static bool IsNull<T>(this T value) where T : class
    {
        return !Is(value);
    }

    public static bool Is<T>(this T value) where T : class
    {
        if (value is Object unityObject)
        {
            return unityObject;
        }

        return value != null;
    }

    public static T Log<T>(this T value)
    {
        Debug.Log(GetValidLog(value));
        return value;
    }

    public static T Warning<T>(this T value)
    {
        Debug.LogWarning(GetValidLog(value));
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

    public static void TryThrowArgumentNullException(this object value, string name)
    {
        if (value.IsNull())
        {
            throw new ArgumentNullException(name);
        }
    }
}