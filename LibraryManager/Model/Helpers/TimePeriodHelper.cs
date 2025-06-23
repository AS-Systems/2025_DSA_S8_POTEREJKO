using System;
using LibraryManager.Model.Enums;

namespace LibraryManager.Model.Helpers
{
    public static class TimePeriodHelper
    {
        public static (DateTime start, DateTime end) GetRange(TimePeriod period)
        {
            var now = DateTime.UtcNow;
            return period switch
            {
                TimePeriod.Today => (new DateTime(now.Year, now.Month, now.Day), new DateTime(now.Year, now.Month, now.Day).AddDays(1)),
                TimePeriod.ThisMonth => (new DateTime(now.Year, now.Month, 1), new DateTime(now.Year, now.Month, 1).AddMonths(1)),
                TimePeriod.ThisYear => (new DateTime(now.Year, 1, 1), new DateTime(now.Year + 1, 1, 1)),
                _ => throw new ArgumentOutOfRangeException(nameof(period), period, null)
            };
        }
    }
}
