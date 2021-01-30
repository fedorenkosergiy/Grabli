using System;

namespace Grabli
{
    public static class ValidatorEx
    {
        public static bool IsValid(this Validator validator)
        {
            return validator.IsValid(out string unused);
        }

        public static void ThrowArgumentExceptionIfInvalid(this Validator validator, string argumentName)
        {
            if (validator.IsValid(out string message))
            {
                return;
            }

            throw new ArgumentException(message, argumentName);
        }
    }
}