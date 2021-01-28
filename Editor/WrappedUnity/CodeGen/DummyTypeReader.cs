using System;

namespace Grabli.WrappedUnity.CodeGen
{
    public abstract class DummyTypeReader : TypeReader, Thrower
    {
        public TypeConfigRaw Read(string guid)
        {
            this.ThrowIfArgumentIsNull(guid, nameof(guid));
            this.ThrowIfStringIsEmpty(guid, nameof(guid));
            return DoRead(guid);
        }

        protected abstract TypeConfigRaw DoRead(string guid);
    }
}