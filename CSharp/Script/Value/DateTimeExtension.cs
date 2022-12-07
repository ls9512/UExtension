using System;
using System.Globalization;
using System.Text;

namespace Aya.Extension
{
    public static class DateTimeExtension
    {
        const int EveningEnds = 2;
        const int MorningEnds = 12;
        const int AfternoonEnds = 18;
        static readonly DateTime Date1970 = new DateTime(1970, 1, 1);

        public static double UtcOffset => DateTime.Now.Subtract(DateTime.UtcNow).TotalHours;

        #region Age

        public static int CalculateAge(this DateTime dateTime)
        {
            var currentDateTime = DateTime.Now;
            return dateTime.CalculateAge(currentDateTime);
        }

        public static int CalculateAge(this DateTime dateTime, DateTime currentDateTime)
        {
            var years = currentDateTime.Year - dateTime.Year;
            if (currentDateTime.Month < dateTime.Month || (currentDateTime.Month == dateTime.Month && currentDateTime.Day < dateTime.Day))
            {
                --years;
            }

            return years;
        }

        #endregion

        #region Day

        public static int GetDays(this DateTime dateTime, DateTime toDate)
        {
            var result = Convert.ToInt32(toDate.Subtract(dateTime).TotalDays);
            return result;
        }

        // morning(2-12)/afternoon(13-18)/evening(18-2))
        public static string GetPeriodOfDay(this DateTime dateTime)
        {
            var hour = dateTime.Hour;
            if (hour < EveningEnds)
            {
                return "evening";
            }

            if (hour < MorningEnds)
            {
                return "morning";
            }

            return hour < AfternoonEnds ? "afternoon" : "evening";
        }

        public static bool IsToday(this DateTime dateTime)
        {
            var result = dateTime.Date == DateTime.Today;
            return result;
        }

        public static DateTime IsTomorrow(this DateTime dateTime)
        {
            var result = dateTime.AddDays(1);
            return result;
        }

        public static DateTime IsYesterday(this DateTime dateTime)
        {
            var result = dateTime.AddDays(-1);
            return result;
        }

        #endregion

        #region Week

        public static DateTime GetFirstDayOfWeek(this DateTime dateTime)
        {
            var result = dateTime.GetFirstDayOfWeek(CultureInfo.CurrentCulture);
            return result;
        }

        public static DateTime GetFirstDayOfWeek(this DateTime dateTime, CultureInfo cultureInfo)
        {
            cultureInfo = (cultureInfo ?? CultureInfo.CurrentCulture);
            var firstDayOfWeek = cultureInfo.DateTimeFormat.FirstDayOfWeek;
            while (dateTime.DayOfWeek != firstDayOfWeek)
            {
                dateTime = dateTime.AddDays(-1);
            }

            return dateTime;
        }

        public static DateTime GetLastDayOfWeek(this DateTime dateTime)
        {
            var result = dateTime.GetLastDayOfWeek(CultureInfo.CurrentCulture);
            return result;
        }

        public static DateTime GetLastDayOfWeek(this DateTime dateTime, CultureInfo cultureInfo)
        {
            var result = dateTime.GetFirstDayOfWeek(cultureInfo).AddDays(6);
            return result;
        }

        public static DateTime GetNextWeekday(this DateTime dateTime, DayOfWeek weekday)
        {
            while (dateTime.DayOfWeek != weekday)
            {
                dateTime = dateTime.AddDays(1);
            }

            return dateTime;
        }

        public static DateTime GetPreviousWeekday(this DateTime dateTime, DayOfWeek weekday)
        {
            while (dateTime.DayOfWeek != weekday)
            {
                dateTime = dateTime.AddDays(-1);
            }

            return dateTime;
        }

        public static bool IsWeekend(this DateTime dateTime)
        {
            var result = dateTime.DayOfWeek.EqualsAny(DayOfWeek.Saturday, DayOfWeek.Sunday);
            return result;
        }

        public static bool IsWorkDay(this DateTime dateTime)
        {
            var result = !dateTime.IsWeekend();
            return result;
        }

        public static int GetWeekOfYear(this DateTime dateTime)
        {
            var result = GetWeekOfYear(dateTime, CultureInfo.CurrentCulture);
            return result;
        }

        public static int GetWeekOfYear(this DateTime dateTime, CultureInfo cultureInfo)
        {
            var calendar = cultureInfo.Calendar;
            var dateTimeFormat = cultureInfo.DateTimeFormat;
            var result = calendar.GetWeekOfYear(dateTime, dateTimeFormat.CalendarWeekRule, dateTimeFormat.FirstDayOfWeek);
            return result;
        }

        #endregion

        #region Month

