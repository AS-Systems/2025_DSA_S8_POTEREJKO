using System;
using LibraryManager.Model.Enums;

namespace LibraryManager.Model.Helpers
{
    public static class TimePeriodHelper
    {
        public static (DateTime start, DateTime end) GetRange(TimePeriod period)
        {
            var now = DateTime.UtcNow.Date; // Just the date part

            return period switch
            {
                TimePeriod.Today => (now, now.AddDays(1)),
                TimePeriod.ThisWeek => (now.StartOfWeek(DayOfWeek.Monday), now.StartOfWeek(DayOfWeek.Monday).AddDays(7)), // ← ✅
                TimePeriod.ThisMonth => (new DateTime(now.Year, now.Month, 1), new DateTime(now.Year, now.Month, 1).AddMonths(1)),
                TimePeriod.ThisYear => (new DateTime(now.Year, 1, 1), new DateTime(now.Year + 1, 1, 1)),
                _ => throw new ArgumentOutOfRangeException(nameof(period), period, null)
            };
        }
        public static (DateTime start, DateTime end) GetUpcomingRange(TimePeriod period)
        {
            var (start, end) = GetRange(period);
            var today = DateTime.UtcNow.Date;
            return (start < today ? today : start, end);
        }

    }
}
