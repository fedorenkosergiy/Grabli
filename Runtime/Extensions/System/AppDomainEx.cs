using System.Collections.Generic;
using System.Reflection;

namespace System
{
	using FilteredAssemblies = Dictionary<Type, List<Assembly>>;
	using DomainsCache = Dictionary<AppDomain, Dictionary<Type, List<Assembly>>>;

	public static class AppDomainEx
	{
		private static Dictionary<AppDomain, List<Assembly>> allAssemblies = new Dictionary<AppDomain, List<Assembly>>();
		private static DomainsCache domains = new DomainsCache();

		public static IReadOnlyList<Assembly> FilterAssemblies<T>(this AppDomain domain) where T : Attribute
		{
			List<Assembly> assemblies;
			if (domains.TryGetValue(domain, out FilteredAssemblies filteredAssemblies))
			{
				if (filteredAssemblies.TryGetValue(typeof(T), out assemblies))
				{
					return assemblies;
				}
				else
				{
					assemblies = AddFilteredList<T>(filteredAssemblies);
				}
			}
			else
			{
				filteredAssemblies = new FilteredAssemblies();
				assemblies = AddFilteredList<T>(filteredAssemblies);
				domains.Add(domain, filteredAssemblies);
			}

			List<Assembly> allAssemblies = GetAllAssemblies(domain);
			List<Assembly> result = new List<Assembly>(allAssemblies.Count);
			for (int i = 0; i < allAssemblies.Count; i++)
			{
				if (allAssemblies[i].GetCustomAttribute<T>() != null)
				{
					assemblies.Add(allAssemblies[i]);
				}
			}
			return assemblies;
		}

		public static List<Assembly> GetAllAssemblies(this AppDomain domain)
		{
			if (allAssemblies.TryGetValue(domain, out List<Assembly> assemblies))
			{
				return assemblies;
			}
			assemblies = new List<Assembly>();
			assemblies.AddRange(domain.GetAssemblies());
			allAssemblies.Add(domain, assemblies);
			return assemblies;
		}

		private static List<Assembly> AddFilteredList<T>(FilteredAssemblies filtered) where T : Attribute
		{
			List<Assembly> assemblies = new List<Assembly>();
			filtered.Add(typeof(T), assemblies);
			return assemblies;
		}

		public static Assembly GetAssembly(this AppDomain domain, string name)
		{
			return domain.GetAllAssemblies().Find(a => a.GetName().Name == name);
		}

#if	UNITY_EDITOR
		[UnityEditor.Callbacks.DidReloadScripts]
		private static void ClearCache()
		{
			domains.Clear();
			allAssemblies.Clear();
		}
#endif
	}
}
