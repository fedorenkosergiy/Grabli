using NUnit.Framework;
using System;

namespace Grabli.WrappedUnity.CodeGen
{
    public partial class DefaultWritableTypeConfigTests
    {
        [Test]
        public void CheckSetSpaceNameIfArgumentNull()
        {
            DefaultWritableTypeConfig config = new DefaultWritableTypeConfig(CreateFakeFactory());
            Assert.Throws<ArgumentNullException>(() => config.SetSpaceName(null));
        }
        
        [Test]
        public void CheckSetSpaceNameIfArgumentEmpty()
        {
            DefaultWritableTypeConfig config = new DefaultWritableTypeConfig(CreateFakeFactory());
            Assert.Throws<ArgumentException>(() => config.SetSpaceName(string.Empty));
        }
        
        [TestCase("Name")]
        [TestCase("SpaceName")]
        [TestCase("MySpace")]
        public void CheckSetSpaceNameIfWorks(string expectedName)
        {
            DefaultWritableTypeConfig config = new DefaultWritableTypeConfig(CreateFakeFactory());
            config.SetSpaceName(expectedName);
            string actualName = config.SpaceName;
            Assert.AreEqual(expectedName, actualName);
        }
    }
}