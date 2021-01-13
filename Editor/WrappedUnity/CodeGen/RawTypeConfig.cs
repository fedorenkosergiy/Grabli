using System;

namespace Grabli.WrappedUnity.CodeGen
{
	[Serializable]
	public struct RawTypeConfig
	{
		public string FullTypeName;
		public string Namespace;
		public string InterfaceName;
		public string ClassName;
		public bool UnityVersionSpecific;
		public string PackageId;
		public Approach Approach;
		public string[] Dependencies;
	}
}
