using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace System
{
	public static class TypeEx
	{
		private const char TypeNameSeparator = '.';

		public static bool HasAttribute<T>(this Type type) where T : Attribute
		{
			object[] attributes = type.GetCustomAttributes(typeof(T), true);
			return attributes != null && attributes.Length > 0;
		}

		public static bool TryGetAttribute<T>(this Type type, out T attribute) where T : Attribute
		{
			attribute = null;
			bool result = type.HasAttribute<T>();
			if (result)
			{
				attribute = type.GetCustomAttribute<T>();
			}
			return result;
		}

		public static bool InheritedFrom<T>(this Type child)
		{
			Type parent = typeof(T);
			return child.InheritedFrom(parent);
		}

		public static bool InheritedFrom(this Type child, Type parent)
		{
			return parent.IsAssignableFrom(child) && child != parent;
		}

		public static MethodInfo[] GetPublicStaticMethods(this Type type)
		{
			return type.GetMethods(BindingFlags.Static | BindingFlags.Public | BindingFlags.DeclaredOnly);
		}

		public static bool IsNotAbstract(this Type type)
		{
			return !type.IsAbstract;
		}

		public static Type[] GetAllNotAbstractChildrenClasses(this Type type, Assembly assembly)
		{
			List<Type> result = new List<Type>(assembly.GetTypes());
			for (int i = 0; i < result.Count; ++i)
			{
				Type current = result[i];
				if (current.InheritedFrom(type) && current.IsNotAbstract())
				{
					continue;
				}
				result.RemoveAt(i--);
			}
			return result.ToArray();
		}

		public static string[] GetNamespaceNodes(this Type type)
		{
			return type.Namespace.Split(TypeNameSeparator);
		}

		public static string[] GetFullNameNodes(this Type type)
		{
			return type.FullName.Split(TypeNameSeparator);
		}

		public static bool IsUnityComponent(this Type type)
		{
			return type.IsCastableClass<Component>();
		}

		private static bool IsCastableClass<T>(this Type type)
		{
			if (!type.IsClass || type == typeof(object))
			{
				return false;
			}
			if (type == typeof(T))
			{
				return true;
			}
			return IsCastableClass<T>(type.BaseType);
		}

		public static bool IsScriptableObject(this Type type)
		{
			return type.IsCastableClass<ScriptableObject>();
		}
	}
}