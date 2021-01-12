using System;

namespace Grabli.WrappedUnity.CodeGen
{
	public interface ReadonlyTypeHandlingConfig
	{
		Guid Guid { get; }
		Type Type { get; }
		string InterfaceName { get; }
		string ClassName { get; }
		bool UnityVersionSpecific { get; }
		string PackageId { get; }
		Approach Approach { get; }
		ReadonlyTypeHandlingConfig[] Dependencies { get; }
	}
}
