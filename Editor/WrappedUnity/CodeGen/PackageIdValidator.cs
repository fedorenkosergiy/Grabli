using System.Text.RegularExpressions;

namespace Grabli.WrappedUnity.CodeGen
{
    public class PackageIdValidator : Validator
    {
        private readonly string packageId;

        public PackageIdValidator(string packageId)
        {
            this.packageId = packageId;
        }

        public bool IsValid(out string message)
        {
            //docs.unity3d.com/Manual/cus-naming.html
            message = string.Empty;
            const int maxLength = 214;
            const string pattern = "(com\\.)([a-z]|[\\d_\\-])+\\.([a-z]|[\\d_\\-\\.])+";
            if (packageId.IsNull())
            {
                message = "Package ID is null";
            }
            else if (packageId.IsEmpty())
            {
                message = "Package ID is empty";
            }
            else if (packageId.Length > maxLength)
            {
                message = "Package ID is too long";
            }
            else if (!Regex.IsMatch(packageId, pattern))
            {
                message = "Package ID has wrong format";
            }

            return message.IsEmpty();
        }
    }
}