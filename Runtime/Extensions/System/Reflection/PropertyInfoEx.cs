namespace System.Reflection
{
	public static class PropertyInfoEx
	{
		public static bool HasGetter(this PropertyInfo propertyInfo)
		{
			MethodInfo[] methods = propertyInfo.GetAccessors();
			for (int i = 0; i < methods.Length; i++)
			{
				if (methods[i].ReturnType != null)
				{
					return true;
				}
			}
			return false;
		}

		public static bool HasPublicGetter(this PropertyInfo propertyInfo)
		{
			MethodInfo[] methods = propertyInfo.GetAccessors();
			for (int i = 0; i < methods.Length; i++)
			{
				if (methods[i].ReturnType != null && methods[i].IsPublic)
				{
					return true;
				}
			}
			return false;
		}
	}
}
