using SystemInterface.IO;
using NUnit.Framework;

namespace Grabli.WrappedUnity.CodeGen
{
	public partial class DefaultRootTypes_DefaultInitializerTests
	{
		[Test]
		public void CheckIfInitDoesntThrow()
		{
			Assert.DoesNotThrow(() =>
			{
				using (new FileContext(CreateFakeIOFile()))
				using (new AssetDatabaseContext(CreateFakeAssetDatabase()))
				{
					var rootTypes = new DefaultRootTypes(rootTypesFilePath);
					var initializer = rootTypes.GetInitializer();
					initializer.Init();
				}
			});
		}
	}
}
