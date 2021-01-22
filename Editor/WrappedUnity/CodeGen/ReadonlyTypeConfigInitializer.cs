using System;
using System.IO;
using UnityEngine;

namespace Grabli.WrappedUnity.CodeGen
{
    public class ReadonlyTypeConfigInitializer : EmptyInitializer
    {
        private string guid;
        private TypeConfigRawSetter setter;

        public ReadonlyTypeConfigInitializer(string guid, TypeConfigRawSetter setter)
        {
            this.guid = guid; 
            this.setter = setter;
        }
        
        protected override void RunInitActions()
        {
            throw new NotImplementedException();
            
            string content = ReadFile();
            TypeConfigRaw raw = JsonUtility.FromJson<TypeConfigRaw>(content);
            setter.Invoke(raw);
        }
        

        private string ReadFile()
        {
            string path = AssetDatabaseContext.Instance.GUIDToAssetPath(guid);
            if (path.IsNull() || !FileContext.Instance.Exists(path))
            {
                throw new FileNotFoundException("File not found", path);
            }

            return FileContext.Instance.ReadAllText(path);
        }

        protected override void RunDeinitActions()
        {
            throw new NotImplementedException();
        }
        
    }
}