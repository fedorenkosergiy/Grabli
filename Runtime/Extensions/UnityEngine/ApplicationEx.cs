namespace UnityEngine
{
	public static class ApplicationEx
	{
		public const string LibraryDirName = "Library";
		public const string ScriptAssembliesDirName = "ScriptAssemblies";
		public const string ProjectSettingsDirName = "ProjectSettings";

		public static string ProjectPath => Application.dataPath.Remove(Application.dataPath.Length - 6);

		public static string ProjectSettingsPath => ProjectPath + ProjectSettingsDirName;
	}
}
