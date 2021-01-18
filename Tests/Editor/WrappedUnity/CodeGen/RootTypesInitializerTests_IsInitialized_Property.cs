﻿using NUnit.Framework;
using static Grabli.WrappedUnity.CodeGen.FakeSerializedTypes;

namespace Grabli.WrappedUnity.CodeGen
{
	public partial class RootTypesInitializerTests
	{
		[Test]
		public void CheckIfIsInitializedDoesntThrow()
		{
			Assert.DoesNotThrow(() =>
			{
				using (new FileContext(CreateFakeIOFile()))
				using (new AssetDatabaseContext(CreateFakeAssetDatabase()))
				{
					var initializer =
						new RootTypesInitializer(CreateFakeFactory(), RootTypesFilePath, DefaultConfigsSetter);
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
				var initializer = new RootTypesInitializer(CreateFakeFactory(), RootTypesFilePath, DefaultConfigsSetter);
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
				var initializer = new RootTypesInitializer(CreateFakeFactory(), RootTypesFilePath, DefaultConfigsSetter);
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
				var initializer = new RootTypesInitializer(CreateFakeFactory(), RootTypesFilePath, DefaultConfigsSetter);
				initializer.Init();
				initializer.Deinit();
				var isInitialized = initializer.IsInitialized;
				Assert.IsFalse(isInitialized);
			}
		}
	}
}