using System;

namespace Grabli
{
    public static class ThrowerEx
    {
        public static void ThrowIfArgumentIsNull(this Thrower unused, object argument, string argumentName)
        {
            if (argument == null)
            {
                throw new ArgumentNullException(argumentName);
            }
        }

        public static void ThrowIfStringIsEmpty(this Thrower unused, string argument, string argumentName)
        {
            if (argument == string.Empty)
            {
                throw new ArgumentException(argumentName, $"{argumentName} is empty");
            }
        }

        public static void ThrowIfStringIsNullOrEmpty(this Thrower obj, string argument, string argumentName)
        {
            obj.ThrowIfArgumentIsNull(argument, argumentName);
            obj.ThrowIfStringIsEmpty(argument, argumentName);
        }
    }
}