using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;

namespace Grabli.WrappedUnity.CodeGen
{
    public partial class TypeConfigExTests
    {
        private static IEnumerable<object[]> CheckIfToRawWorksWellCases()
        {
            const string devendencyGuid = "94adff62137b4f87ae41bc0e3b48b1e5";
            Mock<ReadonlyTypeConfig> dependencyMock = new Mock<ReadonlyTypeConfig>();
            Mock<Initializer> initializer = new Mock<Initializer>();
            initializer.Setup(i => i.IsInitialized).Returns(true);
            dependencyMock.Setup(c => c.Guid).Returns(devendencyGuid);

            {
                var mock = new Mock<ReadonlyTypeConfig>();
                mock.Setup(c => c.Approach).Returns(Approach.EncapsulateStaticType);
                mock.Setup(c => c.Dependencies).Returns(() => new[] {dependencyMock.Object});
                mock.Setup(c => c.Guid).Returns("bbe5884a1b6f4ab396273b7b84302786");
                mock.Setup(c => c.SpaceName).Returns("Grabli.WrappedUnity");
                mock.Setup(c => c.Type).Returns(typeof(UnityEngine.PlayerPrefs));
                mock.Setup(c => c.ClassName).Returns("DefaultPlayerPrefs");
                mock.Setup(c => c.InterfaceName).Returns("PlayerPrefs");
                mock.Setup(c => c.PackageId).Returns(string.Empty);
                mock.Setup(c => c.UnityVersionSpecific).Returns(false);
                mock.Setup(c => c.GetInitializer()).Returns(initializer.Object);

                var raw = new TypeConfigRaw();
                raw.Approach = Approach.EncapsulateStaticType;
                raw.DependencyGuids = new[] {devendencyGuid};
                raw.SpaceName = "Grabli.WrappedUnity";
                raw.ClassName = "DefaultPlayerPrefs";
                raw.InterfaceName = "PlayerPrefs";
                raw.PackageId = string.Empty;
                raw.FullTypeName = "UnityEngine.PlayerPrefs";
                raw.UnityVersionSpecific = false;
                yield return new object[] {mock.Object, raw};
            }
        }

        [TestCaseSource(nameof(CheckIfToRawWorksWellCases))]
        public void CheckIfToRawWorksWell(ReadonlyTypeConfig config, TypeConfigRaw expected)
        {
            var actual = config.ToRaw();
            Assert.AreEqual(expected, actual);
        }
    }
}