//using Qwe.Inspector.CodeGen;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEditor;
using UnityEngine;
namespace Grabli.Pools
{
	using static Debugger;

	public class DebuggerWindow : EditorWindow
	{
		public static void Open()
		{
			DebuggerWindow window = CreateInstance<DebuggerWindow>();
			window.minSize = new Vector2(300, 200);
			window.Show();
		}

		private void OnGUI()
		{
			IReadOnlyList<Type> types = GetTypes();
			if (types.Count == 0)
			{
				GUILayout.Label("Pools are empty");
			}
			for(int i = 0; i < types.Count; ++i)
			{
				GUILayout.BeginHorizontal();
				GUILayout.Label(GetTypeName(types[i]));
				GUILayout.Label(GetCountable(types[i]).Count().ToString());
				GUILayout.EndHorizontal();
			}
		}

		private string GetTypeName(Type type)
		{
			if (type.IsGenericType)
			{
				StringBuilder builder = StringBuilderPool.Get();
				builder.Append(type.GetGenericTypeDefinition().Name);
				builder.Append('<');
				Type[] genericArguments = type.GetGenericArguments();
				builder.Append(GetTypeName(genericArguments[0]));
				for (int i = 1; i < genericArguments.Length; ++i)
				{
					builder.Append(',');
					builder.Append(' ');
					builder.Append(GetTypeName(genericArguments[i]));
				}
				builder.Append('>');
				string result = builder.ToString();
				StringBuilderPool.Release(builder);
				return result;
			}
			else
			{
				return type.Name;
			}
		}
	}
}
