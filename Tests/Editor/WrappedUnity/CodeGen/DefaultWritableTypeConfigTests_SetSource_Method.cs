using NUnit.Framework;
using System;
using static Grabli.WrappedUnity.CodeGen.FakeSerializedTypes;

namespace Grabli.WrappedUnity.CodeGen
{
    public partial class DefaultWritableTypeConfigTests
    {
        [Test]
        public void CheckSetSourceIfWorksWithValidData()
        {
            using (new FileContext(CreateFakeIOFile()))
            using (new AssetDatabaseContext(CreateFakeAssetDatabase()))
            {
                Factory factory = CreateFakeFactory();
                ReadonlyTypeConfig source = factory.CreateTypeConfig<ReadonlyTypeConfig>(RootTypeGuidInput);
                Initializer initializer = source.GetInitializer();
                initializer.Init();
                DependenciesResolver resolver = factory.GetResolver();
                source.ResolveDependencies(resolver);

                DefaultWritableTypeConfig config = new DefaultWritableTypeConfig(factory);
                config.SetSource(source, resolver);

                TypeConfigRaw expected = source.ToRaw();
                TypeConfigRaw actual = config.ToRaw();
                Assert.AreEqual(expected, actual);
            }
        }

        [Test]
        public void CheckSetSourceIfSourceIsNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                using (new FileContext(CreateFakeIOFile()))
                using (new AssetDatabaseContext(CreateFakeAssetDatabase()))
                {
                    Factory factory = CreateFakeFactory();
                    DependenciesResolver resolver = factory.GetResolver();
                    DefaultWritableTypeConfig config = new DefaultWritableTypeConfig(factory);
                    config.SetSource(null, resolver);
                }
            });
        }

        [Test]
        public void CheckSetSourceIfResolverIsNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                using (new FileContext(CreateFakeIOFile()))
                using (new AssetDatabaseContext(CreateFakeAssetDatabase()))
                {
                    Factory factory = CreateFakeFactory();
                    ReadonlyTypeConfig source = factory.CreateTypeConfig<ReadonlyTypeConfig>(RootTypeGuidInput);
                    Initializer initializer = source.GetInitializer();
                    initializer.Init();
                    DependenciesResolver resolver = factory.GetResolver();
                    source.ResolveDependencies(resolver);

                    DefaultWritableTypeConfig config = new DefaultWritableTypeConfig(factory);
                    config.SetSource(source, null);
                }
            });
        }

        [Test]
        public void CheckSetSourceIfSourceIsNotResolved()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                using (new FileContext(CreateFakeIOFile()))
                using (new AssetDatabaseContext(CreateFakeAssetDatabase()))
                {
                    Factory factory = CreateFakeFactory();
                    ReadonlyTypeConfig source = factory.CreateTypeConfig<ReadonlyTypeConfig>(RootTypeGuidInput);
                    Initializer initializer = source.GetInitializer();
                    initializer.Init();

                    DefaultWritableTypeConfig config = new DefaultWritableTypeConfig(factory);
                    DependenciesResolver resolver = factory.GetResolver();
                    config.SetSource(source, resolver);
                }
            });
        }
        
        [Test]
        public void CheckSetSourceIfSourceIsNotInitialized()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                using (new FileContext(CreateFakeIOFile()))
                using (new AssetDatabaseContext(CreateFakeAssetDatabase()))
                {
                    Factory factory = CreateFakeFactory();
                    ReadonlyTypeConfig source = factory.CreateTypeConfig<ReadonlyTypeConfig>(RootTypeGuidInput);

                    DefaultWritableTypeConfig config = new DefaultWritableTypeConfig(factory);
                    DependenciesResolver resolver = factory.GetResolver();
                    config.SetSource(source, resolver);
                }
            });
        }
    }
}