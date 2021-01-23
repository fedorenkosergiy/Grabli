using Moq;

namespace Grabli.WrappedUnity.CodeGen
{
    public partial class DefaultTypeReaderTests
    {
        private Factory CreateFakeFactory()
        {
            Mock<Factory> mock = new Mock<Factory>();
            mock.Setup(factory => factory.CreateTypeConfig<ReadonlyTypeConfig>(It.IsAny<string>())).Returns<string>(
                (guid) =>
                {
                    Mock<ReadonlyTypeConfig> configMock = new Mock<ReadonlyTypeConfig>();
                    configMock.Setup(config => config.Guid).Returns(guid);

                    Mock<Initializer> configInitializerMock = new Mock<Initializer>();
                    configMock.Setup(config => config.GetInitializer()).Returns(configInitializerMock.Object);
                    return configMock.Object;
                }
            );
            mock.Setup(factory => factory.GetReader()).Returns(new DefaultTypeReader(mock.Object));
            return mock.Object;
        }
    }
}