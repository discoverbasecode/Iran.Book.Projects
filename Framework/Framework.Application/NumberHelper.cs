using System.Globalization;

namespace Framework.Application;

public static class NumberHelper
{
    // متد عمومی برای فرمت‌بندی تعداد با و بدون بررسی قیمت 0
    public static string TooMan(this int price, bool ifPriceIsZeroReturnFree = false)
    {
        if (ifPriceIsZeroReturnFree && price == 0)
            return "رایگان";

        return FormatPrice(price);
    }

    // متد عمومی برای فرمت‌بندی قیمت‌های Nullable int
    public static string TooMan(this int? price, bool ifPriceIsZeroReturnFree = false)
    {
        if (price == null)
            return "نامشخص";

        return price.Value.TooMan(ifPriceIsZeroReturnFree);
    }

    // فرمت‌بندی عدد با ویرگول
    public static string SplitNumber(this int price)
    {
        return FormatPrice(price);
    }

    // فرمت‌بندی عدد با ویرگول برای Nullable int
    public static string SplitNumber(this int? price)
    {
        return price.HasValue ? FormatPrice(price.Value) : "نامشخص";
    }

    // متد عمومی برای فرمت‌بندی قیمت‌ها با ویرگول
    private static string FormatPrice(int price)
    {
        return string.Format(CultureInfo.CurrentCulture, "{0:#,0} تومان", price);
    }

    // فرمت‌بندی قیمت به صورت درصد
    public static string ToPercentage(this double value, int decimalPlaces = 2)
    {
        return value.ToString($"P{decimalPlaces}", CultureInfo.InvariantCulture);
    }

    // فرمت‌بندی قیمت به صورت ارز (مثال: دلار)
    public static string ToCurrency(this decimal value, string currencySymbol = "تومان", int decimalPlaces = 2)
    {
        return value.ToString($"#,0.{new string('#', decimalPlaces)} {currencySymbol}", CultureInfo.InvariantCulture);
    }

    // فرمت‌بندی قیمت به صورت هزارگان برای اعداد بزرگ
    public static string ToReadableSize(this long value)
    {
        if (value < 1_000) return value.ToString();
        if (value < 1_000_000) return $"{value / 1_000.0:N1} K";
        if (value < 1_000_000_000) return $"{value / 1_000_000.0:N1} M";
        return $"{value / 1_000_000_000.0:N1} B";
    }

    // فرمت‌بندی برای مقادیر منفی (نمایش با علامت منفی)
    public static string ToFormattedNegativeNumber(this int value)
    {
        if (value < 0)
            return $"(-{FormatPrice(Math.Abs(value))})";
        return FormatPrice(value);
    }

    // فرمت‌بندی برای مقادیر منفی (برای Nullable int)
    public static string ToFormattedNegativeNumber(this int? value)
    {
        if (!value.HasValue)
            return "نامشخص";

        return value.Value.ToFormattedNegativeNumber();
    }
}


