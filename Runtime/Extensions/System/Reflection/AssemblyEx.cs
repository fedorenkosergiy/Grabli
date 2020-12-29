using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace System.Reflection
{
	public static class AssemblyEx
	{
		public static bool IsProjectAssembly(this Assembly assembly)
		{
			try
			{
				if (assembly.IsDynamic) return false;

				FileInfo fileInfo = new FileInfo(assembly.Location);
				if (fileInfo.Directory.Name != ApplicationEx.ScriptAssembliesDirName) return false;

				DirectoryInfo library = fileInfo.Directory.Parent;
				if (library.Name != ApplicationEx.LibraryDirName) return false;

				string dataPath = ApplicationEx.ProjectPath.Replace(Path.AltDirectorySeparatorChar, Path.DirectorySeparatorChar).Trim(Path.DirectorySeparatorChar);
				string projectPath = library.Parent.FullName.Replace(Path.AltDirectorySeparatorChar, Path.DirectorySeparatorChar).Trim(Path.DirectorySeparatorChar);
				return dataPath == projectPath;
			}
			catch (Exeption e)
			{
				assembly.Log();
				e.Message.Log();
				return false;
			}
		}

		public static List<Type> GetAllTypesWithAttribute<T>(this Assembly assembly) where T : Attribute
		{
			Type[] types = assembly.GetTypes();
			List<Type> result = new List<Type>();
			foreach (Type type in types)
			{
				if (type.HasAttribute<T>())
				{
					result.Add(type);
				}
			}
			return result;
		}
	}
}