        public static int GetDaysOfMonth(this DateTime dateTime)
        {
            var nextMonth = dateTime.AddMonths(1);
            var result = new DateTime(nextMonth.Year, nextMonth.Month, 1).AddDays(-1).Day;
            return result;
        }

        public static DateTime GetFirstDayOfMonth(this DateTime dateTime)
        {
            var result = new DateTime(dateTime.Year, dateTime.Month, 1);
            return result;
        }

        public static DateTime GetFirstDayOfMonth(this DateTime dateTime, DayOfWeek dayOfWeek)
        {
            var dt = dateTime.GetFirstDayOfMonth();
            while (dt.DayOfWeek != dayOfWeek)
            {
                dt = dt.AddDays(1);
            }

            return dt;
        }

        public static DateTime GetLastDayOfMonth(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, GetDaysOfMonth(dateTime));
        }

        public static DateTime GetLastDayOfMonth(this DateTime dateTime, DayOfWeek dayOfWeek)
        {
            var dt = dateTime.GetLastDayOfMonth();
            while (dt.DayOfWeek != dayOfWeek)
            {
                dt = dt.AddDays(-1);
            }

            return dt;
        }

        #endregion

        #region Timestamp

        public static long GetTimestamp(this DateTime datetime)
        {
            var ts = datetime.Subtract(Date1970);
            var result = (long) ts.TotalMilliseconds;
            return result;
        }

        #endregion

        #region Equal

        public static bool IsDateEqual(this DateTime dateTime, DateTime dateToCompare)
        {
            var result = dateTime.Date == dateToCompare.Date;
            return result;
        }

        public static bool IsTimeEqual(this DateTime dateTime, DateTime timeToCompare)
        {
            var result = dateTime.TimeOfDay == timeToCompare.TimeOfDay;
            return result;
        }

        public static bool IsBefore(this DateTime dateTime, DateTime other)
        {
            var result = dateTime.CompareTo(other) < 0;
            return result;
        }

        public static bool IsAfter(this DateTime dateTime, DateTime other)
        {
            var result = dateTime.CompareTo(other) > 0;
            return result;
        }

        #endregion

        #region DateTimeOffset

        public static DateTimeOffset ToDateTimeOffset(this DateTime dateTime)
        {
            return dateTime.ToDateTimeOffset(null);
        }

        public static DateTimeOffset ToDateTimeOffset(this DateTime dateTime, TimeZoneInfo localTimeZone)
        {
            localTimeZone = (localTimeZone ?? TimeZoneInfo.Local);
            if (dateTime.Kind != DateTimeKind.Unspecified)
            {
                dateTime = new DateTime(dateTime.Ticks, DateTimeKind.Unspecified);
            }

            var result = TimeZoneInfo.ConvertTimeToUtc(dateTime, localTimeZone);
            return result;
        }

        #endregion

        #region Festival

        public static bool IsEaster(this DateTime dateTime)
        {
            var y = dateTime.Year;
            var a = y % 19;
            var b = y / 100;
            var c = y % 100;
            var d = b / 4;
            var e = b % 4;
            var f = (b + 8) / 25;
            var g = (b - f + 1) / 3;
            var h = (19 * a + b - d - g + 15) % 30;
            var i = c / 4;
            var k = c % 4;
            var l = (32 + 2 * e + 2 * i - h - k) % 7;
            var m = (a + 11 * h + 22 * l) / 451;
            var month = (h + l - 7 * m + 114) / 31;
            var day = ((h + l - 7 * m + 114) % 31) + 1;
            var dtEasterSunday = new DateTime(y, month, day);
            var result = dateTime == dtEasterSunday;
            return result;
        }

        #endregion

        #region Format

        // Today, 3:33 PM
        public static string ToFriendlyDateString(this DateTime dateTime)
        {
            var result = ToFriendlyDateString(dateTime, CultureInfo.CurrentCulture);
            return result;
        }

        public static string ToFriendlyDateString(this DateTime dateTime, CultureInfo cultureInfo)
        {
            var sbFormattedDate = new StringBuilder();
            if (dateTime.Date == DateTime.Today)
            {
                sbFormattedDate.Append("Today");
            }
            else if (dateTime.Date == DateTime.Today.AddDays(-1))
            {
                sbFormattedDate.Append("Yesterday");
            }
            else if (dateTime.Date > DateTime.Today.AddDays(-6))
            {
                // Weekady
                sbFormattedDate.Append(dateTime.ToString("dddd").ToString(cultureInfo));
            }
            else
            {
                sbFormattedDate.Append(dateTime.ToString("MMMM dd, yyyy").ToString(cultureInfo));
            }

            // am / pm
            sbFormattedDate.Append(" at ").Append(dateTime.ToString("t").ToLower());
            return sbFormattedDate.ToString();
        }

        #endregion
    }
}
