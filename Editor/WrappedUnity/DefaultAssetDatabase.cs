namespace Grabli.WrappedUnity
{
	public class DefaultAssetDatabase : AssetDatabase
	{
		public string GUIDToAssetPath(string guid)
		{
			return UnityEditor.AssetDatabase.GUIDToAssetPath(guid);
		}
	}
}
