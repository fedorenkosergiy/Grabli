using NUnit.Framework;
using static Grabli.WrappedUnity.CodeGen.FakeSerializedTypes;

namespace Grabli.WrappedUnity.CodeGen
{
    public partial class TypeReaderExTests
    {
        [TestCase(null, false)]
        [TestCase("", false)]
        [TestCase(RootTypeGuidApplication, true)]
        [TestCase(RootTypeGuidScreen, true)]
        public void CheckTryRead(string guid, bool expectedResult)
        {
            using (new FileContext(CreateFakeIOFile()))
            using (new AssetDatabaseContext(CreateFakeAssetDatabase()))
            {
                var reader = new DefaultTypeReader(CreateFakeFactory());
                bool actual = reader.TryRead(guid, out ReadonlyTypeConfig config);
                Assert.AreEqual(expectedResult, actual);
            }
        }
    }
}