using NUnit.Framework;
using System;
using UnityEngine;
using static Grabli.WrappedUnity.CodeGen.FakeSerializedTypes;

namespace Grabli.WrappedUnity.CodeGen
{
    public partial class DefaultReadonlyTypeConfigTests
    {
        [TestCase(RootTypeGuidApplication)]
        [TestCase(RootTypeGuidScreen)]
        public void CheckNamespaceIfThrowsWhenNotInitialized(string guid)
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                Factory factory = CreateFakeFactory();
                DefaultReadonlyTypeConfig config = new DefaultReadonlyTypeConfig(factory, guid);
                string unused = config.Namespace;
            });
        }
        
        [TestCase(RootTypeGuidApplication, "Grabli.WrappedUnity")]
        [TestCase(RootTypeGuidScreen, "Grabli.WrappedUnity")]
        public void CheckNamespaceIfWorks(string guid, string expected)
        {
            using (new FileContext(CreateFakeIOFile()))
            using (new AssetDatabaseContext(CreateFakeAssetDatabase()))
            {
                Factory factory = CreateFakeFactory();
                DefaultReadonlyTypeConfig config = new DefaultReadonlyTypeConfig(factory, guid);
                Initializer initializer = config.GetInitializer();
                initializer.Init();
                string actual = config.Namespace;
                Assert.AreEqual(expected, actual);
            }
        }
    }
}