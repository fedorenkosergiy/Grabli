namespace System
{
    public static class DayOfWeekEx
    {
        public static bool IsWeekDay(this DayOfWeek day)
        {
            return day < DayOfWeek.Saturday;
        }

        public static bool IsWeekEnd(this DayOfWeek day)
        {
            return day > DayOfWeek.Friday;
        }
    }
}