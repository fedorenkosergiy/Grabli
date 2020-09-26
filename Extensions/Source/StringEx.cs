using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public static class StringEx
{
	private static IDictionary<string, CultureInfo> cultures = new Dictionary<string, CultureInfo>();

	public static bool TryGetAssetBundle(this string name, out AssetBundle bundle)
	{
		bundle = default;
		IEnumerable<AssetBundle> bundles = AssetBundle.GetAllLoadedAssetBundles();
		using (IEnumerator<AssetBundle> enumerator = bundles.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.name == name)
				{
					bundle = enumerator.Current;
					return true;
				}
			}
		}
		return false;
	}

	public static CultureInfo ToCultureInfo(this string name)
	{
		if (!cultures.TryGetValue(name, out CultureInfo result))
		{
			try
			{
				result = new CultureInfo(name);
				cultures.Add(name, result);
			}
			catch
			{
				result = CultureInfo.DefaultThreadCurrentCulture;
			}
		}
		return result;
	}

	public static GUIContent ToGUIContent(this string text)
	{
		return new GUIContent(text);
	}

	public static bool IsNullOrEmpty(this string text)
	{
		return string.IsNullOrEmpty(text);
	}

	public static bool IsSmth(this string text)
	{
		return !IsNullOrEmpty(text);
	}
}
