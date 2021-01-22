using Moq;
using NUnit.Framework;
using System;
using static Grabli.WrappedUnity.CodeGen.FakeSerializedTypes;

namespace Grabli.WrappedUnity.CodeGen
{
    public partial class DefaultReadonlyTypeConfigTests
    {
        [TestCase(RootTypeGuidApplication)]
        [TestCase(RootTypeGuidScreen)]
        public void CheckResolveDependenciesIdIfThrowsWhenNotInitialized(string guid)
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                DefaultReadonlyTypeConfig config = new DefaultReadonlyTypeConfig(guid);
                Mock<Factory> factoryMock = new Mock<Factory>();
                DependenciesResolver resolver = new DefaultDependenciesResolver(factoryMock.Object);
                config.ResolveDependencies(resolver);
            });
        }
    }
}