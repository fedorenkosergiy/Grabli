using System;
using System.Collections.Generic;

namespace Grabli.WrappedUnity.CodeGen
{
	public partial class TypeConfigRawTests
	{
		private static IEnumerable<object[]> GetDifferentConfigs()
		{
			foreach (var pair in GetDifferentValidConfigs())
			{
				yield return pair;
			}

			{
				object[] result = new object[2];
				result[0] = GetConfigWithNullDependencies();
				result[1] = GetConfigWithoutDependencies();
				yield return result;
			}
		}

		private static IEnumerable<object[]> GetDifferentValidConfigs()
		{
			{
				object[] result = new object[2];
				result[0] = GetConfigA();
				result[1] = GetConfigBWithOneDependency();
				yield return result;
			}

			{
				object[] result = new object[2];
				result[0] = GetConfigA();
				result[1] = GetConfigCWithOneDependency();
				yield return result;
			}

			{
				object[] result = new object[2];
				result[0] = GetConfigBWithOneDependency();
				result[1] = GetConfigCWithOneDependency();
				yield return result;
			}
			{
				object[] result = new object[2];
				result[0] = GetConfigA();
				result[1] = GetConfigWithoutDependencies();
				yield return result;
			}
			{
				object[] result = new object[2];
				result[0] = GetConfigBWithOneDependency();
				result[1] = GetConfigWithoutDependencies();
				yield return result;
			}
			{
				object[] result = new object[2];
				result[0] = GetConfigCWithOneDependency();
				result[1] = GetConfigWithoutDependencies();
				yield return result;
			}
		}

		private static TypeConfigRaw GetConfigA()
		{
			var a = new TypeConfigRaw();
			a.Approach = Approach.WrapClass;
			a.SpaceName = "Namespace";
			a.ClassName = "MyClass";
			a.DependencyGuids = new[] {"5cd1a9f2bb154572ad277ace454042e4", "cc8bd0cdeac44458813e3ba235d834dc"};
			a.InterfaceName = "MyInterface";
			a.PackageId = string.Empty;
			a.FullTypeName = "MyType";
			a.UnityVersionSpecific = false;
			return a;
		}

		private static TypeConfigRaw GetConfigBWithOneDependency()
		{
			var a = new TypeConfigRaw();
			a.Approach = Approach.WrapClass;
			a.SpaceName = "Namespace";
			a.ClassName = "MyClass";
			a.DependencyGuids = new[] {"8ad1220447fd4c779ae53776d250f135"};
			a.InterfaceName = "MyInterface";
			a.PackageId = string.Empty;
			a.FullTypeName = "MyType";
			a.UnityVersionSpecific = false;
			return a;
		}

		private static TypeConfigRaw GetConfigCWithOneDependency()
		{
			var a = new TypeConfigRaw();
			a.Approach = Approach.WrapClass;
			a.SpaceName = "Namespace";
			a.ClassName = "MyClass";
			a.DependencyGuids = new[] {"1289a9951ac74dc587f1d5bdc298d1be"};
			a.InterfaceName = "MyInterface";
			a.PackageId = string.Empty;
			a.FullTypeName = "MyType";
			a.UnityVersionSpecific = false;
			return a;
		}

		private static TypeConfigRaw GetConfigWithoutDependencies()
		{
			var a = new TypeConfigRaw();
			a.Approach = Approach.WrapClass;
			a.SpaceName = "Namespace";
			a.ClassName = "MyClass";
			a.DependencyGuids = Array.Empty<string>();
			a.InterfaceName = "MyInterface";
			a.PackageId = string.Empty;
			a.FullTypeName = "MyType";
			a.UnityVersionSpecific = false;
			return a;
		}

		private static TypeConfigRaw GetConfigWithNullDependencies()
		{
			var a = new TypeConfigRaw();
			a.Approach = Approach.WrapClass;
			a.SpaceName = "Namespace";
			a.ClassName = "MyClass";
			a.DependencyGuids = null;
			a.InterfaceName = "MyInterface";
			a.PackageId = string.Empty;
			a.FullTypeName = "MyType";
			a.UnityVersionSpecific = false;
			return a;
		}

		private static string GetConfigAString()
		{
			return "{\n" +
			       "FullTypeName : MyType\n" +
			       "SpaceName : Namespace\n" +
			       "InterfaceName : MyInterface\n" +
			       "ClassName : MyClass\n" +
			       "UnityVersionSpecific : False\n" +
			       "PackageId : \n" +
			       "Approach : WrapClass\n" +
			       "DependencyGuids : [\n" +
			       "5cd1a9f2bb154572ad277ace454042e4\n" +
			       "cc8bd0cdeac44458813e3ba235d834dc\n" +
			       "]\n}";
		}

		private static string GetConfigWithNullDependenciesString()
		{
			return "{\n" +
			       "FullTypeName : MyType\n" +
			       "SpaceName : Namespace\n" +
			       "InterfaceName : MyInterface\n" +
			       "ClassName : MyClass\n" +
			       "UnityVersionSpecific : False\n" +
			       "PackageId : \n" +
			       "Approach : WrapClass\n" +
			       "DependencyGuids : NULL\n" +
			       "}";
		}
	}
}
