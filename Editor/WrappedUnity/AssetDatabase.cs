namespace Grabli.WrappedUnity
{
	public interface AssetDatabase
	{
		/// <summary>
		/// Gets the corresponding asset path for the supplied guid, or an empty string if the GUID can't be found.
		/// </summary>
		/// <param name="guid"></param>
		/// <returns></returns>
		string GUIDToAssetPath(string guid);
	}
}
