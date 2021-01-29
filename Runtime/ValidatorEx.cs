namespace Grabli
{
    public static class ValidatorEx
    {
        public static bool IsValid(this Validator validator)
        {
            return validator.IsValid(out string unused);
        }
    }
}