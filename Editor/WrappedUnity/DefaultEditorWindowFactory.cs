using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace Grabli.WrappedUnity
{
    public class DefaultEditorWindowFactory : EditorWindowFactory
    {
        private readonly ModuleBuilder dynamicTypesBuilder;

        private readonly Dictionary<Type, Type> hosts = new Dictionary<Type, Type>();

        public DefaultEditorWindowFactory()
        {
            AssemblyName assemblyName = new AssemblyName("DefaultEditorWindowFactoryAssembly");
            AssemblyBuilder assemblyBuilder =
                AppDomain.CurrentDomain.DefineDynamicAssembly(
                    assemblyName,
                    AssemblyBuilderAccess.RunAndSave);
            dynamicTypesBuilder =
                assemblyBuilder.DefineDynamicModule(assemblyName.Name, assemblyName.Name + ".dll");
        }

        public T Instantiate<T>() where T : class, EditorWindow, new()
        {
            Type windowType = typeof(T);
            if (!hosts.TryGetValue(windowType, out Type cycleRunnerType))
            {
                cycleRunnerType = GenerateCycleRunnerType<T>(windowType);
                hosts.Add(windowType, cycleRunnerType);
            }


            EditorWindowCycleRunner
                host = (EditorWindowCycleRunner) UnityEditor.EditorWindow.GetWindow(cycleRunnerType);
            return (T) host.Window;
        }

        private Type GenerateCycleRunnerType<T>(Type windowType) where T : class, EditorWindow, new()
        {
            Type baseType = typeof(DefaultEditorWindowCycleRunner<T>);
            TypeBuilder typeBuilder = dynamicTypesBuilder.DefineType(
                $"{windowType.Name}CycleRunner",
                TypeAttributes.Public, baseType);
            ConstructorBuilder constructor = typeBuilder.DefineConstructor(
                MethodAttributes.Public,
                CallingConventions.Standard,
                Type.EmptyTypes);
            ConstructorInfo baseConstructor = baseType.GetConstructor(Array.Empty<Type>());
            ILGenerator constructorImplementation = constructor.GetILGenerator();
            constructorImplementation.Emit(OpCodes.Ldarg_0);
            constructorImplementation.Emit(OpCodes.Call, baseConstructor);
            constructorImplementation.Emit(OpCodes.Ret);
            return typeBuilder.CreateType();
        }
    }
}