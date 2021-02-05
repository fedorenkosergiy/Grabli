using NUnit.Framework;

namespace Grabli.WrappedUnity.CodeGen
{
    public partial class WritableTypeConfigExTests
    {
        [Test]
        public void CheckSetApproachIfWorks()
        {
            DefaultWritableTypeConfig config = new DefaultWritableTypeConfig(CreateFakeFactory());
            config.ResetApproach();
            const Approach expected = Approach.Undefined;
            Approach actual = config.Approach;
            Assert.AreEqual(expected, actual);
        }
    }
}