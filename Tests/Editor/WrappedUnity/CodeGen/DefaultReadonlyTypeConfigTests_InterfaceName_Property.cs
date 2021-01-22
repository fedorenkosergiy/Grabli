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
        public void CheckInterfaceNameIfThrowsWhenNotInitialized(string guid)
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                DefaultReadonlyTypeConfig config = new DefaultReadonlyTypeConfig(guid);
                string unused = config.InterfaceName;
            });
        }
    }
}