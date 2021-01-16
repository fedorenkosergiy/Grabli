using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grabli.WrappedUnity.CodeGen
{
	public interface RootTypes : Initializable
	{
		ReadonlyTypeConfig[] Configs { get; }
	}
}
