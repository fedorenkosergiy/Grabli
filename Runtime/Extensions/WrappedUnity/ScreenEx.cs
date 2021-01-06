using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Grabli.WrappedUnity
{
	public static class ScreenEx
	{
		public static Vector2Int GetSize(this Screen screen) => new Vector2Int(screen.width, screen.height);
	}
}
