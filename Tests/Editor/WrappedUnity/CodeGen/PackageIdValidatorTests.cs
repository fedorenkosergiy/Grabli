namespace Grabli.WrappedUnity.CodeGen
{
    public partial class PackageIdValidatorTests
    {
        private const string maxLongPackageId =
            "com.grabli.aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
            "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
            "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
            "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";

        private const string tooLongPackageId = maxLongPackageId + "a";
    }
}