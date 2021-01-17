using Moq;

namespace Grabli.WrappedUnity.CodeGen
{
	public partial class RootTypesInitializerTests
	{
		private Factory CreateFakeFactory()
		{
			Mock<Factory> mock = new Mock<Factory>();
			mock.Setup(factory => factory.CreateTypeConfig<ReadonlyTypeConfig>(It.IsAny<TypeConfigRaw>()));
			mock.Setup(factory => factory.GetReader()).Returns(new DefaultTypeReader(mock.Object));
			return mock.Object;
		}

		private void DefaultConfigsSetter(ReadonlyTypeConfig[] configs)
		{
		}
	}
}
