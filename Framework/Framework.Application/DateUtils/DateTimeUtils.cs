using System.Globalization;

namespace Framework.Application.DateUtils;

public static class DateTimeUtils
{
    public static DateTime GetCurrentUtc() => DateTime.UtcNow;

    public static DateTime ConvertUtcToLocal(DateTime utcTime) => utcTime.ToLocalTime();

    public static DateTime ConvertLocalToUtc(DateTime localTime) => localTime.ToUniversalTime();

    public static TimeSpan GetDateDifference(DateTime startDate, DateTime endDate) => endDate - startDate;

    public static bool IsPastDate(DateTime date) => date < DateTime.UtcNow;

    public static bool IsFutureDate(DateTime date) => date > DateTime.UtcNow;

    public static string FormatDateTime(DateTime date, string format = "yyyy-MM-dd HH:mm:ss") => date.ToString(format);

    public static DateTime? ParseDateTime(string dateString, string format = "yyyy-MM-dd HH:mm:ss")
    {
        return DateTime.TryParseExact(dateString, format, null, DateTimeStyles.None, out var result) ? result : null;
    }

    public static DateTime GetStartOfDay(DateTime date) => date.Date;

    public static DateTime GetEndOfDay(DateTime date) => date.Date.AddDays(1).AddTicks(-1);

    public static DateTime AddDays(DateTime date, int days) => date.AddDays(days);

    public static string ConvertToPersianDate(DateTime date)
    {
        var pc = new PersianCalendar();
        return $"{pc.GetYear(date)}/{pc.GetMonth(date):00}/{pc.GetDayOfMonth(date):00}";
    }

    public static DateTime? ConvertToGregorianDate(string persianDate)
    {
        try
        {
            var parts = persianDate.Split('/');
            if (parts.Length == 3 &&
                int.TryParse(parts[0], out var year) &&
                int.TryParse(parts[1], out var month) &&
                int.TryParse(parts[2], out var day))
            {
                var pc = new PersianCalendar();
                return pc.ToDateTime(year, month, day, 0, 0, 0, 0);
            }
        }
        catch
        {
            // Handle or log error if needed
        }
        return null;
    }

    public static DateTime? ToGregorianDateTime(this string persianDateTime)
    {
        if (string.IsNullOrEmpty(persianDateTime)) return null;

        try
        {
            var parts = persianDateTime.Split(' ');
            var datePart = parts[0].Split('/');
            var timePart = parts.Length > 1 ? parts[1].Split(':') : new[] { "0", "0", "0" };

            var pc = new PersianCalendar();
            return pc.ToDateTime(
                int.Parse(datePart[0]),
                int.Parse(datePart[1]),
                int.Parse(datePart[2]),
                int.Parse(timePart[0]),
                int.Parse(timePart[1]),
                timePart.Length > 2 ? int.Parse(timePart[2]) : 0,
                0);
        }
        catch
        {
            return null;
        }
    }

    public static string ToPersianDate(this DateTime dateTime, string format = "yyyy/MM/dd")
    {
        var pc = new PersianCalendar();
        return format.Replace("yyyy", pc.GetYear(dateTime).ToString("0000"))
                     .Replace("MM", pc.GetMonth(dateTime).ToString("00"))
                     .Replace("dd", pc.GetDayOfMonth(dateTime).ToString("00"));
    }

    public static string ToPersianDateTime(this DateTime dateTime) =>
        $"{dateTime.ToPersianDate()} {dateTime:HH:mm}";

    public static string ToPersianDateTime(this DateTime? dateTime) =>
        dateTime.HasValue ? dateTime.Value.ToPersianDateTime() : string.Empty;

    public static string ToPersianTime(this TimeSpan? timeSpan) =>
        timeSpan.HasValue ? timeSpan.Value.ToString(@"hh\:mm") : string.Empty;

    private static string[] DayOfWeekStrings = { "یکشنبه", "دوشنبه", "سه‌شنبه", "چهارشنبه", "پنج‌شنبه", "جمعه", "شنبه" };
    private static string[] MonthStrings = { "فروردین", "اردیبهشت", "خرداد", "تیر", "مرداد", "شهریور", "مهر", "آبان", "آذر", "دی", "بهمن", "اسفند" };

    public static string GetDayOfWeekString(int day) => day >= 0 && day < DayOfWeekStrings.Length ? DayOfWeekStrings[day] : string.Empty;

    public static string GetMonthString(int month) => month > 0 && month <= MonthStrings.Length ? MonthStrings[month - 1] : string.Empty;
}
