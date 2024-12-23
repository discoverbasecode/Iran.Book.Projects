using System.Collections.Concurrent;
using System.Globalization;


namespace Framework.Application.EnumUtils;

public static class EnumHelper
{
    // استفاده از ConcurrentDictionary برای کشف نتایج تبدیل‌ها و جلوگیری از تکرار
    private static readonly ConcurrentDictionary<Enum, string> EnumCache = new ConcurrentDictionary<Enum, string>();

    // تبدیل Enum به رشته با فاصله گذاری مناسب
    public static string ConvertToString(this Enum e)
    {
        if (e == null)
        {
            throw new ArgumentNullException(nameof(e), "Enum cannot be null.");
        }

        // بررسی کش (اگر قبلاً انجام شده باشد، از کش استفاده می‌کنیم)
        if (EnumCache.TryGetValue(e, out var cachedResult))
        {
            return cachedResult;
        }

        // تبدیل Enum به رشته و حذف underscores، سپس ذخیره‌سازی در کش
        var result = FormatEnumName(e.ToString());
        EnumCache[e] = result;
        return result;
    }

    // تبدیل enum به رشته با امکان تغییر جداکننده (در صورت نیاز به گسترش)
    public static string ConvertToString(this Enum e, string separator = " ")
    {
        return e.ToString().Replace("_", separator);
    }
    // فرمت کردن نام Enum (تبدیل underscore به فاصله و سایر بهبودها)
    private static string FormatEnumName(string enumName)
    {
        // تبدیل underscore به فاصله و بهبود خوانایی
        var formattedName = enumName.Replace("_", " ");

        // اگر بخواهیم برخی حروف را به حالت Capitalize کنیم، می‌توانیم اینجا اضافه کنیم
        var cultureInfo = CultureInfo.CurrentCulture;
        TextInfo textInfo = cultureInfo.TextInfo;

        // تبدیل هر کلمه به صورت اولیه (عنوانی)
        formattedName = textInfo.ToTitleCase(formattedName.ToLower());

        return formattedName;
    }
    public static string ConvertToLocalizedString(this Enum e, string culture = "en")
    {
        // این قسمت می‌تواند با استفاده از Localizer برای زبان‌های مختلف گسترش یابد
        return e.ToString().Replace("_", " "); // به عنوان یک مثال ساده
    }

}