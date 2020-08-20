using System.IO;
using UnityEngine;

namespace System.Reflection
{
	public static class AssemblyEx
	{
		public static bool IsProjectAssembly(this Assembly assembly)
		{
			FileInfo fileInfo = new FileInfo(assembly.Location);
			if (fileInfo.Directory.Name != ApplicationEx.ScriptAssembliesDirName) return false;
			DirectoryInfo library = fileInfo.Directory.Parent;
			if (library.Name != ApplicationEx.LibraryDirName) return false;
			string dataPath = ApplicationEx.ProjectPath.Replace(Path.AltDirectorySeparatorChar, Path.DirectorySeparatorChar).Trim(Path.DirectorySeparatorChar);
			string projectPath = library.Parent.FullName.Replace(Path.AltDirectorySeparatorChar, Path.DirectorySeparatorChar).Trim(Path.DirectorySeparatorChar);
			return dataPath == projectPath;
		}
	}
}
