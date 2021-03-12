namespace System
{
    public static class DateTimeEx
    {
        public static DateTime Clamp(this DateTime date, DateTime min, DateTime max)
        {
            if (date < min)
            {
                return min;
            }
            if (date > max)
            {
                return max;
            }
            return date;
        }

        public static DateTime SameTimeTomorrow(this DateTime date)
        {
            return date.AddTicks(TimeSpan.TicksPerDay);
        }
    }
}