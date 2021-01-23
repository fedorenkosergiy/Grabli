using System;
using System.Collections.Generic;
using Moq;
using static Grabli.WrappedUnity.CodeGen.FakeSerializedTypes;

namespace Grabli.WrappedUnity.CodeGen
{
    public partial class DefaultDependencyResolverTests
    {
        private class FakeFactory : DefaultFactory
        {
            public override DependenciesResolver GetResolver()
            {
                return new DefaultDependenciesResolver(this);
            }
        }

        private Factory CreateFakeFactory()
        {
            return new FakeFactory();
        }

        private static IEnumerable<object[]> GetValidGuidArrays()
        {
            yield return new object[] {new[] {RootTypeGuidApplication}};
            yield return new object[] {new[] {RootTypeGuidApplication, RootTypeGuidScreen}};
            yield return new object[] {new[] {RootTypeGuidScreen}};
            yield return new object[] {Array.Empty<string>()};
        }
    }
}