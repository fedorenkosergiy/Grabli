using System.Collections.Generic;
using SystemInterface.IO;
using Moq;

namespace Grabli.WrappedUnity.CodeGen
{
	public partial class DefaultInitializerTests
	{
		private const string rootTypeGuidApplication = "78281a11355f4dc2b412c5f2d3279cc6";
		private const string rootTypeGuidScreen = "c6040b9e044d465eb92aa770aac4db9b";
		private const string rootTypesFilePath = "directory/filename.json";

		private const string rootTypesFileContent = "{" +
		                                            "\"Guids\":[" +
		                                            "\"" + rootTypeGuidApplication + "\"" +
		                                            "," +
		                                            "\"" + rootTypeGuidScreen + "\"" +
		                                            "]}";

		public const string applicationTypeConfigPath = "directory/application.json";
		public const string screenTypeConfigPath = "directory/screen.json";

		public readonly string applicationTypeConfigContent = "{" +
		                                                      $"\"{nameof(TypeConfigRaw.FullTypeName)}\":" +
		                                                      $"\"{typeof(UnityEngine.Application).FullName}\"," +
		                                                      $"\"{nameof(TypeConfigRaw.Namespace)}\"" +
		                                                      "\"Grabli.WrappedUnity\"," +
		                                                      $"\"{nameof(TypeConfigRaw.ClassName)}\"" +
		                                                      "\"DefaultApplication\"," +
		                                                      $"\"{nameof(TypeConfigRaw.InterfaceName)}\"" +
		                                                      "\"Application\"," +
		                                                      $"\"{nameof(TypeConfigRaw.UnityVersionSpecific)}\"" +
		                                                      "false," +
		                                                      $"\"{nameof(TypeConfigRaw.PackageId)}\"" +
		                                                      "\"\"," +
		                                                      $"\"{nameof(TypeConfigRaw.Approach)}\"" +
		                                                      "1," +
		                                                      $"\"{nameof(TypeConfigRaw.DependencyGuids)}\"" +
		                                                      "[]" +
		                                                      "}";

		public readonly string screenTypeConfigContent = "{" +
		                                                 $"\"{nameof(TypeConfigRaw.FullTypeName)}\":" +
		                                                 $"\"{typeof(UnityEngine.Screen).FullName}\"," +
		                                                 $"\"{nameof(TypeConfigRaw.Namespace)}\"" +
		                                                 "\"Grabli.WrappedUnity\"," +
		                                                 $"\"{nameof(TypeConfigRaw.ClassName)}\"" +
		                                                 "\"DefaultScreen\"," +
		                                                 $"\"{nameof(TypeConfigRaw.InterfaceName)}\"" +
		                                                 "\"Screen\"," +
		                                                 $"\"{nameof(TypeConfigRaw.UnityVersionSpecific)}\"" +
		                                                 "false," +
		                                                 $"\"{nameof(TypeConfigRaw.PackageId)}\"" +
		                                                 "\"\"," +
		                                                 $"\"{nameof(TypeConfigRaw.Approach)}\"" +
		                                                 "1," +
		                                                 $"\"{nameof(TypeConfigRaw.DependencyGuids)}\"" +
		                                                 "[]" +
		                                                 "}";

		private IFile CreateFakeIOFile()
		{
			IDictionary<string, string> files = new Dictionary<string, string>();
			files.Add(rootTypesFilePath, rootTypesFileContent);
			files.Add(applicationTypeConfigPath, applicationTypeConfigContent);
			files.Add(screenTypeConfigPath, screenTypeConfigContent);
			return CreateFakeIOFile(files);
		}

		private IFile CreateFakeIOFile(IDictionary<string, string> files)
		{
			Mock<IFile> mock = new Mock<IFile>();
			mock.Setup(file => file.ReadAllText(It.IsAny<string>())).Returns<string>(path => files[path]);
			return mock.Object;
		}

		private AssetDatabase CreateFakeAssetDatabase()
		{
			IDictionary<string, string> files = new Dictionary<string, string>();
			files.Add(rootTypeGuidApplication, applicationTypeConfigPath);
			files.Add(rootTypeGuidScreen, screenTypeConfigPath);
			return CreateFakeAssetDatabase(files);
		}

		private AssetDatabase CreateFakeAssetDatabase(IDictionary<string, string> files)
		{
			Mock<AssetDatabase> mock = new Mock<AssetDatabase>();
			mock.Setup(file => file.GUIDToAssetPath(It.IsAny<string>())).Returns<string>(guid => files[guid]);
			return mock.Object;
		}

		private Factory CreateFakeFactory()
		{
			Mock<Factory> mock = new Mock<Factory>();
			mock.Setup(factory => factory.CreateTypeConfig<ReadonlyTypeConfig>(It.IsAny<TypeConfigRaw>()))
				.Returns<ReadonlyTypeConfig>(raw =>
				{
					Mock<ReadonlyTypeConfig> typeConfigMock = new Mock<ReadonlyTypeConfig>();
					return typeConfigMock.Object;
				});
			return mock.Object;
		}

		private void DefaultConfigsSetter(ReadonlyTypeConfig[] configs)
		{

		}
	}
}
