using System;

namespace Grabli.WrappedUnity.CodeGen
{
    public class SourceTypeValidator : Validator
    {
        private readonly Type type;

        public SourceTypeValidator(Type type)
        {
            this.type = type;
        }

        public bool IsValid(out string message)
        {
            message = string.Empty;
            if (type.IsDelegate())
            {
                message = "Type can not be a delegate";
            }
            else if (type.IsAttribute())
            {
                message = "Type can not be an attribute";
            }
            else if (!type.IsClass)
            {
                message = "Type should be a class";
            }

            return message.IsEmpty();
        }
    }
}