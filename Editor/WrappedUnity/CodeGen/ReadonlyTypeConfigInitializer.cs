using System;
using System.IO;
using UnityEngine;

namespace Grabli.WrappedUnity.CodeGen
{
    public class ReadonlyTypeConfigInitializer : EmptyInitializer
    {
        private readonly Factory factory;
        private readonly string guid;
        private readonly TypeConfigRawSetter setter;

        public ReadonlyTypeConfigInitializer(Factory factory, string guid, TypeConfigRawSetter setter)
        {
            this.factory = factory;
            this.guid = guid; 
            this.setter = setter;
        }
        
        protected override void RunInitActions()
        {
            TypeReader reader = factory.GetReader();
            setter.Invoke(reader.Read(guid));
        }

        protected override void RunDeinitActions()
        {
            throw new NotImplementedException();
        }
        
    }
}