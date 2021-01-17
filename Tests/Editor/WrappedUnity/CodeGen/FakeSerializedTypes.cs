using System.Collections.Generic;
using SystemInterface.IO;
using Castle.Core.Internal;
using Moq;

namespace Grabli.WrappedUnity.CodeGen
{
	public static class FakeSerializedTypes
	{
		public const string RootTypeGuidApplication = "78281a11355f4dc2b412c5f2d3279cc6";
		public const string RootTypeGuidScreen = "c6040b9e044d465eb92aa770aac4db9b";
		public const string RootTypesFilePath = "directory/filename.json";

		public const string RootTypesFileContent = "{" +
		                                           "\"Guids\":[" +
		                                           "\"" + RootTypeGuidApplication + "\"," +
		                                           "\"" + RootTypeGuidScreen + "\"" +
		                                           "]}";

		public const string ApplicationTypeConfigPath = "directory/application.json";
		public const string ScreenTypeConfigPath = "directory/screen.json";

		public static readonly string ApplicationTypeConfigContent = "{" +
		                                                             $"\"{nameof(TypeConfigRaw.FullTypeName)}\":" +
		                                                             $"\"{typeof(UnityEngine.Application).FullName}\"," +
		                                                             $"\"{nameof(TypeConfigRaw.Namespace)}\":" +
		                                                             "\"Grabli.WrappedUnity\"," +
		                                                             $"\"{nameof(TypeConfigRaw.ClassName)}\":" +
		                                                             "\"DefaultApplication\"," +
		                                                             $"\"{nameof(TypeConfigRaw.InterfaceName)}\":" +
		                                                             "\"Application\"," +
		                                                             $"\"{nameof(TypeConfigRaw.UnityVersionSpecific)}\":" +
		                                                             "false," +
		                                                             $"\"{nameof(TypeConfigRaw.PackageId)}\":" +
		                                                             "\"\"," +
		                                                             $"\"{nameof(TypeConfigRaw.Approach)}\":" +
		                                                             "1," +
		                                                             $"\"{nameof(TypeConfigRaw.DependencyGuids)}\":" +
		                                                             "[]" +
		                                                             "}";

		public static readonly string ScreenTypeConfigContent = "{" +
		                                                        $"\"{nameof(TypeConfigRaw.FullTypeName)}\":" +
		                                                        $"\"{typeof(UnityEngine.Screen).FullName}\"," +
		                                                        $"\"{nameof(TypeConfigRaw.Namespace)}\":" +
		                                                        "\"Grabli.WrappedUnity\"," +
		                                                        $"\"{nameof(TypeConfigRaw.ClassName)}\":" +
		                                                        "\"DefaultScreen\"," +
		                                                        $"\"{nameof(TypeConfigRaw.InterfaceName)}\":" +
		                                                        "\"Screen\"," +
		                                                        $"\"{nameof(TypeConfigRaw.UnityVersionSpecific)}\":" +
		                                                        "false," +
		                                                        $"\"{nameof(TypeConfigRaw.PackageId)}\":" +
		                                                        "\"\"," +
		                                                        $"\"{nameof(TypeConfigRaw.Approach)}\":" +
		                                                        "1," +
		                                                        $"\"{nameof(TypeConfigRaw.DependencyGuids)}\":" +
		                                                        "[]" +
		                                                        "}";

		public static IFile CreateFakeIOFile()
		{
			IDictionary<string, string> files = new Dictionary<string, string>();
			files.Add(RootTypesFilePath, RootTypesFileContent);
			files.Add(ApplicationTypeConfigPath, ApplicationTypeConfigContent);
			files.Add(ScreenTypeConfigPath, ScreenTypeConfigContent);
			return CreateFakeIOFile(files);
		}

		public static IFile CreateFakeIOFile(IDictionary<string, string> files)
		{
			Mock<IFile> mock = new Mock<IFile>();
			mock.Setup(file => file.ReadAllText(It.IsAny<string>())).Returns<string>(path => files[path]);
			mock.Setup(file => file.Exists(It.IsAny<string>())).Returns<string>(path => files.TryGetValue(path, out string content));
			return mock.Object;
		}

		public static AssetDatabase CreateFakeAssetDatabase()
		{
			IDictionary<string, string> files = new Dictionary<string, string>();
			files.Add(RootTypeGuidApplication, ApplicationTypeConfigPath);
			files.Add(RootTypeGuidScreen, ScreenTypeConfigPath);
			return CreateFakeAssetDatabase(files);
		}

		public static AssetDatabase CreateFakeAssetDatabase(IDictionary<string, string> files)
		{
			Mock<AssetDatabase> mock = new Mock<AssetDatabase>();
			mock.Setup(file => file.GUIDToAssetPath(It.IsAny<string>())).Returns<string>(guid =>
			{
				files.TryGetValue(guid, out string path);
				return path;
			});
			return mock.Object;
		}
	}
}
