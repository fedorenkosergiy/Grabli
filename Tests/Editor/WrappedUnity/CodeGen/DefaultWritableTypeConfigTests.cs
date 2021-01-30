using System;
using System.Collections.Generic;

namespace Grabli.WrappedUnity.CodeGen
{
    public partial class DefaultWritableTypeConfigTests
    {
        private const string maxLongPackageId =
            "com.grabli.aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
            "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
            "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
            "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";

        private const string tooLongPackageId = maxLongPackageId + "a";

        private static Factory CreateFakeFactory()
        {
            return new DefaultFactory();
        }

        private static IEnumerable<object[]> GetAllApproachValues()
        {
            Array values = Enum.GetValues(typeof(Approach));
            for (int i = 0; i < values.Length; ++i)
            {
                yield return new[] {values.GetValue(i)};
            }
        }
        
        private static IEnumerable<object[]> GetAllApproachValuesExceptUndefined()
        {
            Array values = Enum.GetValues(typeof(Approach));
            for (int i = 0; i < values.Length; ++i)
            {
                if (values.GetValue(i).Equals(Approach.Undefined))
                {
                    continue;
                }
                yield return new[] {values.GetValue(i)};
            }
        }
    }
}