using System;
using NUnit.Framework;

namespace Grabli.WrappedUnity.CodeGen
{
    public partial class DefaultWritableTypeConfigTests
    {
        [TestCase(typeof(UnityEngine.Application))]
        [TestCase(typeof(UnityEngine.Input))]
        [TestCase(typeof(UnityEngine.Compass))]
        public void CheckSetTypeIfChangesType(Type expected)
        {
            DefaultWritableTypeConfig config = new DefaultWritableTypeConfig(CreateFakeFactory());
            config.SetType(expected);
            Type actual = config.Type;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CheckSetTypeIfParameterIsNull()
        {
            DefaultWritableTypeConfig config = new DefaultWritableTypeConfig(CreateFakeFactory());
            Assert.Throws<ArgumentNullException>(() => config.SetType(null));
        }

        [Test]
        public void CheckSetTypeIfParameterIsInterfaceType()
        {
            DefaultWritableTypeConfig config = new DefaultWritableTypeConfig(CreateFakeFactory());
            Assert.Throws<ArgumentException>(() => config.SetType(typeof(IDisposable)));
        }

        [Test]
        public void CheckSetTypeIfParameterIsDelegateType()
        {
            DefaultWritableTypeConfig config = new DefaultWritableTypeConfig(CreateFakeFactory());
            Assert.Throws<ArgumentException>(() => config.SetType(typeof(EventHandler)));
        }

        [Test]
        public void CheckSetTypeIfParameterIsValueType()
        {
            DefaultWritableTypeConfig config = new DefaultWritableTypeConfig(CreateFakeFactory());
            Assert.Throws<ArgumentException>(() => config.SetType(typeof(int)));
        }
        
        [Test]
        public void CheckSetTypeIfParameterIsEnumType()
        {
            DefaultWritableTypeConfig config = new DefaultWritableTypeConfig(CreateFakeFactory());
            Assert.Throws<ArgumentException>(() => config.SetType(typeof(AttributeTargets)));
        }
        
        [Test]
        public void CheckSetTypeIfParameterIsAttributeType()
        {
            DefaultWritableTypeConfig config = new DefaultWritableTypeConfig(CreateFakeFactory());
            Assert.Throws<ArgumentException>(() => config.SetType(typeof(SerializableAttribute)));
        }

        [Test]
        public void CheckSetTypeIfParameterIsVoid()
        {
            DefaultWritableTypeConfig config = new DefaultWritableTypeConfig(CreateFakeFactory());
            Assert.Throws<ArgumentException>(() => config.SetType(typeof(void)));
        }
    }
}