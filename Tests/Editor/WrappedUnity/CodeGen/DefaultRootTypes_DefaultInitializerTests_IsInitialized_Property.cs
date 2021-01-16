using NUnit.Framework;

namespace Grabli.WrappedUnity.CodeGen
{
	public partial class DefaultRootTypes_DefaultInitializerTests
	{
		[Test]
		public void CheckIfIsInitializedDoesntThrow()
		{
			Assert.DoesNotThrow(() =>
			{
				using (new FileContext(CreateFakeIOFile()))
				using (new AssetDatabaseContext(CreateFakeAssetDatabase()))
				{
					var rootTypes = new DefaultRootTypes(rootTypesFilePath);
					var initializer = rootTypes.GetInitializer();
					var isInitialized = initializer.IsInitialized;
				}
			});
		}

		[Test]
		public void CheckIfIsInitializedFalseBeforeInit()
		{
			using (new FileContext(CreateFakeIOFile()))
			using (new AssetDatabaseContext(CreateFakeAssetDatabase()))
			{
				var rootTypes = new DefaultRootTypes(rootTypesFilePath);
				var initializer = rootTypes.GetInitializer();
				var isInitialized = initializer.IsInitialized;
				Assert.IsFalse(isInitialized);
			}
		}

		[Test]
		public void CheckIfIsInitializedTrueAfterInit()
		{
			using (new FileContext(CreateFakeIOFile()))
			using (new AssetDatabaseContext(CreateFakeAssetDatabase()))
			{
				var rootTypes = new DefaultRootTypes(rootTypesFilePath);
				var initializer = rootTypes.GetInitializer();
				initializer.Init();
				var isInitialized = initializer.IsInitialized;
				Assert.IsTrue(isInitialized);
			}
		}

		[Test]
		public void CheckIfIsInitializedFalseAfterDeinit()
		{
			using (new FileContext(CreateFakeIOFile()))
			using (new AssetDatabaseContext(CreateFakeAssetDatabase()))
			{
				var rootTypes = new DefaultRootTypes(rootTypesFilePath);
				var initializer = rootTypes.GetInitializer();
				initializer.Init();
				initializer.Deinit();
				var isInitialized = initializer.IsInitialized;
				Assert.IsFalse(isInitialized);
			}
		}
	}
}
