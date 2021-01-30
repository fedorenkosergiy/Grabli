using NUnit.Framework;
using System;
using static Grabli.WrappedUnity.CodeGen.FakeSerializedTypes;

namespace Grabli.WrappedUnity.CodeGen
{
    public partial class DefaultWritableTypeConfigTests
    {
        [Test]
        public void CheckAddDependencyIfWorks()
        {
            Factory factory = CreateFakeFactory();
            DefaultWritableTypeConfig config = new DefaultWritableTypeConfig(factory, RootTypeGuidInput);
            TypeConfig dependency = factory.CreateTypeConfig<WritableTypeConfig>(TypeGuidCompas);
            config.AddDependency(dependency);
            Assert.IsTrue(config.IsDependentOn(dependency));
        }

        [Test]
        public void CheckAddDependencyIfThrowsWhenAlreadyAdded()
        {
            Factory factory = CreateFakeFactory();
            DefaultWritableTypeConfig config = new DefaultWritableTypeConfig(factory, RootTypeGuidInput);
            TypeConfig dependency = factory.CreateTypeConfig<WritableTypeConfig>(TypeGuidCompas);
            config.AddDependency(dependency);
            Assert.Throws<ArgumentException>(() => config.AddDependency(dependency));
        }
        
        [Test]
        public void CheckAddDependencyIfThrowsWhenNull()
        {
            Factory factory = CreateFakeFactory();
            DefaultWritableTypeConfig config = new DefaultWritableTypeConfig(factory, RootTypeGuidInput);
            Assert.Throws<ArgumentNullException>(() => config.AddDependency(null));
        }
    }
}