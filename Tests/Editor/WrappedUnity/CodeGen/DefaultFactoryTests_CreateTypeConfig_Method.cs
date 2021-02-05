using NUnit.Framework;
using System;
using static Grabli.WrappedUnity.CodeGen.FakeSerializedTypes;

namespace Grabli.WrappedUnity.CodeGen
{
    public partial class DefaultFactoryTests
    {
        [Test]
        public void CheckCreateTypeConfigIfThrowsWhenTypeParameterIsNotSupported()
        {
            DefaultFactory factory = new DefaultFactory();
            Assert.Throws<InvalidOperationException>(() =>
            {
                factory.CreateTypeConfig<UnsupportedTypeConfig>(RootTypeGuidInput);
            });
        }
    }
}