using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace Grabli.WrappedUnity
{
    public class DefaultEditorWindowFactory : EditorWindowFactory
    {
        private Dictionary<Type, Type> hosts = new Dictionary<Type, Type>();
        public EditorWindow Instantiate<T>() where T : class, EditorWindow, new()
        {
            AssemblyName aName = new AssemblyName("DynamicAssemblyExample");
            AssemblyBuilder ab =
                AppDomain.CurrentDomain.DefineDynamicAssembly(
                    aName,
                    AssemblyBuilderAccess.RunAndSave);

            // For a single-module assembly, the module name is usually
            // the assembly name plus an extension.
            ModuleBuilder mb =
                ab.DefineDynamicModule(aName.Name, aName.Name + ".dll");

            Type baseType = typeof(DefaultEditorWindowCycleRunner<T>);
            
            TypeBuilder tb = mb.DefineType(
                "MyDynamicType",
                TypeAttributes.Public, baseType);
            
            ConstructorBuilder ctor0 = tb.DefineConstructor(
                MethodAttributes.Public,
                CallingConventions.Standard,
                Type.EmptyTypes );

            ConstructorInfo baseCtorInfo = baseType.GetConstructor(Array.Empty<Type>());
            
            
            ILGenerator ctor0IL = ctor0.GetILGenerator();
            // For a constructor, argument zero is a reference to the new
            // instance. Push it on the stack before pushing the default
            // value on the stack, then call constructor ctor1.
            ctor0IL.Emit(OpCodes.Ldarg_0);
            ctor0IL.Emit(OpCodes.Call, baseCtorInfo);
            ctor0IL.Emit(OpCodes.Ret);
            
            EditorWindowCycleRunner host = (EditorWindowCycleRunner)UnityEditor.EditorWindow.GetWindow(tb.CreateType());
            return host.Window;
        }
    }
}