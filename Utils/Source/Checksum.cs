using Grabli.Pools;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Grabli.Utils
{
	public static class Checksum
	{
		public static int GetChecksum(object obj)
		{
			return GetStringDump(obj, new HashSet<object>()).GetHashCode();
		}

		private static string GetStringDump(object obj, HashSet<object> handled)
		{
			if (obj.IsNull() || handled.Contains(obj))
			{
				return string.Empty;
			}
			else
			{
				handled.Add(obj);
			}
			BindingFlags allFields = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;
			FieldInfo[] fields = obj.GetType().GetFields(allFields);
			StringBuilder builder = StringBuilderPool.Get();
			for (int i = 0; i < fields.Length; ++i)
			{
				FieldInfo field = fields[i];
				builder.Append(field.FieldType.FullName);
				builder.Append(field.Name);
				object value = field.GetValue(obj);
				if (field.FieldType == typeof(string))
				{
					string text = value as string;
					if (!text.IsNullOrEmpty())
					{
						builder.Append(value);
					}
				}
				else if (field.FieldType.IsPrimitive)
				{
					builder.Append(value);
				}
				else if (value.Is())
				{
					if (field.FieldType.IsArray)
					{
						Array array = value as Array;
						for (int j = 0; j < array.Length; ++j)
						{
							builder.Append(j);
							builder.Append(GetStringDump(array.GetValue(j), handled));
						}
					}
					else
					{
						builder.Append(GetStringDump(value, handled));
					}
				}
			}
			return StringBuilderPool.GetValueAndRelease(builder);
		}
	}
}
