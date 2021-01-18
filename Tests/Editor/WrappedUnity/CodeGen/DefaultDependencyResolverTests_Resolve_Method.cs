using System;
using NUnit.Framework;
using static Grabli.WrappedUnity.CodeGen.FakeSerializedTypes;

namespace Grabli.WrappedUnity.CodeGen
{
	public partial class DefaultDependencyResolverTests
	{
		[TestCaseSource(nameof(GetValidGuidArrays))]
		public void CheckResolveIsWorking(string[] guids)
		{
			using (new FileContext(CreateFakeIOFile()))
			using (new AssetDatabaseContext(CreateFakeAssetDatabase()))
			{
				var resolver = new DefaultDependencyResolver(CreateFakeFactory());
				var configs = resolver.Resolve(guids);
				for (int i = 0; i < guids.Length; ++i)
				{
					Assert.AreEqual(guids[i], configs[i].Guid);
				}
			}
		}

		[Test]
		public void ChkechResolveWithNullParameter()
		{
			using (new FileContext(CreateFakeIOFile()))
			using (new AssetDatabaseContext(CreateFakeAssetDatabase()))
			{
				var resolver = new DefaultDependencyResolver(CreateFakeFactory());
				Assert.Throws<ArgumentNullException>(() => { resolver.Resolve(null); });
			}
		}
	}
}
