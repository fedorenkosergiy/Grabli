namespace Grabli
{ 
    public static class EnablerEx
    {
        public static bool IsDisabled(this Enabler enabler)
        {
            return !enabler.IsEnabled;
        }
    }
}
