using System;
using System.Collections.Generic;
using Moq;
using static Grabli.WrappedUnity.CodeGen.FakeSerializedTypes;

namespace Grabli.WrappedUnity.CodeGen
{
	public partial class DefaultDependencyResolverTests
	{
		private Factory CreateFakeFactory()
		{
			Mock<Factory> mock = new Mock<Factory>();
			mock.Setup(factory => factory.CreateTypeConfig<ReadonlyTypeConfig>(It.IsAny<TypeConfigRaw>(),It.IsAny<string>())).Returns<TypeConfigRaw, string>(
				(raw, guid) =>
				{
					Mock<ReadonlyTypeConfig> configMock = new Mock<ReadonlyTypeConfig>();
					configMock.Setup(config => config.Guid).Returns(guid);
					return configMock.Object;
				}
			);
			mock.Setup(factory => factory.GetReader()).Returns(new DefaultTypeReader(mock.Object));
			return mock.Object;
		}

		private static IEnumerable<object[]> GetValidGuidArrays()
		{
			yield return new object[] {new[] {RootTypeGuidApplication}};
			yield return new object[] {new[] {RootTypeGuidApplication, RootTypeGuidScreen}};
			yield return new object[] {new[] {RootTypeGuidScreen}};
			yield return new object[] {Array.Empty<string>()};
		}
	}
}
