using System.Text.RegularExpressions;

namespace Framework.Domain.Utils;

public static class TextHelper
{
    public static bool IsText(this string value)
    {
        return !Regex.IsMatch(value, @"^\d+$");
    }

    public static string SetUnReadableEmail(this string? email)
    {
        if (string.IsNullOrEmpty(email))
        {
            return string.Empty;
        }

        var emailLocalPart = email.Split('@')[0];
        var emailLength = emailLocalPart.Length;
        return "..." + emailLocalPart.Substring(0, emailLength - 2);
    }

    public static string ToSlug(this string url)
    {
        return string.Concat(url.Trim().ToLower()
            .Where(c => !@"$+%?^*!#&~()=/.\s".Contains(c))
            .Select(c => c == ' ' ? '-' : c));
    }

    public static bool IsUniCode(this string value)
    {
        return value.Any(c => c > 255);
    }

    public static string SubStringCustom(this string text, int length)
    {
        return text.Length > length ? text.Substring(0, length - 3) + "..." : text;
    }

    public static bool IsValidPhoneNumber(this string phoneNumber)
    {
        return !string.IsNullOrWhiteSpace(phoneNumber)
               && !phoneNumber.IsText()
               && phoneNumber.Length == 11;
    }

    public static string GenerateCode(int length)
    {
        var random = new Random();
        var code = "";
        for (var i = 0; i < length; i++)
        {
            code += random.Next(0, 9).ToString();
        }

        return code;
    }
    
    public static string ConvertHtmlToText(this string text)
    {
        return Regex.Replace(text, "<.*?>", " ")
            .Replace("&zwnj;", " ")
            .Replace(";&zwnj", " ")
            .Replace("&nbsp;", " ");
    }

}