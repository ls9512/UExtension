using System;

namespace Aya.Extension
{
    public static class DateTimeOffsetExtension
    {
        public static bool IsToday(this DateTimeOffset dateTimeOffset)
        {
            var result = dateTimeOffset.Date.IsToday();
            return result;
        }

        public static DateTime ToLocalDateTime(this DateTimeOffset dateTimeOffset)
        {
            var result = dateTimeOffset.ToLocalDateTime(null);
            return result;
        }

        public static DateTime ToLocalDateTime(this DateTimeOffset dateTimeOffset, TimeZoneInfo localTimeZone)
        {
            localTimeZone = (localTimeZone ?? TimeZoneInfo.Local);
            var result = TimeZoneInfo.ConvertTime(dateTimeOffset, localTimeZone).DateTime;
            return result;
        }
    }
}
