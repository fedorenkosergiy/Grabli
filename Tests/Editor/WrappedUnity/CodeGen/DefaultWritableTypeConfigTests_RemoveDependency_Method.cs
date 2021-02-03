﻿using NUnit.Framework;
using System;
using static Grabli.WrappedUnity.CodeGen.FakeSerializedTypes;

namespace Grabli.WrappedUnity.CodeGen
{
    public partial class DefaultWritableTypeConfigTests
    {
        [Test]
        public void CheckRemoveDependencyIfWorks()
        {
            Factory factory = CreateFakeFactory();
            DefaultWritableTypeConfig config = new DefaultWritableTypeConfig(factory, RootTypeGuidInput);
            TypeConfig dependency = factory.CreateTypeConfig<WritableTypeConfig>(TypeGuidCompas);
            config.AddDependency(dependency);
            config.RemoveDependency(dependency);
            config.ResolveDependencies(factory.GetResolver());
            Assert.IsFalse(config.IsDependentOn(dependency));
        }

        [Test]
        public void CheckRemoveDependencyIfThrowsWhenIsNothingToRemove()
        {
            Factory factory = CreateFakeFactory();
            DefaultWritableTypeConfig config = new DefaultWritableTypeConfig(factory, RootTypeGuidInput);
            TypeConfig dependency = factory.CreateTypeConfig<WritableTypeConfig>(TypeGuidCompas);
            Assert.Throws<ArgumentException>(() => config.RemoveDependency(dependency));
        }

        [Test]
        public void CheckRemoveDependencyIfThrowsWhenNull()
        {
            Factory factory = CreateFakeFactory();
            DefaultWritableTypeConfig config = new DefaultWritableTypeConfig(factory, RootTypeGuidInput);
            Assert.Throws<ArgumentNullException>(() => config.RemoveDependency(null));
        }
        
        [Test]
        public void CheckRemoveDependencyIfRequireResolutionAfter()
        {
            using (new FileContext(CreateFakeIOFile()))
            using (new AssetDatabaseContext(CreateFakeAssetDatabase()))
            {
                Factory factory = CreateFakeFactory();
                DefaultWritableTypeConfig config = new DefaultWritableTypeConfig(factory, RootTypeGuidInput);
                TypeConfig dependency = factory.CreateTypeConfig<WritableTypeConfig>(TypeGuidCompas);
                config.AddDependency(dependency);
                config.ResolveDependencies(factory.GetResolver());
                config.RemoveDependency(dependency);
                Assert.IsFalse(config.IsDependenciesResolved());
            }
        }
    }
}