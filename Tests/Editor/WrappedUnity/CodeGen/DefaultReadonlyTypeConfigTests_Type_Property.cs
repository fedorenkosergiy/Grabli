﻿using NUnit.Framework;
using System;
using UnityEngine;
using static Grabli.WrappedUnity.CodeGen.FakeSerializedTypes;

namespace Grabli.WrappedUnity.CodeGen
{
    public partial class DefaultReadonlyTypeConfigTests
    {
        [TestCase(RootTypeGuidApplication)]
        [TestCase(RootTypeGuidScreen)]
        public void CheckTypeIfThrowsWhenNotInitialized(string guid)
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                Factory factory = CreateFakeFactory();
                DefaultReadonlyTypeConfig config = new DefaultReadonlyTypeConfig(factory, guid);
                Type unused = config.Type;
            });
        }
    }
}