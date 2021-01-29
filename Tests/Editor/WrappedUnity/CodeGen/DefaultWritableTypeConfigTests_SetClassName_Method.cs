using NUnit.Framework;
using System;

namespace Grabli.WrappedUnity.CodeGen
{
    public partial class DefaultWritableTypeConfigTests
    {
        [Test]
        public void CheckSetClassNameIfArgumentNull()
        {
            DefaultWritableTypeConfig config = new DefaultWritableTypeConfig(CreateFakeFactory());
            Assert.Throws<ArgumentNullException>(() => config.SetClassName(null));
        }
        
        [Test]
        public void CheckSetClassNameIfArgumentEmpty()
        {
            DefaultWritableTypeConfig config = new DefaultWritableTypeConfig(CreateFakeFactory());
            Assert.Throws<ArgumentException>(() => config.SetClassName(string.Empty));
        }
        
        [TestCase("Name")]
        [TestCase("CName")]
        [TestCase("MyClass")]
        public void CheckSetClassNameIfWorks(string expectedName)
        {
            DefaultWritableTypeConfig config = new DefaultWritableTypeConfig(CreateFakeFactory());
            config.SetClassName(expectedName);
            string actualName = config.ClassName;
            Assert.AreEqual(expectedName, actualName);
        }
    }
}