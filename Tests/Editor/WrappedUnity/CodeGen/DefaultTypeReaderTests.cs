using Moq;

namespace Grabli.WrappedUnity.CodeGen
{
	public partial class DefaultTypeReaderTests
	{
		private Factory CreateFakeFactory()
		{
			Mock<Factory> mock = new Mock<Factory>();
			mock.Setup(factory => factory.CreateTypeConfig<ReadonlyTypeConfig>(It.IsAny<TypeConfigRaw>())).Returns<TypeConfigRaw>(
				raw =>
				{
					Mock<ReadonlyTypeConfig> configMock = new Mock<ReadonlyTypeConfig>();
					return configMock.Object;
				});
			mock.Setup(factory => factory.GetReader()).Returns(new DefaultTypeReader(mock.Object));
			return mock.Object;
		}
	}
}
