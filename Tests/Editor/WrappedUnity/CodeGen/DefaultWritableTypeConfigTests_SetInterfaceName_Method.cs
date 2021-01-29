﻿using NUnit.Framework;
using System;

namespace Grabli.WrappedUnity.CodeGen
{
    public partial class DefaultWritableTypeConfigTests
    {
        [Test]
        public void CheckSetInterfaceNameIfArgumentNull()
        {
            DefaultWritableTypeConfig config = new DefaultWritableTypeConfig(CreateFakeFactory());
            Assert.Throws<ArgumentNullException>(() => config.SetInterfaceName(null));
        }
        
        [Test]
        public void CheckSetInterfaceNameIfArgumentEmpty()
        {
            DefaultWritableTypeConfig config = new DefaultWritableTypeConfig(CreateFakeFactory());
            Assert.Throws<ArgumentException>(() => config.SetInterfaceName(string.Empty));
        }
        
        [TestCase("Name")]
        [TestCase("IName")]
        [TestCase("InterfaceName")]
        public void CheckSetInterfaceNameIfWorks(string expectedName)
        {
            DefaultWritableTypeConfig config = new DefaultWritableTypeConfig(CreateFakeFactory());
            config.SetInterfaceName(expectedName);
            string actualName = config.InterfaceName;
            Assert.AreEqual(expectedName, actualName);
        }
    }
}