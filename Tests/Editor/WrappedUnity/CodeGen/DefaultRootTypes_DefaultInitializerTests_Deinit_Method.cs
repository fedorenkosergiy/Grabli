using System;
using NUnit.Framework;

namespace Grabli.WrappedUnity.CodeGen
{
	public partial class DefaultRootTypes_DefaultInitializerTests
	{
		[Test]
		public void CheckIfDeinitDoesntThrowAfterInitialized()
		{
			Assert.DoesNotThrow(() =>
			{
				using (new FileContext(CreateFakeIOFile()))
				using (new AssetDatabaseContext(CreateFakeAssetDatabase()))
				{
					var rootTypes = new DefaultRootTypes(rootTypesFilePath);
					var initializer = rootTypes.GetInitializer();
					initializer.Init();
					initializer.Deinit();
				}
			});
		}

		[Test]
		public void CheckIfDeinitThrowsTheSecondTime()
		{
			Assert.Catch<InvalidOperationException>(() =>
			{
				using (new FileContext(CreateFakeIOFile()))
				using (new AssetDatabaseContext(CreateFakeAssetDatabase()))
				{
					var rootTypes = new DefaultRootTypes(rootTypesFilePath);
					var initializer = rootTypes.GetInitializer();
					initializer.Init();
					initializer.Deinit();
					initializer.Deinit();
				}
			});
		}

		[Test]
		public void CheckIfDeinitThrowsIfNotInitialized()
		{
			Assert.Catch<InvalidOperationException>(() =>
			{
				using (new FileContext(CreateFakeIOFile()))
				using (new AssetDatabaseContext(CreateFakeAssetDatabase()))
				{
					var rootTypes = new DefaultRootTypes(rootTypesFilePath);
					var initializer = rootTypes.GetInitializer();
					initializer.Deinit();
				}
			});
		}
	}
}

